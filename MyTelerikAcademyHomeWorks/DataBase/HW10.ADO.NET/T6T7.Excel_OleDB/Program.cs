/* 6.Create an Excel file with 2 columns: name and score.
 * Write a program that reads your MS Excel file through the OLE DB data provider and displays the name and score row by row.
 * 7.Implement appending new rows to the Excel file.
*/

namespace T6T7.Excel_OleDB
{
    using System;
    using System.Configuration;
    using System.Data;
    using System.Data.OleDb;
    class Program
    {
        static void Main()
        {
            string connectionStringForExcel = ConfigurationManager.ConnectionStrings["ExcelExam"].ConnectionString;
            OleDbConnection dbCon = new OleDbConnection(connectionStringForExcel);
            dbCon.Open();
            using (dbCon)
            {
                Console.WriteLine("Exam Scores read from Excel Spreadsheet:\n");
                ReadExcelFile(connectionStringForExcel, dbCon);

                int result = WriteToExcelFile(connectionStringForExcel, dbCon);

                Console.WriteLine("\nAppended {0} new rows to the file ../../ExcelSpreadSheets/ExamScores.xlsx.\n", result);
                ReadExcelFile(connectionStringForExcel, dbCon);
            }
        }

        private static void ReadExcelFile(string connExcel, OleDbConnection dbCon)
        {
            var excelSchema = dbCon.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);

            var sheetName = excelSchema.Rows[0]["TABLE_NAME"].ToString();

            OleDbCommand command = new OleDbCommand("SELECT * FROM [" + sheetName + "]", dbCon);

            var reader = command.ExecuteReader();
            while (reader.Read())
            {
                var name = reader["Name"];
                var score = reader["Score"];

                Console.WriteLine("Name: {0,-20} Score: {1}", name, score);
            }
        }
       
        private static int WriteToExcelFile(string connExcel, OleDbConnection dbCon)
        {
            var excelSchema = dbCon.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);

            var sheetName = excelSchema.Rows[0]["TABLE_NAME"].ToString();

            OleDbCommand command = new OleDbCommand("INSERT INTO [" + sheetName + 
                "] VALUES(@name, @score)", dbCon);

            string name = "Evlogy Christov";
            int score = 34;
            command.Parameters.AddWithValue("@name", name);
            command.Parameters.AddWithValue("@score", score);
            int queryResult = command.ExecuteNonQuery();

            command.Parameters.Clear();
            name = "Christian Zaklev";
            score = 32;
            command.Parameters.AddWithValue("@name", name);
            command.Parameters.AddWithValue("@score", score);
            queryResult += command.ExecuteNonQuery();

            // a ready-made way to "invent" new parameters:
            for (int i = 5; i < 10; i++)
            {
                command.Parameters.Clear();
                command.Parameters.AddWithValue("@name", "Student" + i);
                command.Parameters.AddWithValue("@score", i);                
                queryResult += command.ExecuteNonQuery();
            }
            
            return queryResult;
        } 
    }
}
