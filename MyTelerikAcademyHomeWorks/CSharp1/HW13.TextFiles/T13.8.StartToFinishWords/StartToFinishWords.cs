using System;
using System.IO;
using System.Text.RegularExpressions;

class StartToFinishWords
{
    static void Main()
    {
        Console.WriteLine("Replace all substrings 'start' with 'finish' in a text file\n");

        Console.WriteLine(@"The input file is named '..\..\License.txt'");
        Console.WriteLine(@"The result file is named '..\..\LicenseNew.txt'");
        Console.WriteLine("\nPlease, open these files to see the result.");
        
        using (StreamReader reader = new StreamReader(@"..\..\License.txt"))
        {
            using (StreamWriter writer = new StreamWriter(@"..\..\LicenseNew.txt"))
            {
                string pattern = @"\b(start)\b";
                Regex regex = new Regex(pattern);

                for (string line = reader.ReadLine(); line != null; line = reader.ReadLine())
                {
                    string newLine = regex.Replace(line, "finish");
                    writer.WriteLine(newLine);
                }
            }
        }
    }
}
