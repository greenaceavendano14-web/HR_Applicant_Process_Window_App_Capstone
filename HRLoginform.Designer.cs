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
            panelHeader = new Panel();
            Company = new Label();
            panelLogIn = new Panel();
            LogIn = new Label();
            Email = new Label();
            txtEmail = new TextBox();
            Password = new Label();
            textBox1 = new TextBox();
            btnLogin = new Button();
            this.pictureBox1 = new PictureBox();
            panelHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panelLogIn.SuspendLayout();
            SuspendLayout();
            // 
            // panelHeader
            // 
            panelHeader.BackColor = Color.Thistle;
            panelHeader.Controls.Add(Company);
            panelHeader.Controls.Add(pictureBox1);
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Location = new Point(0, 0);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new Size(884, 100);
            panelHeader.TabIndex = 0;
            // 
            // pictureBox1
            // 
            pictureBox1.ErrorImage = Properties.Resources._6d596f29_cbc8_4189_82bd_307777d73461;
            pictureBox1.Image = Properties.Resources._6d596f29_cbc8_4189_82bd_307777d73461_removebg_preview;
            pictureBox1.ImageLocation = "middle";
            pictureBox1.Location = new Point(-23, -13);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(215, 126);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
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
            panelLogIn.Controls.Add(btnLogin);
            panelLogIn.Controls.Add(textBox1);
            panelLogIn.Controls.Add(Password);
            panelLogIn.Controls.Add(txtEmail);
            panelLogIn.Controls.Add(Email);
            panelLogIn.Controls.Add(LogIn);
            panelLogIn.Location = new Point(209, 153);
            panelLogIn.Name = "panelLogIn";
            panelLogIn.Size = new Size(400, 300);
            panelLogIn.TabIndex = 1;
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
            LogIn.Click += this.LogIn_Click;
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
            // txtEmail
            // 
            txtEmail.BorderStyle = BorderStyle.FixedSingle;
            txtEmail.Location = new Point(50, 110);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(250, 23);
            txtEmail.TabIndex = 2;
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
            // textBox1
            // 
            textBox1.BorderStyle = BorderStyle.FixedSingle;
            textBox1.Location = new Point(50, 185);
            textBox1.Name = "textBox1";
            textBox1.PasswordChar = '*';
            textBox1.Size = new Size(250, 23);
            textBox1.TabIndex = 4;
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
            // 
            // HrLoginForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LavenderBlush;
            ClientSize = new Size(884, 561);
            Controls.Add(panelLogIn);
            Controls.Add(panelHeader);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "HrLoginForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
            Load += Form1_Load;
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panelLogIn.ResumeLayout(false);
            panelLogIn.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelHeader;
        private PictureBox pictureBox1;
        private Label Company;
        private Panel panelLogIn;
        private Label LogIn;
        private Label Password;
        private TextBox txtEmail;
        private Label Email;
        private Button btnLogin;
        private TextBox textBox1;
    }
}
