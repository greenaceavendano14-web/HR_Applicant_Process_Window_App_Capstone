using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace HRApplicationFormView
{
    public partial class ApplicantReviewForm : Form
    {
        private int _applicationId;
        private int _hrUserId;
        private DBConnection _db;

        // Controls
        private Panel pnlHeader, pnlLeft, pnlRight, pnlBottom;
        private Label lblTitle, lblApplicantName, lblEmail, lblPhone, lblAddress;
        private Label lblEducation, lblSkills, lblWorkExp, lblJobApplied, lblStatus;
        private TextBox txtRemarks;
        private Button btnLockReview, btnQualified, btnNotQualified, btnClose;
        private DataGridView dgvDocuments;
        private PictureBox picApplicant;
        private TabControl tabInfo;
        private TabPage tabPersonal, tabDocuments, tabHistory;
        private DataGridView dgvStatusHistory;

        public ApplicantReviewForm(int applicationId, int hrUserId)
        {
            _applicationId = applicationId;
            _hrUserId      = hrUserId;
            _db            = new DBConnection();
            InitializeComponent();
            LoadApplicantData();
        }

        private void InitializeComponent()
        {
            this.Text            = "Applicant Review - HR";
            this.Size            = new Size(950, 680);
            this.StartPosition   = FormStartPosition.CenterScreen;
            this.BackColor       = Color.FromArgb(245, 247, 250);
            this.Font            = new Font("Segoe UI", 9);

            // Header
            pnlHeader           = new Panel();
            pnlHeader.Dock      = DockStyle.Top;
            pnlHeader.Height    = 60;
            pnlHeader.BackColor = Color.FromArgb(30, 80, 150);

            lblTitle           = new Label();
            lblTitle.Text      = "Applicant Review";
            lblTitle.ForeColor = Color.White;
            lblTitle.Font      = new Font("Segoe UI", 16, FontStyle.Bold);
            lblTitle.AutoSize  = true;
            lblTitle.Location  = new Point(20, 15);
            pnlHeader.Controls.Add(lblTitle);

            // Left panel
            pnlLeft             = new Panel();
            pnlLeft.Location    = new Point(10, 70);
            pnlLeft.Size        = new Size(280, 530);
            pnlLeft.BackColor   = Color.White;
            pnlLeft.BorderStyle = BorderStyle.FixedSingle;

            picApplicant           = new PictureBox();
            picApplicant.Size      = new Size(90, 90);
            picApplicant.Location  = new Point(95, 15);
            picApplicant.BorderStyle = BorderStyle.FixedSingle;
            picApplicant.SizeMode  = PictureBoxSizeMode.StretchImage;
            picApplicant.BackColor = Color.LightGray;

            lblApplicantName           = new Label();
            lblApplicantName.Location  = new Point(10, 115);
            lblApplicantName.Size      = new Size(260, 20);
            lblApplicantName.TextAlign = ContentAlignment.MiddleCenter;
            lblApplicantName.Font      = new Font("Segoe UI", 11, FontStyle.Bold);

            lblEmail           = new Label();
            lblEmail.Location  = new Point(10, 140);
            lblEmail.Size      = new Size(260, 18);
            lblEmail.TextAlign = ContentAlignment.MiddleCenter;
            lblEmail.ForeColor = Color.Gray;

            lblPhone           = new Label();
            lblPhone.Location  = new Point(10, 162);
            lblPhone.Size      = new Size(260, 18);
            lblPhone.TextAlign = ContentAlignment.MiddleCenter;

            lblAddress           = new Label();
            lblAddress.Location  = new Point(10, 185);
            lblAddress.Size      = new Size(260, 35);
            lblAddress.TextAlign = ContentAlignment.MiddleCenter;
            lblAddress.ForeColor = Color.DimGray;

            var sep             = new Label();
            sep.BorderStyle     = BorderStyle.Fixed3D;
            sep.Location        = new Point(10, 228);
            sep.Size            = new Size(260, 2);

            lblJobApplied           = new Label();
            lblJobApplied.Location  = new Point(10, 240);
            lblJobApplied.Size      = new Size(260, 20);
            lblJobApplied.Text      = "Job Applied: Loading...";
            lblJobApplied.Font      = new Font("Segoe UI", 9, FontStyle.Bold);
            lblJobApplied.ForeColor = Color.FromArgb(30, 80, 150);

            lblStatus           = new Label();
            lblStatus.Location  = new Point(10, 268);
            lblStatus.Size      = new Size(260, 22);
            lblStatus.TextAlign = ContentAlignment.MiddleCenter;
            lblStatus.Font      = new Font("Segoe UI", 9, FontStyle.Bold);
            lblStatus.BackColor = Color.FromArgb(255, 243, 205);
            lblStatus.ForeColor = Color.FromArgb(133, 77, 14);

            pnlLeft.Controls.AddRange(new Control[] {
                picApplicant, lblApplicantName, lblEmail, lblPhone,
                lblAddress, sep, lblJobApplied, lblStatus
            });

            // Right panel with tabs
            pnlRight             = new Panel();
            pnlRight.Location    = new Point(300, 70);
            pnlRight.Size        = new Size(635, 530);
            pnlRight.BackColor   = Color.White;
            pnlRight.BorderStyle = BorderStyle.FixedSingle;

            tabInfo      = new TabControl();
            tabInfo.Dock = DockStyle.Fill;

            tabPersonal  = new TabPage("Profile Details");
            tabDocuments = new TabPage("Documents");
            tabHistory   = new TabPage("Status History");

            // Personal info tab
            var personalLayout         = new TableLayoutPanel();
            personalLayout.Dock        = DockStyle.Fill;
            personalLayout.Padding     = new Padding(10);
            personalLayout.RowCount    = 6;
            personalLayout.ColumnCount = 2;

            string[] infoLabels = { "Education:", "Skills:", "Work Experience:", "HR Remarks:" };
            for (int i = 0; i < infoLabels.Length; i++)
            {
                var lbl      = new Label();
                lbl.Text     = infoLabels[i];
                lbl.Font     = new Font("Segoe UI", 9, FontStyle.Bold);
                lbl.Dock     = DockStyle.Fill;
                personalLayout.Controls.Add(lbl, 0, i);
            }

            lblEducation = new Label() { Dock = DockStyle.Fill, Text = "Loading..." };
            lblSkills    = new Label() { Dock = DockStyle.Fill, Text = "Loading..." };
            lblWorkExp   = new Label() { Dock = DockStyle.Fill, Text = "Loading...", AutoSize = false };
            personalLayout.Controls.Add(lblEducation, 1, 0);
            personalLayout.Controls.Add(lblSkills,    1, 1);
            personalLayout.Controls.Add(lblWorkExp,   1, 2);

            var lblRemarksHeader      = new Label();
            lblRemarksHeader.Text     = "HR Remarks:";
            lblRemarksHeader.Font     = new Font("Segoe UI", 9, FontStyle.Bold);
            lblRemarksHeader.Dock     = DockStyle.Fill;
            personalLayout.Controls.Add(lblRemarksHeader, 0, 3);

            txtRemarks             = new TextBox();
            txtRemarks.Multiline   = true;
            txtRemarks.Height      = 80;
            txtRemarks.Dock        = DockStyle.Fill;
            txtRemarks.ScrollBars  = ScrollBars.Vertical;
            txtRemarks.PlaceholderText = "Enter HR review remarks here...";
            personalLayout.Controls.Add(txtRemarks, 1, 3);

            tabPersonal.Controls.Add(personalLayout);

            // Documents tab
            dgvDocuments = new DataGridView();
            dgvDocuments.Dock                           = DockStyle.Fill;
            dgvDocuments.AutoSizeColumnsMode            = DataGridViewAutoSizeColumnsMode.Fill;
            dgvDocuments.ReadOnly                       = true;
            dgvDocuments.AllowUserToAddRows             = false;
            dgvDocuments.BackgroundColor                = Color.White;
            dgvDocuments.BorderStyle                    = BorderStyle.None;
            dgvDocuments.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(30, 80, 150);
            dgvDocuments.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvDocuments.ColumnHeadersDefaultCellStyle.Font      = new Font("Segoe UI", 9, FontStyle.Bold);
            dgvDocuments.Columns.Add("DocType",       "Document Type");
            dgvDocuments.Columns.Add("Status",        "Status");
            dgvDocuments.Columns.Add("Remarks",       "Remarks");
            dgvDocuments.Columns.Add("SubmittedDate", "Submitted Date");
            tabDocuments.Controls.Add(dgvDocuments);

            // Status history tab
            dgvStatusHistory = new DataGridView();
            dgvStatusHistory.Dock                           = DockStyle.Fill;
            dgvStatusHistory.AutoSizeColumnsMode            = DataGridViewAutoSizeColumnsMode.Fill;
            dgvStatusHistory.ReadOnly                       = true;
            dgvStatusHistory.AllowUserToAddRows             = false;
            dgvStatusHistory.BackgroundColor                = Color.White;
            dgvStatusHistory.BorderStyle                    = BorderStyle.None;
            dgvStatusHistory.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(30, 80, 150);
            dgvStatusHistory.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvStatusHistory.ColumnHeadersDefaultCellStyle.Font      = new Font("Segoe UI", 9, FontStyle.Bold);
            dgvStatusHistory.Columns.Add("Status",      "Status");
            dgvStatusHistory.Columns.Add("ChangedBy",   "Changed By");
            dgvStatusHistory.Columns.Add("Remarks",     "Remarks");
            dgvStatusHistory.Columns.Add("DateChanged", "Date Changed");
            tabHistory.Controls.Add(dgvStatusHistory);

            tabInfo.TabPages.AddRange(new TabPage[] { tabPersonal, tabDocuments, tabHistory });
            pnlRight.Controls.Add(tabInfo);

            // Bottom panel
            pnlBottom           = new Panel();
            pnlBottom.Dock      = DockStyle.Bottom;
            pnlBottom.Height    = 55;
            pnlBottom.BackColor = Color.FromArgb(240, 242, 245);

            btnLockReview       = CreateButton("🔒 Lock for Review",  Color.FromArgb(30, 80, 150),  20, 12);
            btnLockReview.Click += BtnLockReview_Click;

            btnQualified        = CreateButton("✔ Mark Qualified",    Color.FromArgb(40, 167, 69), 200, 12);
            btnQualified.Click  += BtnQualified_Click;

            btnNotQualified       = CreateButton("✖ Not Qualified",   Color.FromArgb(220, 53, 69), 380, 12);
            btnNotQualified.Click += BtnNotQualified_Click;

            btnClose       = CreateButton("Close", Color.FromArgb(108, 117, 125), 560, 12);
            btnClose.Click += (s, e) => this.Close();

            pnlBottom.Controls.AddRange(new Control[] { btnLockReview, btnQualified, btnNotQualified, btnClose });

            this.Controls.AddRange(new Control[] { pnlHeader, pnlLeft, pnlRight, pnlBottom });
        }

        private Button CreateButton(string text, Color backColor, int x, int y)
        {
            return new Button()
            {
                Text      = text,
                BackColor = backColor,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Size      = new Size(155, 32),
                Location  = new Point(x, y),
                Font      = new Font("Segoe UI", 9, FontStyle.Bold),
                Cursor    = Cursors.Hand
            };
        }

        private void LoadApplicantData()
        {
            try
            {
                _db.OpenConnection();
                MySqlConnection conn = _db.GetConnection();

                // ── Applicant + application info ─────────────────────────────
                string query = @"
                    SELECT ap.FirstName, ap.LastName,
                           aa.Email,
                           ap.Phone,
                           CONCAT_WS(', ', ap.City, ap.Province, ap.Country) AS Address,
                           CONCAT_WS(' | ', ap.HighestDegree, ap.FieldOfStudy,
                                     ap.SchoolName, ap.GradYear)             AS Education,
                           ap.Skills,
                           ap.WorkExperience,
                           jv.JobTitle,
                           app.CurrentStatus
                    FROM   Applications app
                    JOIN   Applicants        ap  ON app.ApplicantID  = ap.ApplicantID
                    JOIN   ApplicantAccounts aa  ON ap.AccountID     = aa.AccountID
                    JOIN   JobVacancies      jv  ON app.VacancyID    = jv.VacancyID
                    WHERE  app.ApplicationID = @AppID";

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@AppID", _applicationId);
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            lblApplicantName.Text = $"{reader["FirstName"]} {reader["LastName"]}";
                            lblEmail.Text         = reader["Email"].ToString();
                            lblPhone.Text         = reader["Phone"].ToString();
                            lblAddress.Text       = reader["Address"].ToString();
                            lblEducation.Text     = reader["Education"].ToString();
                            lblSkills.Text        = reader["Skills"].ToString();
                            lblWorkExp.Text       = reader["WorkExperience"].ToString();
                            lblJobApplied.Text    = $"Job: {reader["JobTitle"]}";
                            lblStatus.Text        = $"Status: {reader["CurrentStatus"]}";
                        }
                    }
                }

                // ── Documents ────────────────────────────────────────────────
                string docQuery = @"
                    SELECT rt.TypeName         AS DocType,
                           ad.SubmissionStatus AS Status,
                           ad.HRRemarks        AS Remarks,
                           ad.UploadedAt       AS SubmittedDate
                    FROM   ApplicantDocuments ad
                    JOIN   RequirementTypes rt ON ad.RequirementTypeID = rt.RequirementTypeID
                    WHERE  ad.ApplicationID = @AppID";

                dgvDocuments.Rows.Clear();
                using (MySqlCommand docCmd = new MySqlCommand(docQuery, conn))
                {
                    docCmd.Parameters.AddWithValue("@AppID", _applicationId);
                    using (MySqlDataReader docReader = docCmd.ExecuteReader())
                    {
                        while (docReader.Read())
                        {
                            dgvDocuments.Rows.Add(
                                docReader["DocType"],
                                docReader["Status"],
                                docReader["Remarks"],
                                docReader["SubmittedDate"]
                            );
                        }
                    }
                }

                // ── Status history ───────────────────────────────────────────
                string histQuery = @"
                    SELECT ash.NewStatus                              AS Status,
                           COALESCE(CONCAT(u.FirstName,' ',u.LastName),
                                    ash.ChangedByType)               AS ChangedBy,
                           ash.Remarks,
                           ash.ChangedAt                             AS DateChanged
                    FROM   ApplicationStatusHistory ash
                    LEFT JOIN Users u ON ash.ChangedByID = u.UserID
                                     AND ash.ChangedByType IN ('HR Staff','HR Manager','Admin')
                    WHERE  ash.ApplicationID = @AppID
                    ORDER  BY ash.ChangedAt ASC";

                dgvStatusHistory.Rows.Clear();
                using (MySqlCommand histCmd = new MySqlCommand(histQuery, conn))
                {
                    histCmd.Parameters.AddWithValue("@AppID", _applicationId);
                    using (MySqlDataReader histReader = histCmd.ExecuteReader())
                    {
                        while (histReader.Read())
                        {
                            dgvStatusHistory.Rows.Add(
                                histReader["Status"],
                                histReader["ChangedBy"],
                                histReader["Remarks"],
                                histReader["DateChanged"]
                            );
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading applicant data: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                _db.CloseConnection();
            }
        }

        private void BtnLockReview_Click(object sender, EventArgs e)
        {
            var confirm = MessageBox.Show(
                "Lock this application for review? The applicant will no longer be able to edit.",
                "Confirm Lock", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirm == DialogResult.Yes)
            {
                UpdateApplicationStatus("Under Review", "Application locked for HR review.");
                MessageBox.Show("Application is now Under Review.", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                lblStatus.Text = "Status: Under Review";
            }
        }

        private void BtnQualified_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtRemarks.Text))
            {
                MessageBox.Show("Please enter HR remarks before proceeding.", "Remarks Required",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var confirm = MessageBox.Show("Mark this applicant as Shortlisted (Qualified)?",
                "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirm == DialogResult.Yes)
            {
                SaveScreeningResult(true);
                UpdateApplicationStatus("Shortlisted", txtRemarks.Text);
                MessageBox.Show("Applicant marked as Qualified and Shortlisted.", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                lblStatus.Text = "Status: Shortlisted";
            }
        }

        private void BtnNotQualified_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtRemarks.Text))
            {
                MessageBox.Show("Please enter HR remarks before proceeding.", "Remarks Required",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var confirm = MessageBox.Show("Mark this applicant as NOT Qualified?",
                "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (confirm == DialogResult.Yes)
            {
                SaveScreeningResult(false);
                UpdateApplicationStatus("Rejected", txtRemarks.Text);
                MessageBox.Show("Applicant marked as Not Qualified.", "Done",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                lblStatus.Text = "Status: Rejected";
            }
        }

        private void SaveScreeningResult(bool isQualified)
        {
            try
            {
                _db.OpenConnection();
                MySqlConnection conn = _db.GetConnection();

                // ScreeningResults uses Result ENUM('Qualified','Not Qualified')
                string query = @"
                    INSERT INTO ScreeningResults
                        (ApplicationID, ScreenedByUserID, Result, Remarks, ScreenedAt)
                    VALUES
                        (@AppID, @UserID, @Result, @Remarks, NOW())
                    ON DUPLICATE KEY UPDATE
                        Result           = @Result,
                        Remarks          = @Remarks,
                        ScreenedByUserID = @UserID,
                        ScreenedAt       = NOW()";

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@AppID",   _applicationId);
                    cmd.Parameters.AddWithValue("@UserID",  _hrUserId);
                    cmd.Parameters.AddWithValue("@Result",  isQualified ? "Qualified" : "Not Qualified");
                    cmd.Parameters.AddWithValue("@Remarks", txtRemarks.Text.Trim());
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving screening result: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                _db.CloseConnection();
            }
        }

        private void UpdateApplicationStatus(string newStatus, string remarks)
        {
            try
            {
                _db.OpenConnection();
                MySqlConnection conn = _db.GetConnection();

                // Get old status first
                string oldStatus = "";
                using (MySqlCommand getCmd = new MySqlCommand(
                    "SELECT CurrentStatus FROM Applications WHERE ApplicationID = @AppID", conn))
                {
                    getCmd.Parameters.AddWithValue("@AppID", _applicationId);
                    oldStatus = getCmd.ExecuteScalar()?.ToString() ?? "";
                }

                // Update application status
                using (MySqlCommand updateCmd = new MySqlCommand(
                    "UPDATE Applications SET CurrentStatus = @Status WHERE ApplicationID = @AppID", conn))
                {
                    updateCmd.Parameters.AddWithValue("@Status", newStatus);
                    updateCmd.Parameters.AddWithValue("@AppID",  _applicationId);
                    updateCmd.ExecuteNonQuery();
                }

                // Insert status history
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
                    histCmd.Parameters.AddWithValue("@Remarks",   remarks);
                    histCmd.ExecuteNonQuery();
                }

                LoadApplicantData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating status: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                _db.CloseConnection();
            }
        }
    }
}
