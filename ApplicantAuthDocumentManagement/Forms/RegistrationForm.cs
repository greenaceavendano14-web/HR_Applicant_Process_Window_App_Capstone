using System;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace ApplicantAuthDocumentManagement.Forms
{
    public partial class RegistrationForm : Form
    {
        public RegistrationForm()
        {
            InitializeComponent();

            this.Size = new Size(1000, 600);
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {

            lblMessage.Text = "";

            if (string.IsNullOrWhiteSpace(txtFirstName.Text) ||
                string.IsNullOrWhiteSpace(txtLastName.Text) ||
                string.IsNullOrWhiteSpace(txtEmail.Text) ||
                string.IsNullOrWhiteSpace(txtPassword.Text) ||
                string.IsNullOrWhiteSpace(txtConfirmPassword.Text))
            {
                lblMessage.ForeColor = Color.Red;
                lblMessage.Text = "Please fill in all fields.";
                return;
            }

            if (txtPassword.Text != txtConfirmPassword.Text)
            {
                lblMessage.ForeColor = Color.Red;
                lblMessage.Text = "Passwords do not match.";
                txtConfirmPassword.Focus();
                return;
            }

            if (!txtEmail.Text.Contains("@") || !txtEmail.Text.Contains("."))
            {
                lblMessage.ForeColor = Color.Red;
                lblMessage.Text = "Please enter a valid email address.";
                txtEmail.Focus();
                return;
            }

            try
            {
                using (MySqlConnection conn = DBConnection.GetConnection())
                {
                    string checkQuery = "SELECT COUNT(*) FROM ApplicantAccounts WHERE Email = @Email";
                    using (MySqlCommand checkCmd = new MySqlCommand(checkQuery, conn))
                    {
                        checkCmd.Parameters.AddWithValue("@Email", txtEmail.Text.Trim());

                        conn.Open();
                        int emailConflictCount = Convert.ToInt32(checkCmd.ExecuteScalar());

                        if (emailConflictCount > 0)
                        {
                            lblMessage.ForeColor = Color.Red;
                            lblMessage.Text = "Email already exists.";
                            return;
                        }
                    }

                    string insertQuery = @"
                        INSERT INTO ApplicantAccounts (Email, PasswordHash, IsActive) 
                        VALUES (@Email, @Password, 1);
                        SELECT LAST_INSERT_ID();";

                    int newAccountID = 0;
                    using (MySqlCommand insertCmd = new MySqlCommand(insertQuery, conn))
                    {
                        insertCmd.Parameters.AddWithValue("@Email", txtEmail.Text.Trim());
                        insertCmd.Parameters.AddWithValue("@Password", txtPassword.Text); // Matches clear-text strategy from login

                        newAccountID = Convert.ToInt32(insertCmd.ExecuteScalar());
                    }

                    string profileQuery = "INSERT INTO Applicants (AccountID, FirstName, LastName) VALUES (@AccountID, @FirstName, @LastName)";
                    using (MySqlCommand profileCmd = new MySqlCommand(profileQuery, conn))
                    {
                        profileCmd.Parameters.AddWithValue("@AccountID", newAccountID);
                        profileCmd.Parameters.AddWithValue("@FirstName", txtFirstName.Text.Trim());
                        profileCmd.Parameters.AddWithValue("@LastName", txtLastName.Text.Trim());

                        profileCmd.ExecuteNonQuery();
                    }

                    lblMessage.ForeColor = Color.Green;
                    lblMessage.Text = "Account created! You can now login.";

                    txtFirstName.Clear();
                    txtLastName.Clear();
                    txtEmail.Clear();
                    txtPassword.Clear();
                    txtConfirmPassword.Clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Database tracking error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lnkLogin_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            LoginForm login = new LoginForm();
            login.Show();
            this.Hide();
        }

        private void lblLastName_Click(object sender, EventArgs e)
        {

        }
    }
}