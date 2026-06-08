using MySql.Data.MySqlClient;
using System;

namespace ApplicationForm
{
    public class DBConnection
    {
        private MySqlConnection conn;

        public DBConnection()
        {
            conn = new MySqlConnection(
                "server=localhost;database=HR_ApplicantSystem;uid=root;pwd=KylaM@e123;"
            );
        }

        public void OpenConnection()
        {
            if (conn.State == System.Data.ConnectionState.Closed)
                conn.Open();
        }

        public void CloseConnection()
        {
            if (conn.State == System.Data.ConnectionState.Open)
                conn.Close();
        }

        public MySqlConnection GetConnection()
        {
            return conn;
        }
    }
}