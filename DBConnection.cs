using MySql.Data.MySqlClient;
using System;
using System.Data;

namespace HRSystem
{
    public class DBConnection
    {
        private MySqlConnection conn;

        public DBConnection()
        {
            conn = new MySqlConnection(
                "server=localhost;port=3306;database=hr_db;uid=root;pwd=KylaM@e123;"
            );
        }

        public void Open()
        {
            if (conn.State == ConnectionState.Closed)
                conn.Open();
        }

        public void Close()
        {
            if (conn.State == ConnectionState.Open)
                conn.Close();
        }

        public MySqlConnection GetConnection()
        {
            return conn;
        }
    }
}