namespace T7.TextToXml
{
using System;
using System.IO;
using System.Xml.Linq;
    internal class Program
    {
        static void Main()
        {
            var person = new Person();
            
            using (StreamReader reader = new StreamReader("../../person.txt"))
            {
                person.Name = reader.ReadLine();
                person.Phone = reader.ReadLine();
                person.Address = reader.ReadLine();
            }

            var personElement = new XElement("person",
                new XElement("name", person.Name),
                new XElement("phone", person.Phone),
                new XElement("address", person.Address));

            Console.WriteLine("File ../../person.xml contains the person's data in structured XML format\n");
            personElement.Save("../../person.xml");
        }
    }
}
