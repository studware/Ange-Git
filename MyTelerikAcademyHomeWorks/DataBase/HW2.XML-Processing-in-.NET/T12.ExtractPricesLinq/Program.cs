using System;
using System.Linq;
using System.Xml.Linq;

namespace T12.ExtractPricesLinq
{
    class Program
    {
        static void Main()
        {
            XDocument xmlDoc = XDocument.Load("../../../catalogue.xml");
            var albums =
                from album in xmlDoc.Descendants("album")
                where int.Parse(album.Element("year").Value) <= 2010
                select new
                    {
                        Name = album.Element("name").Value,
                        Price = album.Element("price").Value,
                        Year = album.Element("year").Value,
                        Artist = album.Element("artist").Value
                    };

            Console.WriteLine("Filter by LINQ");
            Console.WriteLine("Albums produced 5 years and more ago,");
            Console.WriteLine("along with their prices in the catalogue:\n");
            Console.WriteLine("Name\tPrice\tYear\tArtist\n");

            foreach (var albumNode in albums)
            {
                Console.WriteLine("{0}\t{1}\t{2}\t{3}"
                    , albumNode.Name, albumNode.Price, albumNode.Year, albumNode.Artist);
            }
            Console.WriteLine();
        }
    }
}
