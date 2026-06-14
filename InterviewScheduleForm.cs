using HRApplicantSystem.Database;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace HRApplicantSystem
{
    public partial class InterviewScheduleForm : Form
    {
        DbConnection db = new DbConnection();

        private int selectedScheduleID = 0;
        private int selectedApplicationID = 0;

        public InterviewScheduleForm()
        {
            InitializeComponent();

            dgvSchedule.CellClick += dgvSchedule_CellClick;

            btnSave.Click += btnSave_Click;
            btnUpdate.Click += btnUpdate_Click;
            btnDelete.Click += btnDelete_Click;
            btnRefresh.Click += btnRefresh_Click;
            btnClear.Click += btnClear_Click;
        }

        private void InterviewScheduleForm_Load(object sender, EventArgs e)
        {
            LoadSchedules();

            cmbStatus.Items.Clear();
            cmbStatus.Items.Add("Scheduled");
            cmbStatus.Items.Add("Completed");
            cmbStatus.Items.Add("Cancelled");
            cmbStatus.Items.Add("Rescheduled");

            this.WindowState = FormWindowState.Maximized;
        }

        private void LoadSchedules()
        {
            try
            {
                using (MySqlConnection conn = db.GetConnection())
                {
                    conn.Open();

                    string query = @"
                    SELECT
                        s.ScheduleID,
                        s.ApplicationID,
                        CONCAT(a.FirstName,' ',a.LastName) AS ApplicantName,
                        j.JobTitle,
                        s.ScheduledDate,
                        s.ScheduledTime,
                        CONCAT(u.FirstName,' ',u.LastName) AS Interviewer,
                        s.Status
                    FROM InterviewSchedules s
                    INNER JOIN Applications app
                        ON s.ApplicationID = app.ApplicationID
                    INNER JOIN Applicants a
                        ON app.ApplicantID = a.ApplicantID
                    INNER JOIN JobVacancies j
                        ON app.VacancyID = j.VacancyID
                    INNER JOIN Users u
                        ON s.InterviewerUserID = u.UserID";

                    MySqlDataAdapter da =
                        new MySqlDataAdapter(query, conn);

                    DataTable dt = new DataTable();

                    da.Fill(dt);

                    dgvSchedule.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Load Error: " + ex.Message);
            }
        }

        private void dgvSchedule_CellClick(
            object sender,
            DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            DataGridViewRow row =
                dgvSchedule.Rows[e.RowIndex];

            selectedScheduleID =
                Convert.ToInt32(
                row.Cells["ScheduleID"].Value);

            selectedApplicationID =
                Convert.ToInt32(
                row.Cells["ApplicationID"].Value);

            txtApplicant.Text =
                row.Cells["ApplicantName"].Value.ToString();

            txtJob.Text =
                row.Cells["JobTitle"].Value.ToString();

            dtpScheduleDate.Value =
                Convert.ToDateTime(
                row.Cells["ScheduledDate"].Value);

            txtTime.Text =
                row.Cells["ScheduledTime"].Value.ToString();

            txtInterviewer.Text =
                row.Cells["Interviewer"].Value.ToString();

            cmbStatus.Text =
                row.Cells["Status"].Value.ToString();
        }

        private void btnSave_Click(
            object sender,
            EventArgs e)
        {
            try
            {
                if (selectedApplicationID == 0)
                {
                    MessageBox.Show(
                        "Please select an application.");
                    return;
                }

                using (MySqlConnection conn =
                    db.GetConnection())
                {
                    conn.Open();

                    string query = @"
                    INSERT INTO InterviewSchedules
                    (
                        ApplicationID,
                        InterviewTypeID,
                        InterviewerUserID,
                        ScheduledDate,
                        ScheduledTime,
                        Mode,
                        Status,
                        CreatedByUserID
                    )
                    VALUES
                    (
                        @ApplicationID,
                        1,
                        3,
                        @Date,
                        @Time,
                        'Face-to-Face',
                        @Status,
                        3
                    )";

                    MySqlCommand cmd =
                        new MySqlCommand(query, conn);

                    cmd.Parameters.AddWithValue(
                        "@ApplicationID",
                        selectedApplicationID);

                    cmd.Parameters.AddWithValue(
                        "@Date",
                        dtpScheduleDate.Value.Date);

                    cmd.Parameters.AddWithValue(
                        "@Time",
                        TimeSpan.Parse(txtTime.Text));

                    cmd.Parameters.AddWithValue(
                        "@Status",
                        cmbStatus.Text);

                    cmd.ExecuteNonQuery();
                }

                LogAudit(
                    "Interview Schedule Added",
                    "ApplicationID: " +
                    selectedApplicationID);

                MessageBox.Show(
                    "Schedule saved successfully.");

                LoadSchedules();
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Save Error: " + ex.Message);
            }
        }

        private void btnUpdate_Click(
            object sender,
            EventArgs e)
        {
            try
            {
                if (selectedScheduleID == 0)
                {
                    MessageBox.Show(
                        "Select a schedule first.");
                    return;
                }

                using (MySqlConnection conn =
                    db.GetConnection())
                {
                    conn.Open();

                    string query = @"
                    UPDATE InterviewSchedules
                    SET
                        ScheduledDate=@Date,
                        ScheduledTime=@Time,
                        Status=@Status
                    WHERE ScheduleID=@ID";

                    MySqlCommand cmd =
                        new MySqlCommand(query, conn);

                    cmd.Parameters.AddWithValue(
                        "@ID",
                        selectedScheduleID);

                    cmd.Parameters.AddWithValue(
                        "@Date",
                        dtpScheduleDate.Value.Date);

                    cmd.Parameters.AddWithValue(
                        "@Time",
                        TimeSpan.Parse(txtTime.Text));

                    cmd.Parameters.AddWithValue(
                        "@Status",
                        cmbStatus.Text);

                    cmd.ExecuteNonQuery();
                }

                LogAudit(
                    "Interview Schedule Updated",
                    "ScheduleID: " +
                    selectedScheduleID);

                MessageBox.Show(
                    "Schedule updated successfully.");

                LoadSchedules();
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Update Error: " + ex.Message);
            }
        }

        private void btnDelete_Click(
            object sender,
            EventArgs e)
        {
            try
            {
                if (selectedScheduleID == 0)
                {
                    MessageBox.Show(
                        "Select a schedule first.");
                    return;
                }

                using (MySqlConnection conn =
                    db.GetConnection())
                {
                    conn.Open();

                    string query =
                        "DELETE FROM InterviewSchedules WHERE ScheduleID=@ID";

                    MySqlCommand cmd =
                        new MySqlCommand(query, conn);

                    cmd.Parameters.AddWithValue(
                        "@ID",
                        selectedScheduleID);

                    cmd.ExecuteNonQuery();
                }

                LogAudit(
                    "Interview Schedule Deleted",
                    "ScheduleID: " +
                    selectedScheduleID);

                MessageBox.Show(
                    "Schedule deleted successfully.");

                LoadSchedules();
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Delete Error: " + ex.Message);
            }
        }

        private void btnRefresh_Click(
            object sender,
            EventArgs e)
        {
            LoadSchedules();
        }

        private void btnClear_Click(
            object sender,
            EventArgs e)
        {
            ClearFields();
        }

        private void ClearFields()
        {
            txtApplicant.Clear();
            txtJob.Clear();
            txtTime.Clear();
            txtInterviewer.Clear();
            txtNotes.Clear();

            cmbStatus.SelectedIndex = -1;

            selectedScheduleID = 0;
            selectedApplicationID = 0;

            dgvSchedule.ClearSelection();
        }

        private void LogAudit(
            string action,
            string details)
        {
            try
            {
                using (MySqlConnection conn =
                    db.GetConnection())
                {
                    conn.Open();

                    string query = @"
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
                        @ActorType,
                        @ActorID,
                        @Action,
                        'InterviewSchedules',
                        @TargetID,
                        @Details
                    )";

                    MySqlCommand cmd =
                        new MySqlCommand(query, conn);

                    cmd.Parameters.AddWithValue(
                        "@ActorType",
                        "HR Staff");

                    cmd.Parameters.AddWithValue(
                        "@ActorID",
                        3);

                    cmd.Parameters.AddWithValue(
                        "@Action",
                        action);

                    cmd.Parameters.AddWithValue(
                        "@TargetID",
                        selectedScheduleID);

                    cmd.Parameters.AddWithValue(
                        "@Details",
                        details);

                    cmd.ExecuteNonQuery();
                }
            }
            catch
            {
            }
        }
    }
}
