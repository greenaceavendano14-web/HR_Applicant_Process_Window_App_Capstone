using System;
using System.Data;
using System.Windows.Forms;
using System.IO;
using MySql.Data.MySqlClient;
using HRApplicantSystem.Database;
using ApplicantSystem;

namespace HRApplicantSystem
{
    public partial class MyDocumentForm : Form
    {
        DbConnection db = new DbConnection();

        private int currentApplicantID;
        private int applicationID;

        public MyDocumentForm()
        {
            InitializeComponent();
            this.Load += MyDocumentForm_Load;
        }

        private void MyDocumentForm_Load(object sender, EventArgs e)
        {
            currentApplicantID = ApplicantSession.ApplicantID;

            if (currentApplicantID <= 0)
            {
                MessageBox.Show("Applicant session expired.");
                this.Close();
                return;
            }

            GetApplicationID();

            if (applicationID <= 0)
            {
                MessageBox.Show("No application found for this applicant.");
                this.Close();
                return;
            }

            LoadDocumentRequirements();
            LoadStatusTimeline();
        }


        private void GetApplicationID()
        {
            try
            {
                using (MySqlConnection conn = db.GetConnection())
                {
                    conn.Open();

                    string query = @"
                        SELECT ApplicationID
                        FROM Applications
                        WHERE ApplicantID = @id
                        ORDER BY ApplicationID DESC
                        LIMIT 1";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", currentApplicantID);

                        object result = cmd.ExecuteScalar();

                        if (result != null)
                        {
                            applicationID = Convert.ToInt32(result);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error getting application: " + ex.Message);
            }
        }

        private void LoadDocumentRequirements()
        {
            try
            {
                string query = @"
                    SELECT 
                        r.RequirementTypeID AS 'Type ID',
                        r.TypeName AS 'Requirement Name',
                        IFNULL(d.SubmissionStatus, 'Missing') AS 'Submission Status',
                        IFNULL(d.FilePath, 'No File Uploaded') AS 'File Path'
                    FROM RequirementTypes r
                    LEFT JOIN ApplicantDocuments d 
                        ON r.RequirementTypeID = d.RequirementTypeID 
                        AND d.ApplicationID = @AppID";

                using (MySqlConnection conn = db.GetConnection())
                {
                    conn.Open();

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@AppID", applicationID);

                        MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        dgvDocuments.DataSource = dt;

                        // Grid settings (FIXED)
                        dgvDocuments.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                        dgvDocuments.ReadOnly = true;
                        dgvDocuments.AllowUserToAddRows = false;
                        dgvDocuments.AllowUserToDeleteRows = false;
                        dgvDocuments.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

                        if (dgvDocuments.Columns.Contains("Type ID"))
                        {
                            dgvDocuments.Columns["Type ID"].Visible = false;
                        }

                        UpdateSubmissionSummaryCounters();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading requirements: " + ex.Message);
            }
        }


        private void LoadStatusTimeline()
        {
            try
            {
                string query = @"
                    SELECT 
                        NewStatus AS 'Status',
                        Remarks AS 'Remarks',
                        ChangedAt AS 'Date Updated'
                    FROM ApplicationStatusHistory
                    WHERE ApplicationID = @AppID
                    ORDER BY ChangedAt DESC";

                using (MySqlConnection conn = db.GetConnection())
                {
                    conn.Open();

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@AppID", applicationID);

                        MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        dgvTimeline.DataSource = dt;

                        dgvTimeline.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                        dgvTimeline.ReadOnly = true;
                        dgvTimeline.AllowUserToAddRows = false;
                        dgvTimeline.AllowUserToDeleteRows = false;
                        dgvTimeline.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading timeline: " + ex.Message);
            }
        }


        private void btnUpload_Click(object sender, EventArgs e)
        {
            if (IsApplicationLocked())
            {
                MessageBox.Show(
                    "Documents can no longer be modified because HR has already started reviewing your application.",
                    "Application Locked",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            if (dgvDocuments.CurrentRow == null)
            {
                MessageBox.Show("Select a requirement first.");
                return;
            }

            int requirementTypeID = Convert.ToInt32(dgvDocuments.CurrentRow.Cells["Type ID"].Value);
            string requirementName = dgvDocuments.CurrentRow.Cells["Requirement Name"].Value.ToString();

            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Files (*.pdf;*.docx;*.jpg;*.png)|*.pdf;*.docx;*.jpg;*.png";
                ofd.Title = "Upload " + requirementName;

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    string filePath = ofd.FileName;
                    string fileName = Path.GetFileName(filePath);

                    try
                    {
                        using (MySqlConnection conn = db.GetConnection())
                        {
                            conn.Open();

                            string query = @"
                                INSERT INTO ApplicantDocuments
                                (ApplicationID, RequirementTypeID, FilePath, FileName, SubmissionStatus)
                                VALUES
                                (@AppID, @ReqID, @Path, @Name, 'Submitted')
                                ON DUPLICATE KEY UPDATE
                                FilePath = @Path,
                                FileName = @Name,
                                SubmissionStatus = 'Submitted'";

                            using (MySqlCommand cmd = new MySqlCommand(query, conn))
                            {
                                cmd.Parameters.AddWithValue("@AppID", applicationID);
                                cmd.Parameters.AddWithValue("@ReqID", requirementTypeID);
                                cmd.Parameters.AddWithValue("@Path", filePath);
                                cmd.Parameters.AddWithValue("@Name", fileName);

                                cmd.ExecuteNonQuery();
                            }

                            // Audit log
                            string audit = @"
                                INSERT INTO AuditTrail
                                (ActorType, ActorID, Action, Details)
                                VALUES
                                ('Applicant', @id, 'UPLOAD_DOCUMENT', @details)";

                            using (MySqlCommand cmd2 = new MySqlCommand(audit, conn))
                            {
                                cmd2.Parameters.AddWithValue("@id", currentApplicantID);
                                cmd2.Parameters.AddWithValue("@details", requirementName + " uploaded");
                                cmd2.ExecuteNonQuery();
                            }
                        }

                        MessageBox.Show("Uploaded successfully!");
                        LoadDocumentRequirements();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Upload error: " + ex.Message);
                    }
                }
            }
        }


        private bool IsApplicationLocked()
        {
            using (MySqlConnection conn = db.GetConnection())
            {
                conn.Open();

                string query = @"
        SELECT CurrentStatus
        FROM Applications
        WHERE ApplicationID=@AppID";

                MySqlCommand cmd =
                    new MySqlCommand(query, conn);

                cmd.Parameters.AddWithValue(
                    "@AppID",
                    applicationID);

                string status =
                    Convert.ToString(cmd.ExecuteScalar());

                return status == "Under Review" ||
                       status == "Shortlisted" ||
                       status == "For Interview" ||
                       status == "For Assessment" ||
                       status == "For Final Review" ||
                       status == "Accepted" ||
                       status == "Rejected";
            }
        }
        private void UpdateSubmissionSummaryCounters()
        {
            int submitted = 0;
            int missing = 0;

            foreach (DataGridViewRow row in dgvDocuments.Rows)
            {
                if (row.Cells["Submission Status"].Value != null)
                {
                    string status = row.Cells["Submission Status"].Value.ToString();

                    if (status == "Submitted") submitted++;
                    else missing++;
                }
            }

            lblSubmittedIndicator.Text = "Submitted: " + submitted;
            lblMissingIndicator.Text = "Missing: " + missing;
        }
    }
}