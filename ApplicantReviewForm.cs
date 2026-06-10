using HRApplicationFormView;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace HRApplicationFormVieww
{
    public partial class ApplicantReviewForm : Form
    {
        DBConnection db = new DBConnection();

        int selectedApplicationID = 0;

        public ApplicantReviewForm()
        {
            InitializeComponent();

            this.Load += Form1_Load;

            dgvApplicants.CellClick += dgvApplicants_CellClick;

            btnSaveReview.Click += btnSaveReview_Click;
            btnRefresh.Click += btnRefresh_Click;
            btnClose.Click += btnClose_Click;

            // ================= ADD THIS =================
            btnClear.Click += btnClear_Click;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cmbStatus.Items.Clear();

            cmbStatus.Items.Add("Under Review");
            cmbStatus.Items.Add("Shortlisted");
            cmbStatus.Items.Add("For Interview");
            cmbStatus.Items.Add("For Assessment");
            cmbStatus.Items.Add("Accepted");
            cmbStatus.Items.Add("Rejected");

            LoadApplicants();
        }

        private void LoadApplicants()
        {
            try
            {
                db.OpenConnection();

                string query = @"
                SELECT
                    a.ApplicationID,
                    CONCAT(ap.FirstName,' ',ap.LastName) AS ApplicantName,
                    j.JobTitle,
                    a.CurrentStatus,
                    a.SubmittedAt
                FROM Applications a
                INNER JOIN Applicants ap
                    ON a.ApplicantID = ap.ApplicantID
                INNER JOIN JobVacancies j
                    ON a.VacancyID = j.VacancyID";

                MySqlDataAdapter da =
                    new MySqlDataAdapter(query, db.GetConnection());

                DataTable dt = new DataTable();
                da.Fill(dt);

                dgvApplicants.DataSource = dt;

                db.CloseConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dgvApplicants_CellClick(
            object sender,
            DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            DataGridViewRow row =
                dgvApplicants.Rows[e.RowIndex];

            selectedApplicationID =
                Convert.ToInt32(row.Cells["ApplicationID"].Value);

            txtApplicant.Text =
                row.Cells["ApplicantName"].Value.ToString();

            txtJob.Text =
                row.Cells["JobTitle"].Value.ToString();

            cmbStatus.Text =
                row.Cells["CurrentStatus"].Value.ToString();
        }

        private void btnSaveReview_Click(
            object sender,
            EventArgs e)
        {
            try
            {
                if (selectedApplicationID == 0)
                {
                    MessageBox.Show("Please select an applicant.");
                    return;
                }

                db.OpenConnection();

                string updateQuery = @"
                UPDATE Applications
                SET CurrentStatus=@status
                WHERE ApplicationID=@id";

                MySqlCommand cmd =
                    new MySqlCommand(updateQuery,
                    db.GetConnection());

                cmd.Parameters.AddWithValue("@status",
                    cmbStatus.Text);

                cmd.Parameters.AddWithValue("@id",
                    selectedApplicationID);

                cmd.ExecuteNonQuery();

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
                    'HR Staff'
                )";

                MySqlCommand reviewCmd =
                    new MySqlCommand(reviewQuery,
                    db.GetConnection());

                reviewCmd.Parameters.AddWithValue("@app", selectedApplicationID);
                reviewCmd.Parameters.AddWithValue("@remarks", txtRemarks.Text);
                reviewCmd.Parameters.AddWithValue("@recommendation", cmbStatus.Text);

                reviewCmd.ExecuteNonQuery();

                db.CloseConnection();

                MessageBox.Show("Review Saved Successfully!");

                LoadApplicants();

                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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

        // ================= CLEAR FUNCTION =================
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

        private void label2_Click(object sender, EventArgs e) { }
        private void label5_Click(object sender, EventArgs e) { }
        private void label6_Click(object sender, EventArgs e) { }
    }
}