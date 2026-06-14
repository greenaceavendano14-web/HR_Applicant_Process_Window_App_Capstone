using ApplicantSystem;
using HRApplicantSystem.Database;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace HRApplicantSystem
{
    public partial class ApplicationStatusForm : Form
    {
        private int currentApplicantID;

        public ApplicationStatusForm()
        {
            InitializeComponent();

            currentApplicantID = ApplicantSession.ApplicantID;

            btnRefresh.Click += btnRefresh_Click;
            this.Load += ApplicationStatusForm_Load;
        }

        private void ApplicationStatusForm_Load(object sender, EventArgs e)
        {
            LoadApplicationStatus();
        }

        private void LoadApplicationStatus()
        {
            try
            {
                DbConnection db = new DbConnection();

                using (MySqlConnection conn = db.GetConnection())
                {
                    conn.Open();

                    string applicationQuery = @"
                    SELECT
                        A.ApplicationID,
                        J.JobTitle,
                        A.CurrentStatus
                    FROM Applications A
                    INNER JOIN JobVacancies J
                        ON A.VacancyID = J.VacancyID
                    WHERE A.ApplicantID = @ApplicantID
                    ORDER BY A.ApplicationID DESC
                    LIMIT 1";

                    MySqlCommand cmd =
                        new MySqlCommand(applicationQuery, conn);

                    cmd.Parameters.AddWithValue(
                        "@ApplicantID",
                        currentApplicantID);

                    int applicationID = 0;

                    using (MySqlDataReader reader =
                        cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            applicationID =
                                Convert.ToInt32(
                                    reader["ApplicationID"]);

                            lblJobTitle.Text =
                                "Applying For: " +
                                reader["JobTitle"].ToString();

                            lblCurrentStatus.Text =
                                reader["CurrentStatus"].ToString();
                        }
                        else
                        {
                            lblJobTitle.Text =
                                "Applying For: No Application Found";

                            lblCurrentStatus.Text =
                                "No Status Available";

                            dgvTimeline.DataSource = null;

                            txtRemarks.Text =
                                "No application records found.";

                            return;
                        }
                    }

                    string timelineQuery = @"
                    SELECT
                        NewStatus AS 'Status',
                        Remarks AS 'Remarks',
                        ChangedAt AS 'Date'
                    FROM ApplicationStatusHistory
                    WHERE ApplicationID = @ApplicationID
                    ORDER BY ChangedAt DESC";

                    MySqlCommand timelineCmd =
                        new MySqlCommand(
                            timelineQuery,
                            conn);

                    timelineCmd.Parameters.AddWithValue(
                        "@ApplicationID",
                        applicationID);

                    MySqlDataAdapter da =
                        new MySqlDataAdapter(timelineCmd);

                    DataTable dt =
                        new DataTable();

                    da.Fill(dt);

                    dgvTimeline.DataSource = dt;

                    dgvTimeline.AutoSizeColumnsMode =
                        DataGridViewAutoSizeColumnsMode.Fill;

                    dgvTimeline.ReadOnly = true;

                    dgvTimeline.AllowUserToAddRows = false;

                    dgvTimeline.AllowUserToDeleteRows = false;

                    dgvTimeline.SelectionMode =
                        DataGridViewSelectionMode.FullRowSelect;

                    if (dt.Rows.Count > 0)
                    {
                        txtRemarks.Text =
                            dt.Rows[0]["Remarks"]
                            .ToString();
                    }
                    else
                    {
                        txtRemarks.Text =
                            "No status history available.";
                    }

                    LogStatusView();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Database Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void LogStatusView()
        {
            try
            {
                DbConnection db = new DbConnection();

                using (MySqlConnection conn = db.GetConnection())
                {
                    conn.Open();

                    string query = @"
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
                        'VIEW_STATUS',
                        @Details
                    )";

                    MySqlCommand cmd =
                        new MySqlCommand(query, conn);

                    cmd.Parameters.AddWithValue(
                        "@ActorID",
                        ApplicantSession.ApplicantID);

                    cmd.Parameters.AddWithValue(
                        "@Details",
                        "Applicant viewed application status.");

                    cmd.ExecuteNonQuery();
                }
            }
            catch
            {
            }
        }

        private void btnRefresh_Click(
            object sender,
            EventArgs e)
        {
            LoadApplicationStatus();

            MessageBox.Show(
                "Application status refreshed successfully.",
                "Refresh",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        private void pnlMainContent_Paint(
            object sender,
            PaintEventArgs e)
        {

        }
    }
}