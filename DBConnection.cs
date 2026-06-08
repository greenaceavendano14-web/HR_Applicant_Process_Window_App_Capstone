using MySql.Data.MySqlClient;
using System;
using System.Data;

namespace JobVacancyForm
{
    public class DBConnection
    {
        public MySqlConnection connection;

        public DBConnection()
        {
            connection = new MySqlConnection(
                "server=localhost;port=3306;database=HR_ApplicantSystem;uid=root;pwd=KylaM@e123;"
            );
        }

        // ================= OPEN CONNECTION =================
        public void Open()
        {
            try
            {
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Connection Open Failed: " + ex.Message);
            }
        }

        // ================= CLOSE CONNECTION =================
        public void Close()
        {
            try
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Connection Close Failed: " + ex.Message);
            }
        }
    }
}