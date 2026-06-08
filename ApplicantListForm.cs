using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace HRApplicationFormView
{
    public partial class ApplicantListForm : Form
    {
        DBConnection db = new DBConnection();

        public ApplicantListForm()
        {
            InitializeComponent();

            this.Load += ApplicantListForm_Load;

            btnRefresh.Click += btnRefresh_Click;
            btnSearch.Click += btnSearch_Click;
            btnOpenResume.Click += btnOpenResume_Click;
            btnClose.Click += btnClose_Click;
        }

        private void ApplicantListForm_Load(object sender, EventArgs e)
        {
            LoadApplicants();
        }

        // ================= LOAD =================
        private void LoadApplicants()
        {
            db.OpenConnection();

            string query = "SELECT * FROM vw_ApplicantListHR";

            MySqlDataAdapter da = new MySqlDataAdapter(query, db.GetConnection());
            DataTable dt = new DataTable();
            da.Fill(dt);

            dgvApplicants.DataSource = dt;

            db.CloseConnection();
        }

        // ================= REFRESH =================
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtSearch.Clear();
            LoadApplicants();
        }

        // ================= SEARCH =================
        private void btnSearch_Click(object sender, EventArgs e)
        {
            db.OpenConnection();

            string query = @"
            SELECT * FROM vw_ApplicantListHR
            WHERE ApplicantName LIKE @search";

            MySqlCommand cmd = new MySqlCommand(query, db.GetConnection());
            cmd.Parameters.AddWithValue("@search", "%" + txtSearch.Text + "%");

            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            dgvApplicants.DataSource = dt;

            db.CloseConnection();
        }

        // ================= OPEN RESUME (FIXED ERROR) =================
        private void btnOpenResume_Click(object sender, EventArgs e)
        {
            if (dgvApplicants.SelectedRows.Count == 0)
            {
                MessageBox.Show("Select applicant first.");
                return;
            }

            string path = dgvApplicants.SelectedRows[0]
                .Cells["ResumeFilePath"].Value.ToString();

            if (string.IsNullOrEmpty(path))
            {
                MessageBox.Show("No resume uploaded.");
                return;
            }

            if (!File.Exists(path))
            {
                MessageBox.Show("File not found:\n" + path);
                return;
            }

            Process.Start(new ProcessStartInfo
            {
                FileName = path,
                UseShellExecute = true
            });
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}