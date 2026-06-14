using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Data.SqlClient;

namespace HRSystem
{
    public class DBConnection
    {
        private MySqlConnection conn;

        // 🔧 CHANGE THIS if your password/database differs
        private string connectionString =
            "server=localhost;port=3306;database=HR_ApplicantSystem;uid=root;pwd=KylaM@e123;";

        // ================= OPEN CONNECTION =================
        public void OpenConnection()
        {
            try
            {
                if (conn == null)
                {
                    conn = new MySqlConnection(connectionString);
                }

                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Database connection failed: " + ex.Message);
            }
        }

        // ================= GET CONNECTION =================
        public MySqlConnection GetConnection()
        {
            return conn;
        }

        // ================= CLOSE CONNECTION =================
        public void CloseConnection()
        {
            try
            {
                if (conn != null && conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error closing connection: " + ex.Message);
            }
        }
    }
}