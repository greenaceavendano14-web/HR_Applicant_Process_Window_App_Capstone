using MySql.Data.MySqlClient;

namespace HRApplicantSystem.Database
{
    public class DbConnection
    {
        private string connString =
            "server=localhost;user=root;password=ace101407;database=HR_ApplicantSystem;";

        public MySqlConnection GetConnection()
        {
            return new MySqlConnection(connString);
        }
    }
}