namespace HRApplicantSystem
{ 
    partial class ApplicantListForm
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
            panelHeader = new Panel();
            z = new Label();
            panelFilters = new Panel();
            btnRefresh = new Button();
            btnSearch = new Button();
            label1 = new Label();
            txtSearch = new TextBox();
            cmbStatusFilter = new ComboBox();
            dgvApplicants = new DataGridView();
            panel1 = new Panel();
            btnClose = new Button();
            btnViewDetails = new Button();
            btnOpenResume = new Button();
            panelHeader.SuspendLayout();
            panelFilters.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvApplicants).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panelHeader
            // 
            panelHeader.BackColor = Color.Thistle;
            panelHeader.Controls.Add(z);
            panelHeader.Location = new Point(0, 1);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new Size(809, 90);
            panelHeader.TabIndex = 0;
            // 
            // z
            // 
            z.AutoSize = true;
            z.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            z.Location = new Point(246, 33);
            z.Name = "z";
            z.Size = new Size(177, 21);
            z.TabIndex = 0;
            z.Text = "APPLICANT LIST VIEW";
            // 
            // panelFilters
            // 
            panelFilters.BackColor = Color.Thistle;
            panelFilters.Controls.Add(btnRefresh);
            panelFilters.Controls.Add(btnSearch);
            panelFilters.Controls.Add(label1);
            panelFilters.Controls.Add(txtSearch);
            panelFilters.Controls.Add(cmbStatusFilter);
            panelFilters.Location = new Point(0, 97);
            panelFilters.Name = "panelFilters";
            panelFilters.Size = new Size(809, 123);
            panelFilters.TabIndex = 1;
            // 
            // btnRefresh
            // 
            btnRefresh.Font = new Font("Segoe UI", 7.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnRefresh.Location = new Point(444, 20);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(66, 22);
            btnRefresh.TabIndex = 4;
            btnRefresh.Text = "Refresh";
            btnRefresh.UseVisualStyleBackColor = true;
            // 
            // btnSearch
            // 
            btnSearch.Font = new Font("Segoe UI", 7.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSearch.Location = new Point(374, 21);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(66, 22);
            btnSearch.TabIndex = 3;
            btnSearch.Text = "Search";
            btnSearch.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 7.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(28, 23);
            label1.Name = "label1";
            label1.Size = new Size(131, 13);
            label1.TabIndex = 2;
            label1.Text = "Search Applicant Name:";
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(186, 22);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(172, 23);
            txtSearch.TabIndex = 1;
            // 
            // cmbStatusFilter
            // 
            cmbStatusFilter.FormattingEnabled = true;
            cmbStatusFilter.Items.AddRange(new object[] { "All", "Submitted", "Under Review", "Shortlisted", "Accepted", "Rejected" });
            cmbStatusFilter.Location = new Point(529, 19);
            cmbStatusFilter.Name = "cmbStatusFilter";
            cmbStatusFilter.Size = new Size(106, 23);
            cmbStatusFilter.TabIndex = 0;
            // 
            // dgvApplicants
            // 
            dgvApplicants.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvApplicants.Location = new Point(0, 225);
            dgvApplicants.Name = "dgvApplicants";
            dgvApplicants.ReadOnly = true;
            dgvApplicants.RowHeadersWidth = 51;
            dgvApplicants.RowTemplate.Height = 24;
            dgvApplicants.Size = new Size(549, 188);
            dgvApplicants.TabIndex = 2;
            // 
            // panel1
            // 
            panel1.BackColor = Color.Thistle;
            panel1.Controls.Add(btnClose);
            panel1.Controls.Add(btnViewDetails);
            panel1.Controls.Add(btnOpenResume);
            panel1.Location = new Point(554, 225);
            panel1.Name = "panel1";
            panel1.Size = new Size(256, 188);
            panel1.TabIndex = 3;
            // 
            // btnClose
            // 
            btnClose.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnClose.Location = new Point(66, 123);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(125, 48);
            btnClose.TabIndex = 7;
            btnClose.Text = "Close";
            btnClose.UseVisualStyleBackColor = true;
            // 
            // btnViewDetails
            // 
            btnViewDetails.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnViewDetails.Location = new Point(66, 68);
            btnViewDetails.Name = "btnViewDetails";
            btnViewDetails.Size = new Size(125, 48);
            btnViewDetails.TabIndex = 6;
            btnViewDetails.Text = "View Details";
            btnViewDetails.UseVisualStyleBackColor = true;
            btnViewDetails.Click += btnViewDetails_Click;
            // 
            // btnOpenResume
            // 
            btnOpenResume.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnOpenResume.Location = new Point(66, 31);
            btnOpenResume.Name = "btnOpenResume";
            btnOpenResume.Size = new Size(125, 32);
            btnOpenResume.TabIndex = 5;
            btnOpenResume.Text = "Open Resume";
            btnOpenResume.UseVisualStyleBackColor = true;
            // 
            // ApplicantListForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LavenderBlush;
            ClientSize = new Size(809, 413);
            Controls.Add(panel1);
            Controls.Add(dgvApplicants);
            Controls.Add(panelFilters);
            Controls.Add(panelHeader);
            Name = "ApplicantListForm";
            Text = "Form1";
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            panelFilters.ResumeLayout(false);
            panelFilters.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvApplicants).EndInit();
            panel1.ResumeLayout(false);
            ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label z;
        private System.Windows.Forms.Panel panelFilters;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.ComboBox cmbStatusFilter;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.DataGridView dgvApplicants;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnViewDetails;
        private System.Windows.Forms.Button btnOpenResume;
    }
}

