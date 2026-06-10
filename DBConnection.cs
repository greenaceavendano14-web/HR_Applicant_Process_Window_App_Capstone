using MySql.Data.MySqlClient;
using System.Data;

namespace HRInterviewEvaluationForm
{
    public class DBConnection
    {
        private MySqlConnection conn;

        // 🔥 CHANGE ONLY THIS IF YOUR PASSWORD OR DB CHANGES
        private string connectionString =
            "server=localhost;port=3306;database=HR_ApplicantSystem;uid=root;pwd=KylaM@e123;";

        // ================= OPEN CONNECTION =================
        public void OpenConnection()
        {
            if (conn == null)
                conn = new MySqlConnection(connectionString);

            if (conn.State == ConnectionState.Closed)
                conn.Open();
        }

        // ================= CLOSE CONNECTION =================
        public void CloseConnection()
        {
            if (conn != null && conn.State == ConnectionState.Open)
                conn.Close();
        }

        // ================= GET CONNECTION =================
        public MySqlConnection GetConnection()
        {
            return conn;
        }
    }
}