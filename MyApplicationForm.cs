using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace JobVacancyForm
{
    public partial class MyApplicationForm : Form
    {
        DBConnection db = new DBConnection();
        int selectedApplicationID = 0;

        public MyApplicationForm()
        {
            InitializeComponent();

            this.Load += MyApplicationForm_Load;
            dataGridView1.CellClick += dataGridView1_CellClick;
        }

        // ================= LOAD =================
        private void MyApplicationForm_Load(object sender, EventArgs e)
        {
            LoadVacancies();
            LoadApplications();
        }

        // ================= LOAD VACANCIES =================
        private void LoadVacancies()
        {
            db.Open();

            MySqlDataAdapter da = new MySqlDataAdapter(
                "SELECT VacancyID, JobTitle FROM JobVacancies",
                db.connection
            );

            DataTable dt = new DataTable();
            da.Fill(dt);

            cmbJobVacancy.DataSource = dt;
            cmbJobVacancy.DisplayMember = "JobTitle";
            cmbJobVacancy.ValueMember = "VacancyID";

            cmbJobVacancy.SelectedIndex = -1;

            db.Close();
        }

        // ================= LOAD APPLICATIONS =================
        private void LoadApplications()
        {
            db.Open();

            MySqlDataAdapter da = new MySqlDataAdapter(
                "SELECT ApplicationID, VacancyID, CurrentStatus, SubmittedAt FROM Applications",
                db.connection
            );

            DataTable dt = new DataTable();
            da.Fill(dt);

            dataGridView1.DataSource = dt;

            db.Close();

            selectedApplicationID = 0;
            dataGridView1.ClearSelection();
        }

        // ================= SAVE DRAFT =================
        private void btnSaveDraft_Click(object sender, EventArgs e)
        {
            if (cmbJobVacancy.SelectedValue == null)
            {
                MessageBox.Show("Please select a job vacancy!");
                return;
            }

            int vacancyId = Convert.ToInt32(cmbJobVacancy.SelectedValue);

            db.Open();

            MySqlCommand cmd = new MySqlCommand(@"
                INSERT INTO Applications (ApplicantID, VacancyID, CurrentStatus)
                VALUES (1, @vacancy, 'Draft')", db.connection);

            cmd.Parameters.AddWithValue("@vacancy", vacancyId);
            cmd.ExecuteNonQuery();

            db.Close();

            MessageBox.Show("Draft Saved!");
            LoadApplications();
        }

        // ================= CLICK ROW =================
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

            selectedApplicationID = Convert.ToInt32(row.Cells["ApplicationID"].Value);

            lblStatus.Text = row.Cells["CurrentStatus"].Value.ToString();

            cmbJobVacancy.SelectedValue = Convert.ToInt32(row.Cells["VacancyID"].Value);
        }

        // ================= EDIT =================
        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (selectedApplicationID == 0)
            {
                MessageBox.Show("Please select an application first!");
                return;
            }

            if (cmbJobVacancy.SelectedValue == null)
            {
                MessageBox.Show("Please select a job vacancy!");
                return;
            }

            db.Open();

            MySqlCommand cmd = new MySqlCommand(@"
                UPDATE Applications 
                SET VacancyID=@vacancy
                WHERE ApplicationID=@id", db.connection);

            cmd.Parameters.AddWithValue("@vacancy",
                Convert.ToInt32(cmbJobVacancy.SelectedValue));

            cmd.Parameters.AddWithValue("@id", selectedApplicationID);

            cmd.ExecuteNonQuery();

            db.Close();

            MessageBox.Show("Updated!");
            LoadApplications();
        }

        // ================= SUBMIT =================
        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (selectedApplicationID == 0)
            {
                MessageBox.Show("Please select an application first!");
                return;
            }

            db.Open();

            MySqlCommand cmd = new MySqlCommand(@"
                UPDATE Applications 
                SET CurrentStatus='Submitted', SubmittedAt=NOW()
                WHERE ApplicationID=@id", db.connection);

            cmd.Parameters.AddWithValue("@id", selectedApplicationID);

            cmd.ExecuteNonQuery();

            db.Close();

            MessageBox.Show("Submitted!");
            LoadApplications();
        }
    }
}