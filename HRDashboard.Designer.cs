namespace HRApplicantSystem
{
    partial class HRDashboard
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HRDashboard));
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            panelTop = new Panel();
            lblTime = new Label();
            label3 = new Label();
            lblDate = new Label();
            lblRole = new Label();
            lblGreeting = new Label();
            lblRecruitment = new Label();
            pictureBoxLogo = new PictureBox();
            panelMenu = new Panel();
            btnApplicants = new Button();
            btnApplications = new Button();
            btnJobs = new Button();
            btnHiring = new Button();
            btnReports = new Button();
            btnAuditTrail = new Button();
            btnUsers = new Button();
            btnLogout = new Button();
            btnDashboard = new Button();
            timerClock = new System.Windows.Forms.Timer(components);
            panelApplicantsCard = new Panel();
            lblApplicantsCount = new Label();
            lblApplicantsTitle = new Label();
            panelHiredCard = new Panel();
            lblHiredCount = new Label();
            lblHiredTitle = new Label();
            panelJobsCard = new Panel();
            lblJobsCount = new Label();
            lblJobsTitle = new Label();
            panelInterviewCard = new Panel();
            lblInterviewCount = new Label();
            lblInterviewTitle = new Label();
            panelRejectedCard = new Panel();
            lblRejectedCount = new Label();
            lblRejectedTitle = new Label();
            panelPendingCard = new Panel();
            lblPendingCount = new Label();
            lblReviewTitle = new Label();
            grpApplications = new GroupBox();
            dgvRecentApplications = new DataGridView();
            grpActivity = new GroupBox();
            rtbActivity = new RichTextBox();
            panelTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxLogo).BeginInit();
            panelMenu.SuspendLayout();
            panelApplicantsCard.SuspendLayout();
            panelHiredCard.SuspendLayout();
            panelJobsCard.SuspendLayout();
            panelInterviewCard.SuspendLayout();
            panelRejectedCard.SuspendLayout();
            panelPendingCard.SuspendLayout();
            grpApplications.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvRecentApplications).BeginInit();
            grpActivity.SuspendLayout();
            SuspendLayout();
            // 
            // panelTop
            // 
            panelTop.BackColor = Color.Thistle;
            panelTop.Controls.Add(lblTime);
            panelTop.Controls.Add(label3);
            panelTop.Controls.Add(lblDate);
            panelTop.Controls.Add(lblRole);
            panelTop.Controls.Add(lblGreeting);
            panelTop.Controls.Add(lblRecruitment);
            panelTop.Controls.Add(pictureBoxLogo);
            panelTop.Dock = DockStyle.Top;
            panelTop.Location = new Point(0, 0);
            panelTop.Margin = new Padding(4, 5, 4, 5);
            panelTop.Name = "panelTop";
            panelTop.Size = new Size(1907, 133);
            panelTop.TabIndex = 0;
            // 
            // lblTime
            // 
            lblTime.AutoSize = true;
            lblTime.Font = new Font("Segoe UI", 10F);
            lblTime.Location = new Point(1786, 67);
            lblTime.Margin = new Padding(4, 0, 4, 0);
            lblTime.Name = "lblTime";
            lblTime.Size = new Size(96, 19);
            lblTime.TabIndex = 6;
            lblTime.Text = "June 05, 2026";
            lblTime.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(1946, 325);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(38, 15);
            label3.TabIndex = 5;
            label3.Text = "label3";
            // 
            // lblDate
            // 
            lblDate.AutoSize = true;
            lblDate.Font = new Font("Segoe UI", 10F);
            lblDate.Location = new Point(1786, 35);
            lblDate.Margin = new Padding(4, 0, 4, 0);
            lblDate.Name = "lblDate";
            lblDate.Size = new Size(96, 19);
            lblDate.TabIndex = 4;
            lblDate.Text = "June 05, 2026";
            lblDate.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblRole
            // 
            lblRole.AutoSize = true;
            lblRole.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblRole.Location = new Point(1541, 68);
            lblRole.Margin = new Padding(4, 0, 4, 0);
            lblRole.Name = "lblRole";
            lblRole.Size = new Size(131, 19);
            lblRole.TabIndex = 3;
            lblRole.Text = "Role: HR Manager";
            // 
            // lblGreeting
            // 
            lblGreeting.AutoSize = true;
            lblGreeting.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblGreeting.Location = new Point(1541, 35);
            lblGreeting.Margin = new Padding(4, 0, 4, 0);
            lblGreeting.Name = "lblGreeting";
            lblGreeting.Size = new Size(110, 19);
            lblGreeting.TabIndex = 2;
            lblGreeting.Text = "Welcome, User";
            // 
            // lblRecruitment
            // 
            lblRecruitment.AutoSize = true;
            lblRecruitment.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            lblRecruitment.ForeColor = Color.Black;
            lblRecruitment.Location = new Point(313, 37);
            lblRecruitment.Margin = new Padding(4, 0, 4, 0);
            lblRecruitment.Name = "lblRecruitment";
            lblRecruitment.Size = new Size(341, 37);
            lblRecruitment.TabIndex = 1;
            lblRecruitment.Text = "HR Recruitment System   ";
            // 
            // pictureBoxLogo
            // 
            pictureBoxLogo.BackColor = Color.White;
            pictureBoxLogo.Image = (Image)resources.GetObject("pictureBoxLogo.Image");
            pictureBoxLogo.Location = new Point(0, -40);
            pictureBoxLogo.Margin = new Padding(4, 5, 4, 5);
            pictureBoxLogo.Name = "pictureBoxLogo";
            pictureBoxLogo.Size = new Size(236, 225);
            pictureBoxLogo.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxLogo.TabIndex = 0;
            pictureBoxLogo.TabStop = false;
            // 
            // panelMenu
            // 
            panelMenu.BackColor = Color.Thistle;
            panelMenu.Controls.Add(btnApplicants);
            panelMenu.Controls.Add(btnApplications);
            panelMenu.Controls.Add(btnJobs);
            panelMenu.Controls.Add(btnHiring);
            panelMenu.Controls.Add(btnReports);
            panelMenu.Controls.Add(btnAuditTrail);
            panelMenu.Controls.Add(btnUsers);
            panelMenu.Controls.Add(btnLogout);
            panelMenu.Controls.Add(btnDashboard);
            panelMenu.Dock = DockStyle.Left;
            panelMenu.Location = new Point(0, 133);
            panelMenu.Margin = new Padding(4, 5, 4, 5);
            panelMenu.Name = "panelMenu";
            panelMenu.Size = new Size(314, 1009);
            panelMenu.TabIndex = 1;
            // 
            // btnApplicants
            // 
            btnApplicants.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            btnApplicants.ForeColor = Color.Black;
            btnApplicants.Location = new Point(43, 167);
            btnApplicants.Margin = new Padding(4, 5, 4, 5);
            btnApplicants.Name = "btnApplicants";
            btnApplicants.Size = new Size(214, 50);
            btnApplicants.TabIndex = 9;
            btnApplicants.Text = "APPLICANTS";
            btnApplicants.UseVisualStyleBackColor = true;
            btnApplicants.Click += btnApplicants_Click;
            // 
            // btnApplications
            // 
            btnApplications.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            btnApplications.ForeColor = Color.Black;
            btnApplications.Location = new Point(43, 267);
            btnApplications.Margin = new Padding(4, 5, 4, 5);
            btnApplications.Name = "btnApplications";
            btnApplications.Size = new Size(214, 50);
            btnApplications.TabIndex = 8;
            btnApplications.Text = "APPLICATIONS";
            btnApplications.UseVisualStyleBackColor = true;
            btnApplications.Click += btnApplications_Click;
            // 
            // btnJobs
            // 
            btnJobs.Font = new Font("Segoe UI", 12.7F, FontStyle.Bold);
            btnJobs.ForeColor = Color.Black;
            btnJobs.Location = new Point(43, 367);
            btnJobs.Margin = new Padding(4, 5, 4, 5);
            btnJobs.Name = "btnJobs";
            btnJobs.Size = new Size(214, 50);
            btnJobs.TabIndex = 7;
            btnJobs.Text = "JOB VACANCIES";
            btnJobs.UseVisualStyleBackColor = true;
            btnJobs.Click += btnJobs_Click;
            // 
            // btnHiring
            // 
            btnHiring.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
            btnHiring.ForeColor = Color.Black;
            btnHiring.Location = new Point(43, 567);
            btnHiring.Margin = new Padding(4, 5, 4, 5);
            btnHiring.Name = "btnHiring";
            btnHiring.Size = new Size(214, 50);
            btnHiring.TabIndex = 5;
            btnHiring.Text = "HIRING DECISIONS";
            btnHiring.UseVisualStyleBackColor = true;
            btnHiring.Click += btnHiring_Click;
            // 
            // btnReports
            // 
            btnReports.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            btnReports.ForeColor = Color.Black;
            btnReports.Location = new Point(43, 667);
            btnReports.Margin = new Padding(4, 5, 4, 5);
            btnReports.Name = "btnReports";
            btnReports.Size = new Size(214, 50);
            btnReports.TabIndex = 4;
            btnReports.Text = "REPORTS";
            btnReports.UseVisualStyleBackColor = true;
            btnReports.Click += btnReports_Click;
            // 
            // btnAuditTrail
            // 
            btnAuditTrail.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            btnAuditTrail.ForeColor = Color.Black;
            btnAuditTrail.Location = new Point(43, 467);
            btnAuditTrail.Margin = new Padding(4, 5, 4, 5);
            btnAuditTrail.Name = "btnAuditTrail";
            btnAuditTrail.Size = new Size(214, 50);
            btnAuditTrail.TabIndex = 3;
            btnAuditTrail.Text = "AUDIT TRAIL";
            btnAuditTrail.UseVisualStyleBackColor = true;
            btnAuditTrail.Click += btnAuditTrail_Click;
            // 
            // btnUsers
            // 
            btnUsers.Font = new Font("Segoe UI", 9.7F, FontStyle.Bold);
            btnUsers.ForeColor = Color.Black;
            btnUsers.Location = new Point(43, 767);
            btnUsers.Margin = new Padding(4, 5, 4, 5);
            btnUsers.Name = "btnUsers";
            btnUsers.Size = new Size(214, 50);
            btnUsers.TabIndex = 2;
            btnUsers.Text = "USER MANAGEMENT";
            btnUsers.UseVisualStyleBackColor = true;
            btnUsers.Click += btnUsers_Click;
            // 
            // btnLogout
            // 
            btnLogout.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            btnLogout.ForeColor = Color.Black;
            btnLogout.Location = new Point(43, 952);
            btnLogout.Margin = new Padding(4, 5, 4, 5);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(214, 50);
            btnLogout.TabIndex = 1;
            btnLogout.Text = "LOGOUT";
            btnLogout.UseVisualStyleBackColor = true;
            btnLogout.Click += btnLogout_Click;
            // 
            // btnDashboard
            // 
            btnDashboard.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            btnDashboard.ForeColor = Color.Black;
            btnDashboard.Location = new Point(43, 67);
            btnDashboard.Margin = new Padding(4, 5, 4, 5);
            btnDashboard.Name = "btnDashboard";
            btnDashboard.Size = new Size(214, 50);
            btnDashboard.TabIndex = 0;
            btnDashboard.Text = "DASHBOARD";
            btnDashboard.UseVisualStyleBackColor = true;
            // 
            // timerClock
            // 
            timerClock.Enabled = true;
            timerClock.Interval = 1000;
            timerClock.Tick += timerClock_Tick;
            // 
            // panelApplicantsCard
            // 
            panelApplicantsCard.BackColor = Color.White;
            panelApplicantsCard.BorderStyle = BorderStyle.FixedSingle;
            panelApplicantsCard.Controls.Add(lblApplicantsCount);
            panelApplicantsCard.Controls.Add(lblApplicantsTitle);
            panelApplicantsCard.Location = new Point(500, 167);
            panelApplicantsCard.Margin = new Padding(4, 5, 4, 5);
            panelApplicantsCard.Name = "panelApplicantsCard";
            panelApplicantsCard.Size = new Size(356, 249);
            panelApplicantsCard.TabIndex = 2;
            // 
            // lblApplicantsCount
            // 
            lblApplicantsCount.AutoSize = true;
            lblApplicantsCount.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
            lblApplicantsCount.Location = new Point(150, 117);
            lblApplicantsCount.Margin = new Padding(4, 0, 4, 0);
            lblApplicantsCount.Name = "lblApplicantsCount";
            lblApplicantsCount.Size = new Size(38, 45);
            lblApplicantsCount.TabIndex = 1;
            lblApplicantsCount.Text = "0";
            // 
            // lblApplicantsTitle
            // 
            lblApplicantsTitle.AutoSize = true;
            lblApplicantsTitle.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblApplicantsTitle.Location = new Point(93, 58);
            lblApplicantsTitle.Margin = new Padding(4, 0, 4, 0);
            lblApplicantsTitle.Name = "lblApplicantsTitle";
            lblApplicantsTitle.Size = new Size(122, 20);
            lblApplicantsTitle.TabIndex = 0;
            lblApplicantsTitle.Text = "Total Applicants";
            // 
            // panelHiredCard
            // 
            panelHiredCard.BackColor = Color.White;
            panelHiredCard.BorderStyle = BorderStyle.FixedSingle;
            panelHiredCard.Controls.Add(lblHiredCount);
            panelHiredCard.Controls.Add(lblHiredTitle);
            panelHiredCard.Location = new Point(1000, 433);
            panelHiredCard.Margin = new Padding(4, 5, 4, 5);
            panelHiredCard.Name = "panelHiredCard";
            panelHiredCard.Size = new Size(356, 249);
            panelHiredCard.TabIndex = 3;
            // 
            // lblHiredCount
            // 
            lblHiredCount.AutoSize = true;
            lblHiredCount.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
            lblHiredCount.Location = new Point(150, 117);
            lblHiredCount.Margin = new Padding(4, 0, 4, 0);
            lblHiredCount.Name = "lblHiredCount";
            lblHiredCount.Size = new Size(38, 45);
            lblHiredCount.TabIndex = 1;
            lblHiredCount.Text = "0";
            // 
            // lblHiredTitle
            // 
            lblHiredTitle.AutoSize = true;
            lblHiredTitle.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblHiredTitle.Location = new Point(93, 58);
            lblHiredTitle.Margin = new Padding(4, 0, 4, 0);
            lblHiredTitle.Name = "lblHiredTitle";
            lblHiredTitle.Size = new Size(125, 20);
            lblHiredTitle.TabIndex = 0;
            lblHiredTitle.Text = "Hired Applicants";
            // 
            // panelJobsCard
            // 
            panelJobsCard.BackColor = Color.White;
            panelJobsCard.BorderStyle = BorderStyle.FixedSingle;
            panelJobsCard.Controls.Add(lblJobsCount);
            panelJobsCard.Controls.Add(lblJobsTitle);
            panelJobsCard.Location = new Point(1000, 167);
            panelJobsCard.Margin = new Padding(4, 5, 4, 5);
            panelJobsCard.Name = "panelJobsCard";
            panelJobsCard.Size = new Size(356, 249);
            panelJobsCard.TabIndex = 3;
            // 
            // lblJobsCount
            // 
            lblJobsCount.AutoSize = true;
            lblJobsCount.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
            lblJobsCount.Location = new Point(150, 117);
            lblJobsCount.Margin = new Padding(4, 0, 4, 0);
            lblJobsCount.Name = "lblJobsCount";
            lblJobsCount.Size = new Size(38, 45);
            lblJobsCount.TabIndex = 1;
            lblJobsCount.Text = "0";
            // 
            // lblJobsTitle
            // 
            lblJobsTitle.AutoSize = true;
            lblJobsTitle.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblJobsTitle.Location = new Point(114, 58);
            lblJobsTitle.Margin = new Padding(4, 0, 4, 0);
            lblJobsTitle.Name = "lblJobsTitle";
            lblJobsTitle.Size = new Size(82, 20);
            lblJobsTitle.TabIndex = 0;
            lblJobsTitle.Text = "Open Jobs";
            // 
            // panelInterviewCard
            // 
            panelInterviewCard.BackColor = Color.White;
            panelInterviewCard.BorderStyle = BorderStyle.FixedSingle;
            panelInterviewCard.Controls.Add(lblInterviewCount);
            panelInterviewCard.Controls.Add(lblInterviewTitle);
            panelInterviewCard.Location = new Point(500, 433);
            panelInterviewCard.Margin = new Padding(4, 5, 4, 5);
            panelInterviewCard.Name = "panelInterviewCard";
            panelInterviewCard.Size = new Size(356, 249);
            panelInterviewCard.TabIndex = 3;
            // 
            // lblInterviewCount
            // 
            lblInterviewCount.AutoSize = true;
            lblInterviewCount.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
            lblInterviewCount.Location = new Point(150, 117);
            lblInterviewCount.Margin = new Padding(4, 0, 4, 0);
            lblInterviewCount.Name = "lblInterviewCount";
            lblInterviewCount.Size = new Size(38, 45);
            lblInterviewCount.TabIndex = 1;
            lblInterviewCount.Text = "0";
            // 
            // lblInterviewTitle
            // 
            lblInterviewTitle.AutoSize = true;
            lblInterviewTitle.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblInterviewTitle.Location = new Point(64, 58);
            lblInterviewTitle.Margin = new Padding(4, 0, 4, 0);
            lblInterviewTitle.Name = "lblInterviewTitle";
            lblInterviewTitle.Size = new Size(151, 20);
            lblInterviewTitle.TabIndex = 0;
            lblInterviewTitle.Text = "Interview Scheduled";
            // 
            // panelRejectedCard
            // 
            panelRejectedCard.BackColor = Color.White;
            panelRejectedCard.BorderStyle = BorderStyle.FixedSingle;
            panelRejectedCard.Controls.Add(lblRejectedCount);
            panelRejectedCard.Controls.Add(lblRejectedTitle);
            panelRejectedCard.Location = new Point(1493, 433);
            panelRejectedCard.Margin = new Padding(4, 5, 4, 5);
            panelRejectedCard.Name = "panelRejectedCard";
            panelRejectedCard.Size = new Size(356, 249);
            panelRejectedCard.TabIndex = 4;
            // 
            // lblRejectedCount
            // 
            lblRejectedCount.AutoSize = true;
            lblRejectedCount.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
            lblRejectedCount.Location = new Point(150, 117);
            lblRejectedCount.Margin = new Padding(4, 0, 4, 0);
            lblRejectedCount.Name = "lblRejectedCount";
            lblRejectedCount.Size = new Size(38, 45);
            lblRejectedCount.TabIndex = 1;
            lblRejectedCount.Text = "0";
            // 
            // lblRejectedTitle
            // 
            lblRejectedTitle.AutoSize = true;
            lblRejectedTitle.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblRejectedTitle.Location = new Point(71, 58);
            lblRejectedTitle.Margin = new Padding(4, 0, 4, 0);
            lblRejectedTitle.Name = "lblRejectedTitle";
            lblRejectedTitle.Size = new Size(147, 20);
            lblRejectedTitle.TabIndex = 0;
            lblRejectedTitle.Text = "Rejected Applicants";
            // 
            // panelPendingCard
            // 
            panelPendingCard.BackColor = Color.White;
            panelPendingCard.BorderStyle = BorderStyle.FixedSingle;
            panelPendingCard.Controls.Add(lblPendingCount);
            panelPendingCard.Controls.Add(lblReviewTitle);
            panelPendingCard.Location = new Point(1493, 167);
            panelPendingCard.Margin = new Padding(4, 5, 4, 5);
            panelPendingCard.Name = "panelPendingCard";
            panelPendingCard.Size = new Size(356, 249);
            panelPendingCard.TabIndex = 3;
            // 
            // lblPendingCount
            // 
            lblPendingCount.AutoSize = true;
            lblPendingCount.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
            lblPendingCount.Location = new Point(150, 117);
            lblPendingCount.Margin = new Padding(4, 0, 4, 0);
            lblPendingCount.Name = "lblPendingCount";
            lblPendingCount.Size = new Size(38, 45);
            lblPendingCount.TabIndex = 1;
            lblPendingCount.Text = "0";
            // 
            // lblReviewTitle
            // 
            lblReviewTitle.AutoSize = true;
            lblReviewTitle.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblReviewTitle.Location = new Point(86, 58);
            lblReviewTitle.Margin = new Padding(4, 0, 4, 0);
            lblReviewTitle.Name = "lblReviewTitle";
            lblReviewTitle.Size = new Size(127, 20);
            lblReviewTitle.TabIndex = 0;
            lblReviewTitle.Text = "Pending Reviews";
            // 
            // grpApplications
            // 
            grpApplications.Controls.Add(dgvRecentApplications);
            grpApplications.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            grpApplications.Location = new Point(357, 700);
            grpApplications.Margin = new Padding(4, 5, 4, 5);
            grpApplications.Name = "grpApplications";
            grpApplications.Padding = new Padding(4, 5, 4, 5);
            grpApplications.Size = new Size(1127, 442);
            grpApplications.TabIndex = 5;
            grpApplications.TabStop = false;
            grpApplications.Text = "Recent Applications";
            // 
            // dgvRecentApplications
            // 
            dgvRecentApplications.AllowUserToAddRows = false;
            dgvRecentApplications.AllowUserToDeleteRows = false;
            dgvRecentApplications.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvRecentApplications.BackgroundColor = SystemColors.Control;
            dgvRecentApplications.BorderStyle = BorderStyle.None;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = Color.Thistle;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvRecentApplications.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvRecentApplications.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.White;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = Color.Thistle;
            dataGridViewCellStyle2.SelectionForeColor = Color.Black;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgvRecentApplications.DefaultCellStyle = dataGridViewCellStyle2;
            dgvRecentApplications.EnableHeadersVisualStyles = false;
            dgvRecentApplications.Location = new Point(9, 38);
            dgvRecentApplications.Margin = new Padding(4, 5, 4, 5);
            dgvRecentApplications.Name = "dgvRecentApplications";
            dgvRecentApplications.ReadOnly = true;
            dgvRecentApplications.RowHeadersVisible = false;
            dgvRecentApplications.RowHeadersWidth = 62;
            dgvRecentApplications.RowTemplate.Height = 35;
            dgvRecentApplications.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvRecentApplications.Size = new Size(1110, 400);
            dgvRecentApplications.TabIndex = 0;
            // 
            // grpActivity
            // 
            grpActivity.BackColor = Color.White;
            grpActivity.Controls.Add(rtbActivity);
            grpActivity.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            grpActivity.Location = new Point(1493, 700);
            grpActivity.Margin = new Padding(4, 5, 4, 5);
            grpActivity.Name = "grpActivity";
            grpActivity.Padding = new Padding(4, 5, 4, 5);
            grpActivity.Size = new Size(414, 442);
            grpActivity.TabIndex = 6;
            grpActivity.TabStop = false;
            grpActivity.Text = "Recent Activity";
            // 
            // rtbActivity
            // 
            rtbActivity.BackColor = Color.White;
            rtbActivity.BorderStyle = BorderStyle.None;
            rtbActivity.DetectUrls = false;
            rtbActivity.Font = new Font("Segoe UI", 10F);
            rtbActivity.Location = new Point(10, 42);
            rtbActivity.Margin = new Padding(4, 5, 4, 5);
            rtbActivity.Name = "rtbActivity";
            rtbActivity.ReadOnly = true;
            rtbActivity.ScrollBars = RichTextBoxScrollBars.Vertical;
            rtbActivity.ShortcutsEnabled = false;
            rtbActivity.Size = new Size(476, 400);
            rtbActivity.TabIndex = 0;
            rtbActivity.Text = resources.GetString("rtbActivity.Text");
            // 
            // HRDashboard
            // 
            AutoScaleMode = AutoScaleMode.None;
            AutoScroll = true;
            AutoScrollMinSize = new Size(0, 950);
            AutoSize = true;
            BackColor = Color.LavenderBlush;
            ClientSize = new Size(1834, 1011);
            Controls.Add(grpActivity);
            Controls.Add(grpApplications);
            Controls.Add(panelPendingCard);
            Controls.Add(panelRejectedCard);
            Controls.Add(panelJobsCard);
            Controls.Add(panelInterviewCard);
            Controls.Add(panelHiredCard);
            Controls.Add(panelApplicantsCard);
            Controls.Add(panelMenu);
            Controls.Add(panelTop);
            Margin = new Padding(4, 5, 4, 5);
            Name = "HRDashboard";
            StartPosition = FormStartPosition.CenterScreen;
            Text = " ";
            WindowState = FormWindowState.Maximized;
            Load += HRDashboard_Load;
            panelTop.ResumeLayout(false);
            panelTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxLogo).EndInit();
            panelMenu.ResumeLayout(false);
            panelApplicantsCard.ResumeLayout(false);
            panelApplicantsCard.PerformLayout();
            panelHiredCard.ResumeLayout(false);
            panelHiredCard.PerformLayout();
            panelJobsCard.ResumeLayout(false);
            panelJobsCard.PerformLayout();
            panelInterviewCard.ResumeLayout(false);
            panelInterviewCard.PerformLayout();
            panelRejectedCard.ResumeLayout(false);
            panelRejectedCard.PerformLayout();
            panelPendingCard.ResumeLayout(false);
            panelPendingCard.PerformLayout();
            grpApplications.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvRecentApplications).EndInit();
            grpActivity.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panelTop;
        private PictureBox pictureBoxLogo;
        private Label lblRecruitment;
        private Label lblGreeting;
        private Panel panelMenu;
        private Label lblRole;
        private Button btnDashboard;
        private Button btnApplicants;
        private Button btnApplications;
        private Button btnJobs;
        private Button btnHiring;
        private Button btnReports;
        private Button btnAuditTrail;
        private Button btnUsers;
        private Button btnLogout;
        private Label lblDate;
        private System.Windows.Forms.Timer timerClock;
        private Panel panelApplicantsCard;
        private Label lblApplicantsTitle;
        private Label lblApplicantsCount;
        private Panel panelHiredCard;
        private Panel panelJobsCard;
        private Label lblJobsCount;
        private Label lblJobsTitle;
        private Label lblHiredCount;
        private Label lblHiredTitle;
        private Panel panelInterviewCard;
        private Label lblInterviewCount;
        private Label lblInterviewTitle;
        private Panel panelRejectedCard;
        private Label lblRejectedCount;
        private Label lblRejectedTitle;
        private Panel panelPendingCard;
        private Label lblPendingCount;
        private Label lblReviewTitle;
        private Label label3;
        private GroupBox grpApplications;
        private DataGridView dgvRecentApplications;
        private DataGridViewTextBoxColumn colApplicant;
        private DataGridViewTextBoxColumn colPosition;
        private DataGridViewTextBoxColumn colStatus;
        private DataGridViewTextBoxColumn colDateApplied;
        private GroupBox grpActivity;
        private RichTextBox rtbActivity;
        private Label lblTime;
    }
}