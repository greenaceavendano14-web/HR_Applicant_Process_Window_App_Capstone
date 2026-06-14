namespace ApplicantSystem
{
    partial class MyApplicationForm
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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            txtFullName = new TextBox();
            txtEmail = new TextBox();
            label5 = new Label();
            cmbJobs = new ComboBox();
            btnUploadResume = new Button();
            lblFileName = new Label();
            btnApply = new Button();
            dgvApplications = new DataGridView();
            btnDelete = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvApplications).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.ActiveCaptionText;
            label1.Location = new Point(45, 56);
            label1.Name = "label1";
            label1.Size = new Size(80, 19);
            label1.TabIndex = 0;
            label1.Text = "Full Name:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = SystemColors.ActiveCaptionText;
            label2.Location = new Point(45, 105);
            label2.Name = "label2";
            label2.Size = new Size(55, 19);
            label2.TabIndex = 1;
            label2.Text = "E-mail:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = SystemColors.ActiveCaptionText;
            label3.Location = new Point(44, 146);
            label3.Name = "label3";
            label3.Size = new Size(81, 19);
            label3.TabIndex = 2;
            label3.Text = "Select Job:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.ForeColor = SystemColors.ActiveCaptionText;
            label4.Location = new Point(45, 193);
            label4.Name = "label4";
            label4.Size = new Size(92, 19);
            label4.TabIndex = 3;
            label4.Text = "Resume File:";
            // 
            // txtFullName
            // 
            txtFullName.Location = new Point(164, 58);
            txtFullName.Name = "txtFullName";
            txtFullName.Size = new Size(224, 23);
            txtFullName.TabIndex = 4;
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(164, 107);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(224, 23);
            txtEmail.TabIndex = 5;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.ForeColor = SystemColors.ActiveCaptionText;
            label5.Location = new Point(45, 254);
            label5.Name = "label5";
            label5.Size = new Size(36, 19);
            label5.TabIndex = 6;
            label5.Text = "File:";
            // 
            // cmbJobs
            // 
            cmbJobs.FormattingEnabled = true;
            cmbJobs.Items.AddRange(new object[] { "Junior Developer", "HRSystem", "Programmer", "WebDeveloper", "Janitor" });
            cmbJobs.Location = new Point(164, 144);
            cmbJobs.Name = "cmbJobs";
            cmbJobs.Size = new Size(106, 23);
            cmbJobs.TabIndex = 7;
            // 
            // btnUploadResume
            // 
            btnUploadResume.Font = new Font("Segoe UI", 7.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnUploadResume.Location = new Point(164, 193);
            btnUploadResume.Name = "btnUploadResume";
            btnUploadResume.Size = new Size(106, 30);
            btnUploadResume.TabIndex = 8;
            btnUploadResume.Text = "Upload";
            btnUploadResume.UseVisualStyleBackColor = true;
            btnUploadResume.Click += btnUploadResume_Click;
            // 
            // lblFileName
            // 
            lblFileName.AutoSize = true;
            lblFileName.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblFileName.Location = new Point(161, 259);
            lblFileName.Name = "lblFileName";
            lblFileName.Size = new Size(107, 15);
            lblFileName.TabIndex = 9;
            lblFileName.Text = "No file selected";
            // 
            // btnApply
            // 
            btnApply.Font = new Font("Segoe UI", 7.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnApply.Location = new Point(48, 336);
            btnApply.Name = "btnApply";
            btnApply.Size = new Size(106, 30);
            btnApply.TabIndex = 10;
            btnApply.Text = "APPLY";
            btnApply.UseVisualStyleBackColor = true;
            btnApply.Click += btnApply_Click;
            // 
            // dgvApplications
            // 
            dgvApplications.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvApplications.Location = new Point(0, 396);
            dgvApplications.Name = "dgvApplications";
            dgvApplications.ReadOnly = true;
            dgvApplications.RowHeadersWidth = 51;
            dgvApplications.RowTemplate.Height = 24;
            dgvApplications.Size = new Size(625, 192);
            dgvApplications.TabIndex = 11;
            // 
            // btnDelete
            // 
            btnDelete.Font = new Font("Segoe UI", 7.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnDelete.Location = new Point(191, 336);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(106, 30);
            btnDelete.TabIndex = 12;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // MyApplicationForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LavenderBlush;
            ClientSize = new Size(625, 612);
            Controls.Add(btnDelete);
            Controls.Add(dgvApplications);
            Controls.Add(btnApply);
            Controls.Add(lblFileName);
            Controls.Add(btnUploadResume);
            Controls.Add(cmbJobs);
            Controls.Add(label5);
            Controls.Add(txtEmail);
            Controls.Add(txtFullName);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            ForeColor = SystemColors.ControlText;
            Name = "MyApplicationForm";
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)dgvApplications).EndInit();
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtFullName;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbJobs;
        private System.Windows.Forms.Button btnUploadResume;
        private System.Windows.Forms.Label lblFileName;
        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.DataGridView dgvApplications;
        private Button btnDelete;
    }
}

