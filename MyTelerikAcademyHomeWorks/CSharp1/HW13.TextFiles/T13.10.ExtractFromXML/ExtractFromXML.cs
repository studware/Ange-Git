using System;
using System.IO;
using System.Text;
using System.Xml;

class ExtractFromXML
{
    static void Main()
    {
        Console.WriteLine("Extract from given XML file all the text without the tags\n");

        Console.WriteLine(@"The text file is named '..\..\xmlFile.xml'");
        Console.WriteLine(@"(The resulting file is saved in '..\..\parsedXML.txt'");
        Console.WriteLine("\nPlease, open these files to see the result.");
        
        string fileSourcePath = "..//..//xmlFile.xml";
        string fileResultPath = "..//..//parsedXML.txt";

        try
        {
          using (XmlReader reader = XmlReader.Create(new StreamReader(fileSourcePath, Encoding.GetEncoding("utf-8"))))
          {
            while (!reader.EOF)
            {
              using (StreamWriter writer = new StreamWriter(fileResultPath, false, Encoding.GetEncoding("utf-8")))
              {
                while (!reader.EOF)
                {
                    reader.Read();
                    if (reader.NodeType == XmlNodeType.Text)
                    {
                        writer.WriteLine(reader.Value);
                    }
                }
              }
            }
          }
        }
        catch (IOException ex)
        {
            Console.WriteLine("IO error!");
            Console.WriteLine(ex.Message);
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine("Error parsing XML!");
            Console.WriteLine(ex.Message);
        }
        catch (FormatException ex)
        {
            Console.WriteLine("Error parsing XML!");
            Console.WriteLine(ex.Message);
        }
        catch (InvalidOperationException ex)
        {
            Console.WriteLine("Error parsing XML!");
            Console.WriteLine(ex.Message);
        }
        catch (XmlException ex)
        {
            Console.WriteLine("Error parsing XML!");
            Console.WriteLine(ex.Message);
        }
    }
}

