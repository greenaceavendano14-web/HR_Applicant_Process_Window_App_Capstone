namespace HRApplicantSystem
{
    partial class InterviewEvaluationForm
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
            dgvInterview = new DataGridView();
            label4 = new Label();
            label5 = new Label();
            txtApplicant = new TextBox();
            txtJob = new TextBox();
            label6 = new Label();
            dtpInterviewDate = new DateTimePicker();
            label7 = new Label();
            numCommunication = new NumericUpDown();
            numTechnical = new NumericUpDown();
            numProblemSolving = new NumericUpDown();
            numConfidence = new NumericUpDown();
            label8 = new Label();
            label9 = new Label();
            label10 = new Label();
            label11 = new Label();
            lblOverall = new Label();
            label12 = new Label();
            cmbRecommendation = new ComboBox();
            Label13 = new Label();
            txtRemarks = new TextBox();
            btnSave = new Button();
            btnRefresh = new Button();
            btnClear = new Button();
            btnClose = new Button();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvInterview).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numCommunication).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numTechnical).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numProblemSolving).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numConfidence).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.Thistle;
            panel1.Controls.Add(label1);
            panel1.Location = new Point(14, 18);
            panel1.Margin = new Padding(4, 5, 4, 5);
            panel1.Name = "panel1";
            panel1.Size = new Size(1554, 157);
            panel1.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(590, 62);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(342, 30);
            label1.TabIndex = 1;
            label1.Text = "INTERVIEW EVALUATION FORM";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Lucida Fax", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(14, 238);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(76, 21);
            label2.TabIndex = 1;
            label2.Text = "Search:";
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(119, 238);
            txtSearch.Margin = new Padding(4, 5, 4, 5);
            txtSearch.Multiline = true;
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(210, 42);
            txtSearch.TabIndex = 2;
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(383, 238);
            btnSearch.Margin = new Padding(4, 5, 4, 5);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(110, 45);
            btnSearch.TabIndex = 3;
            btnSearch.Text = "Search";
            btnSearch.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            panel2.BackColor = Color.Thistle;
            panel2.Controls.Add(label3);
            panel2.Location = new Point(14, 312);
            panel2.Margin = new Padding(4, 5, 4, 5);
            panel2.Name = "panel2";
            panel2.Size = new Size(1554, 157);
            panel2.TabIndex = 2;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(646, 62);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(188, 30);
            label3.TabIndex = 1;
            label3.Text = "APPLICANT LIST ";
            // 
            // dgvInterview
            // 
            dgvInterview.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvInterview.Location = new Point(19, 497);
            dgvInterview.Margin = new Padding(4, 5, 4, 5);
            dgvInterview.Name = "dgvInterview";
            dgvInterview.RowHeadersWidth = 51;
            dgvInterview.RowTemplate.Height = 24;
            dgvInterview.Size = new Size(1550, 348);
            dgvInterview.TabIndex = 4;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Lucida Fax", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(14, 908);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(104, 21);
            label4.TabIndex = 5;
            label4.Text = "Applicant:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Lucida Fax", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.Location = new Point(361, 908);
            label5.Margin = new Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new Size(94, 21);
            label5.TabIndex = 6;
            label5.Text = "Job Title:";
            // 
            // txtApplicant
            // 
            txtApplicant.Location = new Point(130, 905);
            txtApplicant.Margin = new Padding(4, 5, 4, 5);
            txtApplicant.Name = "txtApplicant";
            txtApplicant.Size = new Size(208, 31);
            txtApplicant.TabIndex = 7;
            // 
            // txtJob
            // 
            txtJob.Location = new Point(466, 908);
            txtJob.Margin = new Padding(4, 5, 4, 5);
            txtJob.Name = "txtJob";
            txtJob.Size = new Size(208, 31);
            txtJob.TabIndex = 8;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Lucida Fax", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label6.Location = new Point(704, 908);
            label6.Margin = new Padding(4, 0, 4, 0);
            label6.Name = "label6";
            label6.Size = new Size(147, 21);
            label6.TabIndex = 9;
            label6.Text = "Interview Date:";
            // 
            // dtpInterviewDate
            // 
            dtpInterviewDate.Location = new Point(864, 908);
            dtpInterviewDate.Margin = new Padding(4, 5, 4, 5);
            dtpInterviewDate.Name = "dtpInterviewDate";
            dtpInterviewDate.Size = new Size(250, 31);
            dtpInterviewDate.TabIndex = 11;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Lucida Fax", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label7.Location = new Point(33, 987);
            label7.Margin = new Padding(4, 0, 4, 0);
            label7.Name = "label7";
            label7.Size = new Size(125, 21);
            label7.TabIndex = 12;
            label7.Text = "SCORES 1 - 5";
            // 
            // numCommunication
            // 
            numCommunication.Location = new Point(221, 1037);
            numCommunication.Margin = new Padding(4, 5, 4, 5);
            numCommunication.Name = "numCommunication";
            numCommunication.Size = new Size(166, 31);
            numCommunication.TabIndex = 13;
            // 
            // numTechnical
            // 
            numTechnical.Location = new Point(221, 1082);
            numTechnical.Margin = new Padding(4, 5, 4, 5);
            numTechnical.Name = "numTechnical";
            numTechnical.Size = new Size(166, 31);
            numTechnical.TabIndex = 14;
            // 
            // numProblemSolving
            // 
            numProblemSolving.Location = new Point(221, 1175);
            numProblemSolving.Margin = new Padding(4, 5, 4, 5);
            numProblemSolving.Name = "numProblemSolving";
            numProblemSolving.Size = new Size(166, 31);
            numProblemSolving.TabIndex = 15;
            // 
            // numConfidence
            // 
            numConfidence.Location = new Point(221, 1125);
            numConfidence.Margin = new Padding(4, 5, 4, 5);
            numConfidence.Name = "numConfidence";
            numConfidence.Size = new Size(166, 31);
            numConfidence.TabIndex = 16;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Lucida Fax", 7.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label8.Location = new Point(14, 1037);
            label8.Margin = new Padding(4, 0, 4, 0);
            label8.Name = "label8";
            label8.Size = new Size(174, 18);
            label8.TabIndex = 17;
            label8.Text = "Comunication Skills:";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Lucida Fax", 7.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label9.Location = new Point(14, 1082);
            label9.Margin = new Padding(4, 0, 4, 0);
            label9.Name = "label9";
            label9.Size = new Size(139, 18);
            label9.TabIndex = 18;
            label9.Text = "Technical Skills:";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Lucida Fax", 7.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label10.Location = new Point(14, 1128);
            label10.Margin = new Padding(4, 0, 4, 0);
            label10.Name = "label10";
            label10.Size = new Size(106, 18);
            label10.TabIndex = 19;
            label10.Text = "Confidence:";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Lucida Fax", 7.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label11.Location = new Point(16, 1178);
            label11.Margin = new Padding(4, 0, 4, 0);
            label11.Name = "label11";
            label11.Size = new Size(144, 18);
            label11.TabIndex = 20;
            label11.Text = "Problem Solving:";
            // 
            // lblOverall
            // 
            lblOverall.AutoSize = true;
            lblOverall.Font = new Font("Lucida Fax", 7.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblOverall.Location = new Point(80, 1287);
            lblOverall.Margin = new Padding(4, 0, 4, 0);
            lblOverall.Name = "lblOverall";
            lblOverall.Size = new Size(0, 18);
            lblOverall.TabIndex = 22;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Lucida Fax", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label12.Location = new Point(704, 1008);
            label12.Margin = new Padding(4, 0, 4, 0);
            label12.Name = "label12";
            label12.Size = new Size(173, 21);
            label12.TabIndex = 23;
            label12.Text = "Recommendation:";
            // 
            // cmbRecommendation
            // 
            cmbRecommendation.FormattingEnabled = true;
            cmbRecommendation.Location = new Point(893, 1005);
            cmbRecommendation.Margin = new Padding(4, 5, 4, 5);
            cmbRecommendation.Name = "cmbRecommendation";
            cmbRecommendation.Size = new Size(220, 33);
            cmbRecommendation.TabIndex = 24;
            // 
            // Label13
            // 
            Label13.AutoSize = true;
            Label13.Font = new Font("Lucida Fax", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Label13.Location = new Point(33, 1243);
            Label13.Margin = new Padding(4, 0, 4, 0);
            Label13.Name = "Label13";
            Label13.Size = new Size(94, 21);
            Label13.TabIndex = 25;
            Label13.Text = "Remarks:";
            // 
            // txtRemarks
            // 
            txtRemarks.Location = new Point(36, 1283);
            txtRemarks.Margin = new Padding(4, 5, 4, 5);
            txtRemarks.Multiline = true;
            txtRemarks.Name = "txtRemarks";
            txtRemarks.Size = new Size(350, 179);
            txtRemarks.TabIndex = 26;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(519, 1428);
            btnSave.Margin = new Padding(4, 5, 4, 5);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(154, 37);
            btnSave.TabIndex = 27;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            // 
            // btnRefresh
            // 
            btnRefresh.Location = new Point(707, 1428);
            btnRefresh.Margin = new Padding(4, 5, 4, 5);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(154, 37);
            btnRefresh.TabIndex = 28;
            btnRefresh.Text = "Refresh";
            btnRefresh.UseVisualStyleBackColor = true;
            // 
            // btnClear
            // 
            btnClear.Location = new Point(904, 1428);
            btnClear.Margin = new Padding(4, 5, 4, 5);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(154, 37);
            btnClear.TabIndex = 29;
            btnClear.Text = "Clear";
            btnClear.UseVisualStyleBackColor = true;
            // 
            // btnClose
            // 
            btnClose.Location = new Point(1096, 1428);
            btnClose.Margin = new Padding(4, 5, 4, 5);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(154, 37);
            btnClose.TabIndex = 30;
            btnClose.Text = "Close";
            btnClose.UseVisualStyleBackColor = true;
            // 
            // InterviewEvaluationForm
            // 
            AutoScaleMode = AutoScaleMode.None;
            AutoScroll = true;
            AutoScrollMinSize = new Size(0, 950);
            BackColor = Color.LavenderBlush;
            ClientSize = new Size(1584, 1050);
            Controls.Add(btnClose);
            Controls.Add(btnClear);
            Controls.Add(btnRefresh);
            Controls.Add(btnSave);
            Controls.Add(txtRemarks);
            Controls.Add(Label13);
            Controls.Add(cmbRecommendation);
            Controls.Add(label12);
            Controls.Add(lblOverall);
            Controls.Add(label11);
            Controls.Add(label10);
            Controls.Add(label9);
            Controls.Add(label8);
            Controls.Add(numConfidence);
            Controls.Add(numProblemSolving);
            Controls.Add(numTechnical);
            Controls.Add(numCommunication);
            Controls.Add(label7);
            Controls.Add(dtpInterviewDate);
            Controls.Add(label6);
            Controls.Add(txtJob);
            Controls.Add(txtApplicant);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(dgvInterview);
            Controls.Add(panel2);
            Controls.Add(btnSearch);
            Controls.Add(txtSearch);
            Controls.Add(label2);
            Controls.Add(panel1);
            Margin = new Padding(4, 5, 4, 5);
            Name = "InterviewEvaluationForm";
            Text = "Form1";
            Load += InterviewEvaluationForm_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvInterview).EndInit();
            ((System.ComponentModel.ISupportInitialize)numCommunication).EndInit();
            ((System.ComponentModel.ISupportInitialize)numTechnical).EndInit();
            ((System.ComponentModel.ISupportInitialize)numProblemSolving).EndInit();
            ((System.ComponentModel.ISupportInitialize)numConfidence).EndInit();
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
        private System.Windows.Forms.DataGridView dgvInterview;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtApplicant;
        private System.Windows.Forms.TextBox txtJob;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dtpInterviewDate;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown numCommunication;
        private System.Windows.Forms.NumericUpDown numTechnical;
        private System.Windows.Forms.NumericUpDown numProblemSolving;
        private System.Windows.Forms.NumericUpDown numConfidence;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label lblOverall;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox cmbRecommendation;
        private System.Windows.Forms.Label Label13;
        private System.Windows.Forms.TextBox txtRemarks;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnClose;
    }
}

