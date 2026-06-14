namespace HRApplicantSystem
{
    partial class UserManagementForm
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
            panelMain = new Panel();
            label3 = new Label();
            cmbRole = new ComboBox();
            textBox2 = new TextBox();
            label2lblPassword = new Label();
            textBox1 = new TextBox();
            lblEmail = new Label();
            txtFullName = new TextBox();
            lblFullName = new Label();
            btnResetPassword = new Button();
            btnBack = new Button();
            pnlApplicants = new Panel();
            lblApplicantsCount = new Label();
            lblApplicants = new Label();
            pnlHRStaff = new Panel();
            lblHRStaffCount = new Label();
            lblHRStaff = new Label();
            pnlHRManagers = new Panel();
            lblHRManagersCount = new Label();
            lblHRManagers = new Label();
            pnlAdmin = new Panel();
            lblAdmiCount = new Label();
            lblAdminTitle = new Label();
            lblSearch = new Label();
            btnEditUser = new Button();
            btnDeactivateUser = new Button();
            btnAddUser = new Button();
            dgvUsers = new DataGridView();
            colUserId = new DataGridViewTextBoxColumn();
            colFullName = new DataGridViewTextBoxColumn();
            colEmail = new DataGridViewTextBoxColumn();
            colRole = new DataGridViewTextBoxColumn();
            colStatus = new DataGridViewTextBoxColumn();
            btnSearch = new Button();
            txtSearchUser = new TextBox();
            lblTitle = new Label();
            panelMain.SuspendLayout();
            pnlApplicants.SuspendLayout();
            pnlHRStaff.SuspendLayout();
            pnlHRManagers.SuspendLayout();
            pnlAdmin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvUsers).BeginInit();
            SuspendLayout();
            // 
            // panelMain
            // 
            panelMain.BackColor = Color.White;
            panelMain.Controls.Add(label3);
            panelMain.Controls.Add(cmbRole);
            panelMain.Controls.Add(textBox2);
            panelMain.Controls.Add(label2lblPassword);
            panelMain.Controls.Add(textBox1);
            panelMain.Controls.Add(lblEmail);
            panelMain.Controls.Add(txtFullName);
            panelMain.Controls.Add(lblFullName);
            panelMain.Controls.Add(btnResetPassword);
            panelMain.Controls.Add(btnBack);
            panelMain.Controls.Add(pnlApplicants);
            panelMain.Controls.Add(pnlHRStaff);
            panelMain.Controls.Add(pnlHRManagers);
            panelMain.Controls.Add(pnlAdmin);
            panelMain.Controls.Add(lblSearch);
            panelMain.Controls.Add(btnEditUser);
            panelMain.Controls.Add(btnDeactivateUser);
            panelMain.Controls.Add(btnAddUser);
            panelMain.Controls.Add(dgvUsers);
            panelMain.Controls.Add(btnSearch);
            panelMain.Controls.Add(txtSearchUser);
            panelMain.Controls.Add(lblTitle);
            panelMain.Location = new Point(22, 20);
            panelMain.Name = "panelMain";
            panelMain.Size = new Size(1140, 620);
            panelMain.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label3.Location = new Point(970, 190);
            label3.Name = "label3";
            label3.Size = new Size(44, 21);
            label3.TabIndex = 26;
            label3.Text = "Role";
            // 
            // cmbRole
            // 
            cmbRole.FormattingEnabled = true;
            cmbRole.Location = new Point(890, 215);
            cmbRole.Name = "cmbRole";
            cmbRole.Size = new Size(210, 23);
            cmbRole.TabIndex = 25;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(604, 215);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(210, 23);
            textBox2.TabIndex = 24;
            // 
            // label2lblPassword
            // 
            label2lblPassword.AutoSize = true;
            label2lblPassword.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label2lblPassword.Location = new Point(665, 190);
            label2lblPassword.Name = "label2lblPassword";
            label2lblPassword.Size = new Size(82, 21);
            label2lblPassword.TabIndex = 23;
            label2lblPassword.Text = "Password";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(325, 215);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(210, 23);
            textBox1.TabIndex = 22;
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblEmail.Location = new Point(400, 190);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(53, 21);
            lblEmail.TabIndex = 21;
            lblEmail.Text = "Email";
            // 
            // txtFullName
            // 
            txtFullName.Location = new Point(70, 215);
            txtFullName.Name = "txtFullName";
            txtFullName.Size = new Size(210, 23);
            txtFullName.TabIndex = 20;
            // 
            // lblFullName
            // 
            lblFullName.AutoSize = true;
            lblFullName.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblFullName.Location = new Point(128, 190);
            lblFullName.Name = "lblFullName";
            lblFullName.Size = new Size(92, 21);
            lblFullName.TabIndex = 19;
            lblFullName.Text = " Full Name";
            // 
            // btnResetPassword
            // 
            btnResetPassword.BackColor = Color.Thistle;
            btnResetPassword.FlatStyle = FlatStyle.Flat;
            btnResetPassword.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnResetPassword.Location = new Point(580, 570);
            btnResetPassword.Name = "btnResetPassword";
            btnResetPassword.Size = new Size(150, 40);
            btnResetPassword.TabIndex = 18;
            btnResetPassword.Text = "Reset Password";
            btnResetPassword.UseVisualStyleBackColor = false;
            btnResetPassword.Click += btnResetPassword_Click;
            // 
            // btnBack
            // 
            btnBack.BackColor = Color.Thistle;
            btnBack.FlatStyle = FlatStyle.Flat;
            btnBack.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnBack.Location = new Point(980, 555);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(130, 55);
            btnBack.TabIndex = 17;
            btnBack.Text = "Back to \r\nDashboard\r\n";
            btnBack.UseVisualStyleBackColor = false;
            // 
            // pnlApplicants
            // 
            pnlApplicants.BackColor = Color.LavenderBlush;
            pnlApplicants.BorderStyle = BorderStyle.FixedSingle;
            pnlApplicants.Controls.Add(lblApplicantsCount);
            pnlApplicants.Controls.Add(lblApplicants);
            pnlApplicants.Location = new Point(940, 80);
            pnlApplicants.Name = "pnlApplicants";
            pnlApplicants.Size = new Size(160, 90);
            pnlApplicants.TabIndex = 12;
            // 
            // lblApplicantsCount
            // 
            lblApplicantsCount.AutoSize = true;
            lblApplicantsCount.Font = new Font("Segoe UI", 12F);
            lblApplicantsCount.Location = new Point(70, 50);
            lblApplicantsCount.Name = "lblApplicantsCount";
            lblApplicantsCount.Size = new Size(19, 21);
            lblApplicantsCount.TabIndex = 1;
            lblApplicantsCount.Text = "0";
            // 
            // lblApplicants
            // 
            lblApplicants.AutoSize = true;
            lblApplicants.Font = new Font("Segoe UI", 12F);
            lblApplicants.Location = new Point(40, 20);
            lblApplicants.Name = "lblApplicants";
            lblApplicants.Size = new Size(82, 21);
            lblApplicants.TabIndex = 0;
            lblApplicants.Text = "Applicants";
            // 
            // pnlHRStaff
            // 
            pnlHRStaff.BackColor = Color.LavenderBlush;
            pnlHRStaff.BorderStyle = BorderStyle.FixedSingle;
            pnlHRStaff.Controls.Add(lblHRStaffCount);
            pnlHRStaff.Controls.Add(lblHRStaff);
            pnlHRStaff.Location = new Point(760, 80);
            pnlHRStaff.Name = "pnlHRStaff";
            pnlHRStaff.Size = new Size(160, 90);
            pnlHRStaff.TabIndex = 10;
            // 
            // lblHRStaffCount
            // 
            lblHRStaffCount.AutoSize = true;
            lblHRStaffCount.Font = new Font("Segoe UI", 12F);
            lblHRStaffCount.Location = new Point(70, 50);
            lblHRStaffCount.Name = "lblHRStaffCount";
            lblHRStaffCount.Size = new Size(19, 21);
            lblHRStaffCount.TabIndex = 1;
            lblHRStaffCount.Text = "0";
            // 
            // lblHRStaff
            // 
            lblHRStaff.AutoSize = true;
            lblHRStaff.Font = new Font("Segoe UI", 12F);
            lblHRStaff.Location = new Point(45, 20);
            lblHRStaff.Name = "lblHRStaff";
            lblHRStaff.Size = new Size(66, 21);
            lblHRStaff.TabIndex = 0;
            lblHRStaff.Text = "HR Staff";
            // 
            // pnlHRManagers
            // 
            pnlHRManagers.BackColor = Color.LavenderBlush;
            pnlHRManagers.BorderStyle = BorderStyle.FixedSingle;
            pnlHRManagers.Controls.Add(lblHRManagersCount);
            pnlHRManagers.Controls.Add(lblHRManagers);
            pnlHRManagers.Location = new Point(580, 80);
            pnlHRManagers.Name = "pnlHRManagers";
            pnlHRManagers.Size = new Size(160, 90);
            pnlHRManagers.TabIndex = 11;
            // 
            // lblHRManagersCount
            // 
            lblHRManagersCount.AutoSize = true;
            lblHRManagersCount.Font = new Font("Segoe UI", 12F);
            lblHRManagersCount.Location = new Point(70, 50);
            lblHRManagersCount.Name = "lblHRManagersCount";
            lblHRManagersCount.Size = new Size(19, 21);
            lblHRManagersCount.TabIndex = 1;
            lblHRManagersCount.Text = "0";
            // 
            // lblHRManagers
            // 
            lblHRManagers.AutoSize = true;
            lblHRManagers.Font = new Font("Segoe UI", 12F);
            lblHRManagers.Location = new Point(30, 20);
            lblHRManagers.Name = "lblHRManagers";
            lblHRManagers.Size = new Size(104, 21);
            lblHRManagers.TabIndex = 0;
            lblHRManagers.Text = "HR Managers";
            // 
            // pnlAdmin
            // 
            pnlAdmin.BackColor = Color.LavenderBlush;
            pnlAdmin.BorderStyle = BorderStyle.FixedSingle;
            pnlAdmin.Controls.Add(lblAdmiCount);
            pnlAdmin.Controls.Add(lblAdminTitle);
            pnlAdmin.Location = new Point(400, 80);
            pnlAdmin.Name = "pnlAdmin";
            pnlAdmin.Size = new Size(160, 90);
            pnlAdmin.TabIndex = 9;
            // 
            // lblAdmiCount
            // 
            lblAdmiCount.AutoSize = true;
            lblAdmiCount.Font = new Font("Segoe UI", 12F);
            lblAdmiCount.Location = new Point(70, 50);
            lblAdmiCount.Name = "lblAdmiCount";
            lblAdmiCount.Size = new Size(19, 21);
            lblAdmiCount.TabIndex = 1;
            lblAdmiCount.Text = "0";
            // 
            // lblAdminTitle
            // 
            lblAdminTitle.AutoSize = true;
            lblAdminTitle.Font = new Font("Segoe UI", 12F);
            lblAdminTitle.Location = new Point(50, 20);
            lblAdminTitle.Name = "lblAdminTitle";
            lblAdminTitle.Size = new Size(56, 21);
            lblAdminTitle.TabIndex = 0;
            lblAdminTitle.Text = "Admin";
            // 
            // lblSearch
            // 
            lblSearch.AutoSize = true;
            lblSearch.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblSearch.Location = new Point(20, 55);
            lblSearch.Name = "lblSearch";
            lblSearch.Size = new Size(88, 19);
            lblSearch.TabIndex = 8;
            lblSearch.Text = "Search User";
            // 
            // btnEditUser
            // 
            btnEditUser.BackColor = Color.Thistle;
            btnEditUser.FlatStyle = FlatStyle.Flat;
            btnEditUser.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnEditUser.Location = new Point(200, 570);
            btnEditUser.Name = "btnEditUser";
            btnEditUser.Size = new Size(130, 40);
            btnEditUser.TabIndex = 7;
            btnEditUser.Text = "Edit User";
            btnEditUser.UseVisualStyleBackColor = false;
            btnEditUser.Click += btnEditUser_Click;
            // 
            // btnDeactivateUser
            // 
            btnDeactivateUser.BackColor = Color.Thistle;
            btnDeactivateUser.FlatStyle = FlatStyle.Flat;
            btnDeactivateUser.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnDeactivateUser.Location = new Point(380, 570);
            btnDeactivateUser.Name = "btnDeactivateUser";
            btnDeactivateUser.Size = new Size(150, 40);
            btnDeactivateUser.TabIndex = 6;
            btnDeactivateUser.Text = "Deactivate User";
            btnDeactivateUser.UseVisualStyleBackColor = false;
            btnDeactivateUser.Click += btnDeactivateUser_Click;
            // 
            // btnAddUser
            // 
            btnAddUser.BackColor = Color.Thistle;
            btnAddUser.FlatStyle = FlatStyle.Flat;
            btnAddUser.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnAddUser.Location = new Point(20, 570);
            btnAddUser.Name = "btnAddUser";
            btnAddUser.Size = new Size(130, 40);
            btnAddUser.TabIndex = 4;
            btnAddUser.Text = "Add User";
            btnAddUser.UseVisualStyleBackColor = false;
            btnAddUser.Click += btnAddUser_Click;
            // 
            // dgvUsers
            // 
            dgvUsers.AllowUserToAddRows = false;
            dgvUsers.AllowUserToDeleteRows = false;
            dgvUsers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvUsers.BackgroundColor = SystemColors.Control;
            dgvUsers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvUsers.Columns.AddRange(new DataGridViewColumn[] { colUserId, colFullName, colEmail, colRole, colStatus });
            dgvUsers.Location = new Point(20, 267);
            dgvUsers.Name = "dgvUsers";
            dgvUsers.ReadOnly = true;
            dgvUsers.RowHeadersVisible = false;
            dgvUsers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvUsers.Size = new Size(1090, 283);
            dgvUsers.TabIndex = 3;
            // 
            // colUserId
            // 
            colUserId.HeaderText = "User ID";
            colUserId.Name = "colUserId";
            colUserId.ReadOnly = true;
            // 
            // colFullName
            // 
            colFullName.HeaderText = "Full Name";
            colFullName.Name = "colFullName";
            colFullName.ReadOnly = true;
            // 
            // colEmail
            // 
            colEmail.HeaderText = "Email";
            colEmail.Name = "colEmail";
            colEmail.ReadOnly = true;
            // 
            // colRole
            // 
            colRole.HeaderText = "Role";
            colRole.Name = "colRole";
            colRole.ReadOnly = true;
            // 
            // colStatus
            // 
            colStatus.HeaderText = "Status";
            colStatus.Name = "colStatus";
            colStatus.ReadOnly = true;
            // 
            // btnSearch
            // 
            btnSearch.BackColor = Color.Thistle;
            btnSearch.FlatStyle = FlatStyle.Flat;
            btnSearch.Location = new Point(280, 75);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(100, 30);
            btnSearch.TabIndex = 2;
            btnSearch.Text = "Search";
            btnSearch.UseVisualStyleBackColor = false;
            // 
            // txtSearchUser
            // 
            txtSearchUser.Location = new Point(20, 80);
            txtSearchUser.Name = "txtSearchUser";
            txtSearchUser.Size = new Size(250, 23);
            txtSearchUser.TabIndex = 1;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblTitle.Location = new Point(20, 20);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(223, 32);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "User Management";
            // 
            // UserManagementForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LavenderBlush;
            ClientSize = new Size(1184, 661);
            Controls.Add(panelMain);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "UserManagementForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "User Management";
            panelMain.ResumeLayout(false);
            panelMain.PerformLayout();
            pnlApplicants.ResumeLayout(false);
            pnlApplicants.PerformLayout();
            pnlHRStaff.ResumeLayout(false);
            pnlHRStaff.PerformLayout();
            pnlHRManagers.ResumeLayout(false);
            pnlHRManagers.PerformLayout();
            pnlAdmin.ResumeLayout(false);
            pnlAdmin.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvUsers).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelMain;
        private Button btnBack;
        private Button btnHiringReport;
        private Button btnJobReport;
        private Button btnAuditReport;
        private Button btnApplicantReport;
        private Panel pnlApplicants;
        private Label lblApplicantsCount;
        private Label lblApplicants;
        private Panel pnlHRStaff;
        private Label lblHRStaffCount;
        private Label lblHRStaff;
        private Panel pnlHRManagers;
        private Label lblHRManagersCount;
        private Label lblHRManagers;
        private Panel pnlAdmin;
        private Label lblAdmiCount;
        private Label lblAdminTitle;
        private Label lblSearch;
        private Button btnDeactivateUser;
        private Button btnResetPassword;
        private Button btnEditUser;
        private Button btnAddUser;
        private DataGridView dgvUsers;
        private Button btnSearch;
        private TextBox txtSearchUser;
        private Label lblTitle;
        private DataGridViewTextBoxColumn colUserId;
        private DataGridViewTextBoxColumn colFullName;
        private DataGridViewTextBoxColumn colEmail;
        private DataGridViewTextBoxColumn colRole;
        private DataGridViewTextBoxColumn colStatus;
        private Label label3;
        private ComboBox cmbRole;
        private TextBox textBox2;
        private Label label2lblPassword;
        private TextBox textBox1;
        private Label lblEmail;
        private TextBox txtFullName;
        private Label lblFullName;
    }
}