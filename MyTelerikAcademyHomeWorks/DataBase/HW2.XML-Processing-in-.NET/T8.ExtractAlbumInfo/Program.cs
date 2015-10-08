namespace T8.ExtractAlbumInfo
{
using System;
using System.Text;
using System.Xml;
    class Program
    {
        static void Main()
        {
            string fileName = "../../albums.xml";
            Encoding encoding = Encoding.GetEncoding("windows-1251");
            using (XmlTextWriter writer = new XmlTextWriter(fileName, encoding))
            {
                writer.Formatting = Formatting.Indented;
                writer.IndentChar = '\t';
                writer.Indentation = 1;
        
                writer.WriteStartDocument();
                writer.WriteStartElement("albums");
                writer.WriteAttributeString("name", "My Albums");

                using (XmlReader reader = XmlReader.Create("../../../catalogue.xml"))
                {
                    while (reader.Read())
                    {
                        if (reader.NodeType==XmlNodeType.Element)
                        {
                            if (reader.Name=="name")
                            {
                                writer.WriteStartElement("album");
                                writer.WriteElementString("name", reader.ReadElementString());
                            }
                            else if (reader.Name=="artist")
                            {
                                writer.WriteElementString("artist", reader.ReadElementString());
                                writer.WriteEndElement();
                            }
                        }    
                    }
                }

                writer.WriteEndDocument();
            }
            Console.WriteLine("Document {0} created.", fileName);
        }
    }
}
