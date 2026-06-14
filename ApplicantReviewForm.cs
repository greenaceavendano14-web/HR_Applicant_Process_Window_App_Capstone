using HRApplicantSystem.Database;
using HRApplicantSystem.Models;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace HRApplicantSystem
{
    public partial class ApplicantReviewForm : Form
    {
        DbConnection db = new DbConnection();

        int selectedApplicationID = 0;

        public ApplicantReviewForm()
        {
            InitializeComponent();

            this.Load += Form1_Load;

            dgvApplicants.CellClick += dgvApplicants_CellClick;

            btnSaveReview.Click += btnSaveReview_Click;
            btnRefresh.Click += btnRefresh_Click;
            btnClose.Click += btnClose_Click;
            btnClear.Click += btnClear_Click;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cmbStatus.Items.Clear();

            cmbStatus.Items.Add("Under Review");
            cmbStatus.Items.Add("Shortlisted");
            cmbStatus.Items.Add("For Interview");
            cmbStatus.Items.Add("For Assessment");
            cmbStatus.Items.Add("For Final Review");

            if (Session.RoleName == Roles.HRManager || Session.RoleName == Roles.Admin)
            {
                cmbStatus.Items.Add("Accepted");
                cmbStatus.Items.Add("Rejected");
            }

            LoadApplicants();
        }

        private void LoadApplicants()
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
                            a.CurrentStatus,
                            a.SubmittedAt
                        FROM Applications a
                        INNER JOIN Applicants ap ON a.ApplicantID = ap.ApplicantID
                        INNER JOIN JobVacancies j ON a.VacancyID = j.VacancyID";

                    MySqlDataAdapter da = new MySqlDataAdapter(query, conn);

                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dgvApplicants.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Load Error: " + ex.Message);
            }
        }

        private void dgvApplicants_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow row = dgvApplicants.Rows[e.RowIndex];

            selectedApplicationID =
                Convert.ToInt32(row.Cells["ApplicationID"].Value);

            txtApplicant.Text =
                row.Cells["ApplicantName"].Value.ToString();

            txtJob.Text =
                row.Cells["JobTitle"].Value.ToString();

            cmbStatus.Text =
                row.Cells["CurrentStatus"].Value.ToString();
        }


        private void btnSaveReview_Click(object sender, EventArgs e)
        {
            if (selectedApplicationID == 0)
            {
                MessageBox.Show("Please select an applicant.");
                return;
            }

            if (string.IsNullOrWhiteSpace(cmbStatus.Text))
            {
                MessageBox.Show("Please select a status.");
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

                    string oldStatus = "";

                    string getQuery = @"
                        SELECT CurrentStatus
                        FROM Applications
                        WHERE ApplicationID=@id";

                    MySqlCommand getCmd = new MySqlCommand(getQuery, conn, transaction);
                    getCmd.Parameters.AddWithValue("@id", selectedApplicationID);

                    object result = getCmd.ExecuteScalar();
                    if (result != null)
                        oldStatus = result.ToString();


                    string updateQuery = @"
                        UPDATE Applications
                        SET CurrentStatus = @status
                        WHERE ApplicationID = @id";

                    MySqlCommand updateCmd = new MySqlCommand(updateQuery, conn, transaction);
                    updateCmd.Parameters.AddWithValue("@status", cmbStatus.Text);
                    updateCmd.Parameters.AddWithValue("@id", selectedApplicationID);
                    updateCmd.ExecuteNonQuery();


                    string reviewQuery = @"
                        INSERT INTO ApplicantReviews
                        (
                            ApplicationID,
                            Remarks,
                            Recommendation,
                            ReviewedBy
                        )
                        VALUES
                        (
                            @app,
                            @remarks,
                            @recommendation,
                            @reviewedBy
                        )";

                    MySqlCommand spCmd = new MySqlCommand("sp_ChangeApplicationStatus", conn, transaction);
                    spCmd.CommandType = CommandType.StoredProcedure;
                    spCmd.Parameters.AddWithValue("p_ApplicationID", selectedApplicationID);
                    spCmd.Parameters.AddWithValue("p_NewStatus", cmbStatus.Text);
                    spCmd.Parameters.AddWithValue("p_ChangedByType", Session.RoleName);
                    spCmd.Parameters.AddWithValue("p_ChangedByID", Session.UserID);
                    spCmd.Parameters.AddWithValue("p_Remarks", remarks);
                    spCmd.ExecuteNonQuery();


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
                    auditCmd.Parameters.AddWithValue("@action", "Applicant Review Update");
                    auditCmd.Parameters.AddWithValue("@target", selectedApplicationID);
                    auditCmd.Parameters.AddWithValue("@details",
                        $"Old: {oldStatus}, New: {cmbStatus.Text}, Remarks: {remarks}");

                    auditCmd.ExecuteNonQuery();


                    transaction.Commit();

                    MessageBox.Show("Review Saved Successfully!",
                        "Success",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    LoadApplicants();
                    ClearFields();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    MessageBox.Show("Save Error: " + ex.Message);
                }
            }
        }


        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadApplicants();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        private void ClearFields()
        {
            txtApplicant.Clear();
            txtJob.Clear();
            txtRemarks.Clear();

            cmbStatus.SelectedIndex = -1;

            selectedApplicationID = 0;

            dgvApplicants.ClearSelection();
        }


        private void btnScreening_Click(object sender, EventArgs e)
        {
            new ScreeningForm().ShowDialog();
        }

        private void Scheduling_Click(object sender, EventArgs e)
        {
            new InterviewScheduleForm().ShowDialog();
        }

        private void btnEvaluation_Click(object sender, EventArgs e)
        {
            new InterviewEvaluationForm().ShowDialog();
        }
    }
}
