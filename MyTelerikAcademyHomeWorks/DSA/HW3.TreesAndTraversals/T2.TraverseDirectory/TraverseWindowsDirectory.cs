using System;
using System.IO;

namespace T2.TraverseDirectory
{
    public class TraverseWindowsDirectory
    {
        public static void Main()
        {
            Console.WriteLine("Display all *.exe files from C:\\WINDOWS and all its subdirectories recursively");
            PrintExeFiles("C:\\Windows");
        }
        
        public static void PrintExeFiles(string directoryToSearch)
        {
            try
            {
                string[] exeFilesInCurrentDir = Directory.GetFiles(directoryToSearch, "*.exe");

                for (int i = 0; i < exeFilesInCurrentDir.Length; i++)
                {
                    Console.WriteLine(exeFilesInCurrentDir[i]);
                }

                var currentDirectory = Directory.EnumerateDirectories(directoryToSearch);

                foreach (var folder in currentDirectory)
                {
                    PrintExeFiles(folder);
                }
            }
            catch (UnauthorizedAccessException)
            {
                Console.WriteLine("Directory {0} cannot be accessed", directoryToSearch);
            }
        }
    }
}