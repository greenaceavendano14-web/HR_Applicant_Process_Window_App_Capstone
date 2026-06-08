using MySql.Data.MySqlClient;
using System.Data;

namespace ApplicationForm
{
    public class DBConnection
    {
        private MySqlConnection conn;

        private string connectionString =
            "server=localhost;port=3306;database=HR_ApplicantSystem;uid=root;pwd=KylaM@e123;";

        public void OpenConnection()
        {
            if (conn == null)
                conn = new MySqlConnection(connectionString);

            if (conn.State == ConnectionState.Closed)
                conn.Open();
        }

        public MySqlConnection GetConnection()
        {
            return conn;
        }

        public void CloseConnection()
        {
            if (conn != null && conn.State == ConnectionState.Open)
                conn.Close();
        }
    }
}