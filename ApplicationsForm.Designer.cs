namespace HRApplicantSystem
{
    partial class ApplicationsForm
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
            panelMain = new Panel();
            btnDocuments = new Button();
            btnInterview = new Button();
            btnViewApplication = new Button();
            btnViewHistory = new Button();
            btnBack = new Button();
            btnApprove = new Button();
            btnReject = new Button();
            btnReview = new Button();
            dgvApplicantions = new DataGridView();
            colApplicationId = new DataGridViewTextBoxColumn();
            colApplicantName = new DataGridViewTextBoxColumn();
            colPositionApplied = new DataGridViewTextBoxColumn();
            colDateApplied = new DataGridViewTextBoxColumn();
            colStatus = new DataGridViewTextBoxColumn();
            btnSearch = new Button();
            txtSearchApplication = new TextBox();
            lblTitle = new Label();
            panelMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvApplicantions).BeginInit();
            SuspendLayout();
            // 
            // panelMain
            // 
            panelMain.BackColor = Color.White;
            panelMain.Controls.Add(btnDocuments);
            panelMain.Controls.Add(btnInterview);
            panelMain.Controls.Add(btnViewApplication);
            panelMain.Controls.Add(btnViewHistory);
            panelMain.Controls.Add(btnBack);
            panelMain.Controls.Add(btnApprove);
            panelMain.Controls.Add(btnReject);
            panelMain.Controls.Add(btnReview);
            panelMain.Controls.Add(dgvApplicantions);
            panelMain.Controls.Add(btnSearch);
            panelMain.Controls.Add(txtSearchApplication);
            panelMain.Controls.Add(lblTitle);
            panelMain.Location = new Point(22, 20);
            panelMain.Name = "panelMain";
            panelMain.Size = new Size(1140, 620);
            panelMain.TabIndex = 1;
            // 
            // btnDocuments
            // 
            btnDocuments.BackColor = Color.Thistle;
            btnDocuments.FlatStyle = FlatStyle.Flat;
            btnDocuments.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnDocuments.Location = new Point(549, 530);
            btnDocuments.Name = "btnDocuments";
            btnDocuments.Size = new Size(130, 40);
            btnDocuments.TabIndex = 22;
            btnDocuments.Text = "Documents\r\n";
            btnDocuments.UseVisualStyleBackColor = false;
            btnDocuments.Click += btnDocuments_Click;
            // 
            // btnInterview
            // 
            btnInterview.BackColor = Color.Thistle;
            btnInterview.FlatStyle = FlatStyle.Flat;
            btnInterview.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnInterview.Location = new Point(368, 523);
            btnInterview.Name = "btnInterview";
            btnInterview.Size = new Size(130, 55);
            btnInterview.TabIndex = 21;
            btnInterview.Text = "Schedule\r\nInterview";
            btnInterview.UseVisualStyleBackColor = false;
            // 
            // btnViewApplication
            // 
            btnViewApplication.BackColor = Color.Thistle;
            btnViewApplication.FlatStyle = FlatStyle.Flat;
            btnViewApplication.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnViewApplication.Location = new Point(685, 523);
            btnViewApplication.Name = "btnViewApplication";
            btnViewApplication.Size = new Size(130, 55);
            btnViewApplication.TabIndex = 20;
            btnViewApplication.Text = "View Applications";
            btnViewApplication.UseVisualStyleBackColor = false;
            btnViewApplication.Click += btnViewApplication_Click;
            // 
            // btnViewHistory
            // 
            btnViewHistory.BackColor = Color.Thistle;
            btnViewHistory.FlatStyle = FlatStyle.Flat;
            btnViewHistory.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnViewHistory.Location = new Point(821, 530);
            btnViewHistory.Name = "btnViewHistory";
            btnViewHistory.Size = new Size(130, 40);
            btnViewHistory.TabIndex = 19;
            btnViewHistory.Text = "View History";
            btnViewHistory.UseVisualStyleBackColor = false;
            btnViewHistory.Click += btnViewHistory_Click;
            // 
            // btnBack
            // 
            btnBack.BackColor = Color.Thistle;
            btnBack.FlatStyle = FlatStyle.Flat;
            btnBack.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnBack.Location = new Point(980, 523);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(130, 55);
            btnBack.TabIndex = 18;
            btnBack.Text = "Back to \r\nDashboard\r\n";
            btnBack.UseVisualStyleBackColor = false;
            btnBack.Click += btnBack_Click;
            // 
            // btnApprove
            // 
            btnApprove.BackColor = Color.Thistle;
            btnApprove.FlatStyle = FlatStyle.Flat;
            btnApprove.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnApprove.Location = new Point(156, 530);
            btnApprove.Name = "btnApprove";
            btnApprove.Size = new Size(100, 40);
            btnApprove.TabIndex = 7;
            btnApprove.Text = "Accepted";
            btnApprove.UseVisualStyleBackColor = false;
            btnApprove.Click += btnApprove_Click;
            // 
            // btnReject
            // 
            btnReject.BackColor = Color.Thistle;
            btnReject.FlatStyle = FlatStyle.Flat;
            btnReject.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnReject.Location = new Point(262, 530);
            btnReject.Name = "btnReject";
            btnReject.Size = new Size(100, 40);
            btnReject.TabIndex = 6;
            btnReject.Text = "Rejected";
            btnReject.UseVisualStyleBackColor = false;
            btnReject.Click += btnReject_Click;
            // 
            // btnReview
            // 
            btnReview.BackColor = Color.Thistle;
            btnReview.FlatStyle = FlatStyle.Flat;
            btnReview.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnReview.Location = new Point(20, 530);
            btnReview.Name = "btnReview";
            btnReview.Size = new Size(130, 40);
            btnReview.TabIndex = 4;
            btnReview.Text = " Under Review";
            btnReview.UseVisualStyleBackColor = false;
            btnReview.Click += btnReview_Click;
            // 
            // dgvApplicantions
            // 
            dgvApplicantions.AllowUserToAddRows = false;
            dgvApplicantions.AllowUserToDeleteRows = false;
            dgvApplicantions.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvApplicantions.BackgroundColor = SystemColors.Control;
            dgvApplicantions.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvApplicantions.Columns.AddRange(new DataGridViewColumn[] { colApplicationId, colApplicantName, colPositionApplied, colDateApplied, colStatus });
            dgvApplicantions.Location = new Point(20, 120);
            dgvApplicantions.Name = "dgvApplicantions";
            dgvApplicantions.ReadOnly = true;
            dgvApplicantions.RowHeadersVisible = false;
            dgvApplicantions.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvApplicantions.Size = new Size(1090, 380);
            dgvApplicantions.TabIndex = 3;
            // 
            // colApplicationId
            // 
            colApplicationId.HeaderText = "Application ID";
            colApplicationId.Name = "colApplicationId";
            colApplicationId.ReadOnly = true;
            // 
            // colApplicantName
            // 
            colApplicantName.HeaderText = "Applicant Name";
            colApplicantName.Name = "colApplicantName";
            colApplicantName.ReadOnly = true;
            // 
            // colPositionApplied
            // 
            colPositionApplied.HeaderText = "Position Applied";
            colPositionApplied.Name = "colPositionApplied";
            colPositionApplied.ReadOnly = true;
            // 
            // colDateApplied
            // 
            colDateApplied.HeaderText = "Date Applied";
            colDateApplied.Name = "colDateApplied";
            colDateApplied.ReadOnly = true;
            // 
            // colStatus
            // 
            colStatus.HeaderText = "Status";
            colStatus.Name = "colStatus";
            colStatus.ReadOnly = true;
            // 
            // btnSearch
            // 
            btnSearch.BackColor = Color.Thistle;
            btnSearch.FlatStyle = FlatStyle.Flat;
            btnSearch.Location = new Point(280, 65);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(100, 30);
            btnSearch.TabIndex = 2;
            btnSearch.Text = "Search";
            btnSearch.UseVisualStyleBackColor = false;
            btnSearch.Click += btnSearch_Click;
            // 
            // txtSearchApplication
            // 
            txtSearchApplication.Location = new Point(20, 70);
            txtSearchApplication.Name = "txtSearchApplication";
            txtSearchApplication.Size = new Size(250, 23);
            txtSearchApplication.TabIndex = 1;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblTitle.Location = new Point(20, 20);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(315, 32);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Applications Management";
            // 
            // ApplicationsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LavenderBlush;
            ClientSize = new Size(1184, 661);
            Controls.Add(panelMain);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "ApplicationsForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Applications Management";
            panelMain.ResumeLayout(false);
            panelMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvApplicantions).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelMain;
        private Button btnApprove;
        private Button btnReject;
        private Button btnReview;
        private DataGridView dgvApplicantions;
        private Button btnSearch;
        private TextBox txtSearchApplication;
        private Label lblTitle;
        private DataGridViewTextBoxColumn colApplicationId;
        private DataGridViewTextBoxColumn colApplicantName;
        private DataGridViewTextBoxColumn colPositionApplied;
        private DataGridViewTextBoxColumn colDateApplied;
        private DataGridViewTextBoxColumn colStatus;
        private Button btnBack;
        private Button btnViewApplication;
        private Button btnViewHistory;
        private Button btnInterview;
        private Button btnDocuments;
    }
}