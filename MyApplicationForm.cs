using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.IO;
using System.Windows.Forms;

namespace ApplicationForm
{
    public partial class Form1 : Form
    {
        DBConnection db = new DBConnection();

        private string resumePath = "";
        private int applicantID = 1;

        public Form1()
        {
            InitializeComponent();

            btnUploadResume.Click += btnUploadResume_Click;
            btnApply.Click += btnApply_Click;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadJobs();
            LoadGrid();
        }

        // ================= LOAD JOBS =================
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

            db.CloseConnection();
        }

        // ================= LOAD DATAGRIDVIEW =================
        private void LoadGrid()
        {
            db.OpenConnection();

            string query = "SELECT * FROM vw_ApplicationsGrid";

            MySqlDataAdapter da = new MySqlDataAdapter(query, db.GetConnection());
            DataTable dt = new DataTable();
            da.Fill(dt);

            dgvApplications.DataSource = dt;

            db.CloseConnection();
        }

        // ================= UPLOAD FILE =================
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
                db.OpenConnection();

                // check duplicate
                string check = @"
                SELECT COUNT(*) FROM Applications
                WHERE ApplicantID=@a AND VacancyID=@v";

                MySqlCommand cmdCheck = new MySqlCommand(check, db.GetConnection());
                cmdCheck.Parameters.AddWithValue("@a", applicantID);
                cmdCheck.Parameters.AddWithValue("@v", cmbJobs.SelectedValue);

                int exists = Convert.ToInt32(cmdCheck.ExecuteScalar());

                if (exists > 0)
                {
                    MessageBox.Show("Already applied!");
                    db.CloseConnection();
                    return;
                }

                // insert
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

                MessageBox.Show("Applied successfully!");

                LoadGrid(); // refresh datagrid
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
            lblFileName.Text = "No file";
            resumePath = "";
        }
    }
}