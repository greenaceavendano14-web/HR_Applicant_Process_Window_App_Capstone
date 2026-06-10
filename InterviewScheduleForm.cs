using HRSystem;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace HRInterviewScheduleForm
{
    public partial class InterviewScheduleForm : Form
    {
        DBConnection db = new DBConnection();

        int selectedScheduleID = 0;
        int selectedApplicationID = 0;

        public InterviewScheduleForm()
        {
            InitializeComponent();

            this.Load += InterviewScheduleForm_Load;

            dgvSchedule.CellClick += dgvSchedule_CellClick;

            btnSave.Click += btnSave_Click;
            btnUpdate.Click += btnUpdate_Click;
            btnDelete.Click += btnDelete_Click;
            btnRefresh.Click += btnRefresh_Click;
            btnClear.Click += btnClear_Click;
        }

        // ================= LOAD =================
        private void InterviewScheduleForm_Load(object sender, EventArgs e)
        {
            cmbStatus.Items.Clear();
            cmbStatus.Items.Add("Scheduled");
            cmbStatus.Items.Add("Completed");
            cmbStatus.Items.Add("Cancelled");

            LoadSchedules();
        }

        // ================= SAFE HELPERS =================
        private string SafeString(object value)
        {
            return value == DBNull.Value || value == null ? "" : value.ToString();
        }

        private int SafeInt(object value)
        {
            return value == DBNull.Value || value == null ? 0 : Convert.ToInt32(value);
        }

        private DateTime SafeDate(object value)
        {
            return value == DBNull.Value || value == null ? DateTime.Now : Convert.ToDateTime(value);
        }

        // ================= LOAD DATA =================
        private void LoadSchedules()
        {
            try
            {
                db.OpenConnection();

                string query = @"
                SELECT
                    s.ScheduleID,
                    s.ApplicationID,
                    CONCAT(ap.FirstName,' ',ap.LastName) AS ApplicantName,
                    j.JobTitle,
                    s.ScheduleDate,
                    s.ScheduleTime,
                    s.Interviewer,
                    s.Status,
                    s.Notes
                FROM InterviewSchedules s
                INNER JOIN Applications a ON s.ApplicationID = a.ApplicationID
                INNER JOIN Applicants ap ON a.ApplicantID = ap.ApplicantID
                INNER JOIN JobVacancies j ON a.VacancyID = j.VacancyID";

                MySqlDataAdapter da = new MySqlDataAdapter(query, db.GetConnection());
                DataTable dt = new DataTable();
                da.Fill(dt);

                dgvSchedule.DataSource = dt;

                db.CloseConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Load Error: " + ex.Message);
            }
        }

        // ================= SELECT ROW =================
        private void dgvSchedule_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow row = dgvSchedule.Rows[e.RowIndex];

            selectedScheduleID = SafeInt(row.Cells["ScheduleID"].Value);
            selectedApplicationID = SafeInt(row.Cells["ApplicationID"].Value);

            txtApplicant.Text = SafeString(row.Cells["ApplicantName"].Value);
            txtJob.Text = SafeString(row.Cells["JobTitle"].Value);

            dtpScheduleDate.Value = SafeDate(row.Cells["ScheduleDate"].Value);

            txtTime.Text = SafeString(row.Cells["ScheduleTime"].Value);
            txtInterviewer.Text = SafeString(row.Cells["Interviewer"].Value);
            cmbStatus.Text = SafeString(row.Cells["Status"].Value);
            txtNotes.Text = SafeString(row.Cells["Notes"].Value);
        }

        // ================= SAVE =================
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (selectedApplicationID == 0)
                {
                    MessageBox.Show("Please select an applicant.");
                    return;
                }

                db.OpenConnection();

                string insert = @"
                INSERT INTO InterviewSchedules
                (ApplicationID, ScheduleDate, ScheduleTime, Interviewer, Status, Notes)
                VALUES
                (@app,@date,@time,@interviewer,@status,@notes)";

                MySqlCommand cmd = new MySqlCommand(insert, db.GetConnection());

                cmd.Parameters.AddWithValue("@app", selectedApplicationID);
                cmd.Parameters.AddWithValue("@date", dtpScheduleDate.Value.Date);
                cmd.Parameters.AddWithValue("@time", txtTime.Text);
                cmd.Parameters.AddWithValue("@interviewer", txtInterviewer.Text);
                cmd.Parameters.AddWithValue("@status", cmbStatus.Text);
                cmd.Parameters.AddWithValue("@notes", txtNotes.Text);

                cmd.ExecuteNonQuery();

                db.CloseConnection();

                MessageBox.Show("Interview Scheduled!");

                LoadSchedules();
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Save Error: " + ex.Message);
            }
        }

        // ================= UPDATE =================
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (selectedScheduleID == 0)
                {
                    MessageBox.Show("Select a schedule first.");
                    return;
                }

                db.OpenConnection();

                string update = @"
                UPDATE InterviewSchedules
                SET ScheduleDate=@date,
                    ScheduleTime=@time,
                    Interviewer=@interviewer,
                    Status=@status,
                    Notes=@notes
                WHERE ScheduleID=@id";

                MySqlCommand cmd = new MySqlCommand(update, db.GetConnection());

                cmd.Parameters.AddWithValue("@id", selectedScheduleID);
                cmd.Parameters.AddWithValue("@date", dtpScheduleDate.Value.Date);
                cmd.Parameters.AddWithValue("@time", txtTime.Text);
                cmd.Parameters.AddWithValue("@interviewer", txtInterviewer.Text);
                cmd.Parameters.AddWithValue("@status", cmbStatus.Text);
                cmd.Parameters.AddWithValue("@notes", txtNotes.Text);

                cmd.ExecuteNonQuery();

                db.CloseConnection();

                MessageBox.Show("Updated Successfully!");

                LoadSchedules();
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Update Error: " + ex.Message);
            }
        }

        // ================= DELETE =================
        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (selectedScheduleID == 0)
                {
                    MessageBox.Show("Select a schedule first.");
                    return;
                }

                db.OpenConnection();

                string delete = "DELETE FROM InterviewSchedules WHERE ScheduleID=@id";

                MySqlCommand cmd = new MySqlCommand(delete, db.GetConnection());
                cmd.Parameters.AddWithValue("@id", selectedScheduleID);

                cmd.ExecuteNonQuery();

                db.CloseConnection();

                MessageBox.Show("Deleted Successfully!");

                LoadSchedules();
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Delete Error: " + ex.Message);
            }
        }

        // ================= REFRESH =================
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadSchedules();
        }

        // ================= CLEAR =================
        private void btnClear_Click(object sender, EventArgs e)
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
    }
}