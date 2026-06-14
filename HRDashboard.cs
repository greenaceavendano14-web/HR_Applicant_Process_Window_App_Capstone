using ApplicantSystem;
using HRApplicantSystem.Database;
using HRApplicantSystem.Models;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace HRApplicantSystem
{
    public partial class HRDashboard : Form
    {
        private int userId;
        private string role = "";
        private string fullName = "";
        public HRDashboard()
        {
            InitializeComponent();
        }

        public HRDashboard(int userId, string role, string fullName)
        {
            InitializeComponent();

            this.userId = userId;
            this.role = role;
            this.fullName = fullName;

            lblGreeting.Text = "Welcome, " + fullName;
            lblRole.Text = "Role: " + role;
        }

        private void LoadDashboardStatistics()
        {
            try
            {
                lblApplicantsCount.Text =
                    ExecuteCount("SELECT COUNT(*) FROM Applicants").ToString();

                lblJobsCount.Text =
                    ExecuteCount("SELECT COUNT(*) FROM JobVacancies WHERE Status='Open'").ToString();

                lblPendingCount.Text =
                    ExecuteCount("SELECT COUNT(*) FROM Applications WHERE CurrentStatus='Under Review'").ToString();

                lblInterviewCount.Text =
                    ExecuteCount("SELECT COUNT(*) FROM Applications WHERE CurrentStatus='For Interview'").ToString();

                lblHiredCount.Text =
                    ExecuteCount("SELECT COUNT(*) FROM Applications WHERE CurrentStatus='Accepted'").ToString();

                lblRejectedCount.Text =
                    ExecuteCount("SELECT COUNT(*) FROM Applications WHERE CurrentStatus='Rejected'").ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void LoadRecentActivity()
        {
            try
            {
                rtbActivity.Clear();

                DbConnection db = new DbConnection();

                using (MySqlConnection conn = db.GetConnection())
                {
                    conn.Open();

                    string query = @"
            SELECT Details, CreatedAt
            FROM AuditTrail
            ORDER BY CreatedAt DESC
            LIMIT 15";

                    MySqlCommand cmd =
                        new MySqlCommand(query, conn);

                    MySqlDataReader dr =
                        cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        rtbActivity.AppendText(
                            "[" +
                            Convert.ToDateTime(
                                dr["CreatedAt"])
                                .ToString("MM/dd/yyyy hh:mm tt")
                            + "] "
                            + dr["Details"]
                            + Environment.NewLine
                            + Environment.NewLine);
                    }

                    if (rtbActivity.Text == "")
                    {
                        rtbActivity.Text = "No recent activity found.";
                    }
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void LoadRecentApplications()
        {
            try
            {
                DbConnection db = new DbConnection();

                using (MySqlConnection conn = db.GetConnection())
                {
                    conn.Open();

                    string query = "SELECT * FROM vw_ApplicationSummary";

                    MySqlDataAdapter da = new MySqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dgvRecentApplications.AutoGenerateColumns = true;
                    dgvRecentApplications.DataSource = dt;
                    dgvRecentApplications.AutoSizeColumnsMode =
                        DataGridViewAutoSizeColumnsMode.Fill;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Dashboard Error: " + ex.Message);
            }
        }


        private void HRDashboard_Load(object sender, EventArgs e)
        {
            lblDate.Text = DateTime.Now.ToString("MMMM dd, yyyy");
            lblTime.Text = DateTime.Now.ToString("hh:mm:ss tt");

            ApplyRolePermissions();

            LoadDashboardStatistics();
            LoadRecentApplications();
            LoadRecentActivity();

            timerClock.Start();

            dgvRecentApplications.ReadOnly = true;
            dgvRecentApplications.AllowUserToAddRows = false;
            dgvRecentApplications.AllowUserToDeleteRows = false;
            dgvRecentApplications.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;
        }



        private void timerClock_Tick(object sender, EventArgs e)
        {
            lblDate.Text = DateTime.Now.ToString("MMMM dd, yyyy");
            lblTime.Text = DateTime.Now.ToString("hh:mm:ss tt");
        }

        private int ExecuteCount(string query)
        {
            try
            {
                DbConnection db = new DbConnection();

                using (MySqlConnection conn = db.GetConnection())
                {
                    conn.Open();

                    MySqlCommand cmd = new MySqlCommand(query, conn);

                    object result = cmd.ExecuteScalar();

                    if (result != null)
                        return Convert.ToInt32(result);

                    return 0;
                }
            }
            catch
            {
                return 0;
            }
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            try
            {
                DbConnection db = new DbConnection();

                using (MySqlConnection conn = db.GetConnection())
                {
                    conn.Open();

                    MySqlCommand cmd = new MySqlCommand(
                        @"INSERT INTO AuditTrail
                (
                    ActorType,
                    ActorID,
                    Action,
                    Details
                )
                VALUES
                (
                    @ActorType,
                    @ActorID,
                    'LOGOUT',
                    @Details
                )",
                        conn);

                    cmd.Parameters.AddWithValue(
                        "@ActorType",
                        Session.RoleName);

                    cmd.Parameters.AddWithValue(
                        "@ActorID",
                        Session.UserID);

                    cmd.Parameters.AddWithValue(
                        "@Details",
                        Session.FullName + " logged out.");

                    cmd.ExecuteNonQuery();
                }
            }
            catch
            {

            }

            HRLoginForm login = new HRLoginForm();

            login.Show();

            this.Close();
        }

        private void ApplyRolePermissions()
        {
            btnUsers.Visible = false;
            btnReports.Visible = false;
            btnHiring.Visible = false;
            btnAuditTrail.Visible = false;

            btnJobs.Visible = false;
            btnApplications.Visible = false;
            btnApplicants.Visible = false;

            if (role == Roles.Admin)
            {
                btnUsers.Visible = true;
                btnReports.Visible = true;
                btnAuditTrail.Visible = true;
                btnJobs.Visible = true;
                btnApplications.Visible = true;
                btnApplicants.Visible = true;
                btnHiring.Visible = true;
            }
            else if (role == Roles.HRManager)
            {
                btnReports.Visible = true;
                btnAuditTrail.Visible = true;
                btnJobs.Visible = true;
                btnApplications.Visible = true;
                btnApplicants.Visible = true;
                btnHiring.Visible = true;
            }
            else if (role == Roles.HRStaff)
            {
                btnApplications.Visible = true;
                btnApplicants.Visible = true;
                btnJobs.Visible = true;
                btnAuditTrail.Visible = true;
            }
        }



        private void btnApplicants_Click(object sender, EventArgs e)
        {
            ApplicantListForm frm = new ApplicantListForm();
            frm.ShowDialog();
        }

        private void btnApplications_Click(object sender, EventArgs e)
        {
            ApplicantReviewForm frm = new ApplicantReviewForm();
            frm.ShowDialog();

        }

        private void btnJobs_Click(object sender, EventArgs e)
        {
            JobVacancyForm frm = new JobVacancyForm();
            frm.ShowDialog();
        }

        private void btnHiring_Click(object sender, EventArgs e)
        {
            HiringDecisionForm frm = new HiringDecisionForm();
            frm.ShowDialog();
        }

        private void btnReports_Click(object sender, EventArgs e)
        {
            ReportsForm frm = new ReportsForm();
            frm.ShowDialog();
        }

        private void btnUsers_Click(object sender, EventArgs e)
        {
            UserManagementForm frm = new UserManagementForm();
            frm.ShowDialog();
        }

        private void btnAuditTrail_Click(object sender, EventArgs e)
        {
            AuditTrailForm frm = new AuditTrailForm();
            frm.ShowDialog();
        }
    }

}
