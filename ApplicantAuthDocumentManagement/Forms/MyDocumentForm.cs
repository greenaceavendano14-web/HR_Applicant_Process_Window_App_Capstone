using System;
using System.Data;
using System.IO;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace ApplicantAuthDocumentManagement.Forms
{
    public partial class MyDocumentForm : Form
    {
        private int currentApplicantID = Session.ApplicantID;

        public MyDocumentForm()
        {
            InitializeComponent();
        }

        private void MyDocumentForm_Load(object sender, EventArgs e)
        {
            LoadDocumentRequirements();
            LoadStatusTimeline();
        }

        /// <summary>
        /// Fetches the current required documents and displays them in the upper grid (dgvDocuments)
        /// </summary>
        private void LoadDocumentRequirements()
        {
            string selectQuery = @"
                SELECT r.RequirementTypeID AS 'Type ID',
                       r.TypeName AS 'Requirement Name', 
                       IFNULL(d.SubmissionStatus, 'Missing') AS 'Submission Status',
                       IFNULL(d.FilePath, 'No File Uploaded') AS 'File Path Location'
                FROM RequirementTypes r
                LEFT JOIN ApplicantDocuments d ON r.RequirementTypeID = d.RequirementTypeID 
                                              AND d.ApplicationID = (SELECT ApplicationID FROM Applications WHERE ApplicantID = @AppID LIMIT 1)";


            using (MySqlConnection conn = DBConnection.GetConnection())
            {
                using (MySqlCommand cmd = new MySqlCommand(selectQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@AppID", currentApplicantID);

                    try
                    {
                        conn.Open();
                        MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);

                        dgvDocuments.DataSource = dt;

                        if (dgvDocuments.Columns.Contains("Type ID"))
                        {
                            dgvDocuments.Columns["Type ID"].Visible = false;
                        }

                        UpdateSubmissionSummaryCounters();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error loading requirements: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        /// <summary>
        /// Fetches the historical log updates and populates the tracking grid (dgvTimeline)
        /// </summary>
        private void LoadStatusTimeline()
        {
            string queryTimeline = @"
                SELECT NewStatus AS 'Stage Progress Status', 
                       Remarks AS 'HR Operational Evaluation Remarks', 
                       ChangedAt AS 'Update Timestamp Log'
                FROM ApplicationStatusHistory
                WHERE ApplicationID = (SELECT ApplicationID FROM Applications WHERE ApplicantID = @AppID LIMIT 1)
                ORDER BY ChangedAt DESC";

            using (MySqlConnection conn = DBConnection.GetConnection())
            {
                using (MySqlCommand cmd = new MySqlCommand(queryTimeline, conn))
                {
                    cmd.Parameters.AddWithValue("@AppID", currentApplicantID);

                    try
                    {
                        conn.Open();
                        MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);

                        dgvTimeline.DataSource = dt;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error loading status log: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        /// <summary>
        /// Button action that opens a file browser window and saves the file record path to MySQL
        /// </summary>
        private void btnUpload_Click(object sender, EventArgs e)
        {
            if (dgvDocuments.CurrentRow == null)
            {
                MessageBox.Show("Please select a specific requirement row item from the list above first.", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int requirementTypeID = Convert.ToInt32(dgvDocuments.CurrentRow.Cells["Type ID"].Value);
            string documentNameLabel = dgvDocuments.CurrentRow.Cells["Requirement Name"].Value.ToString();

            using (OpenFileDialog fileDialog = new OpenFileDialog())
            {
                fileDialog.Filter = "Document Files (*.pdf;*.docx;*.jpg;*.png)|*.pdf;*.docx;*.jpg;*.png|All Files (*.*)|*.*";
                fileDialog.Title = "Select File for " + documentNameLabel;

                if (fileDialog.ShowDialog() == DialogResult.OK)
                {
                    string chosenFilePath = fileDialog.FileName;

                    string standardFileName = Path.GetFileName(chosenFilePath);

                    string saveQuery = @"
                        INSERT INTO ApplicantDocuments (ApplicationID, RequirementTypeID, FilePath, FileName, SubmissionStatus) 
                        VALUES ((SELECT ApplicationID FROM Applications WHERE ApplicantID = @AppID LIMIT 1), @ReqTypeID, @DocPath, @DocName, 'Submitted')
                        ON DUPLICATE KEY UPDATE FilePath = @DocPath, FileName = @DocName, SubmissionStatus = 'Submitted'";

                    using (MySqlConnection conn = DBConnection.GetConnection())
                    {
                        using (MySqlCommand cmd = new MySqlCommand(saveQuery, conn))
                        {
                            cmd.Parameters.AddWithValue("@AppID", currentApplicantID);
                            cmd.Parameters.AddWithValue("@ReqTypeID", requirementTypeID);
                            cmd.Parameters.AddWithValue("@DocPath", chosenFilePath);
                            cmd.Parameters.AddWithValue("@DocName", standardFileName);

                            try
                            {
                                conn.Open();
                                cmd.ExecuteNonQuery();

                                MessageBox.Show(documentNameLabel + " has been recorded successfully!", "Upload Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                LoadDocumentRequirements();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("Critical Error during insertion: " + ex.Message, "Execution Aborted", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Simple structural loops that count status occurrences and updates your designer labels separately
        /// </summary>
        private void UpdateSubmissionSummaryCounters()
        {
            int submittedCount = 0;
            int missingCount = 0;

            foreach (DataGridViewRow row in dgvDocuments.Rows)
            {
                if (row.Cells["Submission Status"].Value != null)
                {
                    string cellStatusValue = row.Cells["Submission Status"].Value.ToString();

                    if (cellStatusValue == "Submitted")
                    {
                        submittedCount++;
                    }
                    else if (cellStatusValue == "Missing")
                    {
                        missingCount++;
                    }
                }
            }

            lblSubmittedIndicator.Text = "Submitted: " + submittedCount.ToString() + " slots";
            lblMissingIndicator.Text = "Missing: " + missingCount.ToString() + " slots";
        }
    }
}