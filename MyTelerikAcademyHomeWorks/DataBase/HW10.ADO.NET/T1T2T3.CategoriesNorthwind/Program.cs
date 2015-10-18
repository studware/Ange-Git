namespace T1T2T3.CategoriesNorthwind
{
using System;
using System.Data.SqlClient;
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Northwind Database\n");
            
            SqlConnection dbConnection = new SqlConnection("Server=.; Database = Northwind; Integrated Security=true");
            dbConnection.Open();

            using (dbConnection)
            {
                /* Write a program that retrieves from the Northwind sample database in MS SQL Server
                    * the number of rows in the Categories table. */
                CountOfCategories(dbConnection);

                /* Write a program that retrieves the name and description of all categories in the Northwind DB */
                AllCategories(dbConnection);

                /* Write a program that retrieves from the Northwind database all product categories and the names of the products in each category.
                       Can you do this with a single SQL query (with table join)? */
                ProductsByCategories(dbConnection);
            }
        }
            
        private static void ProductsByCategories(SqlConnection dbCon)
        {
            string spaces = new string(' ', 14);
            Console.WriteLine("\nProducts by categories:");
            Console.WriteLine("Category{0}Product\n", spaces);

            string sqlStringCommand = @"
            SELECT c.CategoryName, p.ProductName
            FROM Categories c
            JOIN Products p
            ON c.CategoryID=p.CategoryID
            ORDER BY c.CategoryName";

            SqlCommand cmdCategoriesProducts = new SqlCommand(sqlStringCommand, dbCon);

            SqlDataReader reader = cmdCategoriesProducts.ExecuteReader();
            using (reader)
            {
                while (reader.Read())
                {
                    string categoryName = (string)reader["CategoryName"];
                    string productName = (string)reader["ProductName"];
                    Console.WriteLine("{0,-20}  {1}", categoryName, productName);
                }
            }
        }

        private static void AllCategories(SqlConnection dbCon)
        {
            Console.WriteLine("Name and description of all categories:\n");

            string sqlStringCommand = @"
            SELECT CategoryName, Description
            FROM Categories
            ORDER BY CategoryName";

            SqlCommand cmdAllCategories = new SqlCommand(sqlStringCommand, dbCon);

            SqlDataReader reader = cmdAllCategories.ExecuteReader();
            using (reader)
            {
                while (reader.Read())
                {
                    string categoryName = (string)reader["CategoryName"];
                    string description = (string)reader["Description"];
                    Console.WriteLine("{0,-15}  {1}", categoryName, description);
                }
            }
        }

        private static void CountOfCategories(SqlConnection dbCon)
        {
            string sqlStringCommand = @"
            SELECT COUNT(*)
            FROM Categories";

            SqlCommand cmdCount = new SqlCommand(sqlStringCommand, dbCon);

            int categoriesCount = (int)cmdCount.ExecuteScalar();
            Console.WriteLine("Number of rows in the Categories table: {0} ", categoriesCount);
            Console.WriteLine();
        }
    }
}
