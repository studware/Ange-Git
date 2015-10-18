/* Write a program that reads a string from the console and finds all products that contain this string.
 * Ensure you handle correctly characters like ', %, ", \ and _ */
namespace T8.FilterByInputString
{
using System;
using System.Data.SqlClient;
    class Program
    {
        static void Main()  
        {
            Console.Write("Please enter a search pattern: ");
            var pattern = Console.ReadLine();

            FindProductByGivenPattern(pattern);
        }

        private static void FindProductByGivenPattern(string pattern)
        {
            SqlConnection dbConnection = new SqlConnection("Server=.; Database = Northwind; Integrated Security=true");
            dbConnection.Open();
            using (dbConnection)
            {
                var cmd = GetSearchByPatternSqlCommand(dbConnection, pattern);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var productName = reader["ProductName"];
                        Console.WriteLine(" - " + productName);
                    }
                }
            }
        }

        private static SqlCommand GetSearchByPatternSqlCommand(SqlConnection sqlConnection, string pattern)
        {
            // There's no need to escape the characters like ', %, ", \ and _ if you use CHARINDEX().
            var cmd = new SqlCommand(@"SELECT ProductName
                                                     FROM Products
                                                     WHERE CHARINDEX(@pattern, ProductName) > 0", sqlConnection);
            cmd.Parameters.AddWithValue("@pattern", pattern);
            return cmd;
        }
    }
}
