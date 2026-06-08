using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace ApplicantAuthDocumentManagement.Forms
{
    public partial class ApplicationStatusForm : Form
    {
        private int currentApplicantID = Session.ApplicantID;

        public ApplicationStatusForm()
        {
            InitializeComponent();

            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
        }

        private void ApplicationStatusForm_Load(object sender, EventArgs e)
        {
            FetchAndRenderApplicationStatus();
            FixUiLayoutIssues();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            FetchAndRenderApplicationStatus();
            MessageBox.Show("Your application timeline records have been successfully updated live!", "Status Synchronized", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// Simple method to clean up visual bugs, handle parent panel containment, and ensure maximum contrast readability
        /// </summary>
        private void FixUiLayoutIssues()
        {
            if (this.Controls.Contains(lblSectionTitle))
            {
                this.Controls.Remove(lblSectionTitle);
                pnlHeader.Controls.Add(lblSectionTitle);

                lblSectionTitle.Location = new System.Drawing.Point(630, 25);
            }

            lblSectionTitle.ForeColor = System.Drawing.Color.White;
        }

        /// <summary>
        /// Central tracking routine managing database connections to extract job info and historical progress logs
        /// </summary>
        private void FetchAndRenderApplicationStatus()
        {
            string overviewQuery = @"
                SELECT JobTitle, CurrentStatus 
                FROM Applications 
                WHERE ApplicantID = @AppID 
                LIMIT 1;";

            string timelineQuery = @"
                SELECT NewStatus AS 'Recruitment Stage Phase', 
                       Remarks AS 'HR Operations Review Notes', 
                       ChangedAt AS 'Action Date & Timestamp'
                FROM ApplicationStatusHistory
                WHERE ApplicationID = (SELECT ApplicationID FROM Applications WHERE ApplicantID = @AppID LIMIT 1)
                ORDER BY ChangedAt DESC;";

            using (MySqlConnection conn = DBConnection.GetConnection())
            {
                try
                {
                    conn.Open();

                    using (MySqlCommand cmdOverview = new MySqlCommand(overviewQuery, conn))
                    {
                        cmdOverview.Parameters.AddWithValue("@AppID", currentApplicantID);

                        using (MySqlDataReader reader = cmdOverview.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                lblJobTitle.Text = "Applying For: " + reader["JobTitle"].ToString();
                                lblCurrentStatus.Text = reader["CurrentStatus"].ToString().ToUpper();
                            }
                            else
                            {
                                lblJobTitle.Text = "Applying For: No Active Job Request Found";
                                lblCurrentStatus.Text = "NOT INITIALIZED";
                            }
                        }
                    }

                    using (MySqlCommand cmdTimeline = new MySqlCommand(timelineQuery, conn))
                    {
                        cmdTimeline.Parameters.AddWithValue("@AppID", currentApplicantID);

                        MySqlDataAdapter adapter = new MySqlDataAdapter(cmdTimeline);
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);

                        dgvTimeline.DataSource = dt;

                        dgvTimeline.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                        if (dt.Rows.Count > 0)
                        {
                            string latestRemarkText = dt.Rows[0]["HR Operations Review Notes"].ToString();

                            if (string.IsNullOrWhiteSpace(latestRemarkText))
                            {
                                txtRemarks.Text = "Your application request is currently processing. Administrative summary remarks box left blank.";
                            }
                            else
                            {
                                txtRemarks.Text = latestRemarkText;
                            }
                        }
                        else
                        {
                            txtRemarks.Text = "Your application form is currently in queue. No administrative analysis entries written yet.";
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error communicating with timeline server: " + ex.Message, "Database Communication Failure", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void pnlMainContent_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}