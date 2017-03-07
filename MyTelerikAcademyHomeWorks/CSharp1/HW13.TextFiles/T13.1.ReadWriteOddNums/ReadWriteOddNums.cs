using System;
using System.IO;

class ReadWriteOddNums
{
    static void Main()
    {
        Console.WriteLine("Read a text file and print its odd lines");
        string fileName=@"../../License.txt";
        try
        {
            StreamReader reader = new StreamReader(fileName);
            using (reader)
            {
                int lineNumber = 0;
                string line="";
                line = reader.ReadLine(); 
                while (line != null)
                {
                    lineNumber++;
                    if (lineNumber % 2 != 0)
                    {
                        Console.WriteLine("Line {0}: {1}", lineNumber, line);
                    }
                    line = reader.ReadLine();
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error Reading file {0}: {1}", fileName,ex.Message); 
        }   
        finally
            {
                Console.WriteLine("Only lines with odd line numbers are printed.");
            }
    }
}