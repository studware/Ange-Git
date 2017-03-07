using System;
using System.IO;

class Concat2files
{
    static void MoveFile(string inpFile,string resFile)
    {
        string fileContents = "";
        try
            {
                StreamReader reader = new StreamReader(inpFile);
                fileContents = reader.ReadToEnd();
                reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error Reading file {0}: {1}", inpFile, ex.Message);
            }
        try
            {
                StreamWriter streamWriter = new StreamWriter(resFile,true);
                streamWriter.Write(fileContents);
                streamWriter.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error Writing file {0}: {1}", resFile, ex.Message);
            }
            finally
            {
                Console.Write("{0}\n", inpFile);
            }
    }

    static void Main()
    {
        Console.Write("Concatenate text files:\n");
        string fileName1 = @"../../Readme.txt";
        string fileName2 = @"../../License.txt";
        string concatFileName = @"../../ReadmeLicense.txt";
        MoveFile(fileName1,concatFileName);
        MoveFile(fileName2,concatFileName);

        try
        {
        Console.WriteLine("to another text file: {0} \n", concatFileName);
        StreamReader reader = new StreamReader(concatFileName);
            using (reader)
            {
                string line = reader.ReadLine();
                while (line != null)
                {
                    Console.WriteLine(line);
                    line = reader.ReadLine();
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error Reading file {0}: {1}", concatFileName, ex.Message);
        }
        finally
        {
            Console.WriteLine("Please, scroll up to observe the result.");
        }
    }
}
