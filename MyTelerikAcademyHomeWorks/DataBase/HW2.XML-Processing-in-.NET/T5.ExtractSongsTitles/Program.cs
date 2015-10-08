namespace T5.ExtractSongsTitles
{
using System;
using System.Xml;
    internal class Program
    {
        private static void Main()
        {
            Console.WriteLine("List of Songs' Titles using XmlReader:");
            using (var reader = XmlReader.Create("../../../catalogue.xml"))
            {
                while (reader.Read())
	            {
	                if (reader.NodeType == XmlNodeType.Element && (reader.Name =="title"))
	                {
                        Console.WriteLine(reader.ReadElementString());
	                }         
	            }
    
            }
        }
    }
}
