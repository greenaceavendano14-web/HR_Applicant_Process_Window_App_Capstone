namespace ApplicantAuthDocumentManagement.Forms
{
    partial class ApplicationStatusForm
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
            this.lblSectionTitle = new System.Windows.Forms.Label();
            this.pnlMainContent = new System.Windows.Forms.Panel();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.txtRemarks = new System.Windows.Forms.TextBox();
            this.lblRemarksLabel = new System.Windows.Forms.Label();
            this.dgvTimeline = new System.Windows.Forms.DataGridView();
            this.lblCurrentStatus = new System.Windows.Forms.Label();
            this.lblStatusHeader = new System.Windows.Forms.Label();
            this.lblJobTitle = new System.Windows.Forms.Label();
            this.pnlHeader.SuspendLayout();
            this.pnlMainContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTimeline)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.Thistle;
            this.pnlHeader.Controls.Add(this.lblCompany);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1105, 75);
            this.pnlHeader.TabIndex = 0;
            // 
            // lblCompany
            // 
            this.lblCompany.AutoSize = true;
            this.lblCompany.Font = new System.Drawing.Font("Lucida Fax", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCompany.ForeColor = System.Drawing.Color.White;
            this.lblCompany.Location = new System.Drawing.Point(20, 20);
            this.lblCompany.Name = "lblCompany";
            this.lblCompany.Size = new System.Drawing.Size(343, 32);
            this.lblCompany.TabIndex = 0;
            this.lblCompany.Text = "Apex Digital Solutions";
            // 
            // lblSectionTitle
            // 
            this.lblSectionTitle.AutoSize = true;
            this.lblSectionTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblSectionTitle.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSectionTitle.ForeColor = System.Drawing.Color.DimGray;
            this.lblSectionTitle.Location = new System.Drawing.Point(680, 25);
            this.lblSectionTitle.Name = "lblSectionTitle";
            this.lblSectionTitle.Size = new System.Drawing.Size(331, 25);
            this.lblSectionTitle.TabIndex = 1;
            this.lblSectionTitle.Text = "Live Track: Application Progress Timeline";
            // 
            // pnlMainContent
            // 
            this.pnlMainContent.BackColor = System.Drawing.Color.White;
            this.pnlMainContent.Controls.Add(this.btnRefresh);
            this.pnlMainContent.Controls.Add(this.txtRemarks);
            this.pnlMainContent.Controls.Add(this.lblRemarksLabel);
            this.pnlMainContent.Controls.Add(this.dgvTimeline);
            this.pnlMainContent.Controls.Add(this.lblCurrentStatus);
            this.pnlMainContent.Controls.Add(this.lblStatusHeader);
            this.pnlMainContent.Controls.Add(this.lblJobTitle);
            this.pnlMainContent.Location = new System.Drawing.Point(25, 100);
            this.pnlMainContent.Name = "pnlMainContent";
            this.pnlMainContent.Size = new System.Drawing.Size(935, 440);
            this.pnlMainContent.TabIndex = 2;
            this.pnlMainContent.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlMainContent_Paint);
            // 
            // btnRefresh
            // 
            this.btnRefresh.BackColor = System.Drawing.Color.Thistle;
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefresh.ForeColor = System.Drawing.Color.DimGray;
            this.btnRefresh.Location = new System.Drawing.Point(735, 350);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(180, 70);
            this.btnRefresh.TabIndex = 8;
            this.btnRefresh.Text = "Refresh Status Timeline";
            this.btnRefresh.UseVisualStyleBackColor = false;
            // 
            // txtRemarks
            // 
            this.txtRemarks.BackColor = System.Drawing.Color.LavenderBlush;
            this.txtRemarks.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRemarks.ForeColor = System.Drawing.Color.DimGray;
            this.txtRemarks.Location = new System.Drawing.Point(20, 350);
            this.txtRemarks.Multiline = true;
            this.txtRemarks.Name = "txtRemarks";
            this.txtRemarks.Size = new System.Drawing.Size(690, 70);
            this.txtRemarks.TabIndex = 6;
            this.txtRemarks.Text = "No evaluation remarks recorded yet.";
            // 
            // lblRemarksLabel
            // 
            this.lblRemarksLabel.AutoSize = true;
            this.lblRemarksLabel.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRemarksLabel.ForeColor = System.Drawing.Color.DimGray;
            this.lblRemarksLabel.Location = new System.Drawing.Point(20, 325);
            this.lblRemarksLabel.Name = "lblRemarksLabel";
            this.lblRemarksLabel.Size = new System.Drawing.Size(410, 23);
            this.lblRemarksLabel.TabIndex = 5;
            this.lblRemarksLabel.Text = "Latest HR Operational Evaluation Remarks & Notes:";
            // 
            // dgvTimeline
            // 
            this.dgvTimeline.BackgroundColor = System.Drawing.Color.White;
            this.dgvTimeline.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTimeline.Location = new System.Drawing.Point(20, 110);
            this.dgvTimeline.Name = "dgvTimeline";
            this.dgvTimeline.ReadOnly = true;
            this.dgvTimeline.RowHeadersVisible = false;
            this.dgvTimeline.RowHeadersWidth = 51;
            this.dgvTimeline.RowTemplate.Height = 24;
            this.dgvTimeline.Size = new System.Drawing.Size(895, 200);
            this.dgvTimeline.TabIndex = 4;
            // 
            // lblCurrentStatus
            // 
            this.lblCurrentStatus.AutoSize = true;
            this.lblCurrentStatus.Font = new System.Drawing.Font("Segoe UI", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurrentStatus.ForeColor = System.Drawing.Color.DarkMagenta;
            this.lblCurrentStatus.Location = new System.Drawing.Point(310, 62);
            this.lblCurrentStatus.Name = "lblCurrentStatus";
            this.lblCurrentStatus.Size = new System.Drawing.Size(182, 28);
            this.lblCurrentStatus.TabIndex = 3;
            this.lblCurrentStatus.Text = "PENDING REVIEW";
            // 
            // lblStatusHeader
            // 
            this.lblStatusHeader.AutoSize = true;
            this.lblStatusHeader.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatusHeader.ForeColor = System.Drawing.Color.DimGray;
            this.lblStatusHeader.Location = new System.Drawing.Point(20, 65);
            this.lblStatusHeader.Name = "lblStatusHeader";
            this.lblStatusHeader.Size = new System.Drawing.Size(279, 25);
            this.lblStatusHeader.TabIndex = 2;
            this.lblStatusHeader.Text = "Current Application Review Phase:";
            // 
            // lblJobTitle
            // 
            this.lblJobTitle.AutoSize = true;
            this.lblJobTitle.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblJobTitle.ForeColor = System.Drawing.Color.DimGray;
            this.lblJobTitle.Location = new System.Drawing.Point(20, 20);
            this.lblJobTitle.Name = "lblJobTitle";
            this.lblJobTitle.Size = new System.Drawing.Size(545, 62);
            this.lblJobTitle.TabIndex = 1;
            this.lblJobTitle.Text = "Applying For: [Fetch Job Title Name Dynamically]\r\n\r\n";
            // 
            // ApplicationStatusForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LavenderBlush;
            this.ClientSize = new System.Drawing.Size(1105, 795);
            this.Controls.Add(this.pnlMainContent);
            this.Controls.Add(this.lblSectionTitle);
            this.Controls.Add(this.pnlHeader);
            this.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.Name = "ApplicationStatusForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Application Recruitment Status Tracker";
            this.Load += new System.EventHandler(this.ApplicationStatusForm_Load);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlMainContent.ResumeLayout(false);
            this.pnlMainContent.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTimeline)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblCompany;
        private System.Windows.Forms.Label lblSectionTitle;
        private System.Windows.Forms.Panel pnlMainContent;
        private System.Windows.Forms.Label lblJobTitle;
        private System.Windows.Forms.Label lblCurrentStatus;
        private System.Windows.Forms.Label lblStatusHeader;
        private System.Windows.Forms.DataGridView dgvTimeline;
        private System.Windows.Forms.Label lblRemarksLabel;
        private System.Windows.Forms.TextBox txtRemarks;
        private System.Windows.Forms.Button btnRefresh;
    }
}