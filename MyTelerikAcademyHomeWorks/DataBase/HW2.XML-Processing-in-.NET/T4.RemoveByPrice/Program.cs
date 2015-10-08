namespace T4.RemoveByPrice
{
using System;
using System.Collections.Generic;
using System.Xml;
    internal class Program
    {
        private static void Main() 
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("../../../catalogue.xml");

            var rootNode = doc.DocumentElement;

            Console.WriteLine("Count of albums in the original catalogue:\n");
            Console.WriteLine(rootNode.SelectNodes("album").Count);

            foreach (XmlElement album in rootNode.SelectNodes("album"))
            {
                var price = double.Parse(album["price"].InnerText);
                if (price > 20)
                {
                    rootNode.RemoveChild(album);
                }
            }

            Console.WriteLine("\nCount of albums after albums with price greater than 20 removed -\nsee file cheaperCatalogue:\n");
            Console.WriteLine(rootNode.SelectNodes("album").Count);
            Console.WriteLine();

            doc.Save("../../../cheaperCatalogue.xml");
        }
    }
}
