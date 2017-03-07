using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Security;

class RemoveWordsFromFile
{
    static void Main()
    {
        Console.WriteLine(@"Remove from a text file all words listed in given another text file\n");

        Console.WriteLine(@"The input file is named '..\..\input.txt'");
        Console.WriteLine(@"(The resulting file is saved in '..\..\result.txt'");
        Console.WriteLine(@"(The words file is saved in '..\..\words.txt'");
        Console.WriteLine("\nPlease, open these files to see the result.");

        try
        {
            string regex = @"\b(" + String.Join("|", File.ReadAllLines("../../words.txt")) + @")\b";

            using (StreamReader input = new StreamReader("../../input.txt"))
            using (StreamWriter output = new StreamWriter("../../result.txt"))
                for (string line; (line = input.ReadLine()) != null; )
                    output.WriteLine(Regex.Replace(line, regex, String.Empty));
        }

        catch (FileNotFoundException e)
        {
            Console.WriteLine(e.Message);
        }

        catch (DirectoryNotFoundException e)
        {
            Console.WriteLine(e.Message);
        }

        catch (IOException e)
        {
            Console.WriteLine(e.Message);
        }

        catch (SecurityException e)
        {
            Console.WriteLine(e.Message);
        }

        catch (UnauthorizedAccessException e)
        {
            Console.WriteLine(e.Message);
        }
    }
}