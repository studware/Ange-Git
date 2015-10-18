namespace T10.SQLiteDB
{
    using System;
    using System.Data.SQLite;

    public class Program
    {
        public static void Main()
        {
            /* Download and install MySQL database, MySQL Connector/Net (.NET Data Provider for MySQL) + MySQL Workbench GUI administration tool.
             *  Create a MySQL database to store Books (title, author, publish date and ISBN).
             *  Write methods for listing all books, finding a book by name and adding a book.
             *  10. Re-implement the previous task with SQLite embedded DB (see http://sqlite.phxsoftware.com).*/

            var connectionString = @"Data Source=..\..\dataBase\Library; Version=3";

            GetBooks(connectionString);
            InsertBook(connectionString);
        }

        private static void InsertBook(string connectionString)
        {
            SQLiteConnection dbCon = new SQLiteConnection(connectionString);
            dbCon.Open();

            var command = new SQLiteCommand("INSERT INTO books(Title,Author, PublishDate, ISBN) VALUES (@title,@author,@publishDate,@isbn)", dbCon);
            command.Parameters.AddWithValue("@title", "A la Recherche du Temps Perdu");
            command.Parameters.AddWithValue("@author", "Marcel Proust");
            command.Parameters.AddWithValue("@publishDate", DateTime.Now);
            command.Parameters.AddWithValue("@isbn", "6868-123-45");

            command.ExecuteNonQuery();
        }

        private static void GetBooks(string connectionString)
        {
            SQLiteConnection dbCon = new SQLiteConnection(connectionString);
            dbCon.Open();

            SQLiteCommand command = new SQLiteCommand("SELECT * FROM Books", dbCon);
            var reader = command.ExecuteReader();

            while (reader.Read())
            {
                Console.WriteLine("Title: {0}, Author: {1} ISBN: {2}, published on: {3}",
                       reader["Title"], reader["Author"], reader["ISBN"], ((DateTime)reader["PublishDate"]));
            }
        }
    }
}

