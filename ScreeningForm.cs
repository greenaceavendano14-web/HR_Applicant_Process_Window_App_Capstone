using System;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace HRApplicationFormView
{
    public partial class ScreeningForm : Form
    {
        private int _applicationId;
        private int _hrUserId;
        private DBConnection _db;

        // Controls
        private Panel pnlHeader, pnlContent, pnlBottom;
        private Label lblTitle, lblApplicantInfo, lblJobTitle;
        private RadioButton rbQualified, rbNotQualified;
        private TextBox txtRemarks;
        private CheckedListBox chkQualifications;
        private Button btnSave, btnCancel;
        private Label lblExistingResult, lblStatus;
        private GroupBox grpQualifications, grpDecision, grpRemarks;

        public ScreeningForm(int applicationId, int hrUserId)
        {
            _applicationId = applicationId;
            _hrUserId      = hrUserId;
            _db            = new DBConnection();
            InitializeComponent();
            LoadApplicationInfo();
            LoadExistingScreening();
        }

        private void InitializeComponent()
        {
            this.Text            = "Screening - HR";
            this.Size            = new Size(580, 620);
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
            lblTitle.Text      = "Applicant Screening";
            lblTitle.ForeColor = Color.White;
            lblTitle.Font      = new Font("Segoe UI", 15, FontStyle.Bold);
            lblTitle.AutoSize  = true;
            lblTitle.Location  = new Point(20, 16);
            pnlHeader.Controls.Add(lblTitle);

            // Content panel
            pnlContent          = new Panel();
            pnlContent.Location = new Point(15, 70);
            pnlContent.Size     = new Size(545, 480);

            var pnlInfo             = new Panel();
            pnlInfo.Location        = new Point(0, 0);
            pnlInfo.Size            = new Size(545, 60);
            pnlInfo.BackColor       = Color.White;
            pnlInfo.BorderStyle     = BorderStyle.FixedSingle;

            lblApplicantInfo          = new Label();
            lblApplicantInfo.Location = new Point(10, 8);
            lblApplicantInfo.Size     = new Size(390, 20);
            lblApplicantInfo.Font     = new Font("Segoe UI", 10, FontStyle.Bold);
            lblApplicantInfo.Text     = "Loading applicant...";

            lblJobTitle          = new Label();
            lblJobTitle.Location = new Point(10, 32);
            lblJobTitle.Size     = new Size(390, 18);
            lblJobTitle.ForeColor = Color.FromArgb(30, 80, 150);
            lblJobTitle.Text     = "Job: Loading...";

            lblStatus           = new Label();
            lblStatus.Location  = new Point(400, 18);
            lblStatus.Size      = new Size(135, 24);
            lblStatus.TextAlign = ContentAlignment.MiddleCenter;
            lblStatus.Font      = new Font("Segoe UI", 8, FontStyle.Bold);
            lblStatus.BackColor = Color.FromArgb(255, 243, 205);
            lblStatus.ForeColor = Color.FromArgb(133, 77, 14);
            lblStatus.Text      = "Status: ...";

            pnlInfo.Controls.AddRange(new Control[] { lblApplicantInfo, lblJobTitle, lblStatus });

            // Qualifications checklist
            grpQualifications           = new GroupBox();
            grpQualifications.Text      = "Qualification Checklist";
            grpQualifications.Location  = new Point(0, 70);
            grpQualifications.Size      = new Size(545, 150);
            grpQualifications.Font      = new Font("Segoe UI", 9, FontStyle.Bold);
            grpQualifications.BackColor = Color.White;

            chkQualifications             = new CheckedListBox();
            chkQualifications.Location    = new Point(10, 25);
            chkQualifications.Size        = new Size(520, 115);
            chkQualifications.BorderStyle = BorderStyle.None;
            chkQualifications.Font        = new Font("Segoe UI", 9);
            chkQualifications.Items.AddRange(new string[]
            {
                "Complete application form submitted",
                "All required documents uploaded",
                "Educational qualifications met",
                "Work experience requirements met",
                "Skills match job requirements",
                "No duplicate application detected"
            });
            grpQualifications.Controls.Add(chkQualifications);

            // Decision group
            grpDecision           = new GroupBox();
            grpDecision.Text      = "Screening Decision";
            grpDecision.Location  = new Point(0, 230);
            grpDecision.Size      = new Size(545, 75);
            grpDecision.Font      = new Font("Segoe UI", 9, FontStyle.Bold);
            grpDecision.BackColor = Color.White;

            rbQualified          = new RadioButton();
            rbQualified.Text     = "✔  Qualified — Move to Shortlisted";
            rbQualified.Location = new Point(15, 28);
            rbQualified.Size     = new Size(240, 25);
            rbQualified.Font     = new Font("Segoe UI", 9);
            rbQualified.ForeColor = Color.FromArgb(40, 167, 69);

            rbNotQualified          = new RadioButton();
            rbNotQualified.Text     = "✖  Not Qualified — Reject Application";
            rbNotQualified.Location = new Point(270, 28);
            rbNotQualified.Size     = new Size(260, 25);
            rbNotQualified.Font     = new Font("Segoe UI", 9);
            rbNotQualified.ForeColor = Color.FromArgb(220, 53, 69);

            grpDecision.Controls.AddRange(new Control[] { rbQualified, rbNotQualified });

            // Remarks group
            grpRemarks           = new GroupBox();
            grpRemarks.Text      = "Screening Remarks";
            grpRemarks.Location  = new Point(0, 315);
            grpRemarks.Size      = new Size(545, 120);
            grpRemarks.Font      = new Font("Segoe UI", 9, FontStyle.Bold);
            grpRemarks.BackColor = Color.White;

            txtRemarks                 = new TextBox();
            txtRemarks.Location        = new Point(10, 25);
            txtRemarks.Size            = new Size(522, 82);
            txtRemarks.Multiline       = true;
            txtRemarks.ScrollBars      = ScrollBars.Vertical;
            txtRemarks.Font            = new Font("Segoe UI", 9);
            txtRemarks.PlaceholderText = "Enter screening remarks (required)...";
            grpRemarks.Controls.Add(txtRemarks);

            lblExistingResult          = new Label();
            lblExistingResult.Location = new Point(0, 445);
            lblExistingResult.Size     = new Size(545, 20);
            lblExistingResult.ForeColor = Color.Gray;
            lblExistingResult.Font     = new Font("Segoe UI", 8, FontStyle.Italic);
            lblExistingResult.Text     = "";

            pnlContent.Controls.AddRange(new Control[] {
                pnlInfo, grpQualifications, grpDecision, grpRemarks, lblExistingResult
            });

            // Bottom buttons
            pnlBottom           = new Panel();
            pnlBottom.Dock      = DockStyle.Bottom;
            pnlBottom.Height    = 55;
            pnlBottom.BackColor = Color.FromArgb(240, 242, 245);

            btnSave             = new Button();
            btnSave.Text        = "Save Screening Result";
            btnSave.Size        = new Size(180, 32);
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
            btnCancel.Location  = new Point(385, 12);
            btnCancel.BackColor = Color.FromArgb(108, 117, 125);
            btnCancel.ForeColor = Color.White;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.Font      = new Font("Segoe UI", 9, FontStyle.Bold);
            btnCancel.Cursor    = Cursors.Hand;
            btnCancel.Click    += (s, e) => this.Close();

            pnlBottom.Controls.AddRange(new Control[] { btnSave, btnCancel });

            this.Controls.AddRange(new Control[] { pnlHeader, pnlContent, pnlBottom });
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
                            lblApplicantInfo.Text = reader["FullName"].ToString();
                            lblJobTitle.Text      = "Job: " + reader["JobTitle"].ToString();
                            lblStatus.Text        = "Status: " + reader["Status"].ToString();
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

        private void LoadExistingScreening()
        {
            try
            {
                _db.OpenConnection();
                MySqlConnection conn = _db.GetConnection();

                string query = @"
                    SELECT Result, Remarks, ScreenedAt
                    FROM   ScreeningResults
                    WHERE  ApplicationID = @AppID
                    LIMIT  1";

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@AppID", _applicationId);
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            bool isQualified      = reader["Result"].ToString() == "Qualified";
                            rbQualified.Checked    = isQualified;
                            rbNotQualified.Checked = !isQualified;
                            txtRemarks.Text        = reader["Remarks"].ToString();
                            lblExistingResult.Text =
                                $"Previous screening on {reader["ScreenedAt"]:MM/dd/yyyy hh:mm tt}";
                        }
                    }
                }
            }
            catch { /* No existing record — that's fine */ }
            finally
            {
                _db.CloseConnection();
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (!rbQualified.Checked && !rbNotQualified.Checked)
            {
                MessageBox.Show("Please select a screening decision (Qualified or Not Qualified).",
                    "Decision Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtRemarks.Text))
            {
                MessageBox.Show("Please enter screening remarks.", "Remarks Required",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            bool   isQualified = rbQualified.Checked;
            string newStatus   = isQualified ? "Shortlisted" : "Rejected";
            string confirmMsg  = isQualified
                ? "Mark this applicant as QUALIFIED and move to Shortlisted?"
                : "Mark this applicant as NOT QUALIFIED and Reject?";

            if (MessageBox.Show(confirmMsg, "Confirm Screening",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            try
            {
                _db.OpenConnection();
                MySqlConnection conn = _db.GetConnection();

                // Get old status
                string oldStatus = "";
                using (MySqlCommand getCmd = new MySqlCommand(
                    "SELECT CurrentStatus FROM Applications WHERE ApplicationID = @AppID", conn))
                {
                    getCmd.Parameters.AddWithValue("@AppID", _applicationId);
                    oldStatus = getCmd.ExecuteScalar()?.ToString() ?? "";
                }

                // Save / update screening result
                string insertQuery = @"
                    INSERT INTO ScreeningResults
                        (ApplicationID, ScreenedByUserID, Result, Remarks, ScreenedAt)
                    VALUES
                        (@AppID, @UserID, @Result, @Remarks, NOW())
                    ON DUPLICATE KEY UPDATE
                        Result           = @Result,
                        Remarks          = @Remarks,
                        ScreenedByUserID = @UserID,
                        ScreenedAt       = NOW()";

                using (MySqlCommand insertCmd = new MySqlCommand(insertQuery, conn))
                {
                    insertCmd.Parameters.AddWithValue("@AppID",   _applicationId);
                    insertCmd.Parameters.AddWithValue("@UserID",  _hrUserId);
                    insertCmd.Parameters.AddWithValue("@Result",  isQualified ? "Qualified" : "Not Qualified");
                    insertCmd.Parameters.AddWithValue("@Remarks", txtRemarks.Text.Trim());
                    insertCmd.ExecuteNonQuery();
                }

                // Update application status
                using (MySqlCommand updateCmd = new MySqlCommand(
                    "UPDATE Applications SET CurrentStatus = @Status WHERE ApplicationID = @AppID", conn))
                {
                    updateCmd.Parameters.AddWithValue("@Status", newStatus);
                    updateCmd.Parameters.AddWithValue("@AppID",  _applicationId);
                    updateCmd.ExecuteNonQuery();
                }

                // Log in status history
                string histQuery = @"
                    INSERT INTO ApplicationStatusHistory
                        (ApplicationID, OldStatus, NewStatus, ChangedByType, ChangedByID, Remarks)
                    VALUES
                        (@AppID, @OldStatus, @NewStatus, 'HR Staff', @UserID, @Remarks)";

                using (MySqlCommand histCmd = new MySqlCommand(histQuery, conn))
                {
                    histCmd.Parameters.AddWithValue("@AppID",     _applicationId);
                    histCmd.Parameters.AddWithValue("@OldStatus", oldStatus);
                    histCmd.Parameters.AddWithValue("@NewStatus", newStatus);
                    histCmd.Parameters.AddWithValue("@UserID",    _hrUserId);
                    histCmd.Parameters.AddWithValue("@Remarks",   txtRemarks.Text.Trim());
                    histCmd.ExecuteNonQuery();
                }

                MessageBox.Show($"Screening saved. Applicant is now: {newStatus}", "Saved",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving screening: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                _db.CloseConnection();
            }
        }
    }
}
