using System;
using System.IO;
using System.Collections.Generic;

class SaveEvenLines
{
    static void Main()
    {
        Console.WriteLine("Delete from text file all odd lines. The result should be in the same file\n");

        Console.WriteLine(@"The text file is named '..\..\Readme.txt'");
        Console.WriteLine(@"(A copy of the original file is saved in '..\..\ReadmeOriginal.txt'");
        Console.WriteLine("\nPlease, open these files to see the result.");
        
        string filename = "..//..//Readme.txt";
        StreamReader reader = new StreamReader(filename);
        string row = reader.ReadLine();
        int count = 0;
        List<string> rows = new List<string>();
        while (row != null)
        {

            if (count % 2 == 0)
            {
                rows.Add(row);
            }
            row = reader.ReadLine();
            count++;
        }
        reader.Close();

        StreamWriter writer = new StreamWriter(filename, false);
        for (int i = 0; i < rows.Count; i++)
        {
            writer.WriteLine(rows[i]);
        }
        writer.Close();

    }
}
