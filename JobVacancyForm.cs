using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace HRSystem
{
    public partial class JobVacancyForm : Form
    {
        DBConnection db = new DBConnection();
        int selectedJobId = 0;

        public JobVacancyForm()
        {
            InitializeComponent();
            this.Load += JobVacancyForm_Load;
        }

        private void JobVacancyForm_Load(object sender, EventArgs e)
        {
            cmbStatus.Items.Clear();
            cmbStatus.Items.Add("Open");
            cmbStatus.Items.Add("Closed");

            LoadJobs();
        }

        private void LoadJobs()
        {
            try
            {
                db.Open();

                string query = "SELECT * FROM jobs";

                MySqlDataAdapter adapter =
                    new MySqlDataAdapter(query, db.GetConnection());

                DataTable dt = new DataTable();
                adapter.Fill(dt);

                dgvJobs.DataSource = dt;

                db.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Load Error: " + ex.Message);
            }
        }
    }
}