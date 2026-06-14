namespace HRApplicantSystem
{
    partial class HiringDecisionForm
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
            pnlRejected = new Panel();
            lblRejectedCount = new Label();
            lblRejected = new Label();
            pnlApproved = new Panel();
            lblApprovedCount = new Label();
            lblApproved = new Label();
            pnlPendingDecision = new Panel();
            lblPendingDecisionsCount = new Label();
            lblPendingDecision = new Label();
            lblSearch = new Label();
            btnRejectHiring = new Button();
            btnApproveHiring = new Button();
            dgvHiringDecision = new DataGridView();
            btnSearch = new Button();
            txtSearchHiring = new TextBox();
            lblTitle = new Label();
            panelMain.SuspendLayout();
            pnlRejected.SuspendLayout();
            pnlApproved.SuspendLayout();
            pnlPendingDecision.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvHiringDecision).BeginInit();
            SuspendLayout();
            // 
            // panelMain
            // 
            panelMain.BackColor = Color.White;
            panelMain.Controls.Add(btnBack);
            panelMain.Controls.Add(pnlRejected);
            panelMain.Controls.Add(pnlApproved);
            panelMain.Controls.Add(pnlPendingDecision);
            panelMain.Controls.Add(lblSearch);
            panelMain.Controls.Add(btnRejectHiring);
            panelMain.Controls.Add(btnApproveHiring);
            panelMain.Controls.Add(dgvHiringDecision);
            panelMain.Controls.Add(btnSearch);
            panelMain.Controls.Add(txtSearchHiring);
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
            btnBack.Location = new Point(980, 550);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(130, 55);
            btnBack.TabIndex = 18;
            btnBack.Text = "Back to \r\nDashboard\r\n";
            btnBack.UseVisualStyleBackColor = false;
            // 
            // pnlRejected
            // 
            pnlRejected.BackColor = Color.LavenderBlush;
            pnlRejected.BorderStyle = BorderStyle.FixedSingle;
            pnlRejected.Controls.Add(lblRejectedCount);
            pnlRejected.Controls.Add(lblRejected);
            pnlRejected.Location = new Point(900, 80);
            pnlRejected.Name = "pnlRejected";
            pnlRejected.Size = new Size(160, 90);
            pnlRejected.TabIndex = 10;
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
            // pnlApproved
            // 
            pnlApproved.BackColor = Color.LavenderBlush;
            pnlApproved.BorderStyle = BorderStyle.FixedSingle;
            pnlApproved.Controls.Add(lblApprovedCount);
            pnlApproved.Controls.Add(lblApproved);
            pnlApproved.Location = new Point(675, 80);
            pnlApproved.Name = "pnlApproved";
            pnlApproved.Size = new Size(160, 90);
            pnlApproved.TabIndex = 11;
            // 
            // lblApprovedCount
            // 
            lblApprovedCount.AutoSize = true;
            lblApprovedCount.Font = new Font("Segoe UI", 12F);
            lblApprovedCount.Location = new Point(70, 50);
            lblApprovedCount.Name = "lblApprovedCount";
            lblApprovedCount.Size = new Size(19, 21);
            lblApprovedCount.TabIndex = 1;
            lblApprovedCount.Text = "0";
            // 
            // lblApproved
            // 
            lblApproved.AutoSize = true;
            lblApproved.Font = new Font("Segoe UI", 12F);
            lblApproved.Location = new Point(40, 20);
            lblApproved.Name = "lblApproved";
            lblApproved.Size = new Size(78, 21);
            lblApproved.TabIndex = 0;
            lblApproved.Text = "Approved";
            // 
            // pnlPendingDecision
            // 
            pnlPendingDecision.BackColor = Color.LavenderBlush;
            pnlPendingDecision.BorderStyle = BorderStyle.FixedSingle;
            pnlPendingDecision.Controls.Add(lblPendingDecisionsCount);
            pnlPendingDecision.Controls.Add(lblPendingDecision);
            pnlPendingDecision.Location = new Point(450, 80);
            pnlPendingDecision.Name = "pnlPendingDecision";
            pnlPendingDecision.Size = new Size(160, 90);
            pnlPendingDecision.TabIndex = 9;
            // 
            // lblPendingDecisionsCount
            // 
            lblPendingDecisionsCount.AutoSize = true;
            lblPendingDecisionsCount.Font = new Font("Segoe UI", 12F);
            lblPendingDecisionsCount.Location = new Point(70, 50);
            lblPendingDecisionsCount.Name = "lblPendingDecisionsCount";
            lblPendingDecisionsCount.Size = new Size(19, 21);
            lblPendingDecisionsCount.TabIndex = 1;
            lblPendingDecisionsCount.Text = "0";
            // 
            // lblPendingDecision
            // 
            lblPendingDecision.AutoSize = true;
            lblPendingDecision.Font = new Font("Segoe UI", 12F);
            lblPendingDecision.Location = new Point(10, 20);
            lblPendingDecision.Name = "lblPendingDecision";
            lblPendingDecision.Size = new Size(136, 21);
            lblPendingDecision.TabIndex = 0;
            lblPendingDecision.Text = "Pending Decisions";
            // 
            // lblSearch
            // 
            lblSearch.AutoSize = true;
            lblSearch.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblSearch.Location = new Point(20, 55);
            lblSearch.Name = "lblSearch";
            lblSearch.Size = new Size(122, 19);
            lblSearch.TabIndex = 8;
            lblSearch.Text = "Search Applicant";
            // 
            // btnRejectHiring
            // 
            btnRejectHiring.BackColor = Color.Thistle;
            btnRejectHiring.FlatStyle = FlatStyle.Flat;
            btnRejectHiring.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnRejectHiring.Location = new Point(200, 550);
            btnRejectHiring.Name = "btnRejectHiring";
            btnRejectHiring.Size = new Size(130, 55);
            btnRejectHiring.TabIndex = 7;
            btnRejectHiring.Text = "Reject Hiring";
            btnRejectHiring.UseVisualStyleBackColor = false;
            // 
            // btnApproveHiring
            // 
            btnApproveHiring.BackColor = Color.Thistle;
            btnApproveHiring.FlatStyle = FlatStyle.Flat;
            btnApproveHiring.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnApproveHiring.Location = new Point(20, 550);
            btnApproveHiring.Name = "btnApproveHiring";
            btnApproveHiring.Size = new Size(130, 55);
            btnApproveHiring.TabIndex = 4;
            btnApproveHiring.Text = "Approve \r\nHiring";
            btnApproveHiring.UseVisualStyleBackColor = false;
            // 
            // dgvHiringDecision
            // 
            dgvHiringDecision.AllowUserToAddRows = false;
            dgvHiringDecision.AllowUserToDeleteRows = false;
            dgvHiringDecision.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvHiringDecision.BackgroundColor = SystemColors.Control;
            dgvHiringDecision.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvHiringDecision.Location = new Point(20, 180);
            dgvHiringDecision.Name = "dgvHiringDecision";
            dgvHiringDecision.ReadOnly = true;
            dgvHiringDecision.RowHeadersVisible = false;
            dgvHiringDecision.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvHiringDecision.Size = new Size(1090, 350);
            dgvHiringDecision.TabIndex = 3;
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
            // txtSearchHiring
            // 
            txtSearchHiring.Location = new Point(20, 80);
            txtSearchHiring.Name = "txtSearchHiring";
            txtSearchHiring.Size = new Size(250, 23);
            txtSearchHiring.TabIndex = 1;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblTitle.Location = new Point(20, 20);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(244, 32);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Hiring Management";
            // 
            // HiringDecisionForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LavenderBlush;
            ClientSize = new Size(1184, 661);
            Controls.Add(panelMain);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "HiringDecisionForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Hiring Decision";
            panelMain.ResumeLayout(false);
            panelMain.PerformLayout();
            pnlRejected.ResumeLayout(false);
            pnlRejected.PerformLayout();
            pnlApproved.ResumeLayout(false);
            pnlApproved.PerformLayout();
            pnlPendingDecision.ResumeLayout(false);
            pnlPendingDecision.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvHiringDecision).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelMain;
        private Panel pnlRejected;
        private Label lblRejectedCount;
        private Label lblRejected;
        private Panel pnlApproved;
        private Label lblApprovedCount;
        private Label lblApproved;
        private Panel pnlPendingDecision;
        private Label lblPendingDecisionsCount;
        private Label lblPendingDecision;
        private Label lblSearch;
        private Button btnRejectHiring;
        private Button btnApproveHiring;
        private DataGridView dgvHiringDecision;
        private Button btnSearch;
        private TextBox txtSearchHiring;
        private Label lblTitle;
        private DataGridViewTextBoxColumn colDecisionId;
        private DataGridViewTextBoxColumn colApplicantName;
        private DataGridViewTextBoxColumn colPosition;
        private DataGridViewTextBoxColumn colInterviewResults;
        private DataGridViewTextBoxColumn colHRRecommendation;
        private DataGridViewTextBoxColumn colFinalDecision;
        private Button btnBack;
    }
}