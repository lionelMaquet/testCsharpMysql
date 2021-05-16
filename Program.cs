using System;
using System.Data;
using MySql.Data.MySqlClient;
using MySqlConnector;

namespace testmysql2
{
    class Program
    {
        static void Main(string[] args)
        {
            string cs = "server=localhost;userid=root;password=;database=employees";
            using var connexion = new MySql.Data.MySqlClient.MySqlConnection(cs);

            connexion.Open();

            Console.WriteLine($"MySQL Version: {connexion.ServerVersion}");

            var stm = "SELECT * FROM salaries LIMIT 10";
            var cmd = new MySql.Data.MySqlClient.MySqlCommand(stm,connexion);

            using MySql.Data.MySqlClient.MySqlDataReader rdr = cmd.ExecuteReader();

            while(rdr.Read())
            {
                Console.WriteLine("{0} {1} {2} {3}", rdr.GetInt32(0), rdr.GetInt32(1), rdr.GetDateTime(2), rdr.GetDateTime(3));
            }
        }
    }
}
