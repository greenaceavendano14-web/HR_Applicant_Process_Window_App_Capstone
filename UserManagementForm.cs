using HRApplicantSystem.Database;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace HRApplicantSystem
{
    public partial class UserManagementForm : Form
    {
        DbConnection db = new DbConnection();
        int selectedUserID = 0;

        public UserManagementForm()
        {
            InitializeComponent();

            Load += UserManagementForm_Load;

            btnAddUser.Click += btnAddUser_Click;
            btnEditUser.Click += btnEditUser_Click;
            btnDeactivateUser.Click += btnDeactivateUser_Click;
            btnResetPassword.Click += btnResetPassword_Click;
            btnSearch.Click += btnSearch_Click;

            dgvUsers.CellClick += dgvUsers_CellClick;
        }


        private void UserManagementForm_Load(object sender, EventArgs e)
        {
            LoadRoles();
            LoadUsers();
            LoadCounts();
        }

        private void LoadRoles()
        {
            cmbRole.Items.Clear();

            cmbRole.Items.Add("Admin");
            cmbRole.Items.Add("HR Manager");
            cmbRole.Items.Add("HR Staff");
        }


        private void LoadUsers()
        {
            try
            {
                using (var conn = db.GetConnection())
                {
                    conn.Open();

                    string query = @"
                    SELECT 
                        u.UserID,
                        CONCAT(u.FirstName,' ',u.LastName) AS FullName,
                        u.Email,
                        r.RoleName,
                        CASE WHEN u.IsActive = 1 THEN 'Active' ELSE 'Inactive' END AS Status
                    FROM Users u
                    INNER JOIN Roles r ON u.RoleID = r.RoleID";

                    MySqlDataAdapter da = new MySqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dgvUsers.Rows.Clear();

                    foreach (DataRow row in dt.Rows)
                    {
                        dgvUsers.Rows.Add(
                            row["UserID"],
                            row["FullName"],
                            row["Email"],
                            row["RoleName"],
                            row["Status"]
                        );
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Load Users Error: " + ex.Message);
            }
        }


        private void LoadCounts()
        {
            try
            {
                using (var conn = db.GetConnection())
                {
                    conn.Open();

                    string query = @"
                    SELECT 
                        SUM(CASE WHEN r.RoleName='Admin' THEN 1 ELSE 0 END) AS AdminCount,
                        SUM(CASE WHEN r.RoleName='HR Manager' THEN 1 ELSE 0 END) AS ManagerCount,
                        SUM(CASE WHEN r.RoleName='HR Staff' THEN 1 ELSE 0 END) AS StaffCount
                    FROM Users u
                    INNER JOIN Roles r ON u.RoleID = r.RoleID";

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    MySqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        lblAdmiCount.Text = reader["AdminCount"].ToString();
                        lblHRManagersCount.Text = reader["ManagerCount"].ToString();
                        lblHRStaffCount.Text = reader["StaffCount"].ToString();
                    }
                }
            }
            catch { }
        }


        private void dgvUsers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow row = dgvUsers.Rows[e.RowIndex];

            selectedUserID = Convert.ToInt32(row.Cells["colUserId"].Value);
            txtFullName.Text = row.Cells["colFullName"].Value.ToString();
            textBox1.Text = row.Cells["colEmail"].Value.ToString();
            cmbRole.Text = row.Cells["colRole"].Value.ToString();
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            try
            {
                string[] name = txtFullName.Text.Trim().Split(' ');
                string first = name[0];
                string last = name.Length > 1 ? name[name.Length - 1] : "";

                int roleID = GetRoleID(cmbRole.Text);

                using (var conn = db.GetConnection())
                {
                    conn.Open();

                    string query = @"
                    INSERT INTO Users (RoleID, FirstName, LastName, Email, PasswordHash)
                    VALUES (@role, @first, @last, @email, SHA2(@pass,256))";

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@role", roleID);
                    cmd.Parameters.AddWithValue("@first", first);
                    cmd.Parameters.AddWithValue("@last", last);
                    cmd.Parameters.AddWithValue("@email", textBox1.Text);
                    cmd.Parameters.AddWithValue("@pass", textBox2.Text);

                    cmd.ExecuteNonQuery();
                }

                InsertAudit("Admin", 1, "ADD_USER", "Users", selectedUserID, "User created");

                LoadUsers();
                LoadCounts();
                MessageBox.Show("User Added!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void btnEditUser_Click(object sender, EventArgs e)
        {
            try
            {
                if (selectedUserID == 0) return;

                string[] name = txtFullName.Text.Trim().Split(' ');
                string first = name[0];
                string last = name.Length > 1 ? name[name.Length - 1] : "";

                int roleID = GetRoleID(cmbRole.Text);

                using (var conn = db.GetConnection())
                {
                    conn.Open();

                    string query = @"
                    UPDATE Users
                    SET FirstName=@first,
                        LastName=@last,
                        Email=@email,
                        RoleID=@role
                    WHERE UserID=@id";

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@first", first);
                    cmd.Parameters.AddWithValue("@last", last);
                    cmd.Parameters.AddWithValue("@email", textBox1.Text);
                    cmd.Parameters.AddWithValue("@role", roleID);
                    cmd.Parameters.AddWithValue("@id", selectedUserID);

                    cmd.ExecuteNonQuery();
                }

                InsertAudit("Admin", 1, "EDIT_USER", "Users", selectedUserID, "User updated");

                LoadUsers();
                LoadCounts();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void btnDeactivateUser_Click(object sender, EventArgs e)
        {
            try
            {
                using (var conn = db.GetConnection())
                {
                    conn.Open();

                    string query = "UPDATE Users SET IsActive=0 WHERE UserID=@id";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@id", selectedUserID);
                    cmd.ExecuteNonQuery();
                }

                InsertAudit("Admin", 1, "DEACTIVATE_USER", "Users", selectedUserID, "User deactivated");

                LoadUsers();
                LoadCounts();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void btnResetPassword_Click(object sender, EventArgs e)
        {
            try
            {
                using (var conn = db.GetConnection())
                {
                    conn.Open();

                    string query = "UPDATE Users SET PasswordHash = SHA2('123456',256) WHERE UserID=@id";

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@id", selectedUserID);
                    cmd.ExecuteNonQuery();
                }

                InsertAudit("Admin", 1, "RESET_PASSWORD", "Users", selectedUserID, "Password reset");

                MessageBox.Show("Password Reset!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void btnSearch_Click(object sender, EventArgs e)
        {
            string search = txtSearchUser.Text;

            try
            {
                using (var conn = db.GetConnection())
                {
                    conn.Open();

                    string query = @"
                    SELECT 
                        u.UserID,
                        CONCAT(u.FirstName,' ',u.LastName) AS FullName,
                        u.Email,
                        r.RoleName,
                        CASE WHEN u.IsActive = 1 THEN 'Active' ELSE 'Inactive' END AS Status
                    FROM Users u
                    INNER JOIN Roles r ON u.RoleID = r.RoleID
                    WHERE CONCAT(u.FirstName,' ',u.LastName) LIKE @search
                    OR u.Email LIKE @search";

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@search", "%" + search + "%");

                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dgvUsers.Rows.Clear();

                    foreach (DataRow row in dt.Rows)
                    {
                        dgvUsers.Rows.Add(
                            row["UserID"],
                            row["FullName"],
                            row["Email"],
                            row["RoleName"],
                            row["Status"]
                        );
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private int GetRoleID(string role)
        {
            if (role == "Admin") return 1;
            if (role == "HR Manager") return 2;
            return 3;
        }

       
        private void InsertAudit(string actorType, int actorID, string action, string table, int targetID, string details)
        {
            try
            {
                using (var conn = db.GetConnection())
                {
                    conn.Open();

                    string query = @"
                    INSERT INTO AuditTrail
                    (ActorType, ActorID, Action, TargetTable, TargetID, Details)
                    VALUES (@type,@id,@action,@table,@target,@details)";

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@type", actorType);
                    cmd.Parameters.AddWithValue("@id", actorID);
                    cmd.Parameters.AddWithValue("@action", action);
                    cmd.Parameters.AddWithValue("@table", table);
                    cmd.Parameters.AddWithValue("@target", targetID);
                    cmd.Parameters.AddWithValue("@details", details);

                    cmd.ExecuteNonQuery();
                }
            }
            catch { }
        }
    }
}