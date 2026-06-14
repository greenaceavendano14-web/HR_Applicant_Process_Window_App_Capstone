namespace HRApplicantSystem
    {
    partial class ScreeningForm
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
            dgvScreening = new DataGridView();
            label4 = new Label();
            label5 = new Label();
            txtApplicant = new TextBox();
            txtJob = new TextBox();
            label6 = new Label();
            cmbResult = new ComboBox();
            label7 = new Label();
            txtRemarks = new TextBox();
            btnSave = new Button();
            btnRefresh = new Button();
            btnClear = new Button();
            btnClose = new Button();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvScreening).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.Thistle;
            panel1.Controls.Add(label1);
            panel1.Location = new Point(14, 18);
            panel1.Margin = new Padding(4, 5, 4, 5);
            panel1.Name = "panel1";
            panel1.Size = new Size(1414, 157);
            panel1.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(531, 63);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(226, 20);
            label1.TabIndex = 1;
            label1.Text = "APPLICANT SCREENING FORM";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Lucida Fax", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(14, 237);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(52, 15);
            label2.TabIndex = 1;
            label2.Text = "Search:";
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(19, 285);
            txtSearch.Margin = new Padding(4, 5, 4, 5);
            txtSearch.Multiline = true;
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(218, 49);
            txtSearch.TabIndex = 2;
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(281, 285);
            btnSearch.Margin = new Padding(4, 5, 4, 5);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(121, 52);
            btnSearch.TabIndex = 3;
            btnSearch.Text = "Search";
            btnSearch.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            panel2.BackColor = Color.Thistle;
            panel2.Controls.Add(label3);
            panel2.Location = new Point(19, 382);
            panel2.Margin = new Padding(4, 5, 4, 5);
            panel2.Name = "panel2";
            panel2.Size = new Size(1414, 157);
            panel2.TabIndex = 2;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(576, 63);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(126, 20);
            label3.TabIndex = 1;
            label3.Text = "APPLICANT LIST";
            // 
            // dgvScreening
            // 
            dgvScreening.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvScreening.Location = new Point(19, 575);
            dgvScreening.Margin = new Padding(4, 5, 4, 5);
            dgvScreening.Name = "dgvScreening";
            dgvScreening.RowHeadersWidth = 51;
            dgvScreening.RowTemplate.Height = 24;
            dgvScreening.Size = new Size(1411, 357);
            dgvScreening.TabIndex = 4;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Lucida Fax", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(14, 997);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(110, 15);
            label4.TabIndex = 5;
            label4.Text = "Applicant Name:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Lucida Fax", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.Location = new Point(477, 1002);
            label5.Margin = new Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new Size(64, 15);
            label5.TabIndex = 6;
            label5.Text = "Job Title:";
            // 
            // txtApplicant
            // 
            txtApplicant.Location = new Point(211, 993);
            txtApplicant.Margin = new Padding(4, 5, 4, 5);
            txtApplicant.Name = "txtApplicant";
            txtApplicant.Size = new Size(197, 23);
            txtApplicant.TabIndex = 7;
            // 
            // txtJob
            // 
            txtJob.Location = new Point(601, 993);
            txtJob.Margin = new Padding(4, 5, 4, 5);
            txtJob.Name = "txtJob";
            txtJob.Size = new Size(197, 23);
            txtJob.TabIndex = 8;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Lucida Fax", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label6.Location = new Point(867, 1002);
            label6.Margin = new Padding(4, 0, 4, 0);
            label6.Name = "label6";
            label6.Size = new Size(113, 15);
            label6.TabIndex = 9;
            label6.Text = "Screening Result:";
            // 
            // cmbResult
            // 
            cmbResult.FormattingEnabled = true;
            cmbResult.Location = new Point(1069, 993);
            cmbResult.Margin = new Padding(4, 5, 4, 5);
            cmbResult.Name = "cmbResult";
            cmbResult.Size = new Size(197, 23);
            cmbResult.TabIndex = 10;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Lucida Fax", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label7.Location = new Point(36, 1073);
            label7.Margin = new Padding(4, 0, 4, 0);
            label7.Name = "label7";
            label7.Size = new Size(63, 15);
            label7.TabIndex = 11;
            label7.Text = "Remarks:";
            // 
            // txtRemarks
            // 
            txtRemarks.Location = new Point(40, 1120);
            txtRemarks.Margin = new Padding(4, 5, 4, 5);
            txtRemarks.Multiline = true;
            txtRemarks.Name = "txtRemarks";
            txtRemarks.Size = new Size(368, 214);
            txtRemarks.TabIndex = 12;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(40, 1403);
            btnSave.Margin = new Padding(4, 5, 4, 5);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(126, 37);
            btnSave.TabIndex = 13;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            // 
            // btnRefresh
            // 
            btnRefresh.Location = new Point(211, 1403);
            btnRefresh.Margin = new Padding(4, 5, 4, 5);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(126, 37);
            btnRefresh.TabIndex = 14;
            btnRefresh.Text = "Refresh";
            btnRefresh.UseVisualStyleBackColor = true;
            // 
            // btnClear
            // 
            btnClear.Location = new Point(376, 1403);
            btnClear.Margin = new Padding(4, 5, 4, 5);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(126, 37);
            btnClear.TabIndex = 15;
            btnClear.Text = "Clear";
            btnClear.UseVisualStyleBackColor = true;
            // 
            // btnClose
            // 
            btnClose.Location = new Point(531, 1403);
            btnClose.Margin = new Padding(4, 5, 4, 5);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(126, 37);
            btnClose.TabIndex = 16;
            btnClose.Text = "Close";
            btnClose.UseVisualStyleBackColor = true;
            // 
            // ScreeningForm
            // 
            AutoScaleMode = AutoScaleMode.None;
            AutoScroll = true;
            AutoScrollMinSize = new Size(0, 1050);
            BackColor = Color.LavenderBlush;
            ClientSize = new Size(1446, 1061);
            Controls.Add(btnClose);
            Controls.Add(btnClear);
            Controls.Add(btnRefresh);
            Controls.Add(btnSave);
            Controls.Add(txtRemarks);
            Controls.Add(label7);
            Controls.Add(cmbResult);
            Controls.Add(label6);
            Controls.Add(txtJob);
            Controls.Add(txtApplicant);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(dgvScreening);
            Controls.Add(panel2);
            Controls.Add(btnSearch);
            Controls.Add(txtSearch);
            Controls.Add(label2);
            Controls.Add(panel1);
            Margin = new Padding(4, 5, 4, 5);
            Name = "ScreeningForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
            Load += Form1_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvScreening).EndInit();
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.DataGridView dgvScreening;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtApplicant;
        private System.Windows.Forms.TextBox txtJob;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmbResult;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtRemarks;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnClose;
    }
}

