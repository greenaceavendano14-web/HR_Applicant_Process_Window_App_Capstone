using MySql.Data.MySqlClient;
using System;
using System.Data;

namespace HRApplicationFormView
{
    public class DBConnection
    {
        private readonly string connectionString =
            "server=localhost;port=3306;database=HR_ApplicantSystem;uid=root;pwd=KylaM@e123;";

        private MySqlConnection conn;

        public DBConnection()
        {
            conn = new MySqlConnection(connectionString);
        }

        // ================= OPEN =================
        public void OpenConnection()
        {
            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("DB Open Error: " + ex.Message);
            }
        }

        // ================= GET CONNECTION =================
        public MySqlConnection GetConnection()
        {
            return conn;
        }

        // ================= CLOSE =================
        public void CloseConnection()
        {
            try
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("DB Close Error: " + ex.Message);
            }
        }
    }
}