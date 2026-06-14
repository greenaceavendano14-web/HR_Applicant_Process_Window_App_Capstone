using HRApplicantSystem.Database;
using HRApplicantSystem.Models;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace HRApplicantSystem
{
    public partial class ScreeningForm : Form
    {
        DbConnection db = new DbConnection();

        int selectedApplicationID = 0;

        public ScreeningForm()
        {
            InitializeComponent();

            this.Load += Form1_Load;

            dgvScreening.CellClick += dgvScreening_CellClick;

            btnSave.Click += btnSave_Click;
            btnRefresh.Click += btnRefresh_Click;
            btnClear.Click += btnClear_Click;
            btnClose.Click += btnClose_Click;
        }

        // ================= LOAD =================
        private void Form1_Load(object sender, EventArgs e)
        {
            cmbResult.Items.Clear();
            cmbResult.Items.Add("Qualified");
            cmbResult.Items.Add("Not Qualified");

            this.WindowState = FormWindowState.Maximized;

            LoadScreening();
        }

        // ================= LOAD DATA =================
        private void LoadScreening()
        {
            try
            {
                using (MySqlConnection conn = db.GetConnection())
                {
                    conn.Open();

                    string query = @"
                        SELECT
                            a.ApplicationID,
                            CONCAT(ap.FirstName,' ',ap.LastName) AS ApplicantName,
                            j.JobTitle,
                            a.CurrentStatus
                        FROM Applications a
                        INNER JOIN Applicants ap ON a.ApplicantID = ap.ApplicantID
                        INNER JOIN JobVacancies j ON a.VacancyID = j.VacancyID";

                    MySqlDataAdapter da = new MySqlDataAdapter(query, conn);

                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dgvScreening.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Load Error: " + ex.Message);
            }
        }

        // ================= SELECT ROW =================
        private void dgvScreening_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow row = dgvScreening.Rows[e.RowIndex];

            selectedApplicationID =
                Convert.ToInt32(row.Cells["ApplicationID"].Value);

            txtApplicant.Text =
                row.Cells["ApplicantName"].Value.ToString();

            txtJob.Text =
                row.Cells["JobTitle"].Value.ToString();
        }

        // ================= SAVE =================
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (selectedApplicationID == 0)
            {
                MessageBox.Show("Please select an applicant.");
                return;
            }

            if (cmbResult.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a screening result.");
                return;
            }

            string remarks = string.IsNullOrWhiteSpace(txtRemarks.Text)
                ? "No remarks"
                : txtRemarks.Text;

            using (MySqlConnection conn = db.GetConnection())
            {
                conn.Open();
                MySqlTransaction transaction = conn.BeginTransaction();

                try
                {
                    // ================= GET OLD STATUS =================
                    string oldStatus = "";

                    string getStatusQuery = @"
                        SELECT CurrentStatus
                        FROM Applications
                        WHERE ApplicationID=@id";

                    MySqlCommand getCmd = new MySqlCommand(getStatusQuery, conn, transaction);
                    getCmd.Parameters.AddWithValue("@id", selectedApplicationID);

                    object result = getCmd.ExecuteScalar();

                    if (result != null)
                        oldStatus = result.ToString();

                    // ================= NEW STATUS =================
                    string newStatus = cmbResult.Text switch
                    {
                        "Qualified" => "For Interview",
                        "Not Qualified" => "Rejected",
                        _ => "Pending"
                    };

                    // ================= UPDATE APPLICATION =================
                    string updateApp = @"
                        UPDATE Applications
                        SET CurrentStatus=@status
                        WHERE ApplicationID=@id";

                    MySqlCommand updateCmd = new MySqlCommand(updateApp, conn, transaction);
                    updateCmd.Parameters.AddWithValue("@status", newStatus);
                    updateCmd.Parameters.AddWithValue("@id", selectedApplicationID);
                    updateCmd.ExecuteNonQuery();

                    // ================= INSERT / UPDATE SCREENING =================
                    string checkQuery = @"
                        SELECT COUNT(*)
                        FROM ScreeningResults
                        WHERE ApplicationID=@app";

                    MySqlCommand checkCmd = new MySqlCommand(checkQuery, conn, transaction);
                    checkCmd.Parameters.AddWithValue("@app", selectedApplicationID);

                    int exists = Convert.ToInt32(checkCmd.ExecuteScalar());

                    if (exists > 0)
                    {
                        string updateScreen = @"
                            UPDATE ScreeningResults
                            SET Result=@result,
                                Remarks=@remarks,
                                ScreenedByUserID=@user
                            WHERE ApplicationID=@app";

                        MySqlCommand cmd = new MySqlCommand(updateScreen, conn, transaction);
                        cmd.Parameters.AddWithValue("@result", cmbResult.Text);
                        cmd.Parameters.AddWithValue("@remarks", remarks);
                        cmd.Parameters.AddWithValue("@user", Session.UserID);
                        cmd.Parameters.AddWithValue("@app", selectedApplicationID);
                        cmd.ExecuteNonQuery();
                    }
                    else
                    {
                        string insertScreen = @"
                            INSERT INTO ScreeningResults
                            (
                                ApplicationID,
                                ScreenedByUserID,
                                Result,
                                Remarks
                            )
                            VALUES
                            (
                                @app,
                                @user,
                                @result,
                                @remarks
                            )";

                        MySqlCommand cmd = new MySqlCommand(insertScreen, conn, transaction);
                        cmd.Parameters.AddWithValue("@app", selectedApplicationID);
                        cmd.Parameters.AddWithValue("@user", Session.UserID);
                        cmd.Parameters.AddWithValue("@result", cmbResult.Text);
                        cmd.Parameters.AddWithValue("@remarks", remarks);
                        cmd.ExecuteNonQuery();
                    }

                    // ================= STATUS HISTORY =================
                    string historyQuery = @"
                        INSERT INTO ApplicationStatusHistory
                        (
                            ApplicationID,
                            OldStatus,
                            NewStatus,
                            ChangedByType,
                            ChangedByID,
                            Remarks
                        )
                        VALUES
                        (
                            @app,
                            @old,
                            @new,
                            'HR Staff',
                            @user,
                            @remarks
                        )";

                    MySqlCommand histCmd = new MySqlCommand(historyQuery, conn, transaction);
                    histCmd.Parameters.AddWithValue("@app", selectedApplicationID);
                    histCmd.Parameters.AddWithValue("@old", oldStatus);
                    histCmd.Parameters.AddWithValue("@new", newStatus);
                    histCmd.Parameters.AddWithValue("@user", Session.UserID);
                    histCmd.Parameters.AddWithValue("@remarks", remarks);
                    histCmd.ExecuteNonQuery();

                    // ================= AUDIT TRAIL =================
                    string auditQuery = @"
                        INSERT INTO AuditTrail
                        (
                            ActorType,
                            ActorID,
                            Action,
                            TargetTable,
                            TargetID,
                            Details
                        )
                        VALUES
                        (
                            @type,
                            @id,
                            @action,
                            'Applications',
                            @target,
                            @details
                        )";

                    MySqlCommand auditCmd = new MySqlCommand(auditQuery, conn, transaction);
                    auditCmd.Parameters.AddWithValue("@type", Session.RoleName);
                    auditCmd.Parameters.AddWithValue("@id", Session.UserID);
                    auditCmd.Parameters.AddWithValue("@action", "Screening Update");
                    auditCmd.Parameters.AddWithValue("@target", selectedApplicationID);
                    auditCmd.Parameters.AddWithValue("@details",
                        $"Result: {cmbResult.Text}, Status: {newStatus}");

                    auditCmd.ExecuteNonQuery();

                    // ================= COMMIT =================
                    transaction.Commit();

                    MessageBox.Show("Screening saved successfully!");

                    LoadScreening();
                    ClearFields();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    MessageBox.Show("Save Error: " + ex.Message);
                }
            }
        }

        // ================= REFRESH =================
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadScreening();
        }

        // ================= CLEAR =================
        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        private void ClearFields()
        {
            txtApplicant.Clear();
            txtJob.Clear();
            txtRemarks.Clear();
            cmbResult.SelectedIndex = -1;

            selectedApplicationID = 0;
            dgvScreening.ClearSelection();
        }

        // ================= CLOSE =================
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
