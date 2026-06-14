using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using HRApplicantSystem.Database;
using HRApplicantSystem.Models;

namespace HRApplicantSystem
{
    public partial class HiringDecisionForm : Form
    {
        DbConnection db = new DbConnection();

        private int selectedApplicationID = 0;

        public HiringDecisionForm()
        {
            InitializeComponent();

            Load += HiringDecisionForm_Load;

            dgvHiringDecision.CellClick += dgvHiringDecision_CellClick;

            btnApproveHiring.Click += btnApproveHiring_Click;
            btnRejectHiring.Click += btnRejectHiring_Click;
            btnSearch.Click += btnSearch_Click;
            btnBack.Click += btnBack_Click;
        }

        private void HiringDecisionForm_Load(object sender, EventArgs e)
        {
            ApplyRolePermissions();
            LoadApplications();
            LoadCounts();
        }

        private void ApplyRolePermissions()
        {
            bool canDecide =
                Session.RoleName == Roles.Admin ||
                Session.RoleName == Roles.HRManager;

            btnApproveHiring.Enabled = canDecide;
            btnRejectHiring.Enabled = canDecide;
        }

        private void LoadApplications()
        {
            try
            {
                using (MySqlConnection conn = db.GetConnection())
                {
                    conn.Open();

                    string query = @"
                    SELECT
                        a.ApplicationID,
                        CONCAT(ap.FirstName,' ',ap.LastName) ApplicantName,
                        jv.JobTitle,
                        a.CurrentStatus
                    FROM Applications a
                    INNER JOIN Applicants ap
                        ON a.ApplicantID = ap.ApplicantID
                    INNER JOIN JobVacancies jv
                        ON a.VacancyID = jv.VacancyID
                    ORDER BY a.ApplicationID DESC";

                    DataTable dt = new DataTable();

                    MySqlDataAdapter da =
                        new MySqlDataAdapter(query, conn);

                    da.Fill(dt);

                    dgvHiringDecision.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void LoadCounts()
        {
            try
            {
                using (MySqlConnection conn = db.GetConnection())
                {
                    conn.Open();

                    lblPendingDecisionsCount.Text =
                        ExecuteCount(conn,
                        @"SELECT COUNT(*)
                          FROM Applications
                          WHERE CurrentStatus='For Final Review'")
                        .ToString();

                    lblApprovedCount.Text =
                        ExecuteCount(conn,
                        @"SELECT COUNT(*)
                          FROM Applications
                          WHERE CurrentStatus='Accepted'")
                        .ToString();

                    lblRejectedCount.Text =
                        ExecuteCount(conn,
                        @"SELECT COUNT(*)
                          FROM Applications
                          WHERE CurrentStatus='Rejected'")
                        .ToString();
                }
            }
            catch
            {
            }
        }

        private int ExecuteCount(
            MySqlConnection conn,
            string query)
        {
            MySqlCommand cmd =
                new MySqlCommand(query, conn);

            return Convert.ToInt32(cmd.ExecuteScalar());
        }

        private void dgvHiringDecision_CellClick(
            object sender,
            DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            selectedApplicationID =
                Convert.ToInt32(
                dgvHiringDecision.Rows[e.RowIndex]
                .Cells["ApplicationID"].Value);
        }

        private void btnApproveHiring_Click(
            object sender,
            EventArgs e)
        {
            SaveDecision("Accepted");
        }

        private void btnRejectHiring_Click(
            object sender,
            EventArgs e)
        {
            SaveDecision("Rejected");
        }

        private void SaveDecision(string decision)
        {
            if (selectedApplicationID == 0)
            {
                MessageBox.Show("Select an applicant first.");
                return;
            }

            try
            {
                using (MySqlConnection conn =
                    db.GetConnection())
                {
                    conn.Open();

                    MySqlCommand cmd =
                        new MySqlCommand(
                        "sp_RecordHiringDecision",
                        conn);

                    cmd.CommandType =
                        CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue(
                        "p_ApplicationID",
                        selectedApplicationID);

                    cmd.Parameters.AddWithValue(
                        "p_DecidedByID",
                        Session.UserID);

                    cmd.Parameters.AddWithValue(
                        "p_Decision",
                        decision);

                    cmd.Parameters.AddWithValue(
                        "p_Remarks",
                        decision + " by " + Session.FullName);

                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show(
                    "Decision saved successfully.");

                LoadApplications();
                LoadCounts();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSearch_Click(
            object sender,
            EventArgs e)
        {
            try
            {
                using (MySqlConnection conn =
                    db.GetConnection())
                {
                    conn.Open();

                    string query = @"
                    SELECT
                        a.ApplicationID,
                        CONCAT(ap.FirstName,' ',ap.LastName)
                        AS ApplicantName,
                        jv.JobTitle,
                        a.CurrentStatus
                    FROM Applications a
                    INNER JOIN Applicants ap
                        ON a.ApplicantID = ap.ApplicantID
                    INNER JOIN JobVacancies jv
                        ON a.VacancyID = jv.VacancyID
                    WHERE CONCAT(ap.FirstName,' ',ap.LastName)
                    LIKE @search";

                    DataTable dt = new DataTable();

                    MySqlDataAdapter da =
                        new MySqlDataAdapter(query, conn);

                    da.SelectCommand.Parameters.AddWithValue(
                        "@search",
                        "%" + txtSearchHiring.Text + "%");

                    da.Fill(dt);

                    dgvHiringDecision.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnBack_Click(
            object sender,
            EventArgs e)
        {
            this.Close();
        }
    }
}