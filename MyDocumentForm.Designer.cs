namespace HRApplicantSystem
{
    partial class MyDocumentForm
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
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblCompany = new System.Windows.Forms.Label();
            this.picLogo = new System.Windows.Forms.PictureBox();
            this.pnlBackground = new System.Windows.Forms.Panel();
            this.grpTimeline = new System.Windows.Forms.GroupBox();
            this.dgvTimeline = new System.Windows.Forms.DataGridView();
            this.grpDocuments = new System.Windows.Forms.GroupBox();
            this.btnUpload = new System.Windows.Forms.Button();
            this.dgvDocuments = new System.Windows.Forms.DataGridView();
            this.lblMissingIndicator = new System.Windows.Forms.Label();
            this.lblSubmittedIndicator = new System.Windows.Forms.Label();
            this.lblWelcome = new System.Windows.Forms.Label();
            this.pnlHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
            this.pnlBackground.SuspendLayout();
            this.grpTimeline.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTimeline)).BeginInit();
            this.grpDocuments.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDocuments)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.Thistle;
            this.pnlHeader.Controls.Add(this.lblCompany);
            this.pnlHeader.Controls.Add(this.picLogo);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(900, 70);
            this.pnlHeader.TabIndex = 8;
            // 
            // lblCompany
            // 
            this.lblCompany.AutoSize = true;
            this.lblCompany.Font = new System.Drawing.Font("Lucida Fax", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCompany.ForeColor = System.Drawing.Color.White;
            this.lblCompany.Location = new System.Drawing.Point(20, 18);
            this.lblCompany.Name = "lblCompany";
            this.lblCompany.Size = new System.Drawing.Size(343, 32);
            this.lblCompany.TabIndex = 0;
            this.lblCompany.Text = "Apex Digital Solutions";
            // 
            // picLogo
            // 
            this.picLogo.BackColor = System.Drawing.SystemColors.Control;
            this.picLogo.Image = global::HRApplicantSystem.Properties.Resources.logo2;
            this.picLogo.Location = new System.Drawing.Point(-14, -49);
            this.picLogo.Name = "picLogo";
            this.picLogo.Size = new System.Drawing.Size(0, 0);
            this.picLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picLogo.TabIndex = 1;
            this.picLogo.TabStop = false;
            // 
            // pnlBackground
            // 
            this.pnlBackground.BackColor = System.Drawing.Color.LavenderBlush;
            this.pnlBackground.Controls.Add(this.grpTimeline);
            this.pnlBackground.Controls.Add(this.grpDocuments);
            this.pnlBackground.Controls.Add(this.lblWelcome);
            this.pnlBackground.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBackground.Location = new System.Drawing.Point(0, 70);
            this.pnlBackground.Name = "pnlBackground";
            this.pnlBackground.Size = new System.Drawing.Size(900, 520);
            this.pnlBackground.TabIndex = 9;
            // 
            // grpTimeline
            // 
            this.grpTimeline.Controls.Add(this.dgvTimeline);
            this.grpTimeline.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpTimeline.ForeColor = System.Drawing.Color.DimGray;
            this.grpTimeline.Location = new System.Drawing.Point(25, 365);
            this.grpTimeline.Name = "grpTimeline";
            this.grpTimeline.Size = new System.Drawing.Size(850, 200);
            this.grpTimeline.TabIndex = 2;
            this.grpTimeline.TabStop = false;
            this.grpTimeline.Text = "Application Status Timeline & Visible HR Remarks";
            // 
            // dgvTimeline
            // 
            this.dgvTimeline.BackgroundColor = System.Drawing.Color.White;
            this.dgvTimeline.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTimeline.Location = new System.Drawing.Point(20, 35);
            this.dgvTimeline.Name = "dgvTimeline";
            this.dgvTimeline.ReadOnly = true;
            this.dgvTimeline.RowHeadersWidth = 51;
            this.dgvTimeline.RowTemplate.Height = 24;
            this.dgvTimeline.Size = new System.Drawing.Size(810, 140);
            this.dgvTimeline.TabIndex = 0;
            // 
            // grpDocuments
            // 
            this.grpDocuments.Controls.Add(this.btnUpload);
            this.grpDocuments.Controls.Add(this.dgvDocuments);
            this.grpDocuments.Controls.Add(this.lblMissingIndicator);
            this.grpDocuments.Controls.Add(this.lblSubmittedIndicator);
            this.grpDocuments.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpDocuments.ForeColor = System.Drawing.Color.DimGray;
            this.grpDocuments.Location = new System.Drawing.Point(25, 90);
            this.grpDocuments.Name = "grpDocuments";
            this.grpDocuments.Size = new System.Drawing.Size(850, 260);
            this.grpDocuments.TabIndex = 1;
            this.grpDocuments.TabStop = false;
            this.grpDocuments.Text = "My Documents Module (Upload & Tracking)";
            // 
            // btnUpload
            // 
            this.btnUpload.BackColor = System.Drawing.Color.Thistle;
            this.btnUpload.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpload.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpload.Location = new System.Drawing.Point(20, 210);
            this.btnUpload.Name = "btnUpload";
            this.btnUpload.Size = new System.Drawing.Size(250, 35);
            this.btnUpload.TabIndex = 3;
            this.btnUpload.Text = "Select and Upload Document File";
            this.btnUpload.UseVisualStyleBackColor = false;
            this.btnUpload.Click += new System.EventHandler(this.btnUpload_Click);
            // 
            // dgvDocuments
            // 
            this.dgvDocuments.BackgroundColor = System.Drawing.Color.White;
            this.dgvDocuments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDocuments.Location = new System.Drawing.Point(20, 65);
            this.dgvDocuments.Name = "dgvDocuments";
            this.dgvDocuments.ReadOnly = true;
            this.dgvDocuments.RowHeadersWidth = 51;
            this.dgvDocuments.RowTemplate.Height = 24;
            this.dgvDocuments.Size = new System.Drawing.Size(810, 130);
            this.dgvDocuments.TabIndex = 2;
            // 
            // lblMissingIndicator
            // 
            this.lblMissingIndicator.AutoSize = true;
            this.lblMissingIndicator.ForeColor = System.Drawing.Color.Red;
            this.lblMissingIndicator.Location = new System.Drawing.Point(250, 28);
            this.lblMissingIndicator.Name = "lblMissingIndicator";
            this.lblMissingIndicator.Size = new System.Drawing.Size(124, 23);
            this.lblMissingIndicator.TabIndex = 1;
            this.lblMissingIndicator.Text = "Missing: 0 slots";
            // 
            // lblSubmittedIndicator
            // 
            this.lblSubmittedIndicator.AutoSize = true;
            this.lblSubmittedIndicator.ForeColor = System.Drawing.Color.Green;
            this.lblSubmittedIndicator.Location = new System.Drawing.Point(20, 28);
            this.lblSubmittedIndicator.Name = "lblSubmittedIndicator";
            this.lblSubmittedIndicator.Size = new System.Drawing.Size(146, 23);
            this.lblSubmittedIndicator.TabIndex = 0;
            this.lblSubmittedIndicator.Text = "Submitted: 0 slots";
            // 
            // lblWelcome
            // 
            this.lblWelcome.AutoSize = true;
            this.lblWelcome.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWelcome.ForeColor = System.Drawing.Color.DimGray;
            this.lblWelcome.Location = new System.Drawing.Point(550, 25);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(178, 23);
            this.lblWelcome.TabIndex = 0;
            this.lblWelcome.Text = "Applicant Workstation";
            this.lblWelcome.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // MyDocumentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LavenderBlush;
            this.ClientSize = new System.Drawing.Size(900, 590);
            this.Controls.Add(this.pnlBackground);
            this.Controls.Add(this.pnlHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MyDocumentForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Applicant Attachment Requirements & Progress Tracker";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
            this.pnlBackground.ResumeLayout(false);
            this.pnlBackground.PerformLayout();
            this.grpTimeline.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTimeline)).EndInit();
            this.grpDocuments.ResumeLayout(false);
            this.grpDocuments.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDocuments)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblCompany;
        private System.Windows.Forms.PictureBox picLogo;
        private System.Windows.Forms.Panel pnlBackground;
        private System.Windows.Forms.GroupBox grpDocuments;
        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.Label lblSubmittedIndicator;
        private System.Windows.Forms.Label lblMissingIndicator;
        private System.Windows.Forms.Button btnUpload;
        private System.Windows.Forms.DataGridView dgvDocuments;
        private System.Windows.Forms.GroupBox grpTimeline;
        private System.Windows.Forms.DataGridView dgvTimeline;
    }
}