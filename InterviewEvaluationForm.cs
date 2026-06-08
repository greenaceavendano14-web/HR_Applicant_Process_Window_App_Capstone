using System;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace HRApplicantSystem
{
    public partial class InterviewEvaluationForm : Form
    {
        private int _applicationId;
        private int _interviewScheduleId;
        private int _hrUserId;
        private string _connectionString = "server=localhost;database=hr_applicant_db;uid=root;pwd=;";

        // Controls
        private Panel pnlHeader, pnlContent, pnlBottom;
        private Label lblTitle, lblApplicantName, lblJobTitle, lblInterviewDate, lblInterviewMode;
        private GroupBox grpScoring, grpOverall, grpRemarks;

        // Score fields
        private NumericUpDown nudCommunication, nudTechnical, nudProblemSolving;
        private NumericUpDown nudProfessionalism, nudCulturalFit;
        private Label lblCommScore, lblTechScore, lblProbScore, lblProfScore, lblCultScore;
        private Label lblTotalScore, lblAverageScore;

        // Overall result
        private RadioButton rbPass, rbFail, rbOnHold;
        private TextBox txtRemarks, txtRecommendation;
        private Button btnSave, btnCancel;
        private Label lblExistingNote;

        public InterviewEvaluationForm(int applicationId, int interviewScheduleId, int hrUserId)
        {
            _applicationId = applicationId;
            _interviewScheduleId = interviewScheduleId;
            _hrUserId = hrUserId;
            InitializeComponent();
            LoadInterviewInfo();
            LoadExistingEvaluation();
        }

        private void InitializeComponent()
        {
            this.Text = "Interview Evaluation - HR";
            this.Size = new Size(620, 700);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.FromArgb(245, 247, 250);
            this.Font = new Font("Segoe UI", 9);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;

            // Header
            pnlHeader = new Panel();
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Height = 60;
            pnlHeader.BackColor = Color.FromArgb(30, 80, 150);

            lblTitle = new Label();
            lblTitle.Text = "Interview Evaluation";
            lblTitle.ForeColor = Color.White;
            lblTitle.Font = new Font("Segoe UI", 15, FontStyle.Bold);
            lblTitle.AutoSize = true;
            lblTitle.Location = new Point(20, 16);
            pnlHeader.Controls.Add(lblTitle);

            // Content
            pnlContent = new Panel();
            pnlContent.Location = new Point(15, 70);
            pnlContent.Size = new Size(582, 565);

            // Info bar
            var pnlInfo = new Panel();
            pnlInfo.Location = new Point(0, 0);
            pnlInfo.Size = new Size(582, 75);
            pnlInfo.BackColor = Color.White;
            pnlInfo.BorderStyle = BorderStyle.FixedSingle;

            lblApplicantName = new Label();
            lblApplicantName.Location = new Point(10, 8);
            lblApplicantName.Size = new Size(300, 20);
            lblApplicantName.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            lblApplicantName.Text = "Loading...";

            lblJobTitle = new Label();
            lblJobTitle.Location = new Point(10, 30);
            lblJobTitle.Size = new Size(300, 18);
            lblJobTitle.ForeColor = Color.FromArgb(30, 80, 150);

            lblInterviewDate = new Label();
            lblInterviewDate.Location = new Point(320, 8);
            lblInterviewDate.Size = new Size(250, 18);
            lblInterviewDate.Font = new Font("Segoe UI", 9, FontStyle.Bold);

            lblInterviewMode = new Label();
            lblInterviewMode.Location = new Point(320, 30);
            lblInterviewMode.Size = new Size(250, 18);
            lblInterviewMode.ForeColor = Color.DimGray;

            pnlInfo.Controls.AddRange(new Control[] {
                lblApplicantName, lblJobTitle, lblInterviewDate, lblInterviewMode
            });

            // Scoring group
            grpScoring = new GroupBox();
            grpScoring.Text = "Scoring  (1 - 10 per category)";
            grpScoring.Location = new Point(0, 85);
            grpScoring.Size = new Size(582, 215);
            grpScoring.BackColor = Color.White;
            grpScoring.Font = new Font("Segoe UI", 9, FontStyle.Bold);

            string[] categories = {
                "Communication Skills",
                "Technical Knowledge",
                "Problem Solving",
                "Professionalism",
                "Cultural Fit"
            };

            NumericUpDown[] nuds = new NumericUpDown[5];
            Label[] scoreLabels = new Label[5];

            for (int i = 0; i < categories.Length; i++)
            {
                var catLabel = new Label();
                catLabel.Text = categories[i] + ":";
                catLabel.Location = new Point(15, 30 + i * 36);
                catLabel.Size = new Size(190, 24);
                catLabel.Font = new Font("Segoe UI", 9);
                catLabel.TextAlign = ContentAlignment.MiddleLeft;
                grpScoring.Controls.Add(catLabel);

                nuds[i] = new NumericUpDown();
                nuds[i].Location = new Point(215, 30 + i * 36);
                nuds[i].Size = new Size(65, 26);
                nuds[i].Minimum = 1;
                nuds[i].Maximum = 10;
                nuds[i].Value = 5;
                nuds[i].Font = new Font("Segoe UI", 10);
                int idx = i;
                nuds[i].ValueChanged += (s, e) => UpdateTotalScore(nuds);
                grpScoring.Controls.Add(nuds[i]);

                // Visual bar
                var scoreBar = new ProgressBar();
                scoreBar.Location = new Point(295, 33 + i * 36);
                scoreBar.Size = new Size(200, 18);
                scoreBar.Minimum = 1;
                scoreBar.Maximum = 10;
                scoreBar.Value = 5;
                int barIdx = i;
                nuds[i].ValueChanged += (s, e) => {
                    scoreBar.Value = (int)nuds[barIdx].Value;
                };
                grpScoring.Controls.Add(scoreBar);
            }

            nudCommunication = nuds[0];
            nudTechnical = nuds[1];
            nudProblemSolving = nuds[2];
            nudProfessionalism = nuds[3];
            nudCulturalFit = nuds[4];

            // Total/Average display
            var pnlScoreTotal = new Panel();
            pnlScoreTotal.Location = new Point(15, 185);
            pnlScoreTotal.Size = new Size(550, 22);
            pnlScoreTotal.BackColor = Color.FromArgb(235, 245, 255);

            lblTotalScore = new Label();
            lblTotalScore.Location = new Point(5, 3);
            lblTotalScore.Size = new Size(200, 18);
            lblTotalScore.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            lblTotalScore.ForeColor = Color.FromArgb(30, 80, 150);
            lblTotalScore.Text = "Total Score: 25 / 50";

            lblAverageScore = new Label();
            lblAverageScore.Location = new Point(215, 3);
            lblAverageScore.Size = new Size(200, 18);
            lblAverageScore.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            lblAverageScore.ForeColor = Color.FromArgb(30, 80, 150);
            lblAverageScore.Text = "Average: 5.0 / 10";

            pnlScoreTotal.Controls.AddRange(new Control[] { lblTotalScore, lblAverageScore });
            grpScoring.Controls.Add(pnlScoreTotal);

            // Overall result group
            grpOverall = new GroupBox();
            grpOverall.Text = "Overall Result";
            grpOverall.Location = new Point(0, 310);
            grpOverall.Size = new Size(582, 60);
            grpOverall.BackColor = Color.White;
            grpOverall.Font = new Font("Segoe UI", 9, FontStyle.Bold);

            rbPass = new RadioButton();
            rbPass.Text = "✔  Pass";
            rbPass.Location = new Point(20, 25);
            rbPass.Size = new Size(100, 22);
            rbPass.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            rbPass.ForeColor = Color.FromArgb(40, 167, 69);

            rbFail = new RadioButton();
            rbFail.Text = "✖  Fail";
            rbFail.Location = new Point(140, 25);
            rbFail.Size = new Size(100, 22);
            rbFail.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            rbFail.ForeColor = Color.FromArgb(220, 53, 69);

            rbOnHold = new RadioButton();
            rbOnHold.Text = "⏸  On Hold";
            rbOnHold.Location = new Point(260, 25);
            rbOnHold.Size = new Size(130, 22);
            rbOnHold.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            rbOnHold.ForeColor = Color.FromArgb(255, 153, 0);

            grpOverall.Controls.AddRange(new Control[] { rbPass, rbFail, rbOnHold });

            // Remarks group
            grpRemarks = new GroupBox();
            grpRemarks.Text = "Remarks & Recommendation";
            grpRemarks.Location = new Point(0, 380);
            grpRemarks.Size = new Size(582, 170);
            grpRemarks.BackColor = Color.White;
            grpRemarks.Font = new Font("Segoe UI", 9, FontStyle.Bold);

            var lblRem = new Label();
            lblRem.Text = "Interview Remarks:";
            lblRem.Location = new Point(10, 28);
            lblRem.Size = new Size(140, 18);
            lblRem.Font = new Font("Segoe UI", 9);

            txtRemarks = new TextBox();
            txtRemarks.Location = new Point(10, 48);
            txtRemarks.Size = new Size(558, 50);
            txtRemarks.Multiline = true;
            txtRemarks.ScrollBars = ScrollBars.Vertical;
            txtRemarks.Font = new Font("Segoe UI", 9);
            txtRemarks.PlaceholderText = "Enter interview remarks (required)...";

            var lblRec = new Label();
            lblRec.Text = "Recommendation:";
            lblRec.Location = new Point(10, 108);
            lblRec.Size = new Size(140, 18);
            lblRec.Font = new Font("Segoe UI", 9);

            txtRecommendation = new TextBox();
            txtRecommendation.Location = new Point(10, 128);
            txtRecommendation.Size = new Size(558, 32);
            txtRecommendation.Font = new Font("Segoe UI", 9);
            txtRecommendation.PlaceholderText = "e.g. Recommend for final interview, Endorse for technical assessment...";

            grpRemarks.Controls.AddRange(new Control[] { lblRem, txtRemarks, lblRec, txtRecommendation });

            // Previous evaluation note
            lblExistingNote = new Label();
            lblExistingNote.Location = new Point(0, 558);
            lblExistingNote.Size = new Size(582, 18);
            lblExistingNote.ForeColor = Color.Gray;
            lblExistingNote.Font = new Font("Segoe UI", 8, FontStyle.Italic);

            pnlContent.Controls.AddRange(new Control[] {
                pnlInfo, grpScoring, grpOverall, grpRemarks, lblExistingNote
            });

            // Bottom buttons
            pnlBottom = new Panel();
            pnlBottom.Dock = DockStyle.Bottom;
            pnlBottom.Height = 55;
            pnlBottom.BackColor = Color.FromArgb(240, 242, 245);

            btnSave = new Button();
            btnSave.Text = "Save Evaluation";
            btnSave.Size = new Size(160, 32);
            btnSave.Location = new Point(230, 12);
            btnSave.BackColor = Color.FromArgb(30, 80, 150);
            btnSave.ForeColor = Color.White;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            btnSave.Cursor = Cursors.Hand;
            btnSave.Click += BtnSave_Click;

            btnCancel = new Button();
            btnCancel.Text = "Cancel";
            btnCancel.Size = new Size(100, 32);
            btnCancel.Location = new Point(400, 12);
            btnCancel.BackColor = Color.FromArgb(108, 117, 125);
            btnCancel.ForeColor = Color.White;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            btnCancel.Cursor = Cursors.Hand;
            btnCancel.Click += (s, e) => this.Close();

            pnlBottom.Controls.AddRange(new Control[] { btnSave, btnCancel });

            this.Controls.AddRange(new Control[] { pnlHeader, pnlContent, pnlBottom });
        }

        private void UpdateTotalScore(NumericUpDown[] nuds)
        {
            int total = 0;
            foreach (var n in nuds) total += (int)n.Value;
            double avg = total / 5.0;
            lblTotalScore.Text = $"Total Score: {total} / 50";
            lblAverageScore.Text = $"Average: {avg:F1} / 10";
        }

        private void LoadInterviewInfo()
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(_connectionString))
                {
                    conn.Open();
                    string query = @"
                        SELECT CONCAT(a.FirstName,' ',a.LastName) AS FullName,
                               jv.JobTitle, isch.InterviewDate, isch.Mode
                        FROM InterviewSchedules isch
                        INNER JOIN Applications app ON isch.ApplicationID = app.ApplicationID
                        INNER JOIN Applicants a ON app.ApplicantID = a.ApplicantID
                        INNER JOIN JobVacancies jv ON app.JobVacancyID = jv.JobVacancyID
                        WHERE isch.InterviewScheduleID = @SchedID";

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@SchedID", _interviewScheduleId);
                    MySqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        lblApplicantName.Text = reader["FullName"].ToString();
                        lblJobTitle.Text = "Job: " + reader["JobTitle"].ToString();
                        lblInterviewDate.Text = "Date: " + Convert.ToDateTime(reader["InterviewDate"]).ToString("MM/dd/yyyy hh:mm tt");
                        lblInterviewMode.Text = "Mode: " + reader["Mode"].ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading interview info: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadExistingEvaluation()
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(_connectionString))
                {
                    conn.Open();
                    string query = @"
                        SELECT CommunicationScore, TechnicalScore, ProblemSolvingScore,
                               ProfessionalismScore, CulturalFitScore, Result, Remarks,
                               Recommendation, EvaluatedDate
                        FROM InterviewEvaluations
                        WHERE InterviewScheduleID = @SchedID";

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@SchedID", _interviewScheduleId);
                    MySqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        nudCommunication.Value = Convert.ToDecimal(reader["CommunicationScore"]);
                        nudTechnical.Value = Convert.ToDecimal(reader["TechnicalScore"]);
                        nudProblemSolving.Value = Convert.ToDecimal(reader["ProblemSolvingScore"]);
                        nudProfessionalism.Value = Convert.ToDecimal(reader["ProfessionalismScore"]);
                        nudCulturalFit.Value = Convert.ToDecimal(reader["CulturalFitScore"]);

                        string result = reader["Result"].ToString();
                        if (result == "Pass") rbPass.Checked = true;
                        else if (result == "Fail") rbFail.Checked = true;
                        else rbOnHold.Checked = true;

                        txtRemarks.Text = reader["Remarks"].ToString();
                        txtRecommendation.Text = reader["Recommendation"].ToString();
                        lblExistingNote.Text = $"Evaluation last saved on {reader["EvaluatedDate"]:MM/dd/yyyy hh:mm tt}";
                    }
                }
            }
            catch { /* No existing evaluation - that's fine */ }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (!rbPass.Checked && !rbFail.Checked && !rbOnHold.Checked)
            {
                MessageBox.Show("Please select an overall result (Pass / Fail / On Hold).",
                    "Result Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtRemarks.Text))
            {
                MessageBox.Show("Please enter interview remarks.", "Remarks Required",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string result = rbPass.Checked ? "Pass" : rbFail.Checked ? "Fail" : "On Hold";
            string newStatus = rbPass.Checked ? "For Final Review" : rbFail.Checked ? "Rejected" : "For Assessment";

            if (MessageBox.Show($"Save evaluation with result: {result}?\nApplication will be moved to: {newStatus}",
                "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            try
            {
                using (MySqlConnection conn = new MySqlConnection(_connectionString))
                {
                    conn.Open();

                    // Save/update evaluation
                    string upsertQuery = @"
                        INSERT INTO InterviewEvaluations
                            (InterviewScheduleID, ApplicationID, CommunicationScore, TechnicalScore,
                             ProblemSolvingScore, ProfessionalismScore, CulturalFitScore, Result,
                             Remarks, Recommendation, EvaluatedByUserID, EvaluatedDate)
                        VALUES
                            (@SchedID, @AppID, @Comm, @Tech, @Prob, @Prof, @Cult,
                             @Result, @Remarks, @Rec, @UserID, NOW())
                        ON DUPLICATE KEY UPDATE
                            CommunicationScore = @Comm, TechnicalScore = @Tech,
                            ProblemSolvingScore = @Prob, ProfessionalismScore = @Prof,
                            CulturalFitScore = @Cult, Result = @Result,
                            Remarks = @Remarks, Recommendation = @Rec,
                            EvaluatedByUserID = @UserID, EvaluatedDate = NOW()";

                    MySqlCommand cmd = new MySqlCommand(upsertQuery, conn);
                    cmd.Parameters.AddWithValue("@SchedID", _interviewScheduleId);
                    cmd.Parameters.AddWithValue("@AppID", _applicationId);
                    cmd.Parameters.AddWithValue("@Comm", (int)nudCommunication.Value);
                    cmd.Parameters.AddWithValue("@Tech", (int)nudTechnical.Value);
                    cmd.Parameters.AddWithValue("@Prob", (int)nudProblemSolving.Value);
                    cmd.Parameters.AddWithValue("@Prof", (int)nudProfessionalism.Value);
                    cmd.Parameters.AddWithValue("@Cult", (int)nudCulturalFit.Value);
                    cmd.Parameters.AddWithValue("@Result", result);
                    cmd.Parameters.AddWithValue("@Remarks", txtRemarks.Text.Trim());
                    cmd.Parameters.AddWithValue("@Rec", txtRecommendation.Text.Trim());
                    cmd.Parameters.AddWithValue("@UserID", _hrUserId);
                    cmd.ExecuteNonQuery();

                    // Update interview schedule to Completed
                    string schedUpdate = "UPDATE InterviewSchedules SET Status = 'Completed' 
