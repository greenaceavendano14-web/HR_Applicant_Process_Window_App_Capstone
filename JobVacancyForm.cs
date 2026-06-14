using HRApplicantSystem.Database;
using HRApplicantSystem.Models;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;
using System.IO;

namespace ApplicantSystem
{
    public partial class JobVacancyForm : Form
    {
        DbConnection db = new DbConnection();
        int selectedVacancyID = 0;

        public JobVacancyForm()
        {
            InitializeComponent();

            this.Load += JobVacancyForm_Load;
            dataGridView1.CellClick += dataGridView1_CellClick;
        }

        private void JobVacancyForm_Load(object? sender, EventArgs e)
        {
            LoadDepartments();
            LoadEmploymentTypes();
            LoadJobs();

            cmbStatus.Items.Clear();
            cmbStatus.Items.Add("Open");
            cmbStatus.Items.Add("Closed");
            cmbStatus.Items.Add("On Hold");
            cmbStatus.SelectedIndex = 0;
        }

        private void LoadJobs()
        {
            try
            {
                using (MySqlConnection conn = db.GetConnection())
                {
                    conn.Open();

                    string query = @"
SELECT
j.VacancyID,
d.DepartmentName,
e.TypeName,
j.JobTitle,
j.JobDescription,
j.Qualifications,
j.SlotsAvailable,
j.PostedDate,
j.Status
FROM JobVacancies j
INNER JOIN Departments d
ON j.DepartmentID = d.DepartmentID
INNER JOIN EmploymentTypes e
ON j.EmploymentTypeID = e.EmploymentTypeID";

                    MySqlDataAdapter da =
                        new MySqlDataAdapter(query, conn);

                    DataTable dt = new DataTable();

                    da.Fill(dt);

                    dataGridView1.DataSource = dt;
                }

                selectedVacancyID = 0;
                dataGridView1.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("LOAD ERROR: " + ex.Message);
            }
        }

