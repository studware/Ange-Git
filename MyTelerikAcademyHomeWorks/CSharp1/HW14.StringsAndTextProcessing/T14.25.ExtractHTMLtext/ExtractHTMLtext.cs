using System;
using System.IO;
using System.Text.RegularExpressions;

class ExtractHTMLtext
{
    static void Main()
    {
        Console.WriteLine("Extract from HTML file its title (if available),\nand its body text without the HTML tags\n");

        Console.WriteLine(@"The original text file is named '..\..\test.htm'");

        Console.WriteLine("\nPlease, open this file to check the result.");

        StreamReader reader = new StreamReader(@"..\..\test.htm");
        using (reader)
        {
            string record = "";
            MatchCollection matches = Regex.Matches(record, @"(?<=^|>)[^><]+?(?=<|$)");
            while ((record = reader.ReadLine()) != null)
            {
                matches = Regex.Matches(record, @"(?<=^|>)[^><]+?(?=<|$)");

                foreach (var item in matches)
                {
                    Console.WriteLine(item);
                }
            }
        }
        Console.WriteLine();
    }
}