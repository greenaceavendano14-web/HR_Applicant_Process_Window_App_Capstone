using System;
using System.Data;
using System.IO;
using System.Text;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using HRApplicantSystem.Database;
using HRApplicantSystem.Models;

namespace HRApplicantSystem
{
    public partial class ReportsForm : Form
    {
        PrintDocument printDocument = new PrintDocument();

        public ReportsForm()
        {
            InitializeComponent();

            Load += ReportsForm_Load;

            btnApplicantReport.Click += btnApplicantReport_Click;
            btnHiringReport.Click += btnHiringReport_Click;
            btnJobReport.Click += btnJobReport_Click;
            btnAuditReport.Click += btnAuditReport_Click;

            btnSearch.Click += btnSearch_Click;
            btnRefresh.Click += btnRefresh_Click;
            btnExportPDF.Click += btnExportPDF_Click;
            btnPrint.Click += btnPrint_Click;
            btnBack.Click += btnBack_Click;

            printDocument.PrintPage += PrintDocument_PrintPage;
        }

        private void ReportsForm_Load(object sender, EventArgs e)
        {
            LoadStatistics();
            LoadApplicantReport();
        }

        private void LoadStatistics()
        {
            try
            {
                DbConnection db = new DbConnection();

                using (MySqlConnection conn = db.GetConnection())
                {
                    conn.Open();

                    string applicants =
                        "SELECT COUNT(*) FROM Applicants";

                    string applications =
                        "SELECT COUNT(*) FROM Applications";

                    string hired =
                        @"SELECT COUNT(*)
                          FROM Applications
                          WHERE CurrentStatus='Accepted'";

                    string rejected =
                        @"SELECT COUNT(*)
                          FROM Applications
                          WHERE CurrentStatus='Rejected'";

                    lblApplicantsCount.Text =
                        new MySqlCommand(applicants, conn)
                        .ExecuteScalar()
                        .ToString();

                    lblApplicationsCount.Text =
                        new MySqlCommand(applications, conn)
                        .ExecuteScalar()
                        .ToString();

                    lblHiredCount.Text =
                        new MySqlCommand(hired, conn)
                        .ExecuteScalar()
                        .ToString();

                    lblRejectedCount.Text =
                        new MySqlCommand(rejected, conn)
                        .ExecuteScalar()
                        .ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void LoadApplicantReport()
        {
            try
            {
                dgvReports.Rows.Clear();

                DbConnection db = new DbConnection();

                using (MySqlConnection conn = db.GetConnection())
                {
                    conn.Open();

                    string query = @"
                    SELECT
                        ApplicantID,
                        CONCAT(FirstName,' ',LastName) AS ApplicantName
                    FROM Applicants";

                    MySqlCommand cmd =
                        new MySqlCommand(query, conn);

                    MySqlDataReader reader =
                        cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        dgvReports.Rows.Add(
                            reader["ApplicantID"],
                            reader["ApplicantName"],
                            Session.FullName,
                            DateTime.Now.ToString("yyyy-MM-dd"),
                            "Generated"
                        );
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnApplicantReport_Click(object sender, EventArgs e)
        {
            LoadApplicantReport();
        }

        private void btnHiringReport_Click(object sender, EventArgs e)
        {
            try
            {
                dgvReports.Rows.Clear();

                DbConnection db = new DbConnection();

                using (MySqlConnection conn = db.GetConnection())
                {
                    conn.Open();

                    string query = @"
                    SELECT
                        DecisionID,
                        Decision
                    FROM HiringDecisions";

                    MySqlCommand cmd =
                        new MySqlCommand(query, conn);

                    MySqlDataReader reader =
                        cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        dgvReports.Rows.Add(
                            reader["DecisionID"],
                            "Hiring Decision - " +
                            reader["Decision"],
                            Session.FullName,
                            DateTime.Now.ToString("yyyy-MM-dd"),
                            "Generated"
                        );
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnJobReport_Click(object sender, EventArgs e)
        {
            try
            {
                dgvReports.Rows.Clear();

                DbConnection db = new DbConnection();

                using (MySqlConnection conn = db.GetConnection())
                {
                    conn.Open();

                    string query = @"
                    SELECT
                        VacancyID,
                        JobTitle
                    FROM JobVacancies";

                    MySqlCommand cmd =
                        new MySqlCommand(query, conn);

                    MySqlDataReader reader =
                        cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        dgvReports.Rows.Add(
                            reader["VacancyID"],
                            reader["JobTitle"],
                            Session.FullName,
                            DateTime.Now.ToString("yyyy-MM-dd"),
                            "Generated"
                        );
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnAuditReport_Click(object sender, EventArgs e)
        {
            try
            {
                dgvReports.Rows.Clear();

                DbConnection db = new DbConnection();

                using (MySqlConnection conn = db.GetConnection())
                {
                    conn.Open();

                    string query = @"
                    SELECT
                        AuditID,
                        Action
                    FROM AuditTrail";

                    MySqlCommand cmd =
                        new MySqlCommand(query, conn);

                    MySqlDataReader reader =
                        cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        dgvReports.Rows.Add(
                            reader["AuditID"],
                            reader["Action"],
                            Session.FullName,
                            DateTime.Now.ToString("yyyy-MM-dd"),
                            "Generated"
                        );
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string search =
                txtSearchJob.Text.Trim().ToLower();

            foreach (DataGridViewRow row in dgvReports.Rows)
            {
                if (row.IsNewRow)
                    continue;

                string report =
                    row.Cells[1].Value
                    .ToString()
                    .ToLower();

                row.Visible =
                    report.Contains(search);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtSearchJob.Clear();

            LoadStatistics();
            LoadApplicantReport();

            MessageBox.Show(
                "Reports refreshed successfully.");
        }

        private void btnExportPDF_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog save =
                    new SaveFileDialog();

                save.Filter =
                    "CSV Files (*.csv)|*.csv";

                save.FileName =
                    "Reports_" +
                    DateTime.Now.ToString(
                        "yyyyMMddHHmmss");

                if (save.ShowDialog()
                    == DialogResult.OK)
                {
                    StringBuilder sb =
                        new StringBuilder();

                    for (int i = 0;
                         i < dgvReports.Columns.Count;
                         i++)
                    {
                        sb.Append(
                            dgvReports.Columns[i]
                            .HeaderText);

                        if (i <
                            dgvReports.Columns.Count - 1)
                            sb.Append(",");
                    }

                    sb.AppendLine();

                    foreach (DataGridViewRow row
                        in dgvReports.Rows)
                    {
                        if (!row.IsNewRow)
                        {
                            for (int i = 0;
                                 i < dgvReports.Columns.Count;
                                 i++)
                            {
                                sb.Append(
                                    row.Cells[i].Value);

                                if (i <
                                    dgvReports.Columns.Count - 1)
                                    sb.Append(",");
                            }

                            sb.AppendLine();
                        }
                    }

                    File.WriteAllText(
                        save.FileName,
                        sb.ToString());

                    MessageBox.Show(
                        "Export successful.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            PrintPreviewDialog preview =
                new PrintPreviewDialog();

            preview.Document =
                printDocument;

            preview.ShowDialog();
        }

        private void PrintDocument_PrintPage(
            object sender,
            PrintPageEventArgs e)
        {
            int y = 50;

            e.Graphics.DrawString(
                "HR Applicant System Report",
                new Font("Arial", 14,
                FontStyle.Bold),
                Brushes.Black,
                50,
                y);

            y += 40;

            foreach (DataGridViewRow row
                in dgvReports.Rows)
            {
                if (row.IsNewRow)
                    continue;

                string text =
                    row.Cells[0].Value + " | " +
                    row.Cells[1].Value + " | " +
                    row.Cells[2].Value + " | " +
                    row.Cells[3].Value + " | " +
                    row.Cells[4].Value;

                e.Graphics.DrawString(
                    text,
                    new Font("Arial", 10),
                    Brushes.Black,
                    50,
                    y);

                y += 25;
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            HRDashboard dashboard =
                new HRDashboard();

            dashboard.Show();

            this.Close();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}