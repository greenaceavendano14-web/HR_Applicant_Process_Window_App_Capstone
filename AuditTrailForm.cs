using System;
using System.Data;
using System.Windows.Forms;
using System.IO;
using System.Text;
using MySql.Data.MySqlClient;
using HRApplicantSystem.Database;
using HRApplicantSystem.Models;

namespace HRApplicantSystem
{
    public partial class AuditTrailForm : Form
    {
        public AuditTrailForm()
        {
            InitializeComponent();
            Load += AuditTrailForm_Load;
        }

        private void AuditTrailForm_Load(object sender, EventArgs e)
        {
            if (Session.RoleName == Roles.HRStaff)
            {
                MessageBox.Show(
                    "You are not authorized to access Audit Trail.",
                    "Access Denied",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                this.Close();
                return;
            }

            LoadAuditTrail();
            LoadStatistics();

            dgvAuditTrail.ReadOnly = true;
            dgvAuditTrail.AllowUserToAddRows = false;
            dgvAuditTrail.AllowUserToDeleteRows = false;
            dgvAuditTrail.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;

            dgvAuditTrail.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;

            if (Session.RoleName != Roles.Admin)
            {
                btnExportLog.Enabled = false;
            }

            SaveAuditLog(
                "VIEW_AUDIT_TRAIL",
                "AuditTrail",
                0,
                Session.FullName + " viewed Audit Trail.");
        }

        private void SaveAuditLog(
    string action,
    string targetTable,
    int targetId,
    string details)
        {
            try
            {
                DbConnection db = new DbConnection();

                using (MySqlConnection conn = db.GetConnection())
                {
                    conn.Open();

                    string query = @"
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
                @ActorType,
                @ActorID,
                @Action,
                @TargetTable,
                @TargetID,
                @Details
            )";

                    MySqlCommand cmd = new MySqlCommand(query, conn);

                    cmd.Parameters.AddWithValue("@ActorType", Session.RoleName);
                    cmd.Parameters.AddWithValue("@ActorID", Session.UserID);
                    cmd.Parameters.AddWithValue("@Action", action);
                    cmd.Parameters.AddWithValue("@TargetTable", targetTable);
                    cmd.Parameters.AddWithValue("@TargetID", targetId);
                    cmd.Parameters.AddWithValue("@Details", details);

                    cmd.ExecuteNonQuery();
                }
            }
            catch
            {
            }
        }


