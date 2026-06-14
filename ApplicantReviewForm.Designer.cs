namespace HRApplicantSystem
{
    partial class ApplicantReviewForm
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
            panel1 = new Panel();
            label1 = new Label();
            label2 = new Label();
            txtSearch = new TextBox();
            btnSearch = new Button();
            panel2 = new Panel();
            label3 = new Label();
            dgvApplicants = new DataGridView();
            Label4 = new Label();
            label5 = new Label();
            txtApplicant = new TextBox();
            txtJob = new TextBox();
            label6 = new Label();
            cmbStatus = new ComboBox();
            label7 = new Label();
            txtRemarks = new TextBox();
            btnSaveReview = new Button();
            btnRefresh = new Button();
            btnClear = new Button();
            btnClose = new Button();
            btnScreening = new Button();
            Scheduling = new Button();
            btnEvaluation = new Button();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvApplicants).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.Thistle;
            panel1.Controls.Add(label1);
            panel1.Location = new Point(10, 11);
            panel1.Name = "panel1";
            panel1.Size = new Size(1027, 94);
            panel1.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(399, 31);
            label1.Name = "label1";
            label1.Size = new Size(210, 21);
            label1.TabIndex = 1;
            label1.Text = "APPLICANT REVIEW FORM";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Lucida Fax", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(10, 140);
            label2.Name = "label2";
            label2.Size = new Size(116, 15);
            label2.TabIndex = 1;
            label2.Text = "Search Applicant:";
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(148, 140);
            txtSearch.Multiline = true;
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(133, 29);
            txtSearch.TabIndex = 2;
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(313, 140);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(85, 29);
            btnSearch.TabIndex = 3;
            btnSearch.Text = "Search";
            btnSearch.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            panel2.BackColor = Color.Thistle;
            panel2.Controls.Add(label3);
            panel2.Location = new Point(10, 198);
            panel2.Name = "panel2";
            panel2.Size = new Size(1027, 94);
            panel2.TabIndex = 2;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(435, 31);
            label3.Name = "label3";
            label3.Size = new Size(132, 21);
            label3.TabIndex = 1;
            label3.Text = "APPLICANT LIST";
            // 
            // dgvApplicants
            // 
            dgvApplicants.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvApplicants.Location = new Point(13, 321);
            dgvApplicants.Name = "dgvApplicants";
            dgvApplicants.RowHeadersWidth = 51;
            dgvApplicants.RowTemplate.Height = 24;
            dgvApplicants.Size = new Size(1025, 215);
            dgvApplicants.TabIndex = 4;
            // 
            // Label4
            // 
            Label4.AutoSize = true;
            Label4.Font = new Font("Lucida Fax", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Label4.Location = new Point(10, 576);
            Label4.Name = "Label4";
            Label4.Size = new Size(110, 15);
            Label4.TabIndex = 5;
            Label4.Text = "Applicant Name:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Lucida Fax", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.Location = new Point(311, 576);
            label5.Name = "label5";
            label5.Size = new Size(96, 15);
            label5.TabIndex = 6;
            label5.Text = "Applicant Job:";
            // 
            // txtApplicant
            // 
            txtApplicant.Location = new Point(132, 576);
            txtApplicant.Name = "txtApplicant";
            txtApplicant.Size = new Size(148, 23);
            txtApplicant.TabIndex = 7;
            // 
            // txtJob
            // 
            txtJob.Location = new Point(417, 576);
            txtJob.Name = "txtJob";
            txtJob.Size = new Size(148, 23);
            txtJob.TabIndex = 8;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Lucida Fax", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label6.Location = new Point(601, 578);
            label6.Name = "label6";
            label6.Size = new Size(139, 15);
            label6.TabIndex = 9;
            label6.Text = "Current / New Status:";
            // 
            // cmbStatus
            // 
            cmbStatus.FormattingEnabled = true;
            cmbStatus.Location = new Point(772, 574);
            cmbStatus.Name = "cmbStatus";
            cmbStatus.Size = new Size(131, 23);
            cmbStatus.TabIndex = 10;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Lucida Fax", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label7.Location = new Point(24, 628);
            label7.Name = "label7";
            label7.Size = new Size(63, 15);
            label7.TabIndex = 11;
            label7.Text = "Remarks:";
            // 
            // txtRemarks
            // 
            txtRemarks.Location = new Point(27, 665);
            txtRemarks.Multiline = true;
            txtRemarks.Name = "txtRemarks";
            txtRemarks.Size = new Size(311, 144);
            txtRemarks.TabIndex = 12;
            // 
            // btnSaveReview
            // 
            btnSaveReview.Location = new Point(27, 863);
            btnSaveReview.Name = "btnSaveReview";
            btnSaveReview.Size = new Size(100, 22);
            btnSaveReview.TabIndex = 13;
            btnSaveReview.Text = "Save Review";
            btnSaveReview.UseVisualStyleBackColor = true;
            // 
            // btnRefresh
            // 
            btnRefresh.Location = new Point(160, 863);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(100, 22);
            btnRefresh.TabIndex = 14;
            btnRefresh.Text = "Refresh";
            btnRefresh.UseVisualStyleBackColor = true;
            // 
            // btnClear
            // 
            btnClear.Location = new Point(298, 863);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(100, 22);
            btnClear.TabIndex = 15;
            btnClear.Text = "Clear";
            btnClear.UseVisualStyleBackColor = true;
            // 
            // btnClose
            // 
            btnClose.Location = new Point(430, 863);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(100, 22);
            btnClose.TabIndex = 16;
            btnClose.Text = "Close";
            btnClose.UseVisualStyleBackColor = true;
            // 
            // btnScreening
            // 
            btnScreening.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            btnScreening.ForeColor = Color.Black;
            btnScreening.Location = new Point(490, 645);
            btnScreening.Name = "btnScreening";
            btnScreening.Size = new Size(150, 40);
            btnScreening.TabIndex = 17;
            btnScreening.Text = "Screening";
            btnScreening.UseVisualStyleBackColor = true;
            btnScreening.Click += btnScreening_Click;
            // 
            // Scheduling
            // 
            Scheduling.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            Scheduling.ForeColor = Color.Black;
            Scheduling.Location = new Point(670, 640);
            Scheduling.Name = "Scheduling";
            Scheduling.Size = new Size(150, 50);
            Scheduling.TabIndex = 19;
            Scheduling.Text = "Interview \r\nScheduling";
            Scheduling.UseVisualStyleBackColor = true;
            Scheduling.Click += Scheduling_Click;
            // 
            // btnEvaluation
            // 
            btnEvaluation.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnEvaluation.ForeColor = Color.Black;
            btnEvaluation.Location = new Point(850, 640);
            btnEvaluation.Name = "btnEvaluation";
            btnEvaluation.Size = new Size(150, 50);
            btnEvaluation.TabIndex = 20;
            btnEvaluation.Text = "Interview \r\nEvaluation";
            btnEvaluation.UseVisualStyleBackColor = true;
            btnEvaluation.Click += btnEvaluation_Click;
            // 
            // ApplicantReviewForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            AutoScrollMinSize = new Size(0, 950);
            BackColor = Color.LavenderBlush;
            ClientSize = new Size(1084, 701);
            Controls.Add(btnEvaluation);
            Controls.Add(Scheduling);
            Controls.Add(btnScreening);
            Controls.Add(btnClose);
            Controls.Add(btnClear);
            Controls.Add(btnRefresh);
            Controls.Add(btnSaveReview);
            Controls.Add(txtRemarks);
            Controls.Add(label7);
            Controls.Add(cmbStatus);
            Controls.Add(label6);
            Controls.Add(txtJob);
            Controls.Add(txtApplicant);
            Controls.Add(label5);
            Controls.Add(Label4);
            Controls.Add(dgvApplicants);
            Controls.Add(panel2);
            Controls.Add(btnSearch);
            Controls.Add(txtSearch);
            Controls.Add(label2);
            Controls.Add(panel1);
            MinimizeBox = false;
            Name = "ApplicantReviewForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
            Load += Form1_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvApplicants).EndInit();
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dgvApplicants;
        private System.Windows.Forms.Label Label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtApplicant;
        private System.Windows.Forms.TextBox txtJob;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmbStatus;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtRemarks;
        private System.Windows.Forms.Button btnSaveReview;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnClose;
        private Button btnScreening;
        private Button Scheduling;
        private Button btnEvaluation;
    }
}

