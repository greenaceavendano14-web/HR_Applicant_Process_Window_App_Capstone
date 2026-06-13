using System.Drawing;
using System.Windows.Forms;

namespace HRApplicantSystem
{
    partial class JobVacancies
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            headerPanel = new Panel();
            lblTitle = new Label();
            pictureBox1 = new PictureBox();
            lblSearch = new Label();
            label3 = new Label();
            txtSearch = new TextBox();
            label9 = new Label();
            grpDetails = new GroupBox();
            lblPosition = new Label();
            lblDepartment = new Label();
            lblType = new Label();
            lblQualifications = new Label();
            lblDocuments = new Label();
            groupBox2 = new GroupBox();
            lblJobCount = new Label();
            dgvJobs = new DataGridView();
            searchPanel = new Panel();
            btnSearch = new Button();
            btnApply = new Button();
            btnRefresh = new Button();
            btnExit = new Button();
            headerPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            grpDetails.SuspendLayout();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvJobs).BeginInit();
            searchPanel.SuspendLayout();
            SuspendLayout();
            // 
            // headerPanel
            // 
            headerPanel.BackColor = Color.Thistle;
            headerPanel.BackgroundImageLayout = ImageLayout.None;
            headerPanel.Controls.Add(lblTitle);
            headerPanel.Controls.Add(pictureBox1);
            headerPanel.Location = new Point(0, 0);
            headerPanel.Name = "headerPanel";
            headerPanel.Size = new Size(859, 66);
            headerPanel.TabIndex = 0;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.BackColor = Color.Thistle;
            lblTitle.Font = new Font("Lucida Fax", 20F, FontStyle.Bold);
            lblTitle.ForeColor = Color.LavenderBlush;
            lblTitle.Location = new Point(96, 18);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(214, 32);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Job Vacancies";
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.Transparent;
            pictureBox1.BackgroundImageLayout = ImageLayout.None;
            pictureBox1.Image = Properties.Resources.logo2;
            pictureBox1.Location = new Point(-18, -4);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(145, 78);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // lblSearch
            // 
            lblSearch.AutoSize = true;
            lblSearch.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblSearch.ForeColor = Color.DimGray;
            lblSearch.Location = new Point(18, 19);
            lblSearch.Name = "lblSearch";
            lblSearch.Size = new Size(55, 20);
            lblSearch.TabIndex = 1;
            lblSearch.Text = "Search";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            label3.ForeColor = Color.DimGray;
            label3.Location = new Point(5, 0);
            label3.Name = "label3";
            label3.Size = new Size(143, 20);
            label3.TabIndex = 0;
            label3.Text = "Open Job Positions";
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(96, 17);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(158, 23);
            txtSearch.TabIndex = 2;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            label9.ForeColor = Color.DimGray;
            label9.Location = new Point(18, 394);
            label9.Name = "label9";
            label9.Size = new Size(86, 20);
            label9.TabIndex = 5;
            label9.Text = "Job Details";
            // 
            // grpDetails
            // 
            grpDetails.BackColor = Color.White;
            grpDetails.Controls.Add(lblPosition);
            grpDetails.Controls.Add(lblDepartment);
            grpDetails.Controls.Add(lblType);
            grpDetails.Controls.Add(lblQualifications);
            grpDetails.Controls.Add(lblDocuments);
            grpDetails.Location = new Point(18, 427);
            grpDetails.Name = "grpDetails";
            grpDetails.Size = new Size(788, 169);
            grpDetails.TabIndex = 6;
            grpDetails.TabStop = false;
            // 
            // lblPosition
            // 
            lblPosition.AutoSize = true;
            lblPosition.Font = new Font("Segoe UI", 10F);
            lblPosition.Location = new Point(18, 28);
            lblPosition.Name = "lblPosition";
            lblPosition.Size = new Size(60, 19);
            lblPosition.TabIndex = 0;
            lblPosition.Text = "Position:";
            // 
            // lblDepartment
            // 
            lblDepartment.AutoSize = true;
            lblDepartment.Font = new Font("Segoe UI", 10F);
            lblDepartment.Location = new Point(18, 56);
            lblDepartment.Name = "lblDepartment";
            lblDepartment.Size = new Size(86, 19);
            lblDepartment.TabIndex = 1;
            lblDepartment.Text = "Department:";
            // 
            // lblType
            // 
            lblType.AutoSize = true;
            lblType.Font = new Font("Segoe UI", 10F);
            lblType.Location = new Point(18, 84);
            lblType.Name = "lblType";
            lblType.Size = new Size(121, 19);
            lblType.TabIndex = 2;
            lblType.Text = "Employment Type:";
            // 
            // lblQualifications
            // 
            lblQualifications.AutoSize = true;
            lblQualifications.Font = new Font("Segoe UI", 10F);
            lblQualifications.Location = new Point(18, 112);
            lblQualifications.Name = "lblQualifications";
            lblQualifications.Size = new Size(94, 19);
            lblQualifications.TabIndex = 3;
            lblQualifications.Text = "Qualifications:";
            // 
            // lblDocuments
            // 
            lblDocuments.AutoSize = true;
            lblDocuments.Font = new Font("Segoe UI", 10F);
            lblDocuments.Location = new Point(18, 141);
            lblDocuments.Name = "lblDocuments";
            lblDocuments.Size = new Size(140, 19);
            lblDocuments.TabIndex = 4;
            lblDocuments.Text = "Required Documents:";
            // 
            // groupBox2
            // 
            groupBox2.BackColor = Color.White;
            groupBox2.Controls.Add(lblJobCount);
            groupBox2.Controls.Add(label3);
            groupBox2.Controls.Add(dgvJobs);
            groupBox2.Location = new Point(18, 145);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(788, 244);
            groupBox2.TabIndex = 4;
            groupBox2.TabStop = false;
            // 
            // lblJobCount
            // 
            lblJobCount.Location = new Point(612, 9);
            lblJobCount.Name = "lblJobCount";
            lblJobCount.Size = new Size(88, 22);
            lblJobCount.TabIndex = 0;
            lblJobCount.Text = "Total Jobs: 15";
            // 
            // dgvJobs
            // 
            dgvJobs.AllowUserToResizeColumns = false;
            dgvJobs.AllowUserToResizeRows = false;
            dgvJobs.BackgroundColor = Color.White;
            dgvJobs.BorderStyle = BorderStyle.None;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.Thistle;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = Color.White;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvJobs.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvJobs.ColumnHeadersHeight = 30;
            dgvJobs.EnableHeadersVisualStyles = false;
            dgvJobs.Location = new Point(13, 33);
            dgvJobs.Name = "dgvJobs";
            dgvJobs.RowHeadersWidth = 51;
            dgvJobs.RowTemplate.Height = 28;
            dgvJobs.Size = new Size(752, 131);
            dgvJobs.TabIndex = 1;
            // 
            // searchPanel
            // 
            searchPanel.BackColor = Color.White;
            searchPanel.BorderStyle = BorderStyle.FixedSingle;
            searchPanel.Controls.Add(lblSearch);
            searchPanel.Controls.Add(txtSearch);
            searchPanel.Controls.Add(btnSearch);
            searchPanel.Location = new Point(18, 80);
            searchPanel.Name = "searchPanel";
            searchPanel.Size = new Size(788, 52);
            searchPanel.TabIndex = 0;
            // 
            // btnSearch
            // 
            btnSearch.BackColor = Color.Thistle;
            btnSearch.FlatAppearance.BorderSize = 0;
            btnSearch.FlatStyle = FlatStyle.Flat;
            btnSearch.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnSearch.ForeColor = Color.White;
            btnSearch.Location = new Point(271, 14);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(79, 26);
            btnSearch.TabIndex = 3;
            btnSearch.Text = "Search";
            btnSearch.UseVisualStyleBackColor = false;
            // 
            // btnApply
            // 
            btnApply.BackColor = Color.Thistle;
            btnApply.FlatAppearance.BorderSize = 0;
            btnApply.FlatStyle = FlatStyle.Flat;
            btnApply.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnApply.ForeColor = Color.White;
            btnApply.Location = new Point(18, 609);
            btnApply.Name = "btnApply";
            btnApply.Size = new Size(88, 33);
            btnApply.TabIndex = 7;
            btnApply.Text = "Apply";
            btnApply.UseVisualStyleBackColor = false;
            // 
            // btnRefresh
            // 
            btnRefresh.BackColor = Color.Thistle;
            btnRefresh.FlatAppearance.BorderSize = 0;
            btnRefresh.FlatStyle = FlatStyle.Flat;
            btnRefresh.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnRefresh.ForeColor = Color.White;
            btnRefresh.Location = new Point(122, 609);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(88, 33);
            btnRefresh.TabIndex = 8;
            btnRefresh.Text = "Refresh";
            btnRefresh.UseVisualStyleBackColor = false;
            // 
            // btnExit
            // 
            btnExit.BackColor = Color.Thistle;
            btnExit.FlatStyle = FlatStyle.Flat;
            btnExit.ForeColor = Color.White;
            btnExit.Location = new Point(228, 609);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(88, 33);
            btnExit.TabIndex = 9;
            btnExit.Text = "Exit";
            btnExit.UseVisualStyleBackColor = false;
            btnExit.Click += btnExit_Click;
            // 
            // JobVacancies
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LavenderBlush;
            ClientSize = new Size(859, 675);
            Controls.Add(searchPanel);
            Controls.Add(grpDetails);
            Controls.Add(label9);
            Controls.Add(groupBox2);
            Controls.Add(headerPanel);
            Controls.Add(btnApply);
            Controls.Add(btnRefresh);
            Controls.Add(btnExit);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "JobVacancies";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "HR Recruitment System - Job Vacancies";
            headerPanel.ResumeLayout(false);
            headerPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            grpDetails.ResumeLayout(false);
            grpDetails.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvJobs).EndInit();
            searchPanel.ResumeLayout(false);
            searchPanel.PerformLayout();
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.GroupBox grpDetails;
        private System.Windows.Forms.GroupBox groupBox2;
        private Panel headerPanel;
        private Panel searchPanel;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.DataGridView dgvJobs;
        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.Button btnRefresh;
        private Label lblPosition;
        private Label lblDepartment;
        private Label lblJobCount;
        private Label lblType;
        private Label lblQualifications;
        private Label lblDocuments;
        private Button btnExit;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private PictureBox pictureBox1;
    }
}