        private void LoadAuditTrail()
        {
            try
            {
                DbConnection db = new DbConnection();

                using (MySqlConnection conn = db.GetConnection())
                {
                    conn.Open();

                    string query = @"
                        SELECT 
                            AuditID,
                            ActorID,
                            ActorType,
                            Action,
                            TargetTable,
                            TargetID,
                            Details,
                            CreatedAt
                        FROM AuditTrail
                        ORDER BY CreatedAt DESC";

                    MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                    DataTable table = new DataTable();
                    adapter.Fill(table);

                    dgvAuditTrail.Rows.Clear();

                    foreach (DataRow row in table.Rows)
                    {
                        dgvAuditTrail.Rows.Add(
                            row["AuditID"],
                            row["ActorID"],
                            row["ActorType"],
                            row["Action"],
                            row["TargetTable"],
                            row["TargetID"],
                            row["CreatedAt"],
                            row["Details"]
                        );
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error loading audit trail:\n" + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void LoadStatistics()
        {
            try
            {
                DbConnection db = new DbConnection();

                using (MySqlConnection conn = db.GetConnection())
                {
                    conn.Open();

                    string totalQuery = @"
                        SELECT COUNT(*) 
                        FROM AuditTrail 
                        WHERE DATE(CreatedAt) = CURDATE()";

                    MySqlCommand totalCmd = new MySqlCommand(totalQuery, conn);
                    lblActivitiesCount.Text = totalCmd.ExecuteScalar().ToString();

                    string approvedQuery = @"
                        SELECT COUNT(*) 
                        FROM AuditTrail
                        WHERE Action = 'STATUS_CHANGE'
                        AND Details LIKE '%Accepted%'";

                    MySqlCommand approvedCmd = new MySqlCommand(approvedQuery, conn);
                    lblApprovalCount.Text = approvedCmd.ExecuteScalar().ToString();

                    string rejectedQuery = @"
                        SELECT COUNT(*) 
                        FROM AuditTrail
                        WHERE Action = 'STATUS_CHANGE'
                        AND Details LIKE '%Rejected%'";

                    MySqlCommand rejectedCmd = new MySqlCommand(rejectedQuery, conn);
                    lblRejectionsCount.Text = rejectedCmd.ExecuteScalar().ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error loading statistics:\n" + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }


        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                DbConnection db = new DbConnection();

                using (MySqlConnection conn = db.GetConnection())
                {
                    conn.Open();

                    string query = @"
                        SELECT 
                            AuditID,
                            ActorID,
                            ActorType,
                            Action,
                            TargetTable,
                            TargetID,
                            Details,
                            CreatedAt
                        FROM AuditTrail
                        WHERE Action LIKE @search
                           OR ActorType LIKE @search
                           OR Details LIKE @search
                        ORDER BY CreatedAt DESC";

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@search", "%" + txtSearchAudit.Text.Trim() + "%");

                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    DataTable table = new DataTable();
                    adapter.Fill(table);

                    dgvAuditTrail.Rows.Clear();

                    foreach (DataRow row in table.Rows)
                    {
                        dgvAuditTrail.Rows.Add(
                            row["AuditID"],
                            row["ActorID"],
                            row["ActorType"],
                            row["Action"],
                            row["TargetTable"],
                            row["TargetID"],
                            row["CreatedAt"],
                            row["Details"]
                        );
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Search failed:\n" + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtSearchAudit.Clear();
            LoadAuditTrail();
            LoadStatistics();
        }

        private void btnViewDetails_Click(object sender, EventArgs e)
        {
            if (dgvAuditTrail.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a log.");
                return;
            }

            DataGridViewRow row = dgvAuditTrail.SelectedRows[0];

            string details =
                "Audit ID: " + row.Cells[0].Value + "\n" +
                "Actor ID: " + row.Cells[1].Value + "\n" +
                "Actor Type: " + row.Cells[2].Value + "\n" +
                "Action: " + row.Cells[3].Value + "\n" +
                "Table: " + row.Cells[4].Value + "\n" +
                "Target ID: " + row.Cells[5].Value + "\n" +
                "Date: " + row.Cells[6].Value + "\n\n" +
                "Details:\n" + row.Cells[7].Value;

            MessageBox.Show(
                details,
                "Audit Trail Details",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }


        private void btnExportLog_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();

                saveFileDialog.Filter = "CSV Files (*.csv)|*.csv";
                saveFileDialog.FileName =
                    "AuditTrail_" +
                    DateTime.Now.ToString("yyyyMMdd_HHmmss");

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    System.Text.StringBuilder sb =
                        new System.Text.StringBuilder();

                    for (int i = 0; i < dgvAuditTrail.Columns.Count; i++)
                    {
                        sb.Append(
                            dgvAuditTrail.Columns[i].HeaderText);

                        if (i < dgvAuditTrail.Columns.Count - 1)
                            sb.Append(",");
                    }

                    sb.AppendLine();

                    foreach (DataGridViewRow row in dgvAuditTrail.Rows)
                    {
                        if (!row.IsNewRow)
                        {
                            for (int i = 0; i < dgvAuditTrail.Columns.Count; i++)
                            {
                                sb.Append(row.Cells[i].Value);

                                if (i < dgvAuditTrail.Columns.Count - 1)
                                    sb.Append(",");
                            }

                            sb.AppendLine();
                        }
                    }

                    System.IO.File.WriteAllText(
                        saveFileDialog.FileName,
                        sb.ToString());

                    MessageBox.Show(
                        "Audit Trail exported successfully.",
                        "Success",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    SaveAuditLog(
                        "EXPORT_AUDIT_TRAIL",
                        "AuditTrail",
                        0,
                        Session.FullName +
                        " exported Audit Trail.");

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Export Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }


        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}