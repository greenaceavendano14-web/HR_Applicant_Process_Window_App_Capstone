using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using HRApplicantSystem.Database;
using HRApplicantSystem.Models;

namespace HRApplicantSystem
{
    public partial class ApplicationsForm : Form
    {
        public ApplicationsForm()
        {
            InitializeComponent();

            Load += ApplicationsForm_Load;
        }

        private void ApplicationsForm_Load(object sender, EventArgs e)
        {
            LoadApplications();
            ApplyRolePermissions();
        }

        private void LoadApplications()
        {
            try
            {
                DbConnection db = new DbConnection();

                using (MySqlConnection conn = db.GetConnection())
                {
                    conn.Open();

                    string query = @"
                    SELECT
                        a.ApplicationID,
                        CONCAT(ap.FirstName,' ',ap.LastName) AS ApplicantName,
                        jv.JobTitle,
                        DATE(a.SubmittedAt) AS DateApplied,
                        a.CurrentStatus
                    FROM Applications a
                    INNER JOIN Applicants ap
                        ON a.ApplicantID = ap.ApplicantID
                    INNER JOIN JobVacancies jv
                        ON a.VacancyID = jv.VacancyID";

                    MySqlDataAdapter adapter =
                        new MySqlDataAdapter(query, conn);

                    DataTable table = new DataTable();

                    adapter.Fill(table);

                    dgvApplicantions.Rows.Clear();

                    foreach (DataRow row in table.Rows)
                    {
                        dgvApplicantions.Rows.Add(
                            row["ApplicationID"],
                            row["ApplicantName"],
                            row["JobTitle"],
                            row["DateApplied"],
                            row["CurrentStatus"]);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void ApplyRolePermissions()
        {
            if (Session.RoleName == "HR Staff")
            {
                btnReview.Enabled = true;
                btnInterview.Enabled = true;

                btnApprove.Enabled = false;
                btnReject.Enabled = false;
            }
            else if (Session.RoleName == "HR Manager")
            {
                btnReview.Enabled = true;
                btnInterview.Enabled = true;

                btnApprove.Enabled = true;
                btnReject.Enabled = true;
            }
            else if (Session.RoleName == "Admin")
            {
                btnReview.Enabled = true;
                btnInterview.Enabled = true;

                btnApprove.Enabled = true;
                btnReject.Enabled = true;
            }
        }
        private int GetSelectedApplicationID()
        {
            if (dgvApplicantions.SelectedRows.Count == 0)
            {
                MessageBox.Show(
                    "Please select an application first.",
                    "Warning",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return -1;
            }

            return Convert.ToInt32(
                dgvApplicantions.SelectedRows[0]
                .Cells[0].Value);
        }

        private void ChangeStatus(string newStatus)
        {
            try
            {
                int applicationId = GetSelectedApplicationID();

                if (applicationId == -1)
                    return;

                string currentStatus =
                    dgvApplicantions.SelectedRows[0]
                    .Cells[4].Value.ToString();

                // FINALIZED APPLICATIONS
                if (currentStatus == "Accepted" ||
                    currentStatus == "Rejected")
                {
                    MessageBox.Show(
                        "This application is already finalized and cannot be modified.",
                        "Status Locked",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return;
                }

                // LOCK AFTER REVIEW RULE
                if (currentStatus == "Under Review" &&
                    newStatus == "Under Review")
                {
                    MessageBox.Show(
                        "Application is already under review.",
                        "Status Locked",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return;
                }

                DbConnection db = new DbConnection();

                using (MySqlConnection conn = db.GetConnection())
                {
                    conn.Open();

                    MySqlCommand cmd =
                        new MySqlCommand(
                            "sp_ChangeApplicationStatus",
                            conn);

                    cmd.CommandType =
                        CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue(
                        "p_ApplicationID",
                        applicationId);

                    cmd.Parameters.AddWithValue(
                        "p_NewStatus",
                        newStatus);

                    cmd.Parameters.AddWithValue(
                        "p_ChangedByType",
                        Session.RoleName);

                    cmd.Parameters.AddWithValue(
                        "p_ChangedByID",
                        Session.UserID);

                    cmd.Parameters.AddWithValue(
                        "p_Remarks",
                        "Status updated by " +
                        Session.FullName);

                    cmd.ExecuteNonQuery();

                    MessageBox.Show(
                        "Application status updated successfully.",
                        "Success",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    LoadApplications();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void RecordHiringDecision(string decision)
        {
            try
            {
                int applicationId =
                    GetSelectedApplicationID();

                if (applicationId == -1)
                    return;

                DbConnection db = new DbConnection();

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
                        applicationId);

                    cmd.Parameters.AddWithValue(
                        "p_DecidedByID",
                        Session.UserID);

                    cmd.Parameters.AddWithValue(
                        "p_Decision",
                        decision);

                    cmd.Parameters.AddWithValue(
                        "p_Remarks",
                        "Final hiring decision");

                    cmd.ExecuteNonQuery();

                    MessageBox.Show(
                        "Hiring decision recorded successfully.");

                    LoadApplications();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnReview_Click(object sender, EventArgs e)
        {
            ChangeStatus("Under Review");
        }

        private void btnInterview_Click(object sender, EventArgs e)
        {
            ChangeStatus("For Interview");
        }

        private void btnApprove_Click(object sender, EventArgs e)
        {
            if (Session.RoleName == "HR Staff")
            {
                MessageBox.Show(
                    "Only HR Manager or Admin can accept applications.");

                return;
            }
            RecordHiringDecision("Accepted");
        }

        private void btnReject_Click(object sender, EventArgs e)
        {
            if (Session.RoleName == "HR Staff")
            {
                MessageBox.Show(
                    "Only HR Manager or Admin can reject applications.");

                return;
            }
            RecordHiringDecision("Rejected");
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                DbConnection db = new DbConnection();

                using (MySqlConnection conn = db.GetConnection())
                {
                    conn.Open();

                    string query = @"
                    SELECT
                        a.ApplicationID,
                        CONCAT(ap.FirstName,' ',ap.LastName) AS ApplicantName,
                        jv.JobTitle,
                        DATE(a.SubmittedAt) AS DateApplied,
                        a.CurrentStatus
                    FROM Applications a
                    INNER JOIN Applicants ap
                        ON a.ApplicantID = ap.ApplicantID
                    INNER JOIN JobVacancies jv
                        ON a.VacancyID = jv.VacancyID
                    WHERE CONCAT(ap.FirstName,' ',ap.LastName)
                    LIKE @search";

                    MySqlCommand cmd =
                        new MySqlCommand(query, conn);

                    cmd.Parameters.AddWithValue(
                        "@search",
                        "%" +
                        txtSearchApplication.Text.Trim()
                        + "%");

                    MySqlDataAdapter adapter =
                        new MySqlDataAdapter(cmd);

                    DataTable table = new DataTable();

                    adapter.Fill(table);

                    dgvApplicantions.Rows.Clear();

                    foreach (DataRow row in table.Rows)
                    {
                        dgvApplicantions.Rows.Add(
                            row["ApplicationID"],
                            row["ApplicantName"],
                            row["JobTitle"],
                            row["DateApplied"],
                            row["CurrentStatus"]);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnViewApplication_Click(object sender, EventArgs e)
        {
            try
            {
                int applicationId = GetSelectedApplicationID();

                if (applicationId == -1)
                    return;

                DbConnection db = new DbConnection();

                using (MySqlConnection conn = db.GetConnection())
                {
                    conn.Open();

                    string query = @"
        SELECT
            CONCAT(ap.FirstName,' ',ap.LastName) AS ApplicantName,
            ap.Phone,
            ap.City,
            ap.Province,
            ap.HighestDegree,
            ap.SchoolName,
            ap.FieldOfStudy,
            ap.Skills,
            ap.WorkExperience,
            a.CurrentStatus
        FROM Applications a
        INNER JOIN Applicants ap
            ON a.ApplicantID = ap.ApplicantID
        WHERE a.ApplicationID = @ApplicationID";

                    MySqlCommand cmd =
                        new MySqlCommand(query, conn);

                    cmd.Parameters.AddWithValue(
                        "@ApplicationID",
                        applicationId);

                    MySqlDataReader reader =
                        cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        string details =
                            "Applicant Name: " +
                            reader["ApplicantName"] +

                            "\n\nPhone: " +
                            reader["Phone"] +

                            "\n\nCity: " +
                            reader["City"] +

                            "\n\nProvince: " +
                            reader["Province"] +

                            "\n\nHighest Degree: " +
                            reader["HighestDegree"] +

                            "\n\nSchool Name: " +
                            reader["SchoolName"] +

                            "\n\nField Of Study: " +
                            reader["FieldOfStudy"] +

                            "\n\nSkills: " +
                            reader["Skills"] +

                            "\n\nWork Experience: " +
                            reader["WorkExperience"] +

                            "\n\nStatus: " +
                            reader["CurrentStatus"];

                        MessageBox.Show(
                            details,
                            "Application Details",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnViewHistory_Click(object sender, EventArgs e)
        {
            try
            {
                int applicationId =
                    GetSelectedApplicationID();

                if (applicationId == -1)
                    return;

                DbConnection db = new DbConnection();

                using (MySqlConnection conn =
                    db.GetConnection())
                {
                    conn.Open();

                    string query = @"
            SELECT
                OldStatus,
                NewStatus,
                ChangedByType,
                Remarks,
                ChangedAt
            FROM ApplicationStatusHistory
            WHERE ApplicationID = @ApplicationID
            ORDER BY ChangedAt";

                    MySqlCommand cmd =
                        new MySqlCommand(query, conn);

                    cmd.Parameters.AddWithValue(
                        "@ApplicationID",
                        applicationId);

                    MySqlDataReader reader =
                        cmd.ExecuteReader();

                    string history = "";

                    while (reader.Read())
                    {
                        history +=
                            "Old Status: "
                            + reader["OldStatus"]
                            + "\nNew Status: "
                            + reader["NewStatus"]
                            + "\nChanged By: "
                            + reader["ChangedByType"]
                            + "\nRemarks: "
                            + reader["Remarks"]
                            + "\nDate: "
                            + reader["ChangedAt"]
                            + "\n\n";
                    }

                    if (history == "")
                    {
                        history = "No history found.";
                    }

                    MessageBox.Show(
                        history,
                        "Application History",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnDocuments_Click(object sender, EventArgs e)
        {
            try
            {
                int applicationId =
                    GetSelectedApplicationID();

                if (applicationId == -1)
                    return;

                DbConnection db = new DbConnection();

                using (MySqlConnection conn =
                    db.GetConnection())
                {
                    conn.Open();

                    string query = @"
            SELECT
                rt.TypeName,
                ad.SubmissionStatus
            FROM ApplicantDocuments ad
            INNER JOIN RequirementTypes rt
                ON ad.RequirementTypeID =
                   rt.RequirementTypeID
            WHERE ad.ApplicationID =
                  @ApplicationID";

                    MySqlCommand cmd =
                        new MySqlCommand(query, conn);

                    cmd.Parameters.AddWithValue(
                        "@ApplicationID",
                        applicationId);

                    MySqlDataReader reader =
                        cmd.ExecuteReader();

                    string documents = "";

                    while (reader.Read())
                    {
                        documents +=
                            reader["TypeName"].ToString()
                            + " - "
                            + reader["SubmissionStatus"].ToString()
                            + "\n";
                    }

                    if (documents == "")
                    {
                        documents =
                            "No documents found.";
                    }

                    MessageBox.Show(
                        documents,
                        "Applicant Documents",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}