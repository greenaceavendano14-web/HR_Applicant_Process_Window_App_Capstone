using ApplicantSystem;
using HRApplicantSystem.Database;
using HRApplicantSystem.Models;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace HRApplicantSystem
{
    public partial class ApplicantDashboard : Form
    {
        public ApplicantDashboard()
        {
            InitializeComponent();

            Load += ApplicantDashboard_Load;

            btnLogout.Click += btnLogout_Click;
            btnProfile.Click += btnProfile_Click;
            btnVacancies.Click += btnVacancies_Click;
            btnMyApplications.Click += btnMyApplications_Click;
            btnDocuments.Click += btnDocuments_Click;
            btnChangePasword.Click += btnChangePasword_Click;
        }

        private void ApplicantDashboard_Load(object sender, EventArgs e)
        {
            if (ApplicantSession.ApplicantID <= 0)
            {
                MessageBox.Show("Session expired.");

                LoginForm login = new LoginForm();
                login.Show();

                this.Close();
                return;
            }

            LoadApplicantData();
            LoadInterviewSchedule();
            LoadMissingDocuments();
            LoadRecentUpdates();
        }

        private void LoadApplicantData()
        {
            DbConnection db = new DbConnection();

            string query = @"
    SELECT
        ap.ApplicantID,
        CONCAT(ap.FirstName,' ',ap.LastName) AS ApplicantName,
        a.ApplicationID,
        jv.JobTitle,
        a.CurrentStatus,
        a.SubmittedAt
    FROM Applicants ap
    LEFT JOIN Applications a
        ON ap.ApplicantID = a.ApplicantID
    LEFT JOIN JobVacancies jv
        ON a.VacancyID = jv.VacancyID
    WHERE ap.ApplicantID = @ApplicantID
    ORDER BY a.ApplicationID DESC
    LIMIT 1";

            using (MySqlConnection conn = db.GetConnection())
            {
                try
                {
                    conn.Open();

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@ApplicantID",
                        ApplicantSession.ApplicantID);

                    MySqlDataReader dr = cmd.ExecuteReader();

                    if (dr.Read())
                    {
                        lblApplicant.Text =
                            "Applicant: " +
                            dr["ApplicantName"].ToString();

                        if (dr["ApplicationID"] != DBNull.Value)
                        {
                            lblApplicationID.Text =
                                "Application ID: " +
                                dr["ApplicationID"].ToString();

                            lblPosition.Text =
                                "Position: " +
                                dr["JobTitle"].ToString();

                            string status =
                                dr["CurrentStatus"].ToString();

                            lblStatus.Text = status;

                            UpdateProgress(status);

                            if (dr["SubmittedAt"] != DBNull.Value)
                            {
                                lblDateApplied.Text =
                                    "Date Applied: " +
                                    Convert.ToDateTime(dr["SubmittedAt"])
                                    .ToString("MMMM dd, yyyy");
                            }
                        }
                        else
                        {
                            lblApplicationID.Text =
                                "Application ID: N/A";

                            lblPosition.Text =
                                "Position: No Application Yet";

                            lblDateApplied.Text =
                                "Date Applied: N/A";

                            lblStatus.Text =
                                "No Application Yet";

                            progressBar1.Value = 0;
                            lblProgress.Text = "0%";
                        }
                    }

                    dr.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }




        private void LoadInterviewSchedule()
        {
            DbConnection db = new DbConnection();

            string query = @"
    SELECT
        ScheduledDate,
        ScheduledTime,
        Location
    FROM InterviewSchedules s
    INNER JOIN Applications a
        ON s.ApplicationID = a.ApplicationID
    WHERE a.ApplicantID = @ApplicantID
    ORDER BY ScheduledDate DESC
    LIMIT 1";

            using (MySqlConnection conn = db.GetConnection())
            {
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@ApplicantID", ApplicantSession.ApplicantID);

                    try
                    {
                        conn.Open();

                        using (MySqlDataReader dr = cmd.ExecuteReader())
                        {
                            if (dr.Read())
                            {
                                lblInterview.Text =
                                    "Date: " +
                                    Convert.ToDateTime(dr["ScheduledDate"]).ToString("MMMM dd, yyyy") +
                                    "\r\nTime: " +
                                    dr["ScheduledTime"].ToString() +
                                    "\r\nLocation: " +
                                    dr["Location"].ToString();
                            }
                            else
                            {
                                lblInterview.Text =
                                    "Date: N/A" +
                                    "\r\nTime: N/A" +
                                    "\r\nLocation: N/A";
                            }
                        }
                    }
                    catch
                    {
                        lblInterview.Text = "No Interview Scheduled";
                    }
                }

            }
        }

        private void UpdateProgress(string status)
        {
            switch (status.ToLower())
            {
                case "draft": progressBar1.Value = 5; lblProgress.Text = "5%"; break;
                case "submitted": progressBar1.Value = 20; lblProgress.Text = "20%"; break;
                case "under review": progressBar1.Value = 35; lblProgress.Text = "35%"; break;
                case "shortlisted": progressBar1.Value = 50; lblProgress.Text = "50%"; break;
                case "for interview": progressBar1.Value = 65; lblProgress.Text = "65%"; break;
                case "for assessment": progressBar1.Value = 75; lblProgress.Text = "75%"; break;
                case "for final review": progressBar1.Value = 85; lblProgress.Text = "85%"; break;
                case "accepted": progressBar1.Value = 100; lblProgress.Text = "100%"; break;
                case "rejected": progressBar1.Value = 100; lblProgress.Text = "Done"; break;
                default: progressBar1.Value = 0; lblProgress.Text = "0%"; break;
            }
        }
        private void LoadMissingDocuments()
        {
            DbConnection db = new DbConnection();

            string query = @"
    SELECT RequirementType
    FROM vw_MissingDocuments
    WHERE ApplicationID =
    (
        SELECT ApplicationID
        FROM Applications
        WHERE ApplicantID = @ApplicantID
        ORDER BY ApplicationID DESC
        LIMIT 1
    )";

            lstDocs.Items.Clear();

            using (MySqlConnection conn = db.GetConnection())
            {
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@ApplicantID", ApplicantSession.ApplicantID);

                    try
                    {
                        conn.Open();

                        using (MySqlDataReader dr = cmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                lstDocs.Items.Add(
                                    dr["RequirementType"].ToString());
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(
                            "Error loading documents: " + ex.Message);
                    }
                }
            }
        }


        private void LoadRecentUpdates()
        {
            lstUpdates.Items.Clear();

            DbConnection db = new DbConnection();

            string query = @"
    SELECT
        NewStatus,
        ChangedAt
    FROM ApplicationStatusHistory h
    INNER JOIN Applications a
        ON h.ApplicationID = a.ApplicationID
    WHERE a.ApplicantID = @ApplicantID
    ORDER BY ChangedAt DESC";

            using (MySqlConnection conn = db.GetConnection())
            {
                try
                {
                    conn.Open();

                    MySqlCommand cmd =
                        new MySqlCommand(query, conn);

                    cmd.Parameters.AddWithValue(
                        "@ApplicantID",
                        ApplicantSession.ApplicantID);

                    MySqlDataReader dr =
                        cmd.ExecuteReader();

                    bool hasData = false;

                    while (dr.Read())
                    {
                        hasData = true;

                        lstUpdates.Items.Add(
                            Convert.ToDateTime(dr["ChangedAt"])
                            .ToString("MMM dd yyyy") +
                            " - " +
                            dr["NewStatus"].ToString());
                    }

                    if (!hasData)
                    {
                        lstUpdates.Items.Add(
                            "No Updates Available");
                    }

                    dr.Close();
                }
                catch
                {
                    lstUpdates.Items.Add(
                        "No Updates Available");
                }
            }
        }



        private void btnLogout_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Are you sure you want to log out?",
                "Logout Confirmation",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    DbConnection db = new DbConnection();

                    using (MySqlConnection conn = db.GetConnection())
                    {
                        conn.Open();

                        string auditQuery = @"
                INSERT INTO AuditTrail
                (
                    ActorType,
                    ActorID,
                    Action,
                    Details
                )
                VALUES
                (
                    'Applicant',
                    @ActorID,
                    'LOGOUT',
                    @Details
                )";

                        using (MySqlCommand cmd =
                            new MySqlCommand(auditQuery, conn))
                        {
                            cmd.Parameters.AddWithValue(
                                "@ActorID",
                                ApplicantSession.ApplicantID);

                            cmd.Parameters.AddWithValue(
                                "@Details",
                                ApplicantSession.FullName + " logged out.");

                            cmd.ExecuteNonQuery();
                        }
                    }

                    ApplicantSession.Clear();

                    LoginForm login = new LoginForm();

                    login.Show();

                    this.Hide();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        "Logout Error: " + ex.Message,
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
        }

        private void btnProfile_Click(object sender, EventArgs e)
        {
            MyProfile frm = new MyProfile();
            frm.ShowDialog();
        }

        private void btnVacancies_Click(object sender, EventArgs e)
        {
            JobVacancies frm = new JobVacancies();
            frm.ShowDialog();
        }

        private void btnMyApplications_Click(object sender, EventArgs e)
        {
            MyApplicationForm frm = new MyApplicationForm();
            frm.ShowDialog();
        }

        private void btnDocuments_Click(object sender, EventArgs e)
        {
            MyDocumentForm frm = new MyDocumentForm();
            frm.ShowDialog();
        }

        private void btnChangePasword_Click(object sender, EventArgs e)
        {
            ChangePasswordForm frm = new ChangePasswordForm();
            frm.ShowDialog();
        }

        private void timerRefresh_Tick(object sender, EventArgs e)
        {
            LoadApplicantData();
            LoadInterviewSchedule();
            LoadMissingDocuments();
            LoadRecentUpdates();
        }

        private void btnApplicationStatus_Click(object sender, EventArgs e)
        {
            ApplicationStatusForm frm = new ApplicationStatusForm();
            frm.ShowDialog();
        }
    }
}