using System;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using HRApplicantSystem.Database;

namespace HRApplicantSystem
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
                return;
            }

            if (!txtEmail.Text.Contains("@"))
            {
                lblMessage.ForeColor = Color.Red;
                lblMessage.Text = "Invalid Email Address.";
                return;
            }

            try
            {
                DbConnection db = new DbConnection();

                using (MySqlConnection conn = db.GetConnection())
                {
                    conn.Open();

                    string checkQuery =
                    @"SELECT COUNT(*)
              FROM ApplicantAccounts
              WHERE Email=@Email";

                    using (MySqlCommand checkCmd =
                           new MySqlCommand(checkQuery, conn))
                    {
                        checkCmd.Parameters.AddWithValue(
                            "@Email",
                            txtEmail.Text.Trim());

                        int count =
                            Convert.ToInt32(checkCmd.ExecuteScalar());

                        if (count > 0)
                        {
                            lblMessage.ForeColor = Color.Red;
                            lblMessage.Text = "Email already exists.";
                            return;
                        }
                    }

                    string accountQuery = @"
            INSERT INTO ApplicantAccounts
            (
                Email,
                PasswordHash,
                IsActive
            )
            VALUES
            (
                @Email,
                SHA2(@Password,256),
                1
            );

            SELECT LAST_INSERT_ID();";

                    int newAccountID = 0;

                    using (MySqlCommand accountCmd =
                           new MySqlCommand(accountQuery, conn))
                    {
                        accountCmd.Parameters.AddWithValue(
                            "@Email",
                            txtEmail.Text.Trim());

                        accountCmd.Parameters.AddWithValue(
                            "@Password",
                            txtPassword.Text);

                        newAccountID =
                            Convert.ToInt32(accountCmd.ExecuteScalar());
                    }

                    string applicantQuery = @"
            INSERT INTO Applicants
            (
                AccountID,
                FirstName,
                LastName
            )
            VALUES
            (
                @AccountID,
                @FirstName,
                @LastName
            )";

                    using (MySqlCommand applicantCmd =
                           new MySqlCommand(applicantQuery, conn))
                    {
                        applicantCmd.Parameters.AddWithValue(
                            "@AccountID",
                            newAccountID);

                        applicantCmd.Parameters.AddWithValue(
                            "@FirstName",
                            txtFirstName.Text.Trim());

                        applicantCmd.Parameters.AddWithValue(
                            "@LastName",
                            txtLastName.Text.Trim());

                        applicantCmd.ExecuteNonQuery();
                    }

                    string auditQuery = @"
            INSERT INTO AuditTrail
            (
                ActorType,
                ActorID,
                Action,
                TargetTable,
                TargetID,
                Details
            )
            VALUES
            (
                'Applicant',
                @ActorID,
                'REGISTER',
                'ApplicantAccounts',
                @TargetID,
                @Details
            )";

                    using (MySqlCommand auditCmd =
                           new MySqlCommand(auditQuery, conn))
                    {
                        auditCmd.Parameters.AddWithValue(
                            "@ActorID",
                            newAccountID);

                        auditCmd.Parameters.AddWithValue(
                            "@TargetID",
                            newAccountID);

                        auditCmd.Parameters.AddWithValue(
                            "@Details",
                            "New applicant registered.");

                        auditCmd.ExecuteNonQuery();
                    }

                    MessageBox.Show(
                        "Registration Successful!",
                        "Success",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    LoginForm login = new LoginForm();

                    login.Show();

                    this.Hide();
                }
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
