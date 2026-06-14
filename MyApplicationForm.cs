using HRApplicantSystem.Database;
using HRApplicantSystem.Models;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;
using System.IO;

namespace ApplicantSystem
{
    public partial class MyApplicationForm : Form
    {
        DbConnection db = new DbConnection();

        private string resumePath = "";
        private int applicantID;

        public MyApplicationForm()
        {
            InitializeComponent();

            applicantID = ApplicantSession.ApplicantID;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadApplicantInfo();
            LoadJobs();
            LoadGrid();
        }


        private void LoadApplicantInfo()
        {
            using (MySqlConnection conn = db.GetConnection())
            {
                conn.Open();

                string query = @"
        SELECT
            CONCAT(FirstName,' ',LastName) AS FullName,
            Email
        FROM Applicants
        WHERE ApplicantID=@ApplicantID";

                MySqlCommand cmd =
                    new MySqlCommand(query, conn);

                cmd.Parameters.AddWithValue(
                    "@ApplicantID",
                    applicantID);

            }
        }


        private void LoadJobs()
        {
            using (MySqlConnection conn = db.GetConnection())
            {
                conn.Open();

                string query =
                    "SELECT VacancyID, JobTitle FROM JobVacancies WHERE Status='Open'";

                MySqlDataAdapter da =
                    new MySqlDataAdapter(query, conn);

                DataTable dt = new DataTable();

                da.Fill(dt);

                cmbJobs.DataSource = dt;
                cmbJobs.DisplayMember = "JobTitle";
                cmbJobs.ValueMember = "VacancyID";
                cmbJobs.SelectedIndex = -1;
            }
        }

        private void LoadGrid()
        {
            using (MySqlConnection conn = db.GetConnection())
            {
                conn.Open();

                string query = @"
SELECT
    a.ApplicationID,
    j.JobTitle,
    a.CurrentStatus,
    a.SubmittedAt
FROM Applications a
INNER JOIN JobVacancies j
    ON a.VacancyID = j.VacancyID
WHERE a.ApplicantID = @ApplicantID";

                MySqlCommand cmd =
                    new MySqlCommand(query, conn);

                cmd.Parameters.AddWithValue(
                    "@ApplicantID",
                    applicantID);

                MySqlDataAdapter da =
                    new MySqlDataAdapter(cmd);

                DataTable dt = new DataTable();

                da.Fill(dt);

                dgvApplications.DataSource = dt;
            }
        }

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

        private void btnApply_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbJobs.SelectedIndex == -1)
                {
                    MessageBox.Show("Select a job first.");
                    return;
                }

                using (MySqlConnection conn = db.GetConnection())
                {
                    conn.Open();

                    string checkQuery = @"
            SELECT COUNT(*)
            FROM Applications
            WHERE ApplicantID=@ApplicantID
            AND VacancyID=@VacancyID";

                    MySqlCommand checkCmd =
                        new MySqlCommand(checkQuery, conn);

                    checkCmd.Parameters.AddWithValue(
                        "@ApplicantID",
                        applicantID);

                    checkCmd.Parameters.AddWithValue(
                        "@VacancyID",
                        cmbJobs.SelectedValue);

                    int exists =
                        Convert.ToInt32(
                            checkCmd.ExecuteScalar());

                    if (exists > 0)
                    {
                        MessageBox.Show(
                            "You already applied for this job.");
                        return;
                    }

                    string insertQuery = @"
            INSERT INTO Applications
            (
                ApplicantID,
                VacancyID,
                CurrentStatus,
                SubmittedAt
            )
            VALUES
            (
                @ApplicantID,
                @VacancyID,
                'Submitted',
                NOW()
            )";

                    MySqlCommand insertCmd =
                        new MySqlCommand(insertQuery, conn);

                    insertCmd.Parameters.AddWithValue(
                        "@ApplicantID",
                        applicantID);

                    insertCmd.Parameters.AddWithValue(
                        "@VacancyID",
                        cmbJobs.SelectedValue);

                    insertCmd.ExecuteNonQuery();

                    MessageBox.Show(
                        "Application submitted successfully!");
                }

                LoadGrid();
                ClearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error: " + ex.Message);
            }
        }


        private bool IsApplicationLocked(int applicationID)
        {
            using (MySqlConnection conn = db.GetConnection())
            {
                conn.Open();

                string query = @"
        SELECT CurrentStatus
        FROM Applications
        WHERE ApplicationID=@ApplicationID
        AND ApplicantID=@ApplicantID";

                MySqlCommand cmd =
    new MySqlCommand(query, conn);

                cmd.Parameters.AddWithValue(
                    "@ApplicationID",
                    applicationID);

                cmd.Parameters.AddWithValue(
                    "@ApplicantID",
                    applicantID);

                string status =
                    Convert.ToString(
                        cmd.ExecuteScalar());

                return status == "Under Review" ||
                       status == "Shortlisted" ||
                       status == "For Interview" ||
                       status == "For Assessment" ||
                       status == "For Final Review" ||
                       status == "Accepted" ||
                       status == "Rejected";
            }
        }


        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvApplications.CurrentRow == null)
            {
                MessageBox.Show("Select an application first.");
                return;
            }

            int applicationID =
                Convert.ToInt32(
                    dgvApplications.CurrentRow.Cells["ApplicationID"].Value);

            try
            {
                if (IsApplicationLocked(applicationID))
                {
                    MessageBox.Show(
                        "This application can no longer be deleted because HR has already started reviewing it.");
                    return;
                }

                DialogResult result =
                    MessageBox.Show(
                        "Are you sure you want to delete this application?",
                        "Confirm Delete",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);

                if (result == DialogResult.No)
                    return;

                using (MySqlConnection conn = db.GetConnection())
                {
                    conn.Open();
                    string deleteDocs = @"
                DELETE FROM ApplicantDocuments
                WHERE ApplicationID=@ApplicationID";

                    MySqlCommand cmdDocs =
                        new MySqlCommand(deleteDocs, conn);

                    cmdDocs.Parameters.AddWithValue(
                        "@ApplicationID",
                        applicationID);

                    cmdDocs.ExecuteNonQuery();


                    string deleteHistory = @"
                DELETE FROM ApplicationStatusHistory
                WHERE ApplicationID=@ApplicationID";

                    MySqlCommand cmdHistory =
                        new MySqlCommand(deleteHistory, conn);

                    cmdHistory.Parameters.AddWithValue(
                        "@ApplicationID",
                        applicationID);

                    cmdHistory.ExecuteNonQuery();


                    string deleteApplication = @"
                DELETE FROM Applications
                WHERE ApplicationID=@ApplicationID
                AND ApplicantID=@ApplicantID";

                    MySqlCommand cmdDelete = new MySqlCommand(deleteApplication, conn);

                    cmdDelete.Parameters.AddWithValue("@ApplicationID", applicationID);
                    cmdDelete.Parameters.AddWithValue("@ApplicantID", applicantID);

                    cmdDelete.ExecuteNonQuery();

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
                    'Applicant',
                    @ActorID,
                    'DELETE_APPLICATION',
                    'Applications',
                    @TargetID,
                    'Applicant deleted application.'
                )";

                    MySqlCommand auditCmd =
                        new MySqlCommand(auditQuery, conn);

                    auditCmd.Parameters.AddWithValue(
                        "@ActorID",
                        applicantID);
                    auditCmd.Parameters.AddWithValue("@TargetID", applicationID);

                    auditCmd.ExecuteNonQuery();
                }

                MessageBox.Show("Application deleted successfully.");

                LoadGrid();
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
