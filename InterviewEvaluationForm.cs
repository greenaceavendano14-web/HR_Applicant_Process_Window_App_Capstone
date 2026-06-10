using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace HRInterviewEvaluationForm
{
    public partial class InterviewEvaluationForm : Form
    {
        DBConnection db = new DBConnection();

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

            numCommunication.ValueChanged += CalculateScore;
            numTechnical.ValueChanged += CalculateScore;
            numConfidence.ValueChanged += CalculateScore;
            numProblemSolving.ValueChanged += CalculateScore;
        }

        // ================= LOAD FORM =================
        private void InterviewEvaluationForm_Load(object sender, EventArgs e)
        {
            cmbRecommendation.Items.Clear();
            cmbRecommendation.Items.Add("Hire");
            cmbRecommendation.Items.Add("Reject");
            cmbRecommendation.Items.Add("For Final Review");

            LoadApplicants();
            CalculateScore(null, null);
        }

        // ================= LOAD DATA =================
        private void LoadApplicants()
        {
            try
            {
                db.OpenConnection();

                string query = @"
                SELECT
                    a.ApplicationID,
                    CONCAT(ap.FirstName,' ',ap.LastName) AS ApplicantName,
                    j.JobTitle,
                    a.CurrentStatus
                FROM Applications a
                INNER JOIN Applicants ap ON a.ApplicantID = ap.ApplicantID
                INNER JOIN JobVacancies j ON a.VacancyID = j.VacancyID";

                MySqlDataAdapter da =
                    new MySqlDataAdapter(query, db.GetConnection());

                DataTable dt = new DataTable();
                da.Fill(dt);

                dgvInterview.DataSource = dt;

                db.CloseConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Load Error: " + ex.Message);
            }
        }

        // ================= SELECT APPLICANT =================
        private void dgvInterview_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow row = dgvInterview.Rows[e.RowIndex];

            selectedApplicationID =
                Convert.ToInt32(row.Cells["ApplicationID"].Value);

            txtApplicant.Text =
                row.Cells["ApplicantName"].Value.ToString();

            txtJob.Text =
                row.Cells["JobTitle"].Value.ToString();
        }

        // ================= AUTO CALCULATE SCORE =================
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
                if (selectedApplicationID == 0)
                {
                    MessageBox.Show("Select an applicant first.");
                    return;
                }

                db.OpenConnection();

                double overall =
                    (double.Parse(lblOverall.Text));

                string insert = @"
                INSERT INTO InterviewEvaluations
                (ApplicationID, Communication, Technical, Confidence,
                 ProblemSolving, OverallRating, Recommendation,
                 Remarks, InterviewDate, EvaluatedBy)
                VALUES
                (@app,@c,@t,@co,@p,@o,@r,@rm,@d,'HR Staff')";

                MySqlCommand cmd =
                    new MySqlCommand(insert, db.GetConnection());

                cmd.Parameters.AddWithValue("@app", selectedApplicationID);
                cmd.Parameters.AddWithValue("@c", numCommunication.Value);
                cmd.Parameters.AddWithValue("@t", numTechnical.Value);
                cmd.Parameters.AddWithValue("@co", numConfidence.Value);
                cmd.Parameters.AddWithValue("@p", numProblemSolving.Value);
                cmd.Parameters.AddWithValue("@o", overall);
                cmd.Parameters.AddWithValue("@r", cmbRecommendation.Text);
                cmd.Parameters.AddWithValue("@rm", txtRemarks.Text);
                cmd.Parameters.AddWithValue("@d", dtpInterviewDate.Value.Date);

                cmd.ExecuteNonQuery();

                db.CloseConnection();

                MessageBox.Show("Interview Evaluation Saved!");

                LoadApplicants();
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Save Error: " + ex.Message);
            }
        }

        // ================= REFRESH =================
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadApplicants();
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