using System;
using System.Windows.Forms;
using System.Drawing;

namespace HRApplicantSystem
{
    partial class HRLoginForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HRLoginForm));
            panelHeader = new Panel();
            pictureBoxLogo = new PictureBox();
            Company = new Label();
            panelLogIn = new Panel();
            btnShowPassword = new Button();
            btnLogin = new Button();
            txtPassword = new TextBox();
            Password = new Label();
            txtEmail = new TextBox();
            Email = new Label();
            LogIn = new Label();
            panelHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxLogo).BeginInit();
            panelLogIn.SuspendLayout();
            SuspendLayout();
            // 
            // panelHeader
            // 
            panelHeader.BackColor = Color.Thistle;
            panelHeader.Controls.Add(pictureBoxLogo);
            panelHeader.Controls.Add(Company);
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Location = new Point(0, 0);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new Size(884, 100);
            panelHeader.TabIndex = 0;
            // 
            // pictureBoxLogo
            // 
            pictureBoxLogo.BackColor = Color.White;
            pictureBoxLogo.Image = (Image)resources.GetObject("pictureBoxLogo.Image");
            pictureBoxLogo.Location = new Point(0, -21);
            pictureBoxLogo.Name = "pictureBoxLogo";
            pictureBoxLogo.Size = new Size(203, 142);
            pictureBoxLogo.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxLogo.TabIndex = 2;
            pictureBoxLogo.TabStop = false;
            // 
            // Company
            // 
            Company.AutoSize = true;
            Company.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            Company.ForeColor = Color.DimGray;
            Company.Location = new Point(209, 32);
            Company.Name = "Company";
            Company.Size = new Size(269, 32);
            Company.TabIndex = 1;
            Company.Text = "Apex Digital Solutions";
            Company.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panelLogIn
            // 
            panelLogIn.BackColor = Color.White;
            panelLogIn.Controls.Add(btnShowPassword);
            panelLogIn.Controls.Add(btnLogin);
            panelLogIn.Controls.Add(txtPassword);
            panelLogIn.Controls.Add(Password);
            panelLogIn.Controls.Add(txtEmail);
            panelLogIn.Controls.Add(Email);
            panelLogIn.Controls.Add(LogIn);
            panelLogIn.Location = new Point(250, 155);
            panelLogIn.Name = "panelLogIn";
            panelLogIn.Size = new Size(400, 300);
            panelLogIn.TabIndex = 1;
            // 
            // btnShowPassword
            // 
            btnShowPassword.Font = new Font("Segoe UI", 12F);
            btnShowPassword.Location = new Point(306, 183);
            btnShowPassword.Name = "btnShowPassword";
            btnShowPassword.Size = new Size(30, 30);
            btnShowPassword.TabIndex = 6;
            btnShowPassword.Text = "👁";
            btnShowPassword.UseVisualStyleBackColor = true;
            btnShowPassword.Click += btnShowPassword_Click;
            // 
            // btnLogin
            // 
            btnLogin.BackColor = Color.Thistle;
            btnLogin.FlatStyle = FlatStyle.Flat;
            btnLogin.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            btnLogin.ForeColor = Color.DimGray;
            btnLogin.Location = new Point(140, 245);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(120, 40);
            btnLogin.TabIndex = 5;
            btnLogin.Text = "LOGIN";
            btnLogin.UseVisualStyleBackColor = false;
            btnLogin.Click += btnLogin_Click;
            // 
            // txtPassword
            // 
            txtPassword.BorderStyle = BorderStyle.FixedSingle;
            txtPassword.Location = new Point(50, 185);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '*';
            txtPassword.Size = new Size(250, 23);
            txtPassword.TabIndex = 4;
            // 
            // Password
            // 
            Password.AutoSize = true;
            Password.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            Password.ForeColor = Color.DimGray;
            Password.Location = new Point(50, 160);
            Password.Name = "Password";
            Password.Size = new Size(76, 20);
            Password.TabIndex = 3;
            Password.Text = "Password";
            // 
            // txtEmail
            // 
            txtEmail.BorderStyle = BorderStyle.FixedSingle;
            txtEmail.Location = new Point(50, 110);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(250, 23);
            txtEmail.TabIndex = 2;
            // 
            // Email
            // 
            Email.AutoSize = true;
            Email.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            Email.ForeColor = Color.DimGray;
            Email.Location = new Point(50, 85);
            Email.Name = "Email";
            Email.Size = new Size(108, 20);
            Email.TabIndex = 1;
            Email.Text = "Email Address";
            // 
            // LogIn
            // 
            LogIn.AutoSize = true;
            LogIn.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            LogIn.ForeColor = Color.DimGray;
            LogIn.Location = new Point(140, 40);
            LogIn.Name = "LogIn";
            LogIn.Size = new Size(117, 30);
            LogIn.TabIndex = 0;
            LogIn.Text = "HR LOGIN";
            // 
            // HRLoginForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LavenderBlush;
            ClientSize = new Size(884, 561);
            Controls.Add(panelLogIn);
            Controls.Add(panelHeader);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "HRLoginForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "HR Login";
            WindowState = FormWindowState.Minimized;
            Load += Form1_Load;
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxLogo).EndInit();
            panelLogIn.ResumeLayout(false);
            panelLogIn.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelHeader;
        private Label Company;
        private Panel panelLogIn;
        private Label LogIn;
        private Label Password;
        private TextBox txtEmail;
        private Label Email;
        private Button btnLogin;
        private TextBox txtPassword;
        private PictureBox pictureBoxLogo;
        private Button btnShowPassword;
    }
}
