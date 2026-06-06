using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace HRSystem
{
    public partial class LoginForm : Form
    {
        DBConnection db = new DBConnection();

        public LoginForm()
        {
            InitializeComponent();

            // ✅ IMPORTANT FIX: CONNECT BUTTON EVENT
            btnLogin.Click += btnLogin_Click;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Login button clicked"); // DEBUG (you can remove later)

            if (txtUsername.Text.Trim() == "" || txtPassword.Text.Trim() == "")
            {
                MessageBox.Show("Please fill all fields!");
                return;
            }

            try
            {
                db.Open();

                string query = "SELECT user_id FROM users WHERE username=@u AND password=@p";

                MySqlCommand cmd = new MySqlCommand(query, db.GetConnection());
                cmd.Parameters.AddWithValue("@u", txtUsername.Text.Trim());
                cmd.Parameters.AddWithValue("@p", txtPassword.Text.Trim());

                object result = cmd.ExecuteScalar();

                db.Close();

                if (result != null)
                {
                    MessageBox.Show("Login Successful!");

                    this.Hide();

                    JobVacancyForm jobForm = new JobVacancyForm();
                    jobForm.Show();
                }
                else
                {
                    MessageBox.Show("Invalid username or password!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
    }
}