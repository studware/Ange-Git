using System;
using System.IO;

class NumbersOfLines
{
    static void Main()
    {
        string fileName1 = @"../../Readme.txt";
        string fileName2 = @"../../ReadmeWithNumbers.txt";
        string line = "";
        int lineNum = 0;
        try
        {
            System.Text.Encoding encodingCyr = System.Text.Encoding.GetEncoding(1251);

            StreamReader streamReader = new StreamReader(fileName1, encodingCyr);

            StreamWriter streamWriter = new StreamWriter(fileName2,false, encodingCyr);
            try
            {
                while ((line = streamReader.ReadLine()) != null)
                {
                    lineNum++;
                    line = String.Format("{0,3}.{1}", lineNum,line);
                    streamWriter.WriteLine(line, true,encodingCyr);
                    Console.WriteLine(line);
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
        Console.WriteLine("\nHello, I was made of the Readme.txt file with line numbers added.");
    }
}

