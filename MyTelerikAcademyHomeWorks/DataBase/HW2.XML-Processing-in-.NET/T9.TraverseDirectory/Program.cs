namespace T9.TraverseDirectory
{
using System;
using System.IO;
using System.Text;
using System.Xml;
    internal class Program
    {
        private static void Main()
        {
            using (XmlTextWriter wr = new XmlTextWriter("../../directory.xml", Encoding.UTF8))
            {
                wr.Formatting = Formatting.Indented;
                wr.IndentChar = '\t';
                wr.Indentation = 1;

//                string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                string coursePath = "D:\\TelerikAcademyCourse\\JavaScript\\JavaScriptApplications";
 
                wr.WriteStartDocument();
                wr.WriteStartElement("TelerikJSAppsCourse");
                TraverseDirectory(coursePath, wr);
                wr.WriteEndDocument();
            }  

            Console.WriteLine("Traversed Directory saved in file directoryTree.xml");
        }

        static void TraverseDirectory(string dirPath, XmlTextWriter wr)
        {
            foreach (var folder in Directory.GetDirectories(dirPath))
	        {
		        wr.WriteStartElement("folder");
                wr.WriteAttributeString("folderPath", folder);
                TraverseDirectory(folder, wr);
                wr.WriteEndElement();
	        }

            foreach (var file in Directory.GetDirectories(dirPath))
	        {
		        wr.WriteStartElement("file");
                wr.WriteAttributeString("fileName", Path.GetFileNameWithoutExtension(file));
                wr.WriteAttributeString("fileExt", Path.GetExtension(file));
                wr.WriteEndElement();
	        }
        }
    }
}
