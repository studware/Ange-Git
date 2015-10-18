/* Write a method that adds a new product in the products table in the Northwind database.
    Use a parameterized SQL command. */
namespace T4.AddNewProduct
{
    using System;
    using System.Configuration;
    using System.Data.SqlClient;
    class Program
    {
        private static SqlConnection dbConnection;
        static void Main()
        {
            var dbConnectionString = ConfigurationManager.ConnectionStrings["SQLDB"];
            dbConnection = new SqlConnection(dbConnectionString.ConnectionString);
            dbConnection.Open();

            using (dbConnection)
            {
                SqlCommand cmdInsertProduct = new SqlCommand(
                    @"INSERT INTO Products 
                    (ProductName, SupplierID, CategoryID, QuantityPerUnit, UnitPrice, UnitsInStock, UnitsOnOrder, ReorderLevel, Discontinued)
                    VALUES
                    (@name,@supplierId,@categoryId,@quantityPerUnit,@unitPrice,@unitInStock,@unitsOnOrder,@reorderLevel,@discontinued)", dbConnection);

                cmdInsertProduct.Parameters.AddWithValue("@name", "Mustard");
                cmdInsertProduct.Parameters.AddWithValue("@supplierId", 12);
                cmdInsertProduct.Parameters.AddWithValue("@categoryId", 2);
                cmdInsertProduct.Parameters.AddWithValue("@quantityPerUnit", "16 jars");
                cmdInsertProduct.Parameters.AddWithValue("@unitPrice", 2.55);
                cmdInsertProduct.Parameters.AddWithValue("@unitInStock", 2000);
                cmdInsertProduct.Parameters.AddWithValue("@unitsOnOrder", 100);
                int? reorderLevel = 10;
                //                int? reorderLevel = null;
                SqlParameter sqlParamReorderLevel = new SqlParameter("@reorderLevel", reorderLevel);
                if (reorderLevel == null)
                {
                    sqlParamReorderLevel.Value = DBNull.Value;
                }
                cmdInsertProduct.Parameters.Add(sqlParamReorderLevel);
                //               command.Parameters.AddWithValue("@recordLevel", 12);
                cmdInsertProduct.Parameters.AddWithValue("@discontinued", 0);

                cmdInsertProduct.ExecuteNonQuery();

                SqlCommand cmdSelectIdentity = new SqlCommand("SELECT @@Identity", dbConnection);
                int insertedRecordId = (int)(decimal)cmdSelectIdentity.ExecuteScalar();

                Console.WriteLine("Inserted new product. ProductID = {0}", insertedRecordId);
            }
        }
    }
}

