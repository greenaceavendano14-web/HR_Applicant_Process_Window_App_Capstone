namespace HRApplicantSystem
{
    partial class AuditTrailForm
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
            btnBack = new Button();
            pnlRejections = new Panel();
            lblRejectionsCount = new Label();
            lblRejections = new Label();
            pnlApproval = new Panel();
            lblApprovalCount = new Label();
            lblApproval = new Label();
            pnlActivities = new Panel();
            lblActivitiesCount = new Label();
            lblActivities = new Label();
            lblSearch = new Label();
            btnRefresh = new Button();
            btnExportLog = new Button();
            btnViewDetails = new Button();
            dgvAuditTrail = new DataGridView();
            colAuditId = new DataGridViewTextBoxColumn();
            colUser = new DataGridViewTextBoxColumn();
            colRole = new DataGridViewTextBoxColumn();
            colAction = new DataGridViewTextBoxColumn();
            colDateTime = new DataGridViewTextBoxColumn();
            colRemarks = new DataGridViewTextBoxColumn();
            btnSearch = new Button();
            txtSearchAudit = new TextBox();
            lblTitle = new Label();
            panelMain.SuspendLayout();
            pnlRejections.SuspendLayout();
            pnlApproval.SuspendLayout();
            pnlActivities.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvAuditTrail).BeginInit();
            SuspendLayout();
            // 
            // panelMain
            // 
            panelMain.BackColor = Color.White;
            panelMain.Controls.Add(btnBack);
            panelMain.Controls.Add(pnlRejections);
            panelMain.Controls.Add(pnlApproval);
            panelMain.Controls.Add(pnlActivities);
            panelMain.Controls.Add(lblSearch);
            panelMain.Controls.Add(btnRefresh);
            panelMain.Controls.Add(btnExportLog);
            panelMain.Controls.Add(btnViewDetails);
            panelMain.Controls.Add(dgvAuditTrail);
            panelMain.Controls.Add(btnSearch);
            panelMain.Controls.Add(txtSearchAudit);
            panelMain.Controls.Add(lblTitle);
            panelMain.Location = new Point(22, 20);
            panelMain.Name = "panelMain";
            panelMain.Size = new Size(1140, 620);
            panelMain.TabIndex = 2;
            // 
            // btnBack
            // 
            btnBack.BackColor = Color.Thistle;
            btnBack.FlatStyle = FlatStyle.Flat;
            btnBack.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnBack.Location = new Point(980, 555);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(130, 55);
            btnBack.TabIndex = 18;
            btnBack.Text = "Back to \r\nDashboard\r\n";
            btnBack.UseVisualStyleBackColor = false;
            btnBack.Click += btnBack_Click;
            // 
            // pnlRejections
            // 
            pnlRejections.BackColor = Color.LavenderBlush;
            pnlRejections.BorderStyle = BorderStyle.FixedSingle;
            pnlRejections.Controls.Add(lblRejectionsCount);
            pnlRejections.Controls.Add(lblRejections);
            pnlRejections.Location = new Point(900, 80);
            pnlRejections.Name = "pnlRejections";
            pnlRejections.Size = new Size(160, 90);
            pnlRejections.TabIndex = 10;
            // 
            // lblRejectionsCount
            // 
            lblRejectionsCount.AutoSize = true;
            lblRejectionsCount.Font = new Font("Segoe UI", 12F);
            lblRejectionsCount.Location = new Point(70, 50);
            lblRejectionsCount.Name = "lblRejectionsCount";
            lblRejectionsCount.Size = new Size(19, 21);
            lblRejectionsCount.TabIndex = 1;
            lblRejectionsCount.Text = "0";
            // 
            // lblRejections
            // 
            lblRejections.AutoSize = true;
            lblRejections.Font = new Font("Segoe UI", 12F);
            lblRejections.Location = new Point(40, 20);
            lblRejections.Name = "lblRejections";
            lblRejections.Size = new Size(81, 21);
            lblRejections.TabIndex = 0;
            lblRejections.Text = "Rejections";
            // 
            // pnlApproval
            // 
            pnlApproval.BackColor = Color.LavenderBlush;
            pnlApproval.BorderStyle = BorderStyle.FixedSingle;
            pnlApproval.Controls.Add(lblApprovalCount);
            pnlApproval.Controls.Add(lblApproval);
            pnlApproval.Location = new Point(675, 80);
            pnlApproval.Name = "pnlApproval";
            pnlApproval.Size = new Size(160, 90);
            pnlApproval.TabIndex = 11;
            // 
            // lblApprovalCount
            // 
            lblApprovalCount.AutoSize = true;
            lblApprovalCount.Font = new Font("Segoe UI", 12F);
            lblApprovalCount.Location = new Point(70, 50);
            lblApprovalCount.Name = "lblApprovalCount";
            lblApprovalCount.Size = new Size(19, 21);
            lblApprovalCount.TabIndex = 1;
            lblApprovalCount.Text = "0";
            // 
            // lblApproval
            // 
            lblApproval.AutoSize = true;
            lblApproval.Font = new Font("Segoe UI", 12F);
            lblApproval.Location = new Point(45, 20);
            lblApproval.Name = "lblApproval";
            lblApproval.Size = new Size(73, 21);
            lblApproval.TabIndex = 0;
            lblApproval.Text = "Approval";
            // 
            // pnlActivities
            // 
            pnlActivities.BackColor = Color.LavenderBlush;
            pnlActivities.BorderStyle = BorderStyle.FixedSingle;
            pnlActivities.Controls.Add(lblActivitiesCount);
            pnlActivities.Controls.Add(lblActivities);
            pnlActivities.Location = new Point(450, 80);
            pnlActivities.Name = "pnlActivities";
            pnlActivities.Size = new Size(160, 90);
            pnlActivities.TabIndex = 9;
            // 
            // lblActivitiesCount
            // 
            lblActivitiesCount.AutoSize = true;
            lblActivitiesCount.Font = new Font("Segoe UI", 12F);
            lblActivitiesCount.Location = new Point(70, 50);
            lblActivitiesCount.Name = "lblActivitiesCount";
            lblActivitiesCount.Size = new Size(19, 21);
            lblActivitiesCount.TabIndex = 1;
            lblActivitiesCount.Text = "0";
            // 
            // lblActivities
            // 
            lblActivities.AutoSize = true;
            lblActivities.Font = new Font("Segoe UI", 12F);
            lblActivities.Location = new Point(15, 20);
            lblActivities.Name = "lblActivities";
            lblActivities.Size = new Size(127, 21);
            lblActivities.TabIndex = 0;
            lblActivities.Text = "Today's Activities";
            // 
            // lblSearch
            // 
            lblSearch.AutoSize = true;
            lblSearch.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblSearch.Location = new Point(20, 55);
            lblSearch.Name = "lblSearch";
            lblSearch.Size = new Size(109, 19);
            lblSearch.TabIndex = 8;
            lblSearch.Text = "Search Activity";
            // 
            // btnRefresh
            // 
            btnRefresh.BackColor = Color.Thistle;
            btnRefresh.FlatStyle = FlatStyle.Flat;
            btnRefresh.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnRefresh.Location = new Point(200, 570);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(130, 40);
            btnRefresh.TabIndex = 7;
            btnRefresh.Text = "Refresh";
            btnRefresh.UseVisualStyleBackColor = false;
            btnRefresh.Click += btnRefresh_Click;
            // 
            // btnExportLog
            // 
            btnExportLog.BackColor = Color.Thistle;
            btnExportLog.FlatStyle = FlatStyle.Flat;
            btnExportLog.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnExportLog.Location = new Point(380, 570);
            btnExportLog.Name = "btnExportLog";
            btnExportLog.Size = new Size(130, 40);
            btnExportLog.TabIndex = 6;
            btnExportLog.Text = "Export Log";
            btnExportLog.UseVisualStyleBackColor = false;
            btnExportLog.Click += btnExportLog_Click;
            // 
            // btnViewDetails
            // 
            btnViewDetails.BackColor = Color.Thistle;
            btnViewDetails.FlatStyle = FlatStyle.Flat;
            btnViewDetails.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnViewDetails.Location = new Point(20, 570);
            btnViewDetails.Name = "btnViewDetails";
            btnViewDetails.Size = new Size(130, 40);
            btnViewDetails.TabIndex = 4;
            btnViewDetails.Text = "View Details";
            btnViewDetails.UseVisualStyleBackColor = false;
            btnViewDetails.Click += btnViewDetails_Click;
            // 
            // dgvAuditTrail
            // 
            dgvAuditTrail.AllowUserToAddRows = false;
            dgvAuditTrail.AllowUserToDeleteRows = false;
            dgvAuditTrail.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvAuditTrail.BackgroundColor = SystemColors.Control;
            dgvAuditTrail.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvAuditTrail.Columns.AddRange(new DataGridViewColumn[] { colAuditId, colUser, colRole, colAction, colDateTime, colRemarks });
            dgvAuditTrail.Location = new Point(20, 200);
            dgvAuditTrail.Name = "dgvAuditTrail";
            dgvAuditTrail.ReadOnly = true;
            dgvAuditTrail.RowHeadersVisible = false;
            dgvAuditTrail.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvAuditTrail.Size = new Size(1090, 350);
            dgvAuditTrail.TabIndex = 3;
            // 
            // colAuditId
            // 
            colAuditId.HeaderText = "Audit ID";
            colAuditId.Name = "colAuditId";
            colAuditId.ReadOnly = true;
            // 
            // colUser
            // 
            colUser.HeaderText = "User";
            colUser.Name = "colUser";
            colUser.ReadOnly = true;
            // 
            // colRole
            // 
            colRole.HeaderText = "Role";
            colRole.Name = "colRole";
            colRole.ReadOnly = true;
            // 
            // colAction
            // 
            colAction.HeaderText = "Action";
            colAction.Name = "colAction";
            colAction.ReadOnly = true;
            // 
            // colDateTime
            // 
            colDateTime.HeaderText = "Date and Time";
            colDateTime.Name = "colDateTime";
            colDateTime.ReadOnly = true;
            // 
            // colRemarks
            // 
            colRemarks.HeaderText = "Remarks";
            colRemarks.Name = "colRemarks";
            colRemarks.ReadOnly = true;
            // 
            // btnSearch
            // 
            btnSearch.BackColor = Color.Thistle;
            btnSearch.FlatStyle = FlatStyle.Flat;
            btnSearch.Location = new Point(280, 75);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(100, 30);
            btnSearch.TabIndex = 2;
            btnSearch.Text = "Search";
            btnSearch.UseVisualStyleBackColor = false;
            btnSearch.Click += btnSearch_Click;
            // 
            // txtSearchAudit
            // 
            txtSearchAudit.Location = new Point(20, 80);
            txtSearchAudit.Name = "txtSearchAudit";
            txtSearchAudit.Size = new Size(250, 23);
            txtSearchAudit.TabIndex = 1;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblTitle.Location = new Point(20, 20);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(133, 32);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Audit Trail";
            // 
            // AuditTrailForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LavenderBlush;
            ClientSize = new Size(1184, 661);
            Controls.Add(panelMain);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "AuditTrailForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Audit Trail";
            panelMain.ResumeLayout(false);
            panelMain.PerformLayout();
            pnlRejections.ResumeLayout(false);
            pnlRejections.PerformLayout();
            pnlApproval.ResumeLayout(false);
            pnlApproval.PerformLayout();
            pnlActivities.ResumeLayout(false);
            pnlActivities.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvAuditTrail).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelMain;
        private Button btnBack;
        private Panel pnlRejections;
        private Label lblRejectionsCount;
        private Label lblRejections;
        private Panel pnlApproval;
        private Label lblApprovalCount;
        private Label lblApproval;
        private Panel pnlActivities;
        private Label lblActivitiesCount;
        private Label lblActivities;
        private Label lblSearch;
        private Button btnRefresh;
        private Button btnCloseJob;
        private Button btnExportLog;
        private Button btnViewDetails;
        private DataGridView dgvAuditTrail;
        private Button btnSearch;
        private TextBox txtSearchAudit;
        private Label lblTitle;
        private DataGridViewTextBoxColumn colAuditId;
        private DataGridViewTextBoxColumn colUser;
        private DataGridViewTextBoxColumn colRole;
        private DataGridViewTextBoxColumn colAction;
        private DataGridViewTextBoxColumn colDateTime;
        private DataGridViewTextBoxColumn colRemarks;
    }
}