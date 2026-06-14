namespace HRApplicantSystem
{
    partial class ReportsForm
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
            btnHiringReport = new Button();
            btnJobReport = new Button();
            btnAuditReport = new Button();
            btnApplicantReport = new Button();
            pnlRejected = new Panel();
            lblRejectedCount = new Label();
            lblRejected = new Label();
            pnlHired = new Panel();
            lblHiredCount = new Label();
            lblHired = new Label();
            pnlApplications = new Panel();
            lblApplicationsCount = new Label();
            lblApplication = new Label();
            pnlTotalApplicants = new Panel();
            lblApplicantsCount = new Label();
            lblApplicantTitle = new Label();
            lblSearch = new Label();
            btnPrint = new Button();
            btnRefresh = new Button();
            btnExportPDF = new Button();
            dgvReports = new DataGridView();
            colReportId = new DataGridViewTextBoxColumn();
            colReportName = new DataGridViewTextBoxColumn();
            colGeneratedBy = new DataGridViewTextBoxColumn();
            colDateGenerated = new DataGridViewTextBoxColumn();
            colStatus = new DataGridViewTextBoxColumn();
            btnSearch = new Button();
            txtSearchJob = new TextBox();
            lblTitle = new Label();
            panelMain.SuspendLayout();
            pnlRejected.SuspendLayout();
            pnlHired.SuspendLayout();
            pnlApplications.SuspendLayout();
            pnlTotalApplicants.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvReports).BeginInit();
            SuspendLayout();
            // 
            // panelMain
            // 
            panelMain.BackColor = Color.White;
            panelMain.Controls.Add(btnBack);
            panelMain.Controls.Add(btnHiringReport);
            panelMain.Controls.Add(btnJobReport);
            panelMain.Controls.Add(btnAuditReport);
            panelMain.Controls.Add(btnApplicantReport);
            panelMain.Controls.Add(pnlRejected);
            panelMain.Controls.Add(pnlHired);
            panelMain.Controls.Add(pnlApplications);
            panelMain.Controls.Add(pnlTotalApplicants);
            panelMain.Controls.Add(lblSearch);
            panelMain.Controls.Add(btnPrint);
            panelMain.Controls.Add(btnRefresh);
            panelMain.Controls.Add(btnExportPDF);
            panelMain.Controls.Add(dgvReports);
            panelMain.Controls.Add(btnSearch);
            panelMain.Controls.Add(txtSearchJob);
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
            btnBack.TabIndex = 17;
            btnBack.Text = "Back to \r\nDashboard\r\n";
            btnBack.UseVisualStyleBackColor = false;
            // 
            // btnHiringReport
            // 
            btnHiringReport.BackColor = Color.Thistle;
            btnHiringReport.FlatStyle = FlatStyle.Flat;
            btnHiringReport.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnHiringReport.Location = new Point(446, 187);
            btnHiringReport.Name = "btnHiringReport";
            btnHiringReport.Size = new Size(130, 55);
            btnHiringReport.TabIndex = 16;
            btnHiringReport.Text = "Hiring\r\nReport\r\n";
            btnHiringReport.UseVisualStyleBackColor = false;
            // 
            // btnJobReport
            // 
            btnJobReport.BackColor = Color.Thistle;
            btnJobReport.FlatStyle = FlatStyle.Flat;
            btnJobReport.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnJobReport.Location = new Point(626, 187);
            btnJobReport.Name = "btnJobReport";
            btnJobReport.Size = new Size(130, 55);
            btnJobReport.TabIndex = 15;
            btnJobReport.Text = "Job\r\nReport\r\n";
            btnJobReport.UseVisualStyleBackColor = false;
            // 
            // btnAuditReport
            // 
            btnAuditReport.BackColor = Color.Thistle;
            btnAuditReport.FlatStyle = FlatStyle.Flat;
            btnAuditReport.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnAuditReport.Location = new Point(806, 187);
            btnAuditReport.Name = "btnAuditReport";
            btnAuditReport.Size = new Size(130, 55);
            btnAuditReport.TabIndex = 14;
            btnAuditReport.Text = "Audit\r\nReport";
            btnAuditReport.UseVisualStyleBackColor = false;
            // 
            // btnApplicantReport
            // 
            btnApplicantReport.BackColor = Color.Thistle;
            btnApplicantReport.FlatStyle = FlatStyle.Flat;
            btnApplicantReport.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnApplicantReport.Location = new Point(266, 187);
            btnApplicantReport.Name = "btnApplicantReport";
            btnApplicantReport.Size = new Size(130, 55);
            btnApplicantReport.TabIndex = 13;
            btnApplicantReport.Text = "Applicant \r\nReport";
            btnApplicantReport.UseVisualStyleBackColor = false;
            // 
            // pnlRejected
            // 
            pnlRejected.BackColor = Color.LavenderBlush;
            pnlRejected.BorderStyle = BorderStyle.FixedSingle;
            pnlRejected.Controls.Add(lblRejectedCount);
            pnlRejected.Controls.Add(lblRejected);
            pnlRejected.Location = new Point(940, 80);
            pnlRejected.Name = "pnlRejected";
            pnlRejected.Size = new Size(160, 90);
            pnlRejected.TabIndex = 12;
            // 
            // lblRejectedCount
            // 
            lblRejectedCount.AutoSize = true;
            lblRejectedCount.Font = new Font("Segoe UI", 12F);
            lblRejectedCount.Location = new Point(70, 50);
            lblRejectedCount.Name = "lblRejectedCount";
            lblRejectedCount.Size = new Size(19, 21);
            lblRejectedCount.TabIndex = 1;
            lblRejectedCount.Text = "0";
            // 
            // lblRejected
            // 
            lblRejected.AutoSize = true;
            lblRejected.Font = new Font("Segoe UI", 12F);
            lblRejected.Location = new Point(45, 20);
            lblRejected.Name = "lblRejected";
            lblRejected.Size = new Size(69, 21);
            lblRejected.TabIndex = 0;
            lblRejected.Text = "Rejected";
            // 
            // pnlHired
            // 
            pnlHired.BackColor = Color.LavenderBlush;
            pnlHired.BorderStyle = BorderStyle.FixedSingle;
            pnlHired.Controls.Add(lblHiredCount);
            pnlHired.Controls.Add(lblHired);
            pnlHired.Location = new Point(760, 80);
            pnlHired.Name = "pnlHired";
            pnlHired.Size = new Size(160, 90);
            pnlHired.TabIndex = 10;
            // 
            // lblHiredCount
            // 
            lblHiredCount.AutoSize = true;
            lblHiredCount.Font = new Font("Segoe UI", 12F);
            lblHiredCount.Location = new Point(70, 50);
            lblHiredCount.Name = "lblHiredCount";
            lblHiredCount.Size = new Size(19, 21);
            lblHiredCount.TabIndex = 1;
            lblHiredCount.Text = "0";
            // 
            // lblHired
            // 
            lblHired.AutoSize = true;
            lblHired.Font = new Font("Segoe UI", 12F);
            lblHired.Location = new Point(55, 20);
            lblHired.Name = "lblHired";
            lblHired.Size = new Size(48, 21);
            lblHired.TabIndex = 0;
            lblHired.Text = "Hired";
            // 
            // pnlApplications
            // 
            pnlApplications.BackColor = Color.LavenderBlush;
            pnlApplications.BorderStyle = BorderStyle.FixedSingle;
            pnlApplications.Controls.Add(lblApplicationsCount);
            pnlApplications.Controls.Add(lblApplication);
            pnlApplications.Location = new Point(580, 80);
            pnlApplications.Name = "pnlApplications";
            pnlApplications.Size = new Size(160, 90);
            pnlApplications.TabIndex = 11;
            // 
            // lblApplicationsCount
            // 
            lblApplicationsCount.AutoSize = true;
            lblApplicationsCount.Font = new Font("Segoe UI", 12F);
            lblApplicationsCount.Location = new Point(70, 50);
            lblApplicationsCount.Name = "lblApplicationsCount";
            lblApplicationsCount.Size = new Size(19, 21);
            lblApplicationsCount.TabIndex = 1;
            lblApplicationsCount.Text = "0";
            // 
            // lblApplication
            // 
            lblApplication.AutoSize = true;
            lblApplication.Font = new Font("Segoe UI", 12F);
            lblApplication.Location = new Point(33, 20);
            lblApplication.Name = "lblApplication";
            lblApplication.Size = new Size(95, 21);
            lblApplication.TabIndex = 0;
            lblApplication.Text = "Applications";
            // 
            // pnlTotalApplicants
            // 
            pnlTotalApplicants.BackColor = Color.LavenderBlush;
            pnlTotalApplicants.BorderStyle = BorderStyle.FixedSingle;
            pnlTotalApplicants.Controls.Add(lblApplicantsCount);
            pnlTotalApplicants.Controls.Add(lblApplicantTitle);
            pnlTotalApplicants.Location = new Point(400, 80);
            pnlTotalApplicants.Name = "pnlTotalApplicants";
            pnlTotalApplicants.Size = new Size(160, 90);
            pnlTotalApplicants.TabIndex = 9;
            // 
            // lblApplicantsCount
            // 
            lblApplicantsCount.AutoSize = true;
            lblApplicantsCount.Font = new Font("Segoe UI", 12F);
            lblApplicantsCount.Location = new Point(70, 50);
            lblApplicantsCount.Name = "lblApplicantsCount";
            lblApplicantsCount.Size = new Size(19, 21);
            lblApplicantsCount.TabIndex = 1;
            lblApplicantsCount.Text = "0";
            // 
            // lblApplicantTitle
            // 
            lblApplicantTitle.AutoSize = true;
            lblApplicantTitle.Font = new Font("Segoe UI", 12F);
            lblApplicantTitle.Location = new Point(45, 20);
            lblApplicantTitle.Name = "lblApplicantTitle";
            lblApplicantTitle.Size = new Size(75, 21);
            lblApplicantTitle.TabIndex = 0;
            lblApplicantTitle.Text = "Applicant";
            // 
            // lblSearch
            // 
            lblSearch.AutoSize = true;
            lblSearch.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblSearch.Location = new Point(20, 55);
            lblSearch.Name = "lblSearch";
            lblSearch.Size = new Size(140, 19);
            lblSearch.TabIndex = 8;
            lblSearch.Text = "Search Job Position";
            // 
            // btnPrint
            // 
            btnPrint.BackColor = Color.Thistle;
            btnPrint.FlatStyle = FlatStyle.Flat;
            btnPrint.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnPrint.Location = new Point(200, 570);
            btnPrint.Name = "btnPrint";
            btnPrint.Size = new Size(130, 40);
            btnPrint.TabIndex = 7;
            btnPrint.Text = "Print";
            btnPrint.UseVisualStyleBackColor = false;
            btnPrint.Click += btnPrint_Click;
            // 
            // btnRefresh
            // 
            btnRefresh.BackColor = Color.Thistle;
            btnRefresh.FlatStyle = FlatStyle.Flat;
            btnRefresh.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnRefresh.Location = new Point(380, 570);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(130, 40);
            btnRefresh.TabIndex = 6;
            btnRefresh.Text = "Refresh";
            btnRefresh.UseVisualStyleBackColor = false;
            // 
            // btnExportPDF
            // 
            btnExportPDF.BackColor = Color.Thistle;
            btnExportPDF.FlatStyle = FlatStyle.Flat;
            btnExportPDF.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnExportPDF.Location = new Point(20, 570);
            btnExportPDF.Name = "btnExportPDF";
            btnExportPDF.Size = new Size(130, 40);
            btnExportPDF.TabIndex = 4;
            btnExportPDF.Text = "Export PDF";
            btnExportPDF.UseVisualStyleBackColor = false;
            btnExportPDF.Click += btnExportPDF_Click;
            // 
            // dgvReports
            // 
            dgvReports.AllowUserToAddRows = false;
            dgvReports.AllowUserToDeleteRows = false;
            dgvReports.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvReports.BackgroundColor = SystemColors.Control;
            dgvReports.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvReports.Columns.AddRange(new DataGridViewColumn[] { colReportId, colReportName, colGeneratedBy, colDateGenerated, colStatus });
            dgvReports.Location = new Point(20, 257);
            dgvReports.Name = "dgvReports";
            dgvReports.ReadOnly = true;
            dgvReports.RowHeadersVisible = false;
            dgvReports.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvReports.Size = new Size(1090, 293);
            dgvReports.TabIndex = 3;
            // 
            // colReportId
            // 
            colReportId.HeaderText = "Report ID";
            colReportId.Name = "colReportId";
            colReportId.ReadOnly = true;
            // 
            // colReportName
            // 
            colReportName.HeaderText = "Report Name";
            colReportName.Name = "colReportName";
            colReportName.ReadOnly = true;
            // 
            // colGeneratedBy
            // 
            colGeneratedBy.HeaderText = "Generated By";
            colGeneratedBy.Name = "colGeneratedBy";
            colGeneratedBy.ReadOnly = true;
            // 
            // colDateGenerated
            // 
            colDateGenerated.HeaderText = "Date ";
            colDateGenerated.Name = "colDateGenerated";
            colDateGenerated.ReadOnly = true;
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
            btnSearch.Location = new Point(280, 75);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(100, 30);
            btnSearch.TabIndex = 2;
            btnSearch.Text = "Search";
            btnSearch.UseVisualStyleBackColor = false;
            // 
            // txtSearchJob
            // 
            txtSearchJob.Location = new Point(20, 80);
            txtSearchJob.Name = "txtSearchJob";
            txtSearchJob.Size = new Size(250, 23);
            txtSearchJob.TabIndex = 1;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblTitle.Location = new Point(20, 20);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(103, 32);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Reports";
            // 
            // ReportsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LavenderBlush;
            ClientSize = new Size(1184, 661);
            Controls.Add(panelMain);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "ReportsForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Reports";
            panelMain.ResumeLayout(false);
            panelMain.PerformLayout();
            pnlRejected.ResumeLayout(false);
            pnlRejected.PerformLayout();
            pnlHired.ResumeLayout(false);
            pnlHired.PerformLayout();
            pnlApplications.ResumeLayout(false);
            pnlApplications.PerformLayout();
            pnlTotalApplicants.ResumeLayout(false);
            pnlTotalApplicants.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvReports).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelMain;
        private Panel pnlRejected;
        private Label lblRejectedCount;
        private Label lblRejected;
        private Panel pnlHired;
        private Label lblHiredCount;
        private Label lblHired;
        private Panel pnlApplications;
        private Label lblApplicationsCount;
        private Label lblApplication;
        private Panel pnlTotalApplicants;
        private Label lblApplicantsCount;
        private Label lblApplicantTitle;
        private Label lblSearch;
        private Button btnPrint;
        private Button btnRefresh;
        private Button btnExportPDF;
        private DataGridView dgvReports;
        private Button btnSearch;
        private TextBox txtSearchJob;
        private Label lblTitle;
        private Button btnHiringReport;
        private Button btnJobReport;
        private Button btnAuditReport;
        private Button btnApplicantReport;
        private DataGridViewTextBoxColumn colReportId;
        private DataGridViewTextBoxColumn colReportName;
        private DataGridViewTextBoxColumn colGeneratedBy;
        private DataGridViewTextBoxColumn colDateGenerated;
        private DataGridViewTextBoxColumn colStatus;
        private Button btnBack;
    }
}