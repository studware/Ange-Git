using System;
using System.IO;

class FilesCompare
{
    static void Main()
    {
        string fileName1 = @"../../Readme.txt";
        string fileName2 = @"../../ReadmeSomeDiff.txt";
        string line1 = "";
        string line2="";
        int cntEqual = 0;
        int cntNotEqual = 0;
        try
        {
            StreamReader file1Reader = new StreamReader(fileName1);
            StreamReader file2Reader = new StreamReader(fileName2);

            try
            {
                while (((line1 = file1Reader.ReadLine()) != null) && (((line2 = file2Reader.ReadLine()) != null)))
                {
                    if(line1.Equals(line2))
                    {
                        cntEqual++;
                    }
                    else
                    {
                        cntNotEqual++;
                    }
                }
            }
            finally
            {
                file1Reader.Close();
                file2Reader.Close();
                Console.WriteLine("Count of equal lines: {0}",cntEqual);
                Console.WriteLine("Count of different lines: {0}",cntNotEqual);
            }
        }
        catch (System.Exception exc)
        {
            Console.WriteLine(exc.Message);
        }
    }
}

