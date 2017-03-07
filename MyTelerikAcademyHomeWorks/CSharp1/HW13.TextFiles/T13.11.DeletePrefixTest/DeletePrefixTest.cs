using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.IO;


class DeletePrefixTest
{
    static void Main()
    {
        Console.WriteLine(@"Delete from a text file all words that start with the prefix 'test'\n");

        Console.WriteLine(@"The text file is named '..\..\Readme.txt'");
        Console.WriteLine(@"(The resulting file is saved in '..\..\ReadmeResult.txt'");
        Console.WriteLine("\nPlease, open these files to see the result.");
        
        StreamReader reader = new StreamReader("../../Readme.txt");
        StreamWriter writer = new StreamWriter("../../ReadmeResult.txt");
        string line = "";

        using (reader)
        {
            using (writer)
            {
                line = reader.ReadLine();
                while (line != null)
                {
                    line = line.ToLower();
                    line = Regex.Replace(line, @"\btest\w*(\s|\S)\b", "");
                    writer.WriteLine(line);
                    line = reader.ReadLine();
                }
            }
        }
    }
}
