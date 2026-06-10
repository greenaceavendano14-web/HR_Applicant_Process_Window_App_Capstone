using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace HRScreeningForm
{
    public partial class ScreeningForm : Form
    {
        DBConnection db = new DBConnection();

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

        // ================= LOAD FORM =================
        private void Form1_Load(object sender, EventArgs e)
        {
            cmbResult.Items.Clear();
            cmbResult.Items.Add("Qualified");
            cmbResult.Items.Add("Not Qualified");

            LoadScreening();
        }

        // ================= LOAD DATA =================
        private void LoadScreening()
        {
            try
            {
                db.OpenConnection();

                string query = @"
                SELECT
                    a.ApplicationID,
                    CONCAT(ap.FirstName,' ',ap.LastName) AS ApplicantName,
                    j.JobTitle,
                    a.CurrentStatus
                FROM Applications a
                INNER JOIN Applicants ap ON a.ApplicantID = ap.ApplicantID
                INNER JOIN JobVacancies j ON a.VacancyID = j.VacancyID";

                MySqlDataAdapter da =
                    new MySqlDataAdapter(query, db.GetConnection());

                DataTable dt = new DataTable();
                da.Fill(dt);

                dgvScreening.DataSource = dt;

                db.CloseConnection();
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

        // ================= SAVE SCREENING =================
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (selectedApplicationID == 0)
                {
                    MessageBox.Show("Please select an applicant.");
                    return;
                }

                db.OpenConnection();

                // UPDATE STATUS
                string status = cmbResult.Text == "Qualified"
                    ? "For Interview"
                    : "Rejected";

                string update = @"
                UPDATE Applications
                SET CurrentStatus=@status
                WHERE ApplicationID=@id";

                MySqlCommand cmd =
                    new MySqlCommand(update, db.GetConnection());

                cmd.Parameters.AddWithValue("@status", status);
                cmd.Parameters.AddWithValue("@id", selectedApplicationID);
                cmd.ExecuteNonQuery();

                // INSERT SCREENING RESULT
                string insert = @"
                INSERT INTO ScreeningResults
                (ApplicationID, Result, Remarks, ScreenedBy)
                VALUES
                (@app,@res,@remarks,'HR Staff')";

                MySqlCommand cmd2 =
                    new MySqlCommand(insert, db.GetConnection());

                cmd2.Parameters.AddWithValue("@app", selectedApplicationID);
                cmd2.Parameters.AddWithValue("@res", cmbResult.Text);
                cmd2.Parameters.AddWithValue("@remarks", txtRemarks.Text);

                cmd2.ExecuteNonQuery();

                db.CloseConnection();

                MessageBox.Show("Screening Saved!");

                LoadScreening();
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Save Error: " + ex.Message);
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