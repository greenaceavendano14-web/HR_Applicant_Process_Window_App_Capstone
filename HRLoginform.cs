using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using HRApplicantSystem.Database;
using HRApplicantSystem.Models;

namespace HRApplicantSystem
{
    public partial class HRLoginForm : Form
    {
        private bool passwordVisible = false;

        public HRLoginForm()
        {
            InitializeComponent();
        }

        private void HRLoginForm_Load(object sender, EventArgs e)
        {
            txtPassword.PasswordChar = '*';
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text.Trim();
            string password = txtPassword.Text.Trim();

            if (email == "" || password == "")
            {
                MessageBox.Show(
                    "Please enter email and password.",
                    "Required",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

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
                        U.UserID,
                        U.FirstName,
                        U.LastName,
                        R.RoleName
                    FROM Users U
                    INNER JOIN Roles R
                        ON U.RoleID = R.RoleID
                    WHERE U.Email = @Email
                    AND U.PasswordHash = SHA2(@Password,256)
                    AND U.IsActive = 1
                    LIMIT 1";

                    MySqlCommand cmd =
                        new MySqlCommand(query, conn);

                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.Parameters.AddWithValue("@Password", password);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (!reader.Read())
                        {
                            MessageBox.Show(
                                "Invalid Email or Password.",
                                "Login Failed",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);

                            return;
                        }

                        int userId =
                            Convert.ToInt32(reader["UserID"]);

                        string firstName =
                            reader["FirstName"].ToString();

                        string lastName =
                            reader["LastName"].ToString();

                        string role =
    reader["RoleName"]?.ToString() ?? "";

                        string fullName =
                            (firstName ?? "") + " " + (lastName ?? "");

                        Session.UserID = userId;
                        Session.FullName = fullName;
                        Session.RoleName = role;

                        reader.Close();

                        string actorType = role;

                        MySqlCommand auditCmd =
                            new MySqlCommand(
                            @"INSERT INTO AuditTrail
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
                                @ActorType,
                                @ActorID,
                                'LOGIN',
                                'Users',
                                @TargetID,
                                @Details
                            )", conn);

                        auditCmd.Parameters.AddWithValue(
                            "@ActorType", actorType);

                        auditCmd.Parameters.AddWithValue(
                            "@ActorID", userId);

                        auditCmd.Parameters.AddWithValue(
                            "@TargetID", userId);

                        auditCmd.Parameters.AddWithValue(
                            "@Details",
                            fullName + " logged in.");

                        auditCmd.ExecuteNonQuery();

                        MessageBox.Show(
                            "Login Successful!",
                            "Success",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);

                        HRDashboard dashboard =
                            new HRDashboard(
                                userId,
                                role,
                                fullName);

                        dashboard.Show();

                        this.Hide();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Database Error:\n\n" + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btnShowPassword_Click(object sender, EventArgs e)
        {
            if (passwordVisible)
            {
                txtPassword.PasswordChar = '*';
                passwordVisible = false;
                btnShowPassword.Text = "👁";
            }
            else
            {
                txtPassword.PasswordChar = '\0';
                passwordVisible = true;
                btnShowPassword.Text = "🙈";
            }
        }

        private void btnApplicantLogIn_Click(object sender, EventArgs e)
        {
            LoginForm applicantLogin = new LoginForm();
            applicantLogin.Show();
            this.Close();
        }
    }
}