using ApplicantSystem;
using HRApplicantSystem.Database;
using HRApplicantSystem.Models;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;
using HRApplicantSystem;

namespace HRApplicantSystem
{
    public partial class ChangePasswordForm : Form
    {
        private string currentLoggedInUserEmail;

        public ChangePasswordForm()
        {
            InitializeComponent();

            currentLoggedInUserEmail = ApplicantSession.Email;
        }

        private void btnChange_Click(object sender, EventArgs e)
        {
            lblMessage.Text = "";

            if (string.IsNullOrWhiteSpace(txtOldPassword.Text) ||
                string.IsNullOrWhiteSpace(txtNewPassword.Text) ||
                string.IsNullOrWhiteSpace(txtConfirmNew.Text))
            {
                lblMessage.Text = "Please fill in all fields.";
                lblMessage.Visible = true;
                return;
            }

            if (txtNewPassword.Text != txtConfirmNew.Text)
            {
                lblMessage.Text = "New passwords do not match.";
                lblMessage.Visible = true;
                return;
            }

            try
            {
                DbConnection db = new DbConnection();

                using (MySqlConnection conn = db.GetConnection())
                {
                    conn.Open();

                    string verifyQuery = @"
            SELECT AccountID
            FROM ApplicantAccounts
            WHERE Email = @Email
            AND PasswordHash = SHA2(@OldPassword,256)
            AND IsActive = 1";

                    using (MySqlCommand verifyCmd =
                           new MySqlCommand(verifyQuery, conn))
                    {
                        verifyCmd.Parameters.AddWithValue(
                            "@Email",
                            currentLoggedInUserEmail);

                        verifyCmd.Parameters.AddWithValue(
                            "@OldPassword",
                            txtOldPassword.Text);

                        object result = verifyCmd.ExecuteScalar();

                        if (result == null)
                        {
                            lblMessage.Text =
                                "Incorrect current password.";

                            lblMessage.Visible = true;
                            return;
                        }
                    }

                    string updateQuery = @"
            UPDATE ApplicantAccounts
            SET PasswordHash = SHA2(@NewPassword,256)
            WHERE Email = @Email";

                    using (MySqlCommand updateCmd =
                           new MySqlCommand(updateQuery, conn))
                    {
                        updateCmd.Parameters.AddWithValue(
                            "@NewPassword",
                            txtNewPassword.Text);

                        updateCmd.Parameters.AddWithValue(
                            "@Email",
                            currentLoggedInUserEmail);

                        updateCmd.ExecuteNonQuery();
                    }

                    string auditQuery = @"
            INSERT INTO AuditTrail
            (
                ActorType,
                ActorID,
                Action,
                Details
            )
            VALUES
            (
                'Applicant',
                @ActorID,
                'CHANGE_PASSWORD',
                @Details
            )";

                    using (MySqlCommand auditCmd =
                           new MySqlCommand(auditQuery, conn))
                    {
                        auditCmd.Parameters.AddWithValue(
                            "@ActorID",
                            ApplicantSession.ApplicantID);

                        auditCmd.Parameters.AddWithValue(
                            "@Details",
                            "Applicant changed account password.");

                        auditCmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show(
                    "Password changed successfully!",
                    "Success",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Database Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
