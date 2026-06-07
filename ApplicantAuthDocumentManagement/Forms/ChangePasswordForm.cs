using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace ApplicantAuthDocumentManagement.Forms
{
    public partial class ChangePasswordForm : Form
    {
        private string currentLoggedInUserEmail;

        public ChangePasswordForm(string emailPassedFromLogin)
        {
            InitializeComponent();
            currentLoggedInUserEmail = emailPassedFromLogin;
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

            string selectQuery = "SELECT PasswordHash FROM ApplicantAccounts WHERE Email = @Email AND IsActive = 1";
            string updateQuery = "UPDATE ApplicantAccounts SET PasswordHash = @NewPassword WHERE Email = @Email";

            try
            {
                using (MySqlConnection conn = DBConnection.GetConnection())
                {
                    conn.Open();

                    using (MySqlCommand selectCmd = new MySqlCommand(selectQuery, conn))
                    {
                        selectCmd.Parameters.AddWithValue("@Email", currentLoggedInUserEmail);

                        using (MySqlDataReader reader = selectCmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                string databasePassword = reader["PasswordHash"].ToString();

                                if (txtOldPassword.Text != databasePassword)
                                {
                                    lblMessage.Text = "Incorrect current password.";
                                    lblMessage.Visible = true;
                                    return;
                                }
                            }
                            else
                            {
                                lblMessage.Text = "User account configuration error.";
                                lblMessage.Visible = true;
                                return;
                            }
                        }
                    }

                    using (MySqlCommand updateCmd = new MySqlCommand(updateQuery, conn))
                    {
                        updateCmd.Parameters.AddWithValue("@NewPassword", txtNewPassword.Text);
                        updateCmd.Parameters.AddWithValue("@Email", currentLoggedInUserEmail);

                        updateCmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Password changed successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Database tracking error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
} 