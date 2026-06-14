namespace HRApplicantSystem
{
    partial class ChangePasswordForm
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
            pnlHeader = new Panel();
            lblCompany = new Label();
            picLogo = new PictureBox();
            pnlBackground = new Panel();
            pnlChangePassword = new Panel();
            btnCancel = new Button();
            btnChange = new Button();
            lblMessage = new Label();
            txtConfirmNew = new TextBox();
            lblConfirmNew = new Label();
            txtNewPassword = new TextBox();
            txtOldPassword = new TextBox();
            lblNewPassword = new Label();
            lblOldPassword = new Label();
            lblTitle = new Label();
            pnlHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picLogo).BeginInit();
            pnlBackground.SuspendLayout();
            pnlChangePassword.SuspendLayout();
            SuspendLayout();
            // 
            // pnlHeader
            // 
            pnlHeader.BackColor = Color.Thistle;
            pnlHeader.Controls.Add(lblCompany);
            pnlHeader.Controls.Add(picLogo);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(0, 0);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new Size(859, 75);
            pnlHeader.TabIndex = 0;
            // 
            // lblCompany
            // 
            lblCompany.AutoSize = true;
            lblCompany.Font = new Font("Lucida Fax", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblCompany.ForeColor = Color.White;
            lblCompany.Location = new Point(150, 19);
            lblCompany.Name = "lblCompany";
            lblCompany.Size = new Size(294, 27);
            lblCompany.TabIndex = 3;
            lblCompany.Text = "Apex Digital Solutions";
            // 
            // picLogo
            // 
            picLogo.BackColor = SystemColors.Control;
            picLogo.Image = Properties.Resources.logo2;
            picLogo.Location = new Point(-12, -46);
            picLogo.Name = "picLogo";
            picLogo.Size = new Size(158, 169);
            picLogo.SizeMode = PictureBoxSizeMode.Zoom;
            picLogo.TabIndex = 2;
            picLogo.TabStop = false;
            // 
            // pnlBackground
            // 
            pnlBackground.BackColor = Color.LavenderBlush;
            pnlBackground.Controls.Add(pnlChangePassword);
            pnlBackground.Dock = DockStyle.Fill;
            pnlBackground.Location = new Point(0, 75);
            pnlBackground.Name = "pnlBackground";
            pnlBackground.Size = new Size(859, 443);
            pnlBackground.TabIndex = 1;
            // 
            // pnlChangePassword
            // 
            pnlChangePassword.BackColor = Color.White;
            pnlChangePassword.Controls.Add(btnCancel);
            pnlChangePassword.Controls.Add(btnChange);
            pnlChangePassword.Controls.Add(lblMessage);
            pnlChangePassword.Controls.Add(txtConfirmNew);
            pnlChangePassword.Controls.Add(lblConfirmNew);
            pnlChangePassword.Controls.Add(txtNewPassword);
            pnlChangePassword.Controls.Add(txtOldPassword);
            pnlChangePassword.Controls.Add(lblNewPassword);
            pnlChangePassword.Controls.Add(lblOldPassword);
            pnlChangePassword.Controls.Add(lblTitle);
            pnlChangePassword.Location = new Point(217, 36);
            pnlChangePassword.Name = "pnlChangePassword";
            pnlChangePassword.Size = new Size(394, 338);
            pnlChangePassword.TabIndex = 0;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.LightGray;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCancel.ForeColor = Color.Black;
            btnCancel.Location = new Point(206, 239);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(153, 36);
            btnCancel.TabIndex = 10;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += btnCancel_Click;
            // 
            // btnChange
            // 
            btnChange.BackColor = Color.Thistle;
            btnChange.FlatStyle = FlatStyle.Flat;
            btnChange.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnChange.ForeColor = Color.White;
            btnChange.Location = new Point(35, 239);
            btnChange.Name = "btnChange";
            btnChange.Size = new Size(153, 36);
            btnChange.TabIndex = 9;
            btnChange.Text = "Change";
            btnChange.UseVisualStyleBackColor = false;
            btnChange.Click += btnChange_Click;
            // 
            // lblMessage
            // 
            lblMessage.AutoSize = true;
            lblMessage.Font = new Font("Segoe UI", 7.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblMessage.ForeColor = Color.Red;
            lblMessage.Location = new Point(35, 208);
            lblMessage.Name = "lblMessage";
            lblMessage.Size = new Size(0, 13);
            lblMessage.TabIndex = 8;
            // 
            // txtConfirmNew
            // 
            txtConfirmNew.Location = new Point(35, 173);
            txtConfirmNew.Name = "txtConfirmNew";
            txtConfirmNew.Size = new Size(324, 23);
            txtConfirmNew.TabIndex = 7;
            txtConfirmNew.UseSystemPasswordChar = true;
            // 
            // lblConfirmNew
            // 
            lblConfirmNew.AutoSize = true;
            lblConfirmNew.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblConfirmNew.ForeColor = Color.DimGray;
            lblConfirmNew.Location = new Point(35, 155);
            lblConfirmNew.Name = "lblConfirmNew";
            lblConfirmNew.Size = new Size(131, 15);
            lblConfirmNew.TabIndex = 5;
            lblConfirmNew.Text = "Confirm New Password";
            // 
            // txtNewPassword
            // 
            txtNewPassword.Location = new Point(35, 122);
            txtNewPassword.Name = "txtNewPassword";
            txtNewPassword.Size = new Size(324, 23);
            txtNewPassword.TabIndex = 4;
            txtNewPassword.UseSystemPasswordChar = true;
            // 
            // txtOldPassword
            // 
            txtOldPassword.Location = new Point(35, 70);
            txtOldPassword.Name = "txtOldPassword";
            txtOldPassword.Size = new Size(324, 23);
            txtOldPassword.TabIndex = 3;
            txtOldPassword.UseSystemPasswordChar = true;
            // 
            // lblNewPassword
            // 
            lblNewPassword.AutoSize = true;
            lblNewPassword.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblNewPassword.ForeColor = Color.DimGray;
            lblNewPassword.Location = new Point(35, 103);
            lblNewPassword.Name = "lblNewPassword";
            lblNewPassword.Size = new Size(84, 15);
            lblNewPassword.TabIndex = 2;
            lblNewPassword.Text = "New Password";
            // 
            // lblOldPassword
            // 
            lblOldPassword.AutoSize = true;
            lblOldPassword.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblOldPassword.ForeColor = Color.DimGray;
            lblOldPassword.Location = new Point(35, 52);
            lblOldPassword.Name = "lblOldPassword";
            lblOldPassword.Size = new Size(100, 15);
            lblOldPassword.TabIndex = 1;
            lblOldPassword.Text = "Current Password";
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 13.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitle.ForeColor = Color.DimGray;
            lblTitle.Location = new Point(101, 11);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(161, 25);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Change Password";
            // 
            // ChangePasswordForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(859, 518);
            Controls.Add(pnlBackground);
            Controls.Add(pnlHeader);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "ChangePasswordForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = " Change Password Form";
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picLogo).EndInit();
            pnlBackground.ResumeLayout(false);
            pnlChangePassword.ResumeLayout(false);
            pnlChangePassword.PerformLayout();
            ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.PictureBox picLogo;
        private System.Windows.Forms.Panel pnlBackground;
        private System.Windows.Forms.Panel pnlChangePassword;
        private System.Windows.Forms.Label lblCompany;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.TextBox txtNewPassword;
        private System.Windows.Forms.TextBox txtOldPassword;
        private System.Windows.Forms.Label lblNewPassword;
        private System.Windows.Forms.Label lblOldPassword;
        private System.Windows.Forms.Label lblConfirmNew;
        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.TextBox txtConfirmNew;
        private System.Windows.Forms.Button btnChange;
        private System.Windows.Forms.Button btnCancel;
    }
}