        private void ADD_Click(object sender, EventArgs e)
        {
            try
            {
                using (MySqlConnection conn = db.GetConnection())
                {
                    conn.Open();

                    string query = @"
INSERT INTO JobVacancies
(
DepartmentID,
EmploymentTypeID,
JobTitle,
JobDescription,
Qualifications,
SlotsAvailable,
PostedDate,
Status,
CreatedByUserID
)
VALUES
(
@dept,
@emp,
@title,
@desc,
@qual,
1,
CURDATE(),
@status,
@userId
)";

                    MySqlCommand cmd = new MySqlCommand(query, conn);

                    cmd.Parameters.AddWithValue("@dept", cmbDepartment.SelectedValue);
                    cmd.Parameters.AddWithValue("@emp", cmbEmploymentType.SelectedValue);
                    cmd.Parameters.AddWithValue("@title", txtJobTitle.Text);
                    cmd.Parameters.AddWithValue("@desc", txtDescription.Text);
                    cmd.Parameters.AddWithValue("@qual", txtRequirements.Text);
                    cmd.Parameters.AddWithValue("@status", cmbStatus.Text);
                    cmd.Parameters.AddWithValue("@userId", Session.UserID);

                    cmd.ExecuteNonQuery();


                    MySqlCommand audit = new MySqlCommand(@"
                INSERT INTO AuditTrail
                (ActorType, ActorID, Action, TargetTable, Details)
                VALUES
                (@type, @id, 'CREATE_JOB', 'JobVacancies', @details)", conn);

                    audit.Parameters.AddWithValue("@type", Session.RoleName);
                    audit.Parameters.AddWithValue("@id", Session.UserID);
                    audit.Parameters.AddWithValue("@details", "Created job: " + txtJobTitle.Text);

                    audit.ExecuteNonQuery();
                }

                MessageBox.Show("Job Added Successfully!");
                LoadJobs();
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ADD ERROR: " + ex.Message);
            }
        }

        private void LoadDepartments()
        {
            try
            {
                using (MySqlConnection conn = db.GetConnection())
                {
                    conn.Open();

                    string query =
                        "SELECT DepartmentID, DepartmentName FROM Departments ORDER BY DepartmentName";

                    MySqlDataAdapter da = new MySqlDataAdapter(query, conn);

                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    cmbDepartment.DataSource = dt;
                    cmbDepartment.DisplayMember = "DepartmentName";
                    cmbDepartment.ValueMember = "DepartmentID";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Department Load Error: " + ex.Message);
            }
        }

        private void LoadEmploymentTypes()
        {
            try
            {
                using (MySqlConnection conn = db.GetConnection())
                {
                    conn.Open();

                    string query =
                        "SELECT EmploymentTypeID, TypeName FROM EmploymentTypes ORDER BY TypeName";

                    MySqlDataAdapter da = new MySqlDataAdapter(query, conn);

                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    cmbEmploymentType.DataSource = dt;
                    cmbEmploymentType.DisplayMember = "TypeName";
                    cmbEmploymentType.ValueMember = "EmploymentTypeID";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Employment Type Load Error: " + ex.Message);
            }
        }


        private void dataGridView1_CellClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

            selectedVacancyID = Convert.ToInt32(row.Cells["VacancyID"].Value);
            txtJobTitle.Text = row.Cells["JobTitle"].Value?.ToString();
            txtDescription.Text = row.Cells["JobDescription"].Value?.ToString();
            txtRequirements.Text = row.Cells["Qualifications"].Value?.ToString();
            cmbStatus.Text = row.Cells["Status"].Value?.ToString();
        }

        private void UPDATE_Click(object sender, EventArgs e)
        {
            if (!AccessControl.RequireRole(new string[]
            {
        RoleManager.Admin,
        RoleManager.HRManager
            }))
                return;

            if (selectedVacancyID == 0)
            {
                MessageBox.Show("Select a job first!");
                return;
            }

            try
            {
                using (MySqlConnection conn = db.GetConnection())
                {
                    conn.Open();

                    string query = @"
UPDATE JobVacancies
SET
DepartmentID=@dept,
EmploymentTypeID=@emp,
JobTitle=@title,
JobDescription=@desc,
Qualifications=@qual,
Status=@status
WHERE VacancyID=@id";

                    MySqlCommand cmd = new MySqlCommand(query, conn);

                    cmd.Parameters.AddWithValue("@id", selectedVacancyID);
                    cmd.Parameters.AddWithValue("@dept", cmbDepartment.SelectedValue);
                    cmd.Parameters.AddWithValue("@emp", cmbEmploymentType.SelectedValue);
                    cmd.Parameters.AddWithValue("@title", txtJobTitle.Text);
                    cmd.Parameters.AddWithValue("@desc", txtDescription.Text);
                    cmd.Parameters.AddWithValue("@qual", txtRequirements.Text);
                    cmd.Parameters.AddWithValue("@status", cmbStatus.Text);

                    cmd.ExecuteNonQuery();

                    // AUDIT
                    MySqlCommand audit = new MySqlCommand(@"
                INSERT INTO AuditTrail
                (ActorType, ActorID, Action, TargetTable, TargetID, Details)
                VALUES
                (@type, @id, 'UPDATE_JOB', 'JobVacancies', @jobId, @details)", conn);

                    audit.Parameters.AddWithValue("@type", Session.RoleName);
                    audit.Parameters.AddWithValue("@id", Session.UserID);
                    audit.Parameters.AddWithValue("@jobId", selectedVacancyID);
                    audit.Parameters.AddWithValue("@details", "Updated job: " + txtJobTitle.Text);

                    audit.ExecuteNonQuery();
                }

                MessageBox.Show("Updated Successfully!");
                LoadJobs();
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show("UPDATE ERROR: " + ex.Message);
            }
        }

        private void DELETE_Click(object sender, EventArgs e)
        {
            if (!AccessControl.RequireRole(new string[]
            {
        RoleManager.Admin
            }))
                return;

            if (selectedVacancyID == 0)
            {
                MessageBox.Show("Select a job first!");
                return;
            }

            try
            {
                using (MySqlConnection conn = db.GetConnection())
                {
                    conn.Open();

                    string query =
                        "DELETE FROM JobVacancies WHERE VacancyID=@id";

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@id", selectedVacancyID);
                    cmd.ExecuteNonQuery();

                    // AUDIT
                    MySqlCommand audit = new MySqlCommand(@"
                INSERT INTO AuditTrail
                (ActorType, ActorID, Action, TargetTable, TargetID, Details)
                VALUES
                (@type, @id, 'DELETE_JOB', 'JobVacancies', @jobId, @details)", conn);

                    audit.Parameters.AddWithValue("@type", Session.RoleName);
                    audit.Parameters.AddWithValue("@id", Session.UserID);
                    audit.Parameters.AddWithValue("@jobId", selectedVacancyID);
                    audit.Parameters.AddWithValue("@details", "Deleted job ID: " + selectedVacancyID);

                    audit.ExecuteNonQuery();
                }

                MessageBox.Show("Deleted Successfully!");
                LoadJobs();
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show("DELETE ERROR: " + ex.Message);
            }
        }

        private void ClearFields()
        {
            txtJobTitle.Clear();
            txtDescription.Clear();
            txtRequirements.Clear();

            if (cmbDepartment.Items.Count > 0)
                cmbDepartment.SelectedIndex = 0;

            if (cmbEmploymentType.Items.Count > 0)
                cmbEmploymentType.SelectedIndex = 0;

            cmbStatus.SelectedIndex = 0;

            selectedVacancyID = 0;
        }

        private void CLEAR_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

    }
}
