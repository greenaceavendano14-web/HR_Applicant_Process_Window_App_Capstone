using HRApplicantSystem.Database;
using HRApplicantSystem.Models;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;
using ApplicantSystem;

namespace HRApplicantSystem
{
    public partial class JobVacancies : Form
    {
        DbConnection db = new DbConnection();

        private int selectedVacancyID = 0;

        public JobVacancies()
        {
            InitializeComponent();

            Load += JobVacancies_Load;

            dgvJobs.CellClick += dgvJobs_CellClick;

            btnSearch.Click += btnSearch_Click;
            btnRefresh.Click += btnRefresh_Click;
            btnApply.Click += btnApply_Click;
            btnExit.Click += btnExit_Click;
        }

        private void JobVacancies_Load(object sender, EventArgs e)
        {
            LoadVacancies();
        }

        private void LoadVacancies()
        {
            string query = @"
            SELECT
                VacancyID,
                JobTitle,
                DepartmentName,
                TypeName,
                Status
            FROM JobVacancies jv
            INNER JOIN Departments d
                ON jv.DepartmentID = d.DepartmentID
            INNER JOIN EmploymentTypes et
                ON jv.EmploymentTypeID = et.EmploymentTypeID
            WHERE Status='Open'
            AND SlotsAvailable > 0";

            using (MySqlConnection conn = db.GetConnection())
            {
                try
                {
                    conn.Open();

                    MySqlDataAdapter da =
                        new MySqlDataAdapter(query, conn);

                    DataTable dt = new DataTable();

                    da.Fill(dt);

                    dgvJobs.DataSource = dt;

                    lblJobCount.Text =
                        "Total Jobs: " + dt.Rows.Count;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void dgvJobs_CellClick(object sender,
            DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            selectedVacancyID =
                Convert.ToInt32(
                    dgvJobs.Rows[e.RowIndex]
                    .Cells["VacancyID"].Value);

            LoadVacancyDetails(selectedVacancyID);
        }

        private void LoadVacancyDetails(int vacancyID)
        {
            string query = @"
            SELECT
                jv.JobTitle,
                d.DepartmentName,
                et.TypeName,
                jv.Qualifications
            FROM JobVacancies jv
            INNER JOIN Departments d
                ON jv.DepartmentID=d.DepartmentID
            INNER JOIN EmploymentTypes et
                ON jv.EmploymentTypeID=et.EmploymentTypeID
            WHERE VacancyID=@VacancyID";

            using (MySqlConnection conn = db.GetConnection())
            {
                conn.Open();

                MySqlCommand cmd =
                    new MySqlCommand(query, conn);

                cmd.Parameters.AddWithValue(
                    "@VacancyID",
                    vacancyID);

                MySqlDataReader dr =
                    cmd.ExecuteReader();

                if (dr.Read())
                {
                    lblPosition.Text =
                        "Position: " +
                        dr["JobTitle"].ToString();

                    lblDepartment.Text =
                        "Department: " +
                        dr["DepartmentName"].ToString();

                    lblType.Text =
                        "Employment Type: " +
                        dr["TypeName"].ToString();

                    lblQualifications.Text =
                        "Qualifications: " +
                        dr["Qualifications"].ToString();
                }

                dr.Close();
            }

            LoadRequirements(vacancyID);
        }

        private void LoadRequirements(int vacancyID)
        {
            string query = @"
            SELECT rt.TypeName
            FROM VacancyRequirements vr
            INNER JOIN RequirementTypes rt
                ON vr.RequirementTypeID =
                   rt.RequirementTypeID
            WHERE VacancyID=@VacancyID";

            using (MySqlConnection conn =
                db.GetConnection())
            {
                conn.Open();

                MySqlCommand cmd =
                    new MySqlCommand(query, conn);

                cmd.Parameters.AddWithValue(
                    "@VacancyID",
                    vacancyID);

                MySqlDataReader dr =
                    cmd.ExecuteReader();

                string docs = "";

                while (dr.Read())
                {
                    docs +=
                        dr["TypeName"].ToString() +
                        ", ";
                }

                if (docs.Length > 2)
                    docs = docs.Substring(0,
                        docs.Length - 2);

                lblDocuments.Text =
                    "Required Documents: " +
                    docs;
            }
        }

        private void btnApply_Click(object sender,
            EventArgs e)
        {
            if (selectedVacancyID == 0)
            {
                MessageBox.Show(
                    "Select a vacancy first.");
                return;
            }

            using (MySqlConnection conn =
                db.GetConnection())
            {
                try
                {
                    conn.Open();

                    string checkQuery = @"
                    SELECT COUNT(*)
                    FROM Applications
                    WHERE ApplicantID=@ApplicantID
                    AND VacancyID=@VacancyID";

                    MySqlCommand checkCmd =
                        new MySqlCommand(
                            checkQuery,
                            conn);

                    checkCmd.Parameters.AddWithValue(
                        "@ApplicantID",
                        ApplicantSession.ApplicantID);

                    checkCmd.Parameters.AddWithValue(
                        "@VacancyID",
                        selectedVacancyID);

                    int exists =
                        Convert.ToInt32(
                            checkCmd.ExecuteScalar());

                    if (exists > 0)
                    {
                        MessageBox.Show(
                            "You already applied.");
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
                        new MySqlCommand(
                            insertQuery,
                            conn);

                    insertCmd.Parameters.AddWithValue(
                        "@ApplicantID",
                        ApplicantSession.ApplicantID);

                    insertCmd.Parameters.AddWithValue(
                        "@VacancyID",
                        selectedVacancyID);

                    insertCmd.ExecuteNonQuery();

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
                        @ApplicantID,
                        'APPLICATION_SUBMIT',
                        'Applications',
                        LAST_INSERT_ID(),
                        'Application submitted.'
                    )";

                    MySqlCommand auditCmd =
                        new MySqlCommand(
                            auditQuery,
                            conn);

                    auditCmd.Parameters.AddWithValue(
                        "@ApplicantID",
                        ApplicantSession.ApplicantID);

                    auditCmd.ExecuteNonQuery();

                    MessageBox.Show(
                        "Application submitted successfully.");

                    LoadVacancies();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void btnSearch_Click(object sender,
            EventArgs e)
        {
            string keyword =
                txtSearch.Text.Trim();

            string query = @"
            SELECT
                VacancyID,
                JobTitle,
                DepartmentName,
                TypeName,
                Status
            FROM JobVacancies jv
            INNER JOIN Departments d
                ON jv.DepartmentID=d.DepartmentID
            INNER JOIN EmploymentTypes et
                ON jv.EmploymentTypeID=
                   et.EmploymentTypeID
            WHERE JobTitle LIKE @Search";

            using (MySqlConnection conn =
                db.GetConnection())
            {
                conn.Open();

                MySqlCommand cmd =
                    new MySqlCommand(query, conn);

                cmd.Parameters.AddWithValue(
                    "@Search",
                    "%" + keyword + "%");

                MySqlDataAdapter da =
                    new MySqlDataAdapter(cmd);

                DataTable dt =
                    new DataTable();

                da.Fill(dt);

                dgvJobs.DataSource = dt;
            }
        }

        private void btnRefresh_Click(object sender,
            EventArgs e)
        {
            txtSearch.Clear();

            LoadVacancies();
        }

        private void btnExit_Click(object sender,
            EventArgs e)
        {
            this.Close();
        }
    }
}