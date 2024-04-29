using System;
using MySql.Data.MySqlClient;

namespace MySqlConnectionTest
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString;
            if (args.Length != 0)
            {
                connectionString = args[0];
            }
            else{
                Console.WriteLine("Using default connection string use --connection-string tag for custom connection string.");
                connectionString = "server=localhost;user=root;password=hehe;database=testdb";
            }
            try
            {
                using (var connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    Console.WriteLine("MySQL connection successful.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"MySQL connection failed: {ex.Message}");
            }
        }
    }
}
