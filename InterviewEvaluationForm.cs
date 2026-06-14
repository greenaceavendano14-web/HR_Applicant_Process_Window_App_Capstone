using HRApplicantSystem.Database;
using HRApplicantSystem.Models;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace HRApplicantSystem
{
    public partial class InterviewEvaluationForm : Form
    {
        DbConnection db = new DbConnection();

        int selectedScheduleID = 0;
        int selectedApplicationID = 0;

        public InterviewEvaluationForm()
        {
            InitializeComponent();

            this.Load += InterviewEvaluationForm_Load;

            dgvInterview.CellClick += dgvInterview_CellClick;

            btnSave.Click += btnSave_Click;
            btnRefresh.Click += btnRefresh_Click;
            btnClear.Click += btnClear_Click;
            btnClose.Click += btnClose_Click;
            btnSearch.Click += btnSearch_Click;

            numCommunication.ValueChanged += CalculateScore;
            numTechnical.ValueChanged += CalculateScore;
            numConfidence.ValueChanged += CalculateScore;
            numProblemSolving.ValueChanged += CalculateScore;
        }

        // ================= LOAD =================
        private void InterviewEvaluationForm_Load(object sender, EventArgs e)
        {
            cmbRecommendation.Items.Clear();
            cmbRecommendation.Items.Add("Hire");
            cmbRecommendation.Items.Add("Reject");
            cmbRecommendation.Items.Add("For Final Review");

            this.WindowState = FormWindowState.Maximized;

            LoadSchedules();
            CalculateScore(null, null);
        }

        // ================= LOAD DATA =================
        private void LoadSchedules(string search = "")
        {
            try
            {
                string query = @"
                SELECT
                    s.ScheduleID,
                    a.ApplicationID,
                    CONCAT(ap.FirstName,' ',ap.LastName) AS ApplicantName,
                    j.JobTitle,
                    s.ScheduledDate,
                    s.Status
                FROM InterviewSchedules s
                INNER JOIN Applications a ON s.ApplicationID = a.ApplicationID
                INNER JOIN Applicants ap ON a.ApplicantID = ap.ApplicantID
                INNER JOIN JobVacancies j ON a.VacancyID = j.VacancyID
                WHERE s.Status = 'Scheduled'";

                if (!string.IsNullOrEmpty(search))
                {
                    query += @" AND CONCAT(ap.FirstName,' ',ap.LastName)
                               LIKE @search";
                }

                MySqlConnection conn = db.GetConnection();
                conn.Open();

                MySqlCommand cmd = new MySqlCommand(query, conn);

                if (!string.IsNullOrEmpty(search))
                    cmd.Parameters.AddWithValue("@search", "%" + search + "%");

                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dgvInterview.DataSource = dt;

                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Load Error: " + ex.Message);
            }
        }

        // ================= SELECT =================
        private void dgvInterview_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow row = dgvInterview.Rows[e.RowIndex];

            selectedScheduleID =
                Convert.ToInt32(row.Cells["ScheduleID"].Value);

            selectedApplicationID =
                Convert.ToInt32(row.Cells["ApplicationID"].Value);

            txtApplicant.Text =
                row.Cells["ApplicantName"].Value.ToString();

            txtJob.Text =
                row.Cells["JobTitle"].Value.ToString();
        }

        // ================= SCORE =================
        private void CalculateScore(object sender, EventArgs e)
        {
            double total =
                (double)numCommunication.Value +
                (double)numTechnical.Value +
                (double)numConfidence.Value +
                (double)numProblemSolving.Value;

            double average = total / 4;

            lblOverall.Text = average.ToString("0.00");
        }

        // ================= SAVE =================
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (selectedScheduleID == 0)
                {
                    MessageBox.Show("Select an interview schedule.");
                    return;
                }

                if (cmbRecommendation.SelectedIndex == -1)
                {
                    MessageBox.Show("Select recommendation.");
                    return;
                }

                MySqlConnection conn = db.GetConnection();
                conn.Open();

                double score = double.Parse(lblOverall.Text);

                string result = "Pending";

                if (cmbRecommendation.Text == "Hire")
                    result = "Pass";
                else if (cmbRecommendation.Text == "Reject")
                    result = "Fail";

                // ================= INSERT EVALUATION =================
                string insert = @"
                INSERT INTO InterviewEvaluations
                (
                    ScheduleID,
                    EvaluatedByUserID,
                    Score,
                    Result,
                    Remarks,
                    Recommendation
                )
                VALUES
                (
                    @schedule,
                    @user,
                    @score,
                    @result,
                    @remarks,
                    @rec
                )";

                MySqlCommand cmd = new MySqlCommand(insert, conn);
                cmd.Parameters.AddWithValue("@schedule", selectedScheduleID);
                cmd.Parameters.AddWithValue("@user", Session.UserID);
                cmd.Parameters.AddWithValue("@score", score);
                cmd.Parameters.AddWithValue("@result", result);
                cmd.Parameters.AddWithValue("@remarks", txtRemarks.Text);
                cmd.Parameters.AddWithValue("@rec", cmbRecommendation.Text);

                cmd.ExecuteNonQuery();

                // ================= UPDATE SCHEDULE =================
                string updateSched = @"
                UPDATE InterviewSchedules
                SET Status='Completed'
                WHERE ScheduleID=@id";

                MySqlCommand up = new MySqlCommand(updateSched, conn);
                up.Parameters.AddWithValue("@id", selectedScheduleID);
                up.ExecuteNonQuery();

                // ================= UPDATE APPLICATION STATUS =================
                string newStatus = "For Final Review";

                if (cmbRecommendation.Text == "Hire")
                    newStatus = "Accepted";
                else if (cmbRecommendation.Text == "Reject")
                    newStatus = "Rejected";

                string updateApp = @"
                UPDATE Applications
                SET CurrentStatus=@status
                WHERE ApplicationID=@id";

                MySqlCommand upApp = new MySqlCommand(updateApp, conn);
                upApp.Parameters.AddWithValue("@status", newStatus);
                upApp.Parameters.AddWithValue("@id", selectedApplicationID);
                upApp.ExecuteNonQuery();

                conn.Close();

                MessageBox.Show("Evaluation saved successfully!");

                LoadSchedules();
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Save Error: " + ex.Message);
            }
        }

        // ================= SEARCH =================
        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadSchedules(txtSearch.Text.Trim());
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
            txtRemarks.Clear();

            numCommunication.Value = 1;
            numTechnical.Value = 1;
            numConfidence.Value = 1;
            numProblemSolving.Value = 1;

            cmbRecommendation.SelectedIndex = -1;
            lblOverall.Text = "0.00";

            selectedScheduleID = 0;
            selectedApplicationID = 0;

            dgvInterview.ClearSelection();
        }

        // ================= CLOSE =================
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}