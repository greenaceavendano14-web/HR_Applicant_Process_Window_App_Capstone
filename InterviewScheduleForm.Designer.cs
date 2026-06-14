namespace HRApplicantSystem
{
    partial class InterviewScheduleForm
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
            dgvSchedule = new DataGridView();
            Panel2 = new Panel();
            btnRefresh = new Button();
            btnClear = new Button();
            btnDelete = new Button();
            btnUpdate = new Button();
            btnSave = new Button();
            txtNotes = new TextBox();
            label8 = new Label();
            cmbStatus = new ComboBox();
            label7 = new Label();
            txtInterviewer = new TextBox();
            label6 = new Label();
            txtTime = new TextBox();
            label5 = new Label();
            dtpScheduleDate = new DateTimePicker();
            label4 = new Label();
            txtJob = new TextBox();
            label3 = new Label();
            txtApplicant = new TextBox();
            label2 = new Label();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvSchedule).BeginInit();
            Panel2.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.Thistle;
            panel1.Controls.Add(label1);
            panel1.Location = new Point(14, 18);
            panel1.Margin = new Padding(4, 5, 4, 5);
            panel1.Name = "panel1";
            panel1.Size = new Size(1534, 177);
            panel1.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(597, 68);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(317, 30);
            label1.TabIndex = 1;
            label1.Text = "INTERVIEW SCHEDULE FORM";
            // 
            // dgvSchedule
            // 
            dgvSchedule.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvSchedule.Location = new Point(14, 272);
            dgvSchedule.Margin = new Padding(4, 5, 4, 5);
            dgvSchedule.Name = "dgvSchedule";
            dgvSchedule.RowHeadersWidth = 51;
            dgvSchedule.RowTemplate.Height = 24;
            dgvSchedule.Size = new Size(803, 968);
            dgvSchedule.TabIndex = 1;
            // 
            // Panel2
            // 
            Panel2.BackColor = Color.Thistle;
            Panel2.Controls.Add(btnRefresh);
            Panel2.Controls.Add(btnClear);
            Panel2.Controls.Add(btnDelete);
            Panel2.Controls.Add(btnUpdate);
            Panel2.Controls.Add(btnSave);
            Panel2.Controls.Add(txtNotes);
            Panel2.Controls.Add(label8);
            Panel2.Controls.Add(cmbStatus);
            Panel2.Controls.Add(label7);
            Panel2.Controls.Add(txtInterviewer);
            Panel2.Controls.Add(label6);
            Panel2.Controls.Add(txtTime);
            Panel2.Controls.Add(label5);
            Panel2.Controls.Add(dtpScheduleDate);
            Panel2.Controls.Add(label4);
            Panel2.Controls.Add(txtJob);
            Panel2.Controls.Add(label3);
            Panel2.Controls.Add(txtApplicant);
            Panel2.Controls.Add(label2);
            Panel2.Location = new Point(881, 272);
            Panel2.Margin = new Padding(4, 5, 4, 5);
            Panel2.Name = "Panel2";
            Panel2.Size = new Size(667, 968);
            Panel2.TabIndex = 2;
            // 
            // btnRefresh
            // 
            btnRefresh.Location = new Point(336, 712);
            btnRefresh.Margin = new Padding(4, 5, 4, 5);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(110, 48);
            btnRefresh.TabIndex = 18;
            btnRefresh.Text = "Refresh";
            btnRefresh.UseVisualStyleBackColor = true;
            // 
            // btnClear
            // 
            btnClear.Location = new Point(336, 795);
            btnClear.Margin = new Padding(4, 5, 4, 5);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(110, 48);
            btnClear.TabIndex = 17;
            btnClear.Text = "Clear";
            btnClear.UseVisualStyleBackColor = true;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(221, 795);
            btnDelete.Margin = new Padding(4, 5, 4, 5);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(110, 48);
            btnDelete.TabIndex = 16;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = true;
            // 
            // btnUpdate
            // 
            btnUpdate.Location = new Point(221, 712);
            btnUpdate.Margin = new Padding(4, 5, 4, 5);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(110, 48);
            btnUpdate.TabIndex = 15;
            btnUpdate.Text = "Update";
            btnUpdate.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(274, 860);
            btnSave.Margin = new Padding(4, 5, 4, 5);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(110, 48);
            btnSave.TabIndex = 14;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            // 
            // txtNotes
            // 
            txtNotes.Location = new Point(221, 447);
            txtNotes.Margin = new Padding(4, 5, 4, 5);
            txtNotes.Multiline = true;
            txtNotes.Name = "txtNotes";
            txtNotes.Size = new Size(285, 252);
            txtNotes.TabIndex = 13;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Lucida Fax", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label8.Location = new Point(47, 447);
            label8.Margin = new Padding(4, 0, 4, 0);
            label8.Name = "label8";
            label8.Size = new Size(62, 21);
            label8.TabIndex = 12;
            label8.Text = "Notes";
            // 
            // cmbStatus
            // 
            cmbStatus.FormattingEnabled = true;
            cmbStatus.Items.AddRange(new object[] { "Scheduled", "Completed", "Cancelled" });
            cmbStatus.Location = new Point(221, 368);
            cmbStatus.Margin = new Padding(4, 5, 4, 5);
            cmbStatus.Name = "cmbStatus";
            cmbStatus.Size = new Size(224, 33);
            cmbStatus.TabIndex = 11;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Lucida Fax", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label7.Location = new Point(47, 368);
            label7.Margin = new Padding(4, 0, 4, 0);
            label7.Name = "label7";
            label7.Size = new Size(66, 21);
            label7.TabIndex = 10;
            label7.Text = "Status";
            // 
            // txtInterviewer
            // 
            txtInterviewer.Location = new Point(221, 308);
            txtInterviewer.Margin = new Padding(4, 5, 4, 5);
            txtInterviewer.Name = "txtInterviewer";
            txtInterviewer.Size = new Size(224, 31);
            txtInterviewer.TabIndex = 9;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Lucida Fax", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label6.Location = new Point(47, 308);
            label6.Margin = new Padding(4, 0, 4, 0);
            label6.Name = "label6";
            label6.Size = new Size(112, 21);
            label6.TabIndex = 8;
            label6.Text = "Interviewer";
            // 
            // txtTime
            // 
            txtTime.Location = new Point(221, 245);
            txtTime.Margin = new Padding(4, 5, 4, 5);
            txtTime.Name = "txtTime";
            txtTime.Size = new Size(224, 31);
            txtTime.TabIndex = 7;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Lucida Fax", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.Location = new Point(47, 245);
            label5.Margin = new Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new Size(145, 21);
            label5.TabIndex = 6;
            label5.Text = "Interview Time";
            // 
            // dtpScheduleDate
            // 
            dtpScheduleDate.Location = new Point(221, 183);
            dtpScheduleDate.Margin = new Padding(4, 5, 4, 5);
            dtpScheduleDate.Name = "dtpScheduleDate";
            dtpScheduleDate.Size = new Size(285, 31);
            dtpScheduleDate.TabIndex = 5;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Lucida Fax", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(47, 183);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(141, 21);
            label4.TabIndex = 4;
            label4.Text = "Interview Date";
            // 
            // txtJob
            // 
            txtJob.Location = new Point(221, 125);
            txtJob.Margin = new Padding(4, 5, 4, 5);
            txtJob.Name = "txtJob";
            txtJob.ReadOnly = true;
            txtJob.Size = new Size(224, 31);
            txtJob.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Lucida Fax", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(47, 128);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(94, 21);
            label3.TabIndex = 2;
            label3.Text = "Job Title:";
            // 
            // txtApplicant
            // 
            txtApplicant.Location = new Point(221, 73);
            txtApplicant.Margin = new Padding(4, 5, 4, 5);
            txtApplicant.Name = "txtApplicant";
            txtApplicant.ReadOnly = true;
            txtApplicant.Size = new Size(224, 31);
            txtApplicant.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Lucida Fax", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(47, 73);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(161, 21);
            label2.TabIndex = 0;
            label2.Text = "Applicant Name:";
            // 
            // InterviewScheduleForm
            // 
            AutoScaleMode = AutoScaleMode.None;
            AutoScroll = true;
            AutoScrollMinSize = new Size(0, 950);
            BackColor = Color.LavenderBlush;
            ClientSize = new Size(1586, 1050);
            Controls.Add(Panel2);
            Controls.Add(dgvSchedule);
            Controls.Add(panel1);
            Margin = new Padding(4, 5, 4, 5);
            Name = "InterviewScheduleForm";
            Text = "Form1";
            Load += InterviewScheduleForm_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvSchedule).EndInit();
            Panel2.ResumeLayout(false);
            Panel2.PerformLayout();
            ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvSchedule;
        private System.Windows.Forms.Panel Panel2;
        private System.Windows.Forms.TextBox txtJob;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtApplicant;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtTime;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dtpScheduleDate;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtInterviewer;
        private System.Windows.Forms.TextBox txtNotes;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cmbStatus;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnRefresh;
    }
}

