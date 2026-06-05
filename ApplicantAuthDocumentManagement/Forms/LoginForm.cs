using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace ApplicantAuthDocumentManagement.Forms
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e) { }
        private void lblError_Paint(object sender, PaintEventArgs e) { }
        private void lblTitle_Click(object sender, EventArgs e) { }
        private void lblLogin_Click(object sender, EventArgs e) { }
        private void lblPassword_Click(object sender, EventArgs e) { }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            lblError.Text = "";

            if (string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                lblError.Text = "Please enter your email.";
                txtEmail.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                lblError.Text = "Please enter your password.";
                txtPassword.Focus();
                return;
            }

            string query = @"
                SELECT aa.AccountID, a.ApplicantID, aa.Email, a.FirstName, a.LastName 
                FROM ApplicantAccounts aa
                LEFT JOIN Applicants a ON aa.AccountID = a.AccountID
                WHERE aa.Email = @Email AND aa.PasswordHash = @Password AND aa.IsActive = 1";

            try
            {
                using (MySqlConnection conn = DBConnection.GetConnection())
                {
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Email", txtEmail.Text.Trim());
                        cmd.Parameters.AddWithValue("@Password", txtPassword.Text);

                        conn.Open();

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                Session.AccountID = Convert.ToInt32(reader["AccountID"]);
                                Session.ApplicantID = reader["ApplicantID"] != DBNull.Value ? Convert.ToInt32(reader["ApplicantID"]) : 0;
                                Session.Email = reader["Email"].ToString();
                                Session.FirstName = reader["FirstName"].ToString();
                                Session.LastName = reader["LastName"].ToString();

                                MessageBox.Show($"Welcome, {Session.FullName}!", "Login Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                lblError.Text = "Invalid email or password.";
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Database connection error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}