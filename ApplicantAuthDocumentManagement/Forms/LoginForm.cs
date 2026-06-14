using ApplicantSystem;
using HRApplicantSystem.Database;
using MySql.Data.MySqlClient;

namespace HRApplicantSystem
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

            try
            {
                DbConnection db = new DbConnection();

                using (MySqlConnection conn = db.GetConnection())
                {
                    conn.Open();

                    string query = @"
            SELECT
                aa.AccountID,
                a.ApplicantID,
                aa.Email,
                a.FirstName,
                a.LastName
            FROM ApplicantAccounts aa
            INNER JOIN Applicants a
                ON aa.AccountID = a.AccountID
            WHERE aa.Email = @Email
            AND aa.PasswordHash = SHA2(@Password,256)
            AND aa.IsActive = 1";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Email", txtEmail.Text.Trim());
                        cmd.Parameters.AddWithValue("@Password", txtPassword.Text);

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                ApplicantSession.AccountID =
                                    Convert.ToInt32(reader["AccountID"]);

                                ApplicantSession.ApplicantID =
                                    Convert.ToInt32(reader["ApplicantID"]);

                                ApplicantSession.Email =
                                    reader["Email"].ToString();

                                ApplicantSession.FirstName =
                                    reader["FirstName"].ToString();

                                ApplicantSession.LastName =
                                    reader["LastName"].ToString();
                            }
                            else
                            {
                                lblError.Text = "Invalid Email or Password.";
                                return;
                            }
                        }
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
                'LOGIN',
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
                            "Applicant logged in.");

                        auditCmd.ExecuteNonQuery();
                    }

                    MessageBox.Show(
                        "Welcome " + ApplicantSession.FullName + "!",
                        "Login Successful",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    ApplicantDashboard dashboard =
                        new ApplicantDashboard();

                    dashboard.Show();

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

        private void lnkRegister_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            RegistrationForm register = new RegistrationForm();

            register.Show();

            this.Hide();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to exit the application?", "Exit Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void chkShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            if (chkShowPassword.Checked)
            {
                txtPassword.PasswordChar = '\0';
                chkShowPassword.Text = "🙈";
            }
            else
            {
                txtPassword.PasswordChar = '•';
                chkShowPassword.Text = "👁️";
            }
        }

        private void btnHRLogin_Click(object sender, EventArgs e)
        {
            HRLoginForm hrLogin = new HRLoginForm();
            this.Hide();
            hrLogin.Show();
        }
    }
}
