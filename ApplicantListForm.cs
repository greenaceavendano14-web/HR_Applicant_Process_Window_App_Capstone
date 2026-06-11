using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using HRApplicantSystem.Database;
using HRApplicantSystem.Models;

namespace HRApplicantSystem
{
    public partial class ApplicantListForm : Form
    {
        DbConnection db = new DbConnection();

        public ApplicantListForm()
        {
            InitializeComponent();

            this.Load += ApplicantListForm_Load;

            btnRefresh.Click += btnRefresh_Click;
            btnSearch.Click += btnSearch_Click;
            btnOpenResume.Click += btnOpenResume_Click;
            btnClose.Click += btnClose_Click;
        }

        private void ApplicantListForm_Load(object? sender, EventArgs e)
        {
            LoadApplicants();
        }


        private void LoadApplicants()
        {
            try
            {
                MySqlConnection conn = db.GetConnection();
                conn.Open();

                string query = "SELECT * FROM vw_ApplicationSummary";

                MySqlDataAdapter da = new MySqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dgvApplicants.DataSource = dt;
                dgvApplicants.ReadOnly = true;
                dgvApplicants.AllowUserToAddRows = false;
                dgvApplicants.AllowUserToDeleteRows = false;
                dgvApplicants.SelectionMode =
                    DataGridViewSelectionMode.FullRowSelect;

                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Load error: " + ex.Message);
            }
        }


        private void btnRefresh_Click(object? sender, EventArgs e)
        {
            txtSearch.Clear();
            LoadApplicants();
        }


        private void btnSearch_Click(object? sender, EventArgs e)
        {
            try
            {
                MySqlConnection conn = db.GetConnection();
                conn.Open();

                string query = @"
        SELECT *
        FROM vw_ApplicationSummary
        WHERE ApplicantName LIKE @search
           OR JobTitle LIKE @search
           OR CurrentStatus LIKE @search";

                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue(
                    "@search",
                    "%" + txtSearch.Text.Trim() + "%");

                MySqlDataAdapter da = new MySqlDataAdapter(cmd);

                DataTable dt = new DataTable();
                da.Fill(dt);

                dgvApplicants.DataSource = dt;

                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Search error: " + ex.Message);
            }
        }


        private void btnOpenResume_Click(object? sender, EventArgs e)
        {
            btnOpenResume.Enabled = false;
        }

        private void LogAudit(string action, string details)
        {
            try
            {
                MySqlConnection conn = db.GetConnection();
                conn.Open();

                string query = @"
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
            @ActorType,
            @ActorID,
            @Action,
            'Applicants',
            0,
            @Details
        )";

                MySqlCommand cmd = new MySqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@ActorType", Session.RoleName);
                cmd.Parameters.AddWithValue("@ActorID", Session.UserID);
                cmd.Parameters.AddWithValue("@Action", action);
                cmd.Parameters.AddWithValue("@Details", details);

                cmd.ExecuteNonQuery();

                conn.Close();
            }
            catch
            {
            }
        }

        private void btnViewDetails_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvApplicants.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Please select an applicant first.");
                    return;
                }

                DataGridViewRow row = dgvApplicants.SelectedRows[0];

                if (row.Cells["ApplicationID"].Value == null)
                {
                    MessageBox.Show("Invalid row selected.");
                    return;
                }


                string applicationId = row.Cells["ApplicationID"].Value?.ToString() ?? "N/A";
                string applicantName = row.Cells["ApplicantName"].Value?.ToString() ?? "N/A";
                string jobTitle = row.Cells["JobTitle"].Value?.ToString() ?? "N/A";
                string department = row.Cells["DepartmentName"].Value?.ToString() ?? "N/A";
                string status = row.Cells["CurrentStatus"].Value?.ToString() ?? "N/A";
                string submittedAt = row.Cells["SubmittedAt"].Value?.ToString() ?? "N/A";
                string missingDocs = row.Cells["MissingDocCount"].Value?.ToString() ?? "0";

 
                string details = $@"
APPLICATION DETAILS

Application ID: {applicationId}
Applicant Name: {applicantName}
Job Title: {jobTitle}
Department: {department}

Status: {status}
Submitted At: {submittedAt}
Missing Documents: {missingDocs}
";

                MessageBox.Show(details, "Applicant Details", MessageBoxButtons.OK, MessageBoxIcon.Information);


                LogAudit(
                    "VIEW_APPLICANT_DETAILS",
                    "Viewed ApplicationID: " + applicationId
                );
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading details: " + ex.Message);
            }
        }

        private void btnClose_Click(object? sender, EventArgs e)
        {
            this.Close();
        }

        
    }
}
