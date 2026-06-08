namespace ApplicationForm
{
    partial class Form1
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtFullName = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbJobs = new System.Windows.Forms.ComboBox();
            this.btnUploadResume = new System.Windows.Forms.Button();
            this.lblFileName = new System.Windows.Forms.Label();
            this.btnApply = new System.Windows.Forms.Button();
            this.dgvApplications = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvApplications)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Location = new System.Drawing.Point(51, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Full Name:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label2.Location = new System.Drawing.Point(51, 112);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 23);
            this.label2.TabIndex = 1;
            this.label2.Text = "E-mail:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label3.Location = new System.Drawing.Point(50, 156);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(97, 23);
            this.label3.TabIndex = 2;
            this.label3.Text = "Select Job:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label4.Location = new System.Drawing.Point(51, 206);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(110, 23);
            this.label4.TabIndex = 3;
            this.label4.Text = "Resume File:";
            // 
            // txtFullName
            // 
            this.txtFullName.Location = new System.Drawing.Point(187, 62);
            this.txtFullName.Name = "txtFullName";
            this.txtFullName.Size = new System.Drawing.Size(255, 22);
            this.txtFullName.TabIndex = 4;
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(187, 114);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(255, 22);
            this.txtEmail.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label5.Location = new System.Drawing.Point(51, 271);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 23);
            this.label5.TabIndex = 6;
            this.label5.Text = "File:";
            // 
            // cmbJobs
            // 
            this.cmbJobs.FormattingEnabled = true;
            this.cmbJobs.Items.AddRange(new object[] {
            "Junior Developer",
            "HRSystem"});
            this.cmbJobs.Location = new System.Drawing.Point(187, 154);
            this.cmbJobs.Name = "cmbJobs";
            this.cmbJobs.Size = new System.Drawing.Size(121, 24);
            this.cmbJobs.TabIndex = 7;
            // 
            // btnUploadResume
            // 
            this.btnUploadResume.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUploadResume.Location = new System.Drawing.Point(187, 206);
            this.btnUploadResume.Name = "btnUploadResume";
            this.btnUploadResume.Size = new System.Drawing.Size(121, 32);
            this.btnUploadResume.TabIndex = 8;
            this.btnUploadResume.Text = "Upload";
            this.btnUploadResume.UseVisualStyleBackColor = true;
            this.btnUploadResume.Click += new System.EventHandler(this.btnUploadResume_Click);
            // 
            // lblFileName
            // 
            this.lblFileName.AutoSize = true;
            this.lblFileName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFileName.Location = new System.Drawing.Point(184, 276);
            this.lblFileName.Name = "lblFileName";
            this.lblFileName.Size = new System.Drawing.Size(125, 18);
            this.lblFileName.TabIndex = 9;
            this.lblFileName.Text = "No file selected";
            // 
            // btnApply
            // 
            this.btnApply.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnApply.Location = new System.Drawing.Point(55, 358);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(121, 32);
            this.btnApply.TabIndex = 10;
            this.btnApply.Text = "APPLY";
            this.btnApply.UseVisualStyleBackColor = true;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // dgvApplications
            // 
            this.dgvApplications.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvApplications.Location = new System.Drawing.Point(0, 422);
            this.dgvApplications.Name = "dgvApplications";
            this.dgvApplications.ReadOnly = true;
            this.dgvApplications.RowHeadersWidth = 51;
            this.dgvApplications.RowTemplate.Height = 24;
            this.dgvApplications.Size = new System.Drawing.Size(714, 205);
            this.dgvApplications.TabIndex = 11;
            
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LavenderBlush;
            this.ClientSize = new System.Drawing.Size(714, 653);
            this.Controls.Add(this.dgvApplications);
            this.Controls.Add(this.btnApply);
            this.Controls.Add(this.lblFileName);
            this.Controls.Add(this.btnUploadResume);
            this.Controls.Add(this.cmbJobs);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.txtFullName);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvApplications)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

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
    }
}

