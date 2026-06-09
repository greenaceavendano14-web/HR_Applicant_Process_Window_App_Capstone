using System;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace HRApplicationFormView
{
    public partial class InterviewScheduleForm : Form
    {
        private int _applicationId;
        private int _hrUserId;
        private int _existingScheduleId = -1;
        private DBConnection _db;

        // Controls
        private Panel pnlHeader, pnlContent, pnlBottom;
        private Label lblTitle, lblApplicantName, lblJobTitle, lblCurrentStatus;
        private GroupBox grpSchedule, grpInterviewer, grpNotes;

        // Schedule fields
        private DateTimePicker dtpDate, dtpTime;
        private ComboBox cboMode, cboStatus, cboInterviewType;
        private TextBox txtLocation, txtMeetingLink, txtNotes;
        private Label lblExistingNote;

        // Buttons
        private Button btnSave, btnCancel;

        public InterviewScheduleForm(int applicationId, int hrUserId)
        {
            _applicationId = applicationId;
            _hrUserId      = hrUserId;
            _db            = new DBConnection();
            InitializeComponent();
            LoadInterviewTypes();
            LoadApplicationInfo();
            LoadExistingSchedule();
        }

        private void InitializeComponent()
        {
            this.Text            = "Interview Schedule - HR";
            this.Size            = new Size(580, 640);
            this.StartPosition   = FormStartPosition.CenterScreen;
            this.BackColor       = Color.FromArgb(245, 247, 250);
            this.Font            = new Font("Segoe UI", 9);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox     = false;

            // Header
            pnlHeader           = new Panel();
            pnlHeader.Dock      = DockStyle.Top;
            pnlHeader.Height    = 60;
            pnlHeader.BackColor = Color.FromArgb(30, 80, 150);

            lblTitle           = new Label();
            lblTitle.Text      = "Interview Schedule";
            lblTitle.ForeColor = Color.White;
            lblTitle.Font      = new Font("Segoe UI", 15, FontStyle.Bold);
            lblTitle.AutoSize  = true;
            lblTitle.Location  = new Point(20, 16);
            pnlHeader.Controls.Add(lblTitle);

            // Content panel
            pnlContent          = new Panel();
            pnlContent.Location = new Point(15, 70);
            pnlContent.Size     = new Size(542, 510);

            // Applicant info bar
            var pnlInfo         = new Panel();
            pnlInfo.Location    = new Point(0, 0);
            pnlInfo.Size        = new Size(542, 65);
            pnlInfo.BackColor   = Color.White;
            pnlInfo.BorderStyle = BorderStyle.FixedSingle;

            lblApplicantName          = new Label();
            lblApplicantName.Location = new Point(10, 8);
            lblApplicantName.Size     = new Size(360, 20);
            lblApplicantName.Font     = new Font("Segoe UI", 10, FontStyle.Bold);
            lblApplicantName.Text     = "Loading...";

            lblJobTitle          = new Label();
            lblJobTitle.Location = new Point(10, 30);
            lblJobTitle.Size     = new Size(360, 18);
            lblJobTitle.ForeColor = Color.FromArgb(30, 80, 150);

            lblCurrentStatus           = new Label();
            lblCurrentStatus.Location  = new Point(385, 20);
            lblCurrentStatus.Size      = new Size(145, 24);
            lblCurrentStatus.TextAlign = ContentAlignment.MiddleCenter;
            lblCurrentStatus.Font      = new Font("Segoe UI", 8, FontStyle.Bold);
            lblCurrentStatus.BackColor = Color.FromArgb(209, 236, 241);
            lblCurrentStatus.ForeColor = Color.FromArgb(12, 84, 96);

            pnlInfo.Controls.AddRange(new Control[] { lblApplicantName, lblJobTitle, lblCurrentStatus });

            // Schedule group
            grpSchedule           = new GroupBox();
            grpSchedule.Text      = "Interview Schedule Details";
            grpSchedule.Location  = new Point(0, 75);
            grpSchedule.Size      = new Size(542, 230);
            grpSchedule.BackColor = Color.White;
            grpSchedule.Font      = new Font("Segoe UI", 9, FontStyle.Bold);

            // Interview Type
            AddFormLabel(grpSchedule, "Interview Type:", 15, 28);
            cboInterviewType              = new ComboBox();
            cboInterviewType.Location     = new Point(160, 26);
            cboInterviewType.Size         = new Size(210, 26);
            cboInterviewType.DropDownStyle = ComboBoxStyle.DropDownList;
            grpSchedule.Controls.Add(cboInterviewType);

            // Date
            AddFormLabel(grpSchedule, "Interview Date:", 15, 63);
            dtpDate          = new DateTimePicker();
            dtpDate.Location = new Point(160, 61);
            dtpDate.Size     = new Size(175, 26);
            dtpDate.Format   = DateTimePickerFormat.Short;
            dtpDate.MinDate  = DateTime.Today;
            grpSchedule.Controls.Add(dtpDate);

            // Time
            AddFormLabel(grpSchedule, "Time:", 15, 98);
            dtpTime          = new DateTimePicker();
            dtpTime.Location = new Point(160, 96);
            dtpTime.Size     = new Size(130, 26);
            dtpTime.Format   = DateTimePickerFormat.Time;
            dtpTime.ShowUpDown = true;
            dtpTime.Value    = DateTime.Today.AddHours(9);
            grpSchedule.Controls.Add(dtpTime);

            // Mode
            AddFormLabel(grpSchedule, "Mode:", 15, 133);
            cboMode              = new ComboBox();
            cboMode.Location     = new Point(160, 131);
            cboMode.Size         = new Size(175, 26);
            cboMode.DropDownStyle = ComboBoxStyle.DropDownList;
            // Values match the DB ENUM: Face-to-Face, Online, Phone
            cboMode.Items.AddRange(new string[] { "Face-to-Face", "Online", "Phone" });
            cboMode.SelectedIndex = 0;
            grpSchedule.Controls.Add(cboMode);

            // Location
            AddFormLabel(grpSchedule, "Location:", 15, 168);
            txtLocation                 = new TextBox();
            txtLocation.Location        = new Point(160, 166);
            txtLocation.Size            = new Size(368, 26);
            txtLocation.Font            = new Font("Segoe UI", 9);
            txtLocation.PlaceholderText = "Office room, building, address...";
            grpSchedule.Controls.Add(txtLocation);

            // Meeting Link
            AddFormLabel(grpSchedule, "Meeting Link:", 15, 203);
            txtMeetingLink                 = new TextBox();
            txtMeetingLink.Location        = new Point(160, 201);
            txtMeetingLink.Size            = new Size(368, 26);
            txtMeetingLink.Font            = new Font("Segoe UI", 9);
            txtMeetingLink.PlaceholderText = "https://meet.google.com/... (optional for online)";
            grpSchedule.Controls.Add(txtMeetingLink);

            // Schedule status group — reuses grpInterviewer slot
            grpInterviewer           = new GroupBox();
            grpInterviewer.Text      = "Schedule Status";
            grpInterviewer.Location  = new Point(0, 315);
            grpInterviewer.Size      = new Size(542, 60);
            grpInterviewer.BackColor = Color.White;
            grpInterviewer.Font      = new Font("Segoe UI", 9, FontStyle.Bold);

            AddFormLabel(grpInterviewer, "Status:", 15, 28);
            cboStatus              = new ComboBox();
            cboStatus.Location     = new Point(160, 26);
            cboStatus.Size         = new Size(175, 26);
            cboStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            // Values match DB ENUM: Scheduled, Completed, Cancelled, Rescheduled
            cboStatus.Items.AddRange(new string[] { "Scheduled", "Completed", "Cancelled", "Rescheduled" });
            cboStatus.SelectedIndex = 0;
            grpInterviewer.Controls.Add(cboStatus);

            // Notes group
            grpNotes           = new GroupBox();
            grpNotes.Text      = "Notes / Instructions for Applicant";
            grpNotes.Location  = new Point(0, 385);
            grpNotes.Size      = new Size(542, 100);
            grpNotes.BackColor = Color.White;
            grpNotes.Font      = new Font("Segoe UI", 9, FontStyle.Bold);

            txtNotes                 = new TextBox();
            txtNotes.Location        = new Point(10, 25);
            txtNotes.Size            = new Size(518, 65);
            txtNotes.Multiline       = true;
            txtNotes.ScrollBars      = ScrollBars.Vertical;
            txtNotes.Font            = new Font("Segoe UI", 9);
            txtNotes.PlaceholderText = "Optional: Documents to bring, dress code, instructions...";
            grpNotes.Controls.Add(txtNotes);

            // Existing schedule note
            lblExistingNote          = new Label();
            lblExistingNote.Location = new Point(0, 492);
            lblExistingNote.Size     = new Size(542, 18);
            lblExistingNote.ForeColor = Color.Gray;
            lblExistingNote.Font     = new Font("Segoe UI", 8, FontStyle.Italic);

            pnlContent.Controls.AddRange(new Control[] {
                pnlInfo, grpSchedule, grpInterviewer, grpNotes, lblExistingNote
            });

            // Bottom buttons
            pnlBottom           = new Panel();
            pnlBottom.Dock      = DockStyle.Bottom;
            pnlBottom.Height    = 55;
            pnlBottom.BackColor = Color.FromArgb(240, 242, 245);

            btnSave             = new Button();
            btnSave.Text        = "Save Schedule";
            btnSave.Size        = new Size(150, 32);
            btnSave.Location    = new Point(195, 12);
            btnSave.BackColor   = Color.FromArgb(30, 80, 150);
            btnSave.ForeColor   = Color.White;
            btnSave.FlatStyle   = FlatStyle.Flat;
            btnSave.Font        = new Font("Segoe UI", 9, FontStyle.Bold);
            btnSave.Cursor      = Cursors.Hand;
            btnSave.Click      += BtnSave_Click;

            btnCancel           = new Button();
            btnCancel.Text      = "Cancel";
            btnCancel.Size      = new Size(100, 32);
            btnCancel.Location  = new Point(355, 12);
            btnCancel.BackColor = Color.FromArgb(108, 117, 125);
            btnCancel.ForeColor = Color.White;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.Font      = new Font("Segoe UI", 9, FontStyle.Bold);
            btnCancel.Cursor    = Cursors.Hand;
            btnCancel.Click    += (s, e) => this.Close();

            pnlBottom.Controls.AddRange(new Control[] { btnSave, btnCancel });

            this.Controls.AddRange(new Control[] { pnlHeader, pnlContent, pnlBottom });
        }

        private void AddFormLabel(Control parent, string text, int x, int y)
        {
            var lbl      = new Label();
            lbl.Text     = text;
            lbl.Location = new Point(x, y + 3);
            lbl.Size     = new Size(140, 20);
            lbl.Font     = new Font("Segoe UI", 9);
            parent.Controls.Add(lbl);
        }

        /// <summary>Populate the Interview Type combo from the InterviewTypes table.</summary>
        private void LoadInterviewTypes()
        {
            try
            {
                _db.OpenConnection();
                MySqlConnection conn = _db.GetConnection();

                string query = "SELECT InterviewTypeID, TypeName FROM InterviewTypes WHERE IsActive = 1 ORDER BY TypeName";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        cboInterviewType.Items.Add(new ComboItem(
                            reader["TypeName"].ToString(),
                            Convert.ToInt32(reader["InterviewTypeID"])
                        ));
                    }
                }

                if (cboInterviewType.Items.Count > 0)
                    cboInterviewType.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading interview types: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                _db.CloseConnection();
            }
        }

        private void LoadApplicationInfo()
        {
            try
            {
                _db.OpenConnection();
                MySqlConnection conn = _db.GetConnection();

                string query = @"
                    SELECT CONCAT(ap.FirstName,' ',ap.LastName) AS FullName,
                           jv.JobTitle,
                           app.CurrentStatus                    AS Status
                    FROM   Applications app
                    JOIN   Applicants   ap ON app.ApplicantID = ap.ApplicantID
                    JOIN   JobVacancies jv ON app.VacancyID   = jv.VacancyID
                    WHERE  app.ApplicationID = @AppID";

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@AppID", _applicationId);
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            lblApplicantName.Text  = reader["FullName"].ToString();
                            lblJobTitle.Text        = "Job: " + reader["JobTitle"].ToString();
                            lblCurrentStatus.Text   = reader["Status"].ToString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading application: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                _db.CloseConnection();
            }
        }

        private void LoadExistingSchedule()
        {
            try
            {
                _db.OpenConnection();
                MySqlConnection conn = _db.GetConnection();

                // InterviewSchedules columns:
                //   ScheduleID, ApplicationID, InterviewTypeID, InterviewerUserID,
                //   ScheduledDate, ScheduledTime, Mode, Location, MeetingLink, Status
                string query = @"
                    SELECT ScheduleID, InterviewTypeID,
                           ScheduledDate, ScheduledTime,
                           Mode, Location, MeetingLink, Status
                    FROM   InterviewSchedules
                    WHERE  ApplicationID = @AppID
                    ORDER  BY ScheduledDate DESC
                    LIMIT  1";

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@AppID", _applicationId);
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            _existingScheduleId = Convert.ToInt32(reader["ScheduleID"]);

                            DateTime date     = Convert.ToDateTime(reader["ScheduledDate"]);
                            TimeSpan time     = (TimeSpan)reader["ScheduledTime"];
                            dtpDate.Value     = date.Date;
                            dtpTime.Value     = DateTime.Today.Date.Add(time);

                            // Select matching interview type in combo
                            int typeId = Convert.ToInt32(reader["InterviewTypeID"]);
                            foreach (ComboItem item in cboInterviewType.Items)
                            {
                                if (item.Value == typeId)
                                {
                                    cboInterviewType.SelectedItem = item;
                                    break;
                                }
                            }

                            // Mode — match the ENUM value
                            string mode = reader["Mode"].ToString();
                            if (cboMode.Items.Contains(mode))
                                cboMode.SelectedItem = mode;

                            txtLocation.Text    = reader["Location"]?.ToString() ?? "";
                            txtMeetingLink.Text = reader["MeetingLink"]?.ToString() ?? "";

                            string status = reader["Status"].ToString();
                            if (cboStatus.Items.Contains(status))
                                cboStatus.SelectedItem = status;

                            lblExistingNote.Text =
                                $"Existing schedule found (ID #{_existingScheduleId}). Saving will update it.";
                        }
                    }
                }
            }
            catch { /* No existing schedule — that's fine */ }
            finally
            {
                _db.CloseConnection();
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (cboInterviewType.SelectedItem == null)
            {
                MessageBox.Show("Please select an interview type.", "Required Field",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DateTime selectedDate     = dtpDate.Value.Date;
            TimeSpan selectedTime     = dtpTime.Value.TimeOfDay;
            DateTime selectedDateTime = selectedDate.Add(selectedTime);

            if (selectedDateTime < DateTime.Now && cboStatus.SelectedItem?.ToString() == "Scheduled")
            {
                MessageBox.Show("Interview date and time cannot be in the past for a Scheduled interview.",
                    "Invalid Date", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtLocation.Text) &&
                string.IsNullOrWhiteSpace(txtMeetingLink.Text))
            {
                MessageBox.Show("Please enter a location or a meeting link.", "Required Field",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int    interviewTypeId = ((ComboItem)cboInterviewType.SelectedItem).Value;
            string confirmMsg      = _existingScheduleId == -1
                ? $"Schedule interview on {selectedDateTime:MM/dd/yyyy hh:mm tt}?"
                : $"Update existing interview schedule to {selectedDateTime:MM/dd/yyyy hh:mm tt}?";

            if (MessageBox.Show(confirmMsg, "Confirm",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            try
            {
                _db.OpenConnection();
                MySqlConnection conn = _db.GetConnection();

                if (_existingScheduleId == -1)
                {
                    // INSERT new schedule
                    // InterviewerUserID = the HR user saving the schedule
                    string insertQuery = @"
                        INSERT INTO InterviewSchedules
                            (ApplicationID, InterviewTypeID, InterviewerUserID,
                             ScheduledDate, ScheduledTime, Mode,
                             Location, MeetingLink, Status, CreatedByUserID)
                        VALUES
                            (@AppID, @TypeID, @InterviewerID,
                             @Date, @Time, @Mode,
                             @Location, @Link, @Status, @CreatedBy)";

                    using (MySqlCommand cmd = new MySqlCommand(insertQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@AppID",       _applicationId);
                        cmd.Parameters.AddWithValue("@TypeID",      interviewTypeId);
                        cmd.Parameters.AddWithValue("@InterviewerID", _hrUserId);
                        cmd.Parameters.AddWithValue("@Date",        selectedDate.ToString("yyyy-MM-dd"));
                        cmd.Parameters.AddWithValue("@Time",        selectedTime.ToString(@"hh\:mm\:ss"));
                        cmd.Parameters.AddWithValue("@Mode",        cboMode.SelectedItem.ToString());
                        cmd.Parameters.AddWithValue("@Location",    txtLocation.Text.Trim());
                        cmd.Parameters.AddWithValue("@Link",        txtMeetingLink.Text.Trim());
                        cmd.Parameters.AddWithValue("@Status",      cboStatus.SelectedItem.ToString());
                        cmd.Parameters.AddWithValue("@CreatedBy",   _hrUserId);
                        cmd.ExecuteNonQuery();
                    }
                }
                else
                {
                    // UPDATE existing
                    string updateQuery = @"
                        UPDATE InterviewSchedules SET
                            InterviewTypeID   = @TypeID,
                            InterviewerUserID = @InterviewerID,
                            ScheduledDate     = @Date,
                            ScheduledTime     = @Time,
                            Mode              = @Mode,
                            Location          = @Location,
                            MeetingLink       = @Link,
                            Status            = @Status
                        WHERE ScheduleID = @SchedID";

                    using (MySqlCommand cmd = new MySqlCommand(updateQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@TypeID",      interviewTypeId);
                        cmd.Parameters.AddWithValue("@InterviewerID", _hrUserId);
                        cmd.Parameters.AddWithValue("@Date",        selectedDate.ToString("yyyy-MM-dd"));
                        cmd.Parameters.AddWithValue("@Time",        selectedTime.ToString(@"hh\:mm\:ss"));
                        cmd.Parameters.AddWithValue("@Mode",        cboMode.SelectedItem.ToString());
                        cmd.Parameters.AddWithValue("@Location",    txtLocation.Text.Trim());
                        cmd.Parameters.AddWithValue("@Link",        txtMeetingLink.Text.Trim());
                        cmd.Parameters.AddWithValue("@Status",      cboStatus.SelectedItem.ToString());
                        cmd.Parameters.AddWithValue("@SchedID",     _existingScheduleId);
                        cmd.ExecuteNonQuery();
                    }
                }

                // Get old status for history
                string oldStatus = "";
                using (MySqlCommand getCmd = new MySqlCommand(
                    "SELECT CurrentStatus FROM Applications WHERE ApplicationID = @AppID", conn))
                {
                    getCmd.Parameters.AddWithValue("@AppID", _applicationId);
                    oldStatus = getCmd.ExecuteScalar()?.ToString() ?? "";
                }

                // Update application status to For Interview
                using (MySqlCommand appCmd = new MySqlCommand(
                    "UPDATE Applications SET CurrentStatus = 'For Interview' WHERE ApplicationID = @AppID", conn))
                {
                    appCmd.Parameters.AddWithValue("@AppID", _applicationId);
                    appCmd.ExecuteNonQuery();
                }

                // Log status history
                string histQuery = @"
                    INSERT INTO ApplicationStatusHistory
                        (ApplicationID, OldStatus, NewStatus, ChangedByType, ChangedByID, Remarks)
                    VALUES
                        (@AppID, @OldStatus, 'For Interview', 'HR Staff', @UserID, @Remarks)";

                using (MySqlCommand histCmd = new MySqlCommand(histQuery, conn))
                {
                    histCmd.Parameters.AddWithValue("@AppID",     _applicationId);
                    histCmd.Parameters.AddWithValue("@OldStatus", oldStatus);
                    histCmd.Parameters.AddWithValue("@UserID",    _hrUserId);
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
                MessageBox.Show("Error saving schedule: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                _db.CloseConnection();
            }
        }

        // ─── Helper class for ComboBox items that carry an int ID ───────────
        private class ComboItem
        {
            public string Text  { get; }
            public int    Value { get; }
            public ComboItem(string text, int value) { Text = text; Value = value; }
            public override string ToString() => Text;
        }
    }
}
