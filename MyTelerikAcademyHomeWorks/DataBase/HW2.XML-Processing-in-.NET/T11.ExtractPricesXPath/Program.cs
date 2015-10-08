namespace T11.ExtractPricesXPath
{
    using System;
    using System.Xml;
    internal class Program
    {
        private static void Main()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("../../../catalogue.xml");

//            int years5Ago = DateTime.Now.Year - 5;
//            var xPathQuery = "/catalogue/album[year<=years5Ago]";

            var xPathQuery = "/catalogue/album[year<=2010]";

            var listOfAlbums = doc.SelectNodes(xPathQuery);

            Console.WriteLine("Filter by XPath");
            Console.WriteLine("Albums produced 5 years and more ago,");
            Console.WriteLine("along with their prices in the catalogue:\n");
            Console.WriteLine("Name\tPrice\tYear\tArtist\n");

            foreach (XmlNode albumNode in listOfAlbums)
            {
                Console.WriteLine("{0}\t{1}\t{2}\t{3}"
                    ,albumNode["name"].InnerText, albumNode["price"].InnerText, albumNode["year"].InnerText, albumNode["artist"].InnerText);
            }
            Console.WriteLine();
        }
    }
}
