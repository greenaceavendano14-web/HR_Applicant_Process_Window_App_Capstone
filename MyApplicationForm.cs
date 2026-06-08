using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.IO;
using System.Windows.Forms;

namespace ApplicationForm
{
    public partial class MyApplicationForm : Form
    {
        DBConnection db = new DBConnection();

        private string resumePath = "";
        private int applicantID;

        public MyApplicationForm(int id)
        {
            InitializeComponent();
            applicantID = id;

            this.Load += Form1_Load;

            btnUploadResume.Click += btnUploadResume_Click;
            btnApply.Click += btnApply_Click;
        }

        // ================= LOAD =================
        private void Form1_Load(object sender, EventArgs e)
        {
            LoadJobs();
            LoadGrid();
        }

        // ================= JOBS =================
        private void LoadJobs()
        {
            db.OpenConnection();

            string query = "SELECT VacancyID, JobTitle FROM JobVacancies WHERE Status='Open'";

            MySqlDataAdapter da = new MySqlDataAdapter(query, db.GetConnection());
            DataTable dt = new DataTable();
            da.Fill(dt);

            cmbJobs.DataSource = dt;
            cmbJobs.DisplayMember = "JobTitle";
            cmbJobs.ValueMember = "VacancyID";
            cmbJobs.SelectedIndex = -1;

            db.CloseConnection();
        }

        // ================= GRID =================
        private void LoadGrid()
        {
            db.OpenConnection();

            string query = @"
            SELECT 
                a.ApplicationID,
                ap.FirstName,
                ap.LastName,
                j.JobTitle,
                a.CurrentStatus
            FROM Applications a
            INNER JOIN Applicants ap ON a.ApplicantID = ap.ApplicantID
            INNER JOIN JobVacancies j ON a.VacancyID = j.VacancyID";

            MySqlDataAdapter da = new MySqlDataAdapter(query, db.GetConnection());
            DataTable dt = new DataTable();
            da.Fill(dt);

            dgvApplications.DataSource = dt;

            db.CloseConnection();
        }

        // ================= UPLOAD =================
        private void btnUploadResume_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "PDF|*.pdf|Word|*.docx|All Files|*.*";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                resumePath = ofd.FileName;
                lblFileName.Text = Path.GetFileName(resumePath);
            }
        }

        // ================= APPLY =================
        private void btnApply_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbJobs.SelectedIndex == -1)
                {
                    MessageBox.Show("Select a job first.");
                    return;
                }

                if (string.IsNullOrEmpty(resumePath))
                {
                    MessageBox.Show("Upload resume first.");
                    return;
                }

                db.OpenConnection();

                // CHECK DUPLICATE
                string check = @"
                SELECT COUNT(*) FROM Applications
                WHERE ApplicantID=@a AND VacancyID=@v";

                MySqlCommand cmdCheck = new MySqlCommand(check, db.GetConnection());
                cmdCheck.Parameters.AddWithValue("@a", applicantID);
                cmdCheck.Parameters.AddWithValue("@v", cmbJobs.SelectedValue);

                int exists = Convert.ToInt32(cmdCheck.ExecuteScalar());

                if (exists > 0)
                {
                    MessageBox.Show("Already applied to this job.");
                    db.CloseConnection();
                    return;
                }

                // INSERT APPLICATION
                string insert = @"
                INSERT INTO Applications
                (ApplicantID, VacancyID, CurrentStatus, ResumeFilePath)
                VALUES (@a,@v,'Submitted',@r)";

                MySqlCommand cmd = new MySqlCommand(insert, db.GetConnection());

                cmd.Parameters.AddWithValue("@a", applicantID);
                cmd.Parameters.AddWithValue("@v", cmbJobs.SelectedValue);
                cmd.Parameters.AddWithValue("@r", resumePath);

                cmd.ExecuteNonQuery();

                db.CloseConnection();

                MessageBox.Show("Application submitted successfully!");

                LoadGrid();
                ClearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void ClearForm()
        {
            cmbJobs.SelectedIndex = -1;
            lblFileName.Text = "No file selected";
            resumePath = "";
        }
    }
}