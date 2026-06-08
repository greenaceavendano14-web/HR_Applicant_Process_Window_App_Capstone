using System;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace HRApplicantSystem
{
    public partial class InterviewScheduleForm : Form
    {
        private int _applicationId;
        private int _hrUserId;
        private int _existingScheduleId = -1;
        private string _connectionString = "server=localhost;database=hr_applicant_db;uid=root;pwd=;";

        // Controls
        private Panel pnlHeader, pnlContent, pnlBottom;
        private Label lblTitle, lblApplicantName, lblJobTitle, lblCurrentStatus;
        private GroupBox grpSchedule, grpInterviewer, grpNotes;

        // Schedule fields
        private DateTimePicker dtpDate, dtpTime;
        private ComboBox cboMode, cboStatus;
        private TextBox txtLocation, txtInterviewerName, txtNotes;
        private Label lblExistingNote;

        // Buttons
        private Button btnSave, btnCancel;

        public InterviewScheduleForm(int applicationId, int hrUserId)
        {
            _applicationId = applicationId;
            _hrUserId = hrUserId;
            InitializeComponent();
            LoadApplicationInfo();
            LoadExistingSchedule();
        }

        private void InitializeComponent()
        {
            this.Text = "Interview Schedule - HR";
            this.Size = new Size(560, 600);
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
            lblTitle.Text = "Interview Schedule";
            lblTitle.ForeColor = Color.White;
            lblTitle.Font = new Font("Segoe UI", 15, FontStyle.Bold);
            lblTitle.AutoSize = true;
            lblTitle.Location = new Point(20, 16);
            pnlHeader.Controls.Add(lblTitle);

            // Content panel
            pnlContent = new Panel();
            pnlContent.Location = new Point(15, 70);
            pnlContent.Size = new Size(522, 468);

            // Applicant info bar
            var pnlInfo = new Panel();
            pnlInfo.Location = new Point(0, 0);
            pnlInfo.Size = new Size(522, 65);
            pnlInfo.BackColor = Color.White;
            pnlInfo.BorderStyle = BorderStyle.FixedSingle;

            lblApplicantName = new Label();
            lblApplicantName.Location = new Point(10, 8);
            lblApplicantName.Size = new Size(350, 20);
            lblApplicantName.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            lblApplicantName.Text = "Loading...";

            lblJobTitle = new Label();
            lblJobTitle.Location = new Point(10, 30);
            lblJobTitle.Size = new Size(350, 18);
            lblJobTitle.ForeColor = Color.FromArgb(30, 80, 150);

            lblCurrentStatus = new Label();
            lblCurrentStatus.Location = new Point(375, 20);
            lblCurrentStatus.Size = new Size(135, 24);
            lblCurrentStatus.TextAlign = ContentAlignment.MiddleCenter;
            lblCurrentStatus.Font = new Font("Segoe UI", 8, FontStyle.Bold);
            lblCurrentStatus.BackColor = Color.FromArgb(209, 236, 241);
            lblCurrentStatus.ForeColor = Color.FromArgb(12, 84, 96);

            pnlInfo.Controls.AddRange(new Control[] { lblApplicantName, lblJobTitle, lblCurrentStatus });

            // Schedule group
            grpSchedule = new GroupBox();
            grpSchedule.Text = "Interview Schedule Details";
            grpSchedule.Location = new Point(0, 75);
            grpSchedule.Size = new Size(522, 190);
            grpSchedule.BackColor = Color.White;
            grpSchedule.Font = new Font("Segoe UI", 9, FontStyle.Bold);

            // Date
            AddFormLabel(grpSchedule, "Interview Date:", 15, 30);
            dtpDate = new DateTimePicker();
            dtpDate.Location = new Point(155, 28);
            dtpDate.Size = new Size(175, 26);
            dtpDate.Format = DateTimePickerFormat.Short;
            dtpDate.MinDate = DateTime.Today;
            grpSchedule.Controls.Add(dtpDate);

            // Time
            AddFormLabel(grpSchedule, "Time:", 15, 65);
            dtpTime = new DateTimePicker();
            dtpTime.Location = new Point(155, 63);
            dtpTime.Size = new Size(130, 26);
            dtpTime.Format = DateTimePickerFormat.Time;
            dtpTime.ShowUpDown = true;
            dtpTime.Value = DateTime.Today.AddHours(9);
            grpSchedule.Controls.Add(dtpTime);

            // Mode/Type
            AddFormLabel(grpSchedule, "Mode:", 15, 100);
            cboMode = new ComboBox();
            cboMode.Location = new Point(155, 98);
            cboMode.Size = new Size(175, 26);
            cboMode.DropDownStyle = ComboBoxStyle.DropDownList;
            cboMode.Items.AddRange(new string[] { "Face-to-Face", "Online (Video Call)", "Phone Call", "Panel Interview" });
            cboMode.SelectedIndex = 0;
            grpSchedule.Controls.Add(cboMode);

            // Location
            AddFormLabel(grpSchedule, "Location / Link:", 15, 135);
            txtLocation = new TextBox();
            txtLocation.Location = new Point(155, 133);
            txtLocation.Size = new Size(350, 26);
            txtLocation.Font = new Font("Segoe UI", 9);
            txtLocation.PlaceholderText = "Office room / Meeting link / Phone number";
            grpSchedule.Controls.Add(txtLocation);

            // Schedule status
            AddFormLabel(grpSchedule, "Schedule Status:", 15, 165);
            cboStatus = new ComboBox();
            cboStatus.Location = new Point(155, 163);
            cboStatus.Size = new Size(175, 26);
            cboStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            cboStatus.Items.AddRange(new string[] { "Scheduled", "Completed", "Cancelled", "Rescheduled" });
            cboStatus.SelectedIndex = 0;
            grpSchedule.Controls.Add(cboStatus);

            // Interviewer group
            grpInterviewer = new GroupBox();
            grpInterviewer.Text = "Interviewer";
            grpInterviewer.Location = new Point(0, 275);
            grpInterviewer.Size = new Size(522, 70);
            grpInterviewer.BackColor = Color.White;
            grpInterviewer.Font = new Font("Segoe UI", 9, FontStyle.Bold);

            AddFormLabel(grpInterviewer, "Interviewer Name:", 15, 30);
            txtInterviewerName = new TextBox();
            txtInterviewerName.Location = new Point(155, 28);
            txtInterviewerName.Size = new Size(350, 26);
            txtInterviewerName.Font = new Font("Segoe UI", 9);
            txtInterviewerName.PlaceholderText = "Enter interviewer full name...";
            grpInterviewer.Controls.Add(txtInterviewerName);

            // Notes group
            grpNotes = new GroupBox();
            grpNotes.Text = "Notes / Instructions for Applicant";
            grpNotes.Location = new Point(0, 355);
            grpNotes.Size = new Size(522, 100);
            grpNotes.BackColor = Color.White;
            grpNotes.Font = new Font("Segoe UI", 9, FontStyle.Bold);

            txtNotes = new TextBox();
            txtNotes.Location = new Point(10, 25);
            txtNotes.Size = new Size(498, 65);
            txtNotes.Multiline = true;
            txtNotes.ScrollBars = ScrollBars.Vertical;
            txtNotes.Font = new Font("Segoe UI", 9);
            txtNotes.PlaceholderText = "Optional: Instructions, documents to bring, dress code, etc.";
            grpNotes.Controls.Add(txtNotes);

            // Existing schedule note
            lblExistingNote = new Label();
            lblExistingNote.Location = new Point(0, 462);
            lblExistingNote.Size = new Size(522, 18);
            lblExistingNote.ForeColor = Color.Gray;
            lblExistingNote.Font = new Font("Segoe UI", 8, FontStyle.Italic);

            pnlContent.Controls.AddRange(new Control[] {
                pnlInfo, grpSchedule, grpInterviewer, grpNotes, lblExistingNote
            });

            // Bottom buttons
            pnlBottom = new Panel();
            pnlBottom.Dock = DockStyle.Bottom;
            pnlBottom.Height = 55;
            pnlBottom.BackColor = Color.FromArgb(240, 242, 245);

            btnSave = new Button();
            btnSave.Text = "Save Schedule";
            btnSave.Size = new Size(150, 32);
            btnSave.Location = new Point(195, 12);
            btnSave.BackColor = Color.FromArgb(30, 80, 150);
            btnSave.ForeColor = Color.White;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            btnSave.Cursor = Cursors.Hand;
            btnSave.Click += BtnSave_Click;

            btnCancel = new Button();
            btnCancel.Text = "Cancel";
            btnCancel.Size = new Size(100, 32);
            btnCancel.Location = new Point(355, 12);
            btnCancel.BackColor = Color.FromArgb(108, 117, 125);
            btnCancel.ForeColor = Color.White;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            btnCancel.Cursor = Cursors.Hand;
            btnCancel.Click += (s, e) => this.Close();

            pnlBottom.Controls.AddRange(new Control[] { btnSave, btnCancel });

            this.Controls.AddRange(new Control[] { pnlHeader, pnlContent, pnlBottom });
        }

        private void AddFormLabel(Control parent, string text, int x, int y)
        {
            var lbl = new Label();
            lbl.Text = text;
            lbl.Location = new Point(x, y + 3);
            lbl.Size = new Size(140, 20);
            lbl.Font = new Font("Segoe UI", 9);
            parent.Controls.Add(lbl);
        }

        private void LoadApplicationInfo()
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(_connectionString))
                {
                    conn.Open();
                    string query = @"
                        SELECT CONCAT(a.FirstName,' ',a.LastName) AS FullName,
                               jv.JobTitle, app.Status
                        FROM Applications app
                        INNER JOIN Applicants a ON app.ApplicantID = a.ApplicantID
                        INNER JOIN JobVacancies jv ON app.JobVacancyID = jv.JobVacancyID
                        WHERE app.ApplicationID = @AppID";

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@AppID", _applicationId);
                    MySqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        lblApplicantName.Text = reader["FullName"].ToString();
                        lblJobTitle.Text = "Job: " + reader["JobTitle"].ToString();
                        lblCurrentStatus.Text = reader["Status"].ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading application: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadExistingSchedule()
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(_connectionString))
                {
                    conn.Open();
                    string query = @"
                        SELECT InterviewScheduleID, InterviewDate, Mode, Location,
                               InterviewerName, Status, Notes
                        FROM InterviewSchedules
                        WHERE ApplicationID = @AppID
                        ORDER BY InterviewDate DESC LIMIT 1";

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@AppID", _applicationId);
                    MySqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        _existingScheduleId = Convert.ToInt32(reader["InterviewScheduleID"]);
                        DateTime interviewDT = Convert.ToDateTime(reader["InterviewDate"]);
                        dtpDate.Value = interviewDT.Date;
                        dtpTime.Value = interviewDT;
                        cboMode.SelectedItem = reader["Mode"].ToString();
                        txtLocation.Text = reader["Location"].ToString();
                        txtInterviewerName.Text = reader["InterviewerName"].ToString();
                        cboStatus.SelectedItem = reader["Status"].ToString();
                        txtNotes.Text = reader["Notes"].ToString();
                        lblExistingNote.Text = $"Existing schedule found (ID #{_existingScheduleId}). Saving will update it.";
                    }
                }
            }
            catch { /* No existing schedule - that's fine */ }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            // Validate date is not in the past
            DateTime selectedDateTime = dtpDate.Value.Date.Add(dtpTime.Value.TimeOfDay);
            if (selectedDateTime < DateTime.Now && cboStatus.SelectedItem?.ToString() == "Scheduled")
            {
                MessageBox.Show("Interview date and time cannot be in the past for a Scheduled interview.",
                    "Invalid Date", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtInterviewerName.Text))
            {
                MessageBox.Show("Please enter the interviewer's name.", "Required Field",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtLocation.Text))
            {
                MessageBox.Show("Please enter the location or meeting link.", "Required Field",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string confirmMsg = _existingScheduleId == -1
                ? $"Schedule interview on {selectedDateTime:MM/dd/yyyy hh:mm tt}?"
                : $"Update existing interview schedule to {selectedDateTime:MM/dd/yyyy hh:mm tt}?";

            if (MessageBox.Show(confirmMsg, "Confirm", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            try
            {
                using (MySqlConnection conn = new MySqlConnection(_connectionString))
                {
                    conn.Open();

                    if (_existingScheduleId == -1)
                    {
                        // INSERT new schedule
                        string insertQuery = @"
                            INSERT INTO InterviewSchedules
                                (ApplicationID, InterviewDate, Mode, Location, InterviewerName, Status, Notes, ScheduledByUserID, CreatedDate)
                            VALUES
                                (@AppID, @Date, @Mode, @Location, @Interviewer, @Status, @Notes, @UserID, NOW())";

                        MySqlCommand cmd = new MySqlCommand(insertQuery, conn);
                        cmd.Parameters.AddWithValue("@AppID", _applicationId);
                        cmd.Parameters.AddWithValue("@Date", selectedDateTime);
                        cmd.Parameters.AddWithValue("@Mode", cboMode.SelectedItem.ToString());
                        cmd.Parameters.AddWithValue("@Location", txtLocation.Text.Trim());
                        cmd.Parameters.AddWithValue("@Interviewer", txtInterviewerName.Text.Trim());
                        cmd.Parameters.AddWithValue("@Status", cboStatus.SelectedItem.ToString());
                        cmd.Parameters.AddWithValue("@Notes", txtNotes.Text.Trim());
                        cmd.Parameters.AddWithValue("@UserID", _hrUserId);
                        cmd.ExecuteNonQuery();
                    }
                    else
                    {
                        // UPDATE existing
                        string updateQuery = @"
                            UPDATE InterviewSchedules SET
                                InterviewDate = @Date, Mode = @Mode, Location = @Location,
                                InterviewerName = @Interviewer, Status = @Status,
                                Notes = @Notes, ScheduledByUserID = @UserID
                            WHERE InterviewScheduleID = @SchedID";

                        MySqlCommand cmd = new MySqlCommand(updateQuery, conn);
                        cmd.Parameters.AddWithValue("@Date", selectedDateTime);
                        cmd.Parameters.AddWithValue("@Mode", cboMode.SelectedItem.ToString());
                        cmd.Parameters.AddWithValue("@Location", txtLocation.Text.Trim());
                        cmd.Parameters.AddWithValue("@Interviewer", txtInterviewerName.Text.Trim());
                        cmd.Parameters.AddWithValue("@Status", cboStatus.SelectedItem.ToString());
                        cmd.Parameters.AddWithValue("@Notes", txtNotes.Text.Trim());
                        cmd.Parameters.AddWithValue("@UserID", _hrUserId);
                        cmd.Parameters.AddWithValue("@SchedID", _existingScheduleId);
                        cmd.ExecuteNonQuery();
                    }

                    // Update application status to "For Interview"
                    string appUpdate = "UPDATE Applications SET Status = 'For Interview' WHERE ApplicationID = @AppID";
                    MySqlCommand appCmd = new MySqlCommand(appUpdate, conn);
                    appCmd.Parameters.AddWithValue("@AppID", _applicationId);
                    appCmd.ExecuteNonQuery();

                    // Log status history
                    string histQuery = @"
                        INSERT INTO ApplicationStatusHistory
                            (ApplicationID, Status, ChangedByUserID, Remarks, DateChanged)
                        VALUES (@AppID, 'For Interview', @UserID, @Remarks, NOW())";
                    MySqlCommand histCmd = new MySqlCommand(histQuery, conn);
                    histCmd.Parameters.AddWithValue("@AppID", _applicationId);
                    histCmd.Parameters.AddWithValue("@UserID", _hrUserId);
                    histCmd.Parameters.AddWithValue("@Remarks",
                        $"Interview scheduled: {selectedDateTime:MM/dd/yyyy hh:mm tt} via {cboMode.SelectedItem}");
                    histCmd.ExecuteNonQuery();
                }

                MessageBox.Show("Interview schedule saved successfully!", "Saved",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving schedule: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
