using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace JobVacancyForm
{
    public partial class JobVacancyForm : Form
    {
        DBConnection db = new DBConnection();
        int selectedVacancyID = 0;

        public JobVacancyForm()
        {
            InitializeComponent();

            this.Load += JobVacancyForm_Load;
            dataGridView1.CellClick += dataGridView1_CellClick;
        }

        // ================= LOAD =================
        private void JobVacancyForm_Load(object sender, EventArgs e)
        {
            LoadJobs();

            cmbStatus.Items.Clear();
            cmbStatus.Items.Add("Open");
            cmbStatus.Items.Add("Closed");
            cmbStatus.Items.Add("On Hold");
            cmbStatus.SelectedIndex = 0;
        }

        // ================= LOAD JOBS =================
        private void LoadJobs()
        {
            try
            {
                db.Open();

                string query = "SELECT * FROM JobVacancies";

                MySqlDataAdapter da = new MySqlDataAdapter(query, db.connection);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dataGridView1.DataSource = dt;

                db.Close();

                selectedVacancyID = 0;
                dataGridView1.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("LOAD ERROR: " + ex.Message);
            }
        }

        // ================= ADD (FIXED) =================
        private void ADD_Click(object sender, EventArgs e)
        {
            try
            {
                db.Open();

                string query = @"
                INSERT INTO JobVacancies
                (JobTitle, JobDescription, Qualifications, SlotsAvailable, PostedDate, Status, CreatedByUserID)
                VALUES
                (@title, @desc, @qual, 1, CURDATE(), @status, 1)";

                MySqlCommand cmd = new MySqlCommand(query, db.connection);

                cmd.Parameters.AddWithValue("@title", txtJobTitle.Text);
                cmd.Parameters.AddWithValue("@desc", txtDescription.Text);
                cmd.Parameters.AddWithValue("@qual", txtRequirements.Text);
                cmd.Parameters.AddWithValue("@status", cmbStatus.Text);

                cmd.ExecuteNonQuery();

                db.Close();

                MessageBox.Show("Job Added Successfully!");

                LoadJobs();
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ADD ERROR: " + ex.Message);
            }
        }

        // ================= SELECT =================
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

            selectedVacancyID = Convert.ToInt32(row.Cells["VacancyID"].Value);
            txtJobTitle.Text = row.Cells["JobTitle"].Value?.ToString();
            txtDescription.Text = row.Cells["JobDescription"].Value?.ToString();
            txtRequirements.Text = row.Cells["Qualifications"].Value?.ToString();
            cmbStatus.Text = row.Cells["Status"].Value?.ToString();
        }

        // ================= UPDATE =================
        private void UPDATE_Click(object sender, EventArgs e)
        {
            try
            {
                if (selectedVacancyID == 0)
                {
                    MessageBox.Show("Select a job first!");
                    return;
                }

                db.Open();

                string query = @"
                UPDATE JobVacancies
                SET JobTitle=@title,
                    JobDescription=@desc,
                    Qualifications=@qual,
                    Status=@status
                WHERE VacancyID=@id";

                MySqlCommand cmd = new MySqlCommand(query, db.connection);

                cmd.Parameters.AddWithValue("@id", selectedVacancyID);
                cmd.Parameters.AddWithValue("@title", txtJobTitle.Text);
                cmd.Parameters.AddWithValue("@desc", txtDescription.Text);
                cmd.Parameters.AddWithValue("@qual", txtRequirements.Text);
                cmd.Parameters.AddWithValue("@status", cmbStatus.Text);

                cmd.ExecuteNonQuery();

                db.Close();

                MessageBox.Show("Updated Successfully!");

                LoadJobs();
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show("UPDATE ERROR: " + ex.Message);
            }
        }

        // ================= DELETE =================
        private void DELETE_Click(object sender, EventArgs e)
        {
            try
            {
                if (selectedVacancyID == 0)
                {
                    MessageBox.Show("Select a job first!");
                    return;
                }

                db.Open();

                string query = "DELETE FROM JobVacancies WHERE VacancyID=@id";

                MySqlCommand cmd = new MySqlCommand(query, db.connection);
                cmd.Parameters.AddWithValue("@id", selectedVacancyID);

                cmd.ExecuteNonQuery();

                db.Close();

                MessageBox.Show("Deleted Successfully!");

                LoadJobs();
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show("DELETE ERROR: " + ex.Message);
            }
        }

        // ================= CLEAR =================
        private void ClearFields()
        {
            txtJobTitle.Clear();
            txtDescription.Clear();
            txtRequirements.Clear();
            cmbStatus.SelectedIndex = 0;
            selectedVacancyID = 0;
        }

        private void CLEAR_Click(object sender, EventArgs e)
        {
            ClearFields();
        }
    }
}
