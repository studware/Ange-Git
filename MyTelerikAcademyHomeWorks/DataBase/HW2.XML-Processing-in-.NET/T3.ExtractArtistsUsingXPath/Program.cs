namespace T3.ExtractArtistsUsingXPath
{
using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
    internal class Program
    {
        private static void Main()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("../../../catalogue.xml");

            var rootNode = doc.DocumentElement;

            var listOfAlbums = doc.SelectNodes("/catalogue/album");       // using xPath

            var albumsPerArtist = new Dictionary<string, int>();

            foreach (XmlNode album in listOfAlbums)
            {
                var artist = album["artist"].InnerText;
                if (!albumsPerArtist.ContainsKey(artist))
                {
                    albumsPerArtist[artist] = 0;
                }

                albumsPerArtist[artist]++;
            }
            
            Console.WriteLine("Number of albums in the catalogue for each artist:\n");

            foreach (var album in albumsPerArtist)
            {
                Console.WriteLine("{0,-16}: {1,6} albums", album.Key, album.Value);     
            }
            Console.WriteLine();
        }


    }
}
