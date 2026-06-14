using System.Drawing;
using System.Windows.Forms;

namespace HRApplicantSystem
{
    public partial class ApplicantDashboard : Form
    {

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            grpUpdates = new GroupBox();
            lstUpdates = new ListBox();
            headerPanel = new Panel();
            lblTitle = new Label();
            grpInfo = new GroupBox();
            lblApplicant = new Label();
            lblPosition = new Label();
            lblApplicationID = new Label();
            lblDateApplied = new Label();
            btnProfile = new Button();
            grpStatus = new GroupBox();
            lblStatus = new Label();
            progressBar1 = new ProgressBar();
            lblProgress = new Label();
            grpDocs = new GroupBox();
            lstDocs = new ListBox();
            grpInterview = new GroupBox();
            lblInterview = new Label();
            btnLogout = new Button();
            btnVacancies = new Button();
            btnMyApplications = new Button();
            btnChangePasword = new Button();
            btnDocuments = new Button();
            timerRefresh = new System.Windows.Forms.Timer(components);
            btnApplicationStatus = new Button();
            grpUpdates.SuspendLayout();
            headerPanel.SuspendLayout();
            grpInfo.SuspendLayout();
            grpStatus.SuspendLayout();
            grpDocs.SuspendLayout();
            grpInterview.SuspendLayout();
            SuspendLayout();
            // 
            // grpUpdates
            // 
            grpUpdates.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            grpUpdates.Controls.Add(lstUpdates);
            grpUpdates.Location = new Point(440, 400);
            grpUpdates.Name = "grpUpdates";
            grpUpdates.Size = new Size(420, 200);
            grpUpdates.TabIndex = 5;
            grpUpdates.TabStop = false;
            grpUpdates.Text = "Recent Updates";
            // 
            // lstUpdates
            // 
            lstUpdates.Dock = DockStyle.Fill;
            lstUpdates.Location = new Point(3, 19);
            lstUpdates.Name = "lstUpdates";
            lstUpdates.Size = new Size(414, 178);
            lstUpdates.TabIndex = 0;
            // 
            // headerPanel
            // 
            headerPanel.BackColor = Color.Thistle;
            headerPanel.Controls.Add(lblTitle);
            headerPanel.Dock = DockStyle.Top;
            headerPanel.Location = new Point(0, 0);
            headerPanel.Name = "headerPanel";
            headerPanel.Size = new Size(900, 90);
            headerPanel.TabIndex = 0;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Georgia", 22F, FontStyle.Bold);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(20, 25);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(344, 35);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Applicant Dashboard";
            // 
            // grpInfo
            // 
            grpInfo.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            grpInfo.Controls.Add(lblApplicant);
            grpInfo.Controls.Add(lblPosition);
            grpInfo.Controls.Add(lblApplicationID);
            grpInfo.Controls.Add(lblDateApplied);
            grpInfo.Controls.Add(btnProfile);
            grpInfo.Location = new Point(20, 110);
            grpInfo.Name = "grpInfo";
            grpInfo.Size = new Size(840, 120);
            grpInfo.TabIndex = 1;
            grpInfo.TabStop = false;
            grpInfo.Text = "Application Information";
            // 
            // lblApplicant
            // 
            lblApplicant.AutoSize = true;
            lblApplicant.Location = new Point(20, 35);
            lblApplicant.Name = "lblApplicant";
            lblApplicant.Size = new Size(141, 15);
            lblApplicant.TabIndex = 0;
            lblApplicant.Text = "Applicant: Juan Dela Cruz";
            // 
            // lblPosition
            // 
            lblPosition.AutoSize = true;
            lblPosition.Location = new Point(20, 65);
            lblPosition.Name = "lblPosition";
            lblPosition.Size = new Size(158, 15);
            lblPosition.TabIndex = 1;
            lblPosition.Text = "Position: Software Developer";
            // 
            // lblApplicationID
            // 
            lblApplicationID.AutoSize = true;
            lblApplicationID.Location = new Point(400, 35);
            lblApplicationID.Name = "lblApplicationID";
            lblApplicationID.Size = new Size(133, 15);
            lblApplicationID.TabIndex = 2;
            lblApplicationID.Text = "Application ID: APP-001";
            // 
            // lblDateApplied
            // 
            lblDateApplied.AutoSize = true;
            lblDateApplied.Location = new Point(400, 65);
            lblDateApplied.Name = "lblDateApplied";
            lblDateApplied.Size = new Size(150, 15);
            lblDateApplied.TabIndex = 3;
            lblDateApplied.Text = "Date Applied: June 10, 2026";
            // 
            // btnProfile
            // 
            btnProfile.BackColor = Color.Thistle;
            btnProfile.FlatStyle = FlatStyle.Flat;
            btnProfile.Location = new Point(754, 89);
            btnProfile.Name = "btnProfile";
            btnProfile.Size = new Size(80, 25);
            btnProfile.TabIndex = 6;
            btnProfile.Text = "My Profile";
            btnProfile.UseVisualStyleBackColor = false;
            btnProfile.Click += btnProfile_Click;
            // 
            // grpStatus
            // 
            grpStatus.Controls.Add(btnApplicationStatus);
            grpStatus.Controls.Add(lblStatus);
            grpStatus.Controls.Add(progressBar1);
            grpStatus.Controls.Add(lblProgress);
            grpStatus.Location = new Point(20, 230);
            grpStatus.Name = "grpStatus";
            grpStatus.Size = new Size(400, 100);
            grpStatus.TabIndex = 2;
            grpStatus.TabStop = false;
            grpStatus.Text = "Current Status";
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblStatus.ForeColor = Color.DarkGreen;
            lblStatus.Location = new Point(20, 40);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(186, 21);
            lblStatus.TabIndex = 0;
            lblStatus.Text = "Under Initial Screening";
            // 
            // progressBar1
            // 
            progressBar1.Location = new Point(20, 65);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(300, 20);
            progressBar1.TabIndex = 1;
            progressBar1.Value = 60;
            // 
            // lblProgress
            // 
            lblProgress.AutoSize = true;
            lblProgress.Location = new Point(330, 65);
            lblProgress.Name = "lblProgress";
            lblProgress.Size = new Size(29, 15);
            lblProgress.TabIndex = 2;
            lblProgress.Text = "60%";
            // 
            // grpDocs
            // 
            grpDocs.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            grpDocs.Controls.Add(lstDocs);
            grpDocs.Location = new Point(440, 230);
            grpDocs.Name = "grpDocs";
            grpDocs.Size = new Size(420, 150);
            grpDocs.TabIndex = 3;
            grpDocs.TabStop = false;
            grpDocs.Text = "Missing Documents";
            // 
            // lstDocs
            // 
            lstDocs.Dock = DockStyle.Fill;
            lstDocs.Location = new Point(3, 19);
            lstDocs.Name = "lstDocs";
            lstDocs.Size = new Size(414, 128);
            lstDocs.TabIndex = 0;
            // 
            // grpInterview
            // 
            grpInterview.Controls.Add(lblInterview);
            grpInterview.Location = new Point(20, 350);
            grpInterview.Name = "grpInterview";
            grpInterview.Size = new Size(400, 165);
            grpInterview.TabIndex = 4;
            grpInterview.TabStop = false;
            grpInterview.Text = "Interview Schedule";
            // 
            // lblInterview
            // 
            lblInterview.AutoSize = true;
            lblInterview.Location = new Point(20, 30);
            lblInterview.Name = "lblInterview";
            lblInterview.Size = new Size(110, 45);
            lblInterview.TabIndex = 0;
            lblInterview.Text = "Date: June 20, 2026\r\nTime: 9:00 AM\r\nLocation: HR Office";
            // 
            // btnLogout
            // 
            btnLogout.BackColor = Color.Thistle;
            btnLogout.FlatStyle = FlatStyle.Flat;
            btnLogout.Location = new Point(782, 646);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(75, 25);
            btnLogout.TabIndex = 8;
            btnLogout.Text = "Logout";
            btnLogout.UseVisualStyleBackColor = false;
            btnLogout.Click += btnLogout_Click;
            // 
            // btnVacancies
            // 
            btnVacancies.BackColor = Color.Thistle;
            btnVacancies.FlatStyle = FlatStyle.Flat;
            btnVacancies.Location = new Point(70, 555);
            btnVacancies.Name = "btnVacancies";
            btnVacancies.Size = new Size(100, 40);
            btnVacancies.TabIndex = 7;
            btnVacancies.Text = "Job Vacancy";
            btnVacancies.UseVisualStyleBackColor = false;
            btnVacancies.Click += btnVacancies_Click;
            // 
            // btnMyApplications
            // 
            btnMyApplications.BackColor = Color.Thistle;
            btnMyApplications.FlatStyle = FlatStyle.Flat;
            btnMyApplications.Location = new Point(260, 555);
            btnMyApplications.Name = "btnMyApplications";
            btnMyApplications.Size = new Size(100, 40);
            btnMyApplications.TabIndex = 9;
            btnMyApplications.Text = "My Applications";
            btnMyApplications.UseVisualStyleBackColor = false;
            btnMyApplications.Click += btnMyApplications_Click;
            // 
            // btnChangePasword
            // 
            btnChangePasword.BackColor = Color.Thistle;
            btnChangePasword.FlatStyle = FlatStyle.Flat;
            btnChangePasword.Location = new Point(260, 630);
            btnChangePasword.Name = "btnChangePasword";
            btnChangePasword.Size = new Size(100, 40);
            btnChangePasword.TabIndex = 10;
            btnChangePasword.Text = "Change Password";
            btnChangePasword.UseVisualStyleBackColor = false;
            btnChangePasword.Click += btnChangePasword_Click;
            // 
            // btnDocuments
            // 
            btnDocuments.BackColor = Color.Thistle;
            btnDocuments.FlatStyle = FlatStyle.Flat;
            btnDocuments.Location = new Point(70, 630);
            btnDocuments.Name = "btnDocuments";
            btnDocuments.Size = new Size(100, 40);
            btnDocuments.TabIndex = 11;
            btnDocuments.Text = "My Documents";
            btnDocuments.UseVisualStyleBackColor = false;
            btnDocuments.Click += btnDocuments_Click;
            // 
            // timerRefresh
            // 
            timerRefresh.Enabled = true;
            timerRefresh.Interval = 30000;
            timerRefresh.Tick += timerRefresh_Tick;
            // 
            // btnApplicationStatus
            // 
            btnApplicationStatus.FlatAppearance.BorderSize = 0;
            btnApplicationStatus.FlatStyle = FlatStyle.Flat;
            btnApplicationStatus.Font = new Font("Segoe UI", 9F, FontStyle.Underline);
            btnApplicationStatus.Location = new Point(310, 19);
            btnApplicationStatus.Name = "btnApplicationStatus";
            btnApplicationStatus.Size = new Size(75, 23);
            btnApplicationStatus.TabIndex = 3;
            btnApplicationStatus.Text = "View Status";
            btnApplicationStatus.UseVisualStyleBackColor = true;
            btnApplicationStatus.Click += btnApplicationStatus_Click;
            // 
            // ApplicantDashboard
            // 
            BackColor = Color.LavenderBlush;
            ClientSize = new Size(900, 700);
            Controls.Add(btnDocuments);
            Controls.Add(btnChangePasword);
            Controls.Add(btnMyApplications);
            Controls.Add(btnVacancies);
            Controls.Add(headerPanel);
            Controls.Add(grpInfo);
            Controls.Add(grpStatus);
            Controls.Add(grpDocs);
            Controls.Add(grpInterview);
            Controls.Add(grpUpdates);
            Controls.Add(btnLogout);
            Name = "ApplicantDashboard";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Applicant Dashboard";
            grpUpdates.ResumeLayout(false);
            headerPanel.ResumeLayout(false);
            headerPanel.PerformLayout();
            grpInfo.ResumeLayout(false);
            grpInfo.PerformLayout();
            grpStatus.ResumeLayout(false);
            grpStatus.PerformLayout();
            grpDocs.ResumeLayout(false);
            grpInterview.ResumeLayout(false);
            grpInterview.PerformLayout();
            ResumeLayout(false);

        }

        private Panel headerPanel;
        private Label lblTitle;
        private GroupBox grpInfo;
        private Label lblApplicant;
        private Label lblPosition;
        private GroupBox grpStatus;
        private Label lblStatus;
        private GroupBox grpDocs;
        private ListBox lstDocs;
        private GroupBox grpInterview;
        private Label lblInterview;
        private GroupBox grpUpdates;
        private ListBox lstUpdates;
        private Button btnProfile;
        private Button btnLogout;
        private ProgressBar progressBar1;
        private Label lblProgress;
        private Label lblApplicationID;
        private Label lblDateApplied;
        private Button btnVacancies;
        private Button btnMyApplications;
        private Button btnChangePasword;
        private Button btnDocuments;
        private System.Windows.Forms.Timer timerRefresh;
        private System.ComponentModel.IContainer components;
        private Button btnApplicationStatus;
    }
}