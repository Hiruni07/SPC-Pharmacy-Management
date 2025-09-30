using System;
using MySql.Data.MySqlClient;
using System.Configuration;

namespace SPCPharmacyManagement
{
    public class DatabaseConnection
    {
        private static string connectionString = "Server=localhost;Database=spc_pharmacy_db;Uid=root;Pwd=;";

        public static MySqlConnection GetConnection()
        {
            return new MySqlConnection(connectionString);
        }

        public static bool TestConnection()
        {
            try
            {
                using (var connection = GetConnection())
                {
                    connection.Open();
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
