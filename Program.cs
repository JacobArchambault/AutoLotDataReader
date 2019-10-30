using System;
using System.Data;
using System.Data.SqlClient;
using static System.Console;
namespace AutoLotDataReader
{
    class Program
    {
        static void Main(string[] args)
        {
            WriteLine("***** Fun with Data Readers *****\n");


            // Create and open a connection.
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString =
                    @"Data Source=(localdb)\mssqllocaldb;Integrated Security=true;Initial Catalog=AutoLot;Connect Timeout=30";
                connection.Open();

                ShowConnectionStatus(connection);

                // Create a SQL command object.
                string sql = "Select * From Inventory";
                SqlCommand myCommand = new SqlCommand(sql, connection);

                // Obtain a data reader a la ExecuteReader().
                using (SqlDataReader myDataReader = myCommand.ExecuteReader())
                {
                    // Loop over the results.
                    while (myDataReader.Read())
                    {
                        WriteLine($"-> Make: {myDataReader["Make"]}, PetName: {myDataReader["PetName"]}, Color: {myDataReader["Color"]}.");
                    }
                }
            }

            ReadLine();
        }

        static void ShowConnectionStatus (SqlConnection connection)
        {
            // Show various stats about current connection object.
            WriteLine("***** Info about your connection *****");
            WriteLine($"Database location: {connection.DataSource}");
            WriteLine($"Database name: {connection.Database}");
            WriteLine($"Timeout: {connection.ConnectionTimeout}");
            WriteLine($"Connection state: {connection.State}\n");
        }
    }
}
