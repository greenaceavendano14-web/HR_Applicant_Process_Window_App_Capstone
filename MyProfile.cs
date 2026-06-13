using HRApplicantSystem.Database;
using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;
using ApplicantSystem;

namespace HRApplicantSystem
{
    public partial class MyProfile : Form
    {
        DbConnection db = new DbConnection();

        public MyProfile()
        {
            InitializeComponent();

            Load += MyProfile_Load;

            btnSave.Click += btnSave_Click;
            btnUpdate.Click += btnUpdate_Click;
            btnBack.Click += btnBack_Click;
        }

        private void MyProfile_Load(object sender, EventArgs e)
        {
            LoadProfile();
        }

        private void LoadProfile()
        {
            string query = @"
            SELECT *
            FROM Applicants
            WHERE ApplicantID=@ApplicantID";

            using (MySqlConnection conn = db.GetConnection())
            {
                try
                {
                    conn.Open();

                    MySqlCommand cmd =
                        new MySqlCommand(query, conn);

                    cmd.Parameters.AddWithValue(
                        "@ApplicantID",
                        ApplicantSession.ApplicantID);

                    MySqlDataReader dr =
                        cmd.ExecuteReader();

                    if (dr.Read())
                    {
                        txtFirstName.Text =
                            dr["FirstName"].ToString();

                        txtLastName.Text =
                            dr["LastName"].ToString();

                        cboGender.Text =
                            dr["Gender"].ToString();

                        txtPhone.Text =
                            dr["Phone"].ToString();

                        txtAddress.Text =
                            dr["AddressLine1"].ToString();

                        cboEducation.Text =
                            dr["HighestDegree"].ToString();

                        txtSchool.Text =
                            dr["SchoolName"].ToString();

                        txtYear.Text =
                            dr["GradYear"].ToString();

                        txtSkills.Text =
                            dr["Skills"].ToString();

                        txtPosition.Text =
                            dr["WorkExperience"].ToString();

                        if (dr["DateOfBirth"] != DBNull.Value)
                        {
                            dtpBirthDate.Value =
                                Convert.ToDateTime(
                                    dr["DateOfBirth"]);
                        }
                    }

                    dr.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void SaveProfile()
        {
            string query = @"
            UPDATE Applicants
            SET
                FirstName=@FirstName,
                LastName=@LastName,
                DateOfBirth=@DateOfBirth,
                Gender=@Gender,
                Phone=@Phone,
                AddressLine1=@Address,
                HighestDegree=@Education,
                SchoolName=@School,
                GradYear=@GradYear,
                Skills=@Skills,
                WorkExperience=@WorkExperience
            WHERE ApplicantID=@ApplicantID";

            using (MySqlConnection conn = db.GetConnection())
            {
                try
                {
                    conn.Open();

                    MySqlCommand cmd =
                        new MySqlCommand(query, conn);

                    cmd.Parameters.AddWithValue(
                        "@FirstName",
                        txtFirstName.Text);

                    cmd.Parameters.AddWithValue(
                        "@LastName",
                        txtLastName.Text);

                    cmd.Parameters.AddWithValue(
                        "@DateOfBirth",
                        dtpBirthDate.Value);

                    cmd.Parameters.AddWithValue(
                        "@Gender",
                        cboGender.Text);

                    cmd.Parameters.AddWithValue(
                        "@Phone",
                        txtPhone.Text);

                    cmd.Parameters.AddWithValue(
                        "@Address",
                        txtAddress.Text);

                    cmd.Parameters.AddWithValue(
                        "@Education",
                        cboEducation.Text);

                    cmd.Parameters.AddWithValue(
                        "@School",
                        txtSchool.Text);

                    cmd.Parameters.AddWithValue(
                        "@GradYear",
                        txtYear.Text);

                    cmd.Parameters.AddWithValue(
                        "@Skills",
                        txtSkills.Text);

                    cmd.Parameters.AddWithValue(
                        "@WorkExperience",
                        txtPosition.Text);

                    cmd.Parameters.AddWithValue(
                        "@ApplicantID",
                        ApplicantSession.ApplicantID);

                    cmd.ExecuteNonQuery();

                    MessageBox.Show(
                        "Profile updated successfully!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveProfile();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            SaveProfile();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}