using System;
using System.IO;
using System.Collections.Generic;

class ReadSortWrite
{
    static void SortFileByStrings(string inpFile, string resFile)
    {
        List <string> lines = new List<string>();
        string line = "";
        try
        {
            System.Text.Encoding encodingCyr = System.Text.Encoding.GetEncoding(1251);

            StreamReader streamReader = new StreamReader(inpFile, encodingCyr);

          using (streamReader)
            {
              line = streamReader.ReadLine();
              lines.Add(line);
                while (line != null)
                {
                    Console.WriteLine(line);
                    line = streamReader.ReadLine();
                    lines.Add(line);
                }
            }

            lines.Sort();

            Console.Write("\nSorted file: ");
            StreamWriter streamWriter = new StreamWriter(resFile, false, encodingCyr);
            using (streamWriter)
            {
                foreach (string lin in lines)
                {
                    streamWriter.Write(lin+"\n");
                    Console.WriteLine(lin);
                }
            }
        }
        catch (System.Exception exc)
        {
            Console.WriteLine("File input/output operation failed: {0}, ", exc.Message);
        }
    }
    
    static void Main()
    {
        Console.WriteLine("Read text file with list of strings, sort and save them to another text file");
        Console.WriteLine("Input file:");        
        string inpFile = @"../../words.txt";
        string sortedFile = @"../../sortedWords.txt";
        SortFileByStrings(inpFile, sortedFile);
    }
}

