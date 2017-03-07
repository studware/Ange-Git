using System;
using System.IO;
using System.Security;

class ReadTextFile
{
    static void Main()
    {
        Console.WriteLine("Enter file name with its full path, read and print it on the console");
        Console.Write("Enter full path&filename: ");
        string fileName = Console.ReadLine();
        try
        {
            ReadFile(fileName);
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("The file '{0}' was not found!", fileName);
        }
        catch (DirectoryNotFoundException)
        {
            Console.WriteLine("Directory not found!");
        }
        catch (SecurityException)
        {
            Console.WriteLine("You don't have the required permission to access this file!");
        }
        catch (UnauthorizedAccessException ae)
        {
            Console.WriteLine(ae.Message);
        }
        catch (ArgumentException)
        {
            Console.WriteLine("File name not correct!");
        }
        catch (IOException ioe)
        {
            Console.WriteLine(ioe.Message);
        }
        catch (NotSupportedException)
        {
            Console.WriteLine("Invalid path format!");
        }
    }

    static void ReadFile(string fName)
    {
            string fileText = File.ReadAllText(fName);
            Console.WriteLine("The content of the file is: ");
            Console.WriteLine(fileText);
        
    }
}
