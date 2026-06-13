
using System.Drawing;
using System.Windows.Forms;

namespace HRApplicantSystem
{
    partial class MyProfile
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

        private Panel headerPanel;
        private Label lblTitle;

        private GroupBox grpPersonal;
        private GroupBox grpContact;
        private GroupBox grpEducation;
        private GroupBox grpWork;

        private TextBox txtFirstName;
        private TextBox txtLastName;
        private ComboBox cboGender;
        private DateTimePicker dtpBirthDate;

        private TextBox txtEmail;
        private TextBox txtPhone;
        private TextBox txtAddress;

        private ComboBox cboEducation;
        private TextBox txtSchool;
        private TextBox txtYear;

        private TextBox txtSkills;
        private TextBox txtCompany;
        private TextBox txtPosition;

        private Button btnSave;
        private Button btnUpdate;
        private Button btnBack;

        private void InitializeComponent()
        {
            headerPanel = new Panel();
            lblTitle = new Label();
            grpPersonal = new GroupBox();
            lblFirstName = new Label();
            txtFirstName = new TextBox();
            lblLastName = new Label();
            txtLastName = new TextBox();
            lblGender = new Label();
            cboGender = new ComboBox();
            lblBirthDate = new Label();
            dtpBirthDate = new DateTimePicker();
            grpContact = new GroupBox();
            lblEmail = new Label();
            txtEmail = new TextBox();
            lblPhone = new Label();
            txtPhone = new TextBox();
            lblAddress = new Label();
            txtAddress = new TextBox();
            grpEducation = new GroupBox();
            lblEducation = new Label();
            cboEducation = new ComboBox();
            lblSchool = new Label();
            txtSchool = new TextBox();
            lblYear = new Label();
            txtYear = new TextBox();
            grpWork = new GroupBox();
            lblSkills = new Label();
            txtSkills = new TextBox();
            lblCompany = new Label();
            txtCompany = new TextBox();
            lblPosition = new Label();
            txtPosition = new TextBox();
            btnSave = new Button();
            btnUpdate = new Button();
            btnBack = new Button();
            headerPanel.SuspendLayout();
            grpPersonal.SuspendLayout();
            grpContact.SuspendLayout();
            grpEducation.SuspendLayout();
            grpWork.SuspendLayout();
            SuspendLayout();
            // 
            // headerPanel
            // 
            headerPanel.BackColor = Color.Thistle;
            headerPanel.Controls.Add(lblTitle);
            headerPanel.Dock = DockStyle.Top;
            headerPanel.Location = new Point(0, 0);
            headerPanel.Name = "headerPanel";
            headerPanel.Size = new Size(814, 84);
            headerPanel.TabIndex = 0;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Georgia", 22F, FontStyle.Bold);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(18, 21);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(280, 35);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Applicant Profile";
            // 
            // grpPersonal
            // 
            grpPersonal.BackColor = Color.WhiteSmoke;
            grpPersonal.Controls.Add(lblFirstName);
            grpPersonal.Controls.Add(txtFirstName);
            grpPersonal.Controls.Add(lblLastName);
            grpPersonal.Controls.Add(txtLastName);
            grpPersonal.Controls.Add(lblGender);
            grpPersonal.Controls.Add(cboGender);
            grpPersonal.Controls.Add(lblBirthDate);
            grpPersonal.Controls.Add(dtpBirthDate);
            grpPersonal.Font = new Font("Palatino Linotype", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            grpPersonal.ForeColor = Color.Thistle;
            grpPersonal.Location = new Point(18, 103);
            grpPersonal.Name = "grpPersonal";
            grpPersonal.Size = new Size(376, 188);
            grpPersonal.TabIndex = 1;
            grpPersonal.TabStop = false;
            grpPersonal.Text = "Personal Information";
            // 
            // lblFirstName
            // 
            lblFirstName.Location = new Point(13, 33);
            lblFirstName.Name = "lblFirstName";
            lblFirstName.Size = new Size(88, 22);
            lblFirstName.TabIndex = 0;
            lblFirstName.Text = "First Name:";
            // 
            // txtFirstName
            // 
            txtFirstName.Location = new Point(105, 28);
            txtFirstName.Name = "txtFirstName";
            txtFirstName.Size = new Size(219, 26);
            txtFirstName.TabIndex = 1;
            // 
            // lblLastName
            // 
            lblLastName.Location = new Point(13, 70);
            lblLastName.Name = "lblLastName";
            lblLastName.Size = new Size(88, 22);
            lblLastName.TabIndex = 2;
            lblLastName.Text = "Last Name:";
            // 
            // txtLastName
            // 
            txtLastName.Location = new Point(105, 66);
            txtLastName.Name = "txtLastName";
            txtLastName.Size = new Size(219, 26);
            txtLastName.TabIndex = 3;
            // 
            // lblGender
            // 
            lblGender.Location = new Point(13, 108);
            lblGender.Name = "lblGender";
            lblGender.Size = new Size(88, 22);
            lblGender.TabIndex = 4;
            lblGender.Text = "Gender:";
            // 
            // cboGender
            // 
            cboGender.Items.AddRange(new object[] { "Male", "Female", "Other" });
            cboGender.Location = new Point(105, 103);
            cboGender.Name = "cboGender";
            cboGender.Size = new Size(219, 27);
            cboGender.TabIndex = 5;
            // 
            // lblBirthDate
            // 
            lblBirthDate.Location = new Point(13, 145);
            lblBirthDate.Name = "lblBirthDate";
            lblBirthDate.Size = new Size(88, 22);
            lblBirthDate.TabIndex = 6;
            lblBirthDate.Text = "Birth Date:";
            // 
            // dtpBirthDate
            // 
            dtpBirthDate.Location = new Point(105, 141);
            dtpBirthDate.Name = "dtpBirthDate";
            dtpBirthDate.Size = new Size(219, 26);
            dtpBirthDate.TabIndex = 7;
            // 
            // grpContact
            // 
            grpContact.BackColor = Color.WhiteSmoke;
            grpContact.Controls.Add(lblEmail);
            grpContact.Controls.Add(txtEmail);
            grpContact.Controls.Add(lblPhone);
            grpContact.Controls.Add(txtPhone);
            grpContact.Controls.Add(lblAddress);
            grpContact.Controls.Add(txtAddress);
            grpContact.Font = new Font("Palatino Linotype", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            grpContact.ForeColor = Color.Thistle;
            grpContact.Location = new Point(420, 103);
            grpContact.Name = "grpContact";
            grpContact.Size = new Size(376, 188);
            grpContact.TabIndex = 2;
            grpContact.TabStop = false;
            grpContact.Text = "Contact Information";
            // 
            // lblEmail
            // 
            lblEmail.Location = new Point(13, 33);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(88, 22);
            lblEmail.TabIndex = 0;
            lblEmail.Text = "Email:";
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(105, 28);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(219, 26);
            txtEmail.TabIndex = 1;
            // 
            // lblPhone
            // 
            lblPhone.Location = new Point(13, 70);
            lblPhone.Name = "lblPhone";
            lblPhone.Size = new Size(88, 22);
            lblPhone.TabIndex = 2;
            lblPhone.Text = "Phone:";
            // 
            // txtPhone
            // 
            txtPhone.Location = new Point(105, 66);
            txtPhone.Name = "txtPhone";
            txtPhone.Size = new Size(219, 26);
            txtPhone.TabIndex = 3;
            // 
            // lblAddress
            // 
            lblAddress.Location = new Point(13, 108);
            lblAddress.Name = "lblAddress";
            lblAddress.Size = new Size(88, 22);
            lblAddress.TabIndex = 4;
            lblAddress.Text = "Address:";
            // 
            // txtAddress
            // 
            txtAddress.Location = new Point(105, 103);
            txtAddress.Multiline = true;
            txtAddress.Name = "txtAddress";
            txtAddress.Size = new Size(219, 47);
            txtAddress.TabIndex = 5;
            // 
            // grpEducation
            // 
            grpEducation.BackColor = Color.WhiteSmoke;
            grpEducation.Controls.Add(lblEducation);
            grpEducation.Controls.Add(cboEducation);
            grpEducation.Controls.Add(lblSchool);
            grpEducation.Controls.Add(txtSchool);
            grpEducation.Controls.Add(lblYear);
            grpEducation.Controls.Add(txtYear);
            grpEducation.Font = new Font("Palatino Linotype", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            grpEducation.ForeColor = Color.Thistle;
            grpEducation.Location = new Point(18, 309);
            grpEducation.Name = "grpEducation";
            grpEducation.Size = new Size(376, 206);
            grpEducation.TabIndex = 3;
            grpEducation.TabStop = false;
            grpEducation.Text = "Educational Background";
            // 
            // lblEducation
            // 
            lblEducation.Location = new Point(13, 33);
            lblEducation.Name = "lblEducation";
            lblEducation.Size = new Size(88, 22);
            lblEducation.TabIndex = 0;
            lblEducation.Text = "Level:";
            // 
            // cboEducation
            // 
            cboEducation.Items.AddRange(new object[] { "High School", "Senior High School", "College", "Master's Degree" });
            cboEducation.Location = new Point(105, 28);
            cboEducation.Name = "cboEducation";
            cboEducation.Size = new Size(219, 27);
            cboEducation.TabIndex = 1;
            // 
            // lblSchool
            // 
            lblSchool.Location = new Point(13, 75);
            lblSchool.Name = "lblSchool";
            lblSchool.Size = new Size(88, 22);
            lblSchool.TabIndex = 2;
            lblSchool.Text = "School:";
            // 
            // txtSchool
            // 
            txtSchool.Location = new Point(105, 70);
            txtSchool.Name = "txtSchool";
            txtSchool.Size = new Size(219, 26);
            txtSchool.TabIndex = 3;
            // 
            // lblYear
            // 
            lblYear.Location = new Point(13, 117);
            lblYear.Name = "lblYear";
            lblYear.Size = new Size(88, 22);
            lblYear.TabIndex = 4;
            lblYear.Text = "Year Graduated:";
            // 
            // txtYear
            // 
            txtYear.Location = new Point(105, 112);
            txtYear.Name = "txtYear";
            txtYear.Size = new Size(219, 26);
            txtYear.TabIndex = 5;
            // 
            // grpWork
            // 
            grpWork.BackColor = Color.WhiteSmoke;
            grpWork.Controls.Add(lblSkills);
            grpWork.Controls.Add(txtSkills);
            grpWork.Controls.Add(lblCompany);
            grpWork.Controls.Add(txtCompany);
            grpWork.Controls.Add(lblPosition);
            grpWork.Controls.Add(txtPosition);
            grpWork.Font = new Font("Palatino Linotype", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            grpWork.ForeColor = Color.Thistle;
            grpWork.Location = new Point(420, 309);
            grpWork.Name = "grpWork";
            grpWork.Size = new Size(376, 206);
            grpWork.TabIndex = 4;
            grpWork.TabStop = false;
            grpWork.Text = "Skills and Work Experience";
            // 
            // lblSkills
            // 
            lblSkills.Location = new Point(13, 33);
            lblSkills.Name = "lblSkills";
            lblSkills.Size = new Size(88, 22);
            lblSkills.TabIndex = 0;
            lblSkills.Text = "Skills:";
            // 
            // txtSkills
            // 
            txtSkills.Location = new Point(105, 28);
            txtSkills.Multiline = true;
            txtSkills.Name = "txtSkills";
            txtSkills.Size = new Size(219, 47);
            txtSkills.TabIndex = 1;
            // 
            // lblCompany
            // 
            lblCompany.Location = new Point(13, 89);
            lblCompany.Name = "lblCompany";
            lblCompany.Size = new Size(88, 22);
            lblCompany.TabIndex = 2;
            lblCompany.Text = "Company:";
            // 
            // txtCompany
            // 
            txtCompany.Location = new Point(105, 84);
            txtCompany.Name = "txtCompany";
            txtCompany.Size = new Size(219, 26);
            txtCompany.TabIndex = 3;
            // 
            // lblPosition
            // 
            lblPosition.Location = new Point(13, 127);
            lblPosition.Name = "lblPosition";
            lblPosition.Size = new Size(88, 22);
            lblPosition.TabIndex = 4;
            lblPosition.Text = "Position:";
            // 
            // txtPosition
            // 
            txtPosition.Location = new Point(105, 122);
            txtPosition.Name = "txtPosition";
            txtPosition.Size = new Size(219, 26);
            txtPosition.TabIndex = 5;
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.Thistle;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.Font = new Font("Microsoft Sans Serif", 7.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSave.ForeColor = Color.White;
            btnSave.Location = new Point(184, 539);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(114, 38);
            btnSave.TabIndex = 5;
            btnSave.Text = "Save Profile";
            btnSave.UseVisualStyleBackColor = false;
            // 
            // btnUpdate
            // 
            btnUpdate.BackColor = Color.Thistle;
            btnUpdate.FlatStyle = FlatStyle.Flat;
            btnUpdate.Font = new Font("Microsoft Sans Serif", 7.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnUpdate.ForeColor = Color.White;
            btnUpdate.Location = new Point(352, 539);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(114, 38);
            btnUpdate.TabIndex = 6;
            btnUpdate.Text = "Update";
            btnUpdate.UseVisualStyleBackColor = false;
            // 
            // btnBack
            // 
            btnBack.BackColor = Color.Thistle;
            btnBack.FlatStyle = FlatStyle.Flat;
            btnBack.Font = new Font("Microsoft Sans Serif", 7.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnBack.ForeColor = Color.White;
            btnBack.Location = new Point(525, 539);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(114, 38);
            btnBack.TabIndex = 7;
            btnBack.Text = "Back";
            btnBack.UseVisualStyleBackColor = false;
            btnBack.Click += btnBack_Click;
            // 
            // MyProfile
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LavenderBlush;
            ClientSize = new Size(814, 611);
            Controls.Add(headerPanel);
            Controls.Add(grpPersonal);
            Controls.Add(grpContact);
            Controls.Add(grpEducation);
            Controls.Add(grpWork);
            Controls.Add(btnSave);
            Controls.Add(btnUpdate);
            Controls.Add(btnBack);
            Name = "MyProfile";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
            headerPanel.ResumeLayout(false);
            headerPanel.PerformLayout();
            grpPersonal.ResumeLayout(false);
            grpPersonal.PerformLayout();
            grpContact.ResumeLayout(false);
            grpContact.PerformLayout();
            grpEducation.ResumeLayout(false);
            grpEducation.PerformLayout();
            grpWork.ResumeLayout(false);
            grpWork.PerformLayout();
            ResumeLayout(false);

        }
        #endregion

        private Label lblFirstName;
        private Label lblLastName;
        private Label lblGender;
        private Label lblBirthDate;
        private Label lblEmail;
        private Label lblPhone;
        private Label lblAddress;
        private Label lblEducation;
        private Label lblSchool;
        private Label lblYear;
        private Label lblSkills;
        private Label lblCompany;
        private Label lblPosition;
    }
}