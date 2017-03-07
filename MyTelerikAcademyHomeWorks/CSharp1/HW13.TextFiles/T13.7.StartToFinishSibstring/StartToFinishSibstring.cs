using System;
using System.IO;

class StartToFinishSibstring
{
    static void Main()
    {
        Console.WriteLine("Replace all substrings 'start' with 'finish' in a text file\n");

        Console.WriteLine(@"The input file is named '..\..\License.txt'");
        Console.WriteLine(@"The result file is named '..\..\LicenseNew.txt'");
        Console.WriteLine("\nPlease, open these files to see the result.");

        string fileName=@"..\..\License.txt";
        string fileNameN=@"..\..\LicenseNew.txt";
        try
        {
            // Getting Cyrillic encoding 
            System.Text.Encoding encoding = System.Text.Encoding.GetEncoding(1251);

            // Create reader with the Cyrillic encoding
            StreamReader streamReader = new StreamReader(fileName, encoding);
            // Create writer with the Cyrillic encoding
            StreamWriter streamWriter = new StreamWriter(fileNameN, false, encoding);
            try
            {
                string line = "";
                while ((line = streamReader.ReadLine()) != null)
                {
                    streamWriter.WriteLine(SubstLine(line));
                }
            }
            finally
            {
                streamReader.Close();
                streamWriter.Close();
            }
        }
        catch (System.Exception exc)
        {
            Console.WriteLine(exc.Message);
        }
    }

    static string SubstLine(string line)
    {
        string fixedLine = "";
        if (line == "")
        {
            return fixedLine;
        }
        int startIndex = line.IndexOf("start");
        if (startIndex == -1)
        {
            fixedLine = line;
        }
        else
        {
            while (startIndex != -1)
            {
                int next = startIndex + 5;
                if (startIndex != 0 && startIndex < line.Length - 5)
                    {
                        fixedLine = line.Substring(0,startIndex - 1) + "finish" + line.Substring(next);
                    }
                else if (startIndex == 0)
                    {
                        fixedLine = "finish" + line.Substring(next);
                    }
                else if ( startIndex == line.Length - 5)
                    {
                        fixedLine =  line.Substring(0,startIndex)+"finish";
                    }
                startIndex = line.Substring(next).IndexOf("start");
            }
        }
        return fixedLine;
    }
}