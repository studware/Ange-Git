namespace T10.TraverseDirectoryLinq
{
using System;
using System.IO;
using System.Xml.Linq;
    internal class Program
    {
        private static void Main()
        {
            string coursePath = "D:\\TelerikAcademyCourse\\JavaScript\\JavaScriptApplications";
            var coursePathLinq=TraverseDirectoryLinq(coursePath);
            coursePathLinq.Save("../../directoryTreeLinq.xml");
            Console.WriteLine("Traversed Directory using LINQ (XDocument, XElement and XAttribute)\nsaved in file directoryTreeLinq.xml");
        }

        static XElement TraverseDirectoryLinq(string dirPath)
        {
            var element = new XElement("folder", new XAttribute("folderPath", dirPath));

            foreach (var folder in Directory.GetDirectories(dirPath))
            {
                element.Add(TraverseDirectoryLinq(folder));
            }

            foreach (var file in Directory.GetDirectories(dirPath))
            {
                element.Add(new XElement("file",
                    new XAttribute("fileName", Path.GetFileNameWithoutExtension(file)),
                    new XAttribute("fileExt", Path.GetExtension(file))));
            }

            return element;
        }
    }
}
