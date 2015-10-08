namespace T2.ExtractArtists
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

            var artists = ExtractDistinctArtists(rootNode);
            Console.WriteLine("Task1: file catalogue.xml is in the solution folder.\n");
            Console.WriteLine("Task2: All different artists from the Catalog:\n{0}", string.Join(", ", artists));
            Console.WriteLine();

            Console.WriteLine("Number of albums in the catalogue for each artist:\n");
            var albums = AlbumsNumbersPerArtist(rootNode);
            foreach (var album in albums)
            {
                Console.WriteLine("{0}: {1} albums", album.Key, album.Value);     
            }
        }
        
        private static IEnumerable<string> ExtractDistinctArtists(XmlElement rootNode)
        {
            var distinctArtists = new HashSet<string>();

            var albums = rootNode.GetElementsByTagName("album");
            foreach (XmlNode album in albums)
            {
                distinctArtists.Add(album["artist"].InnerText);
            }
            
            return distinctArtists;
        }

        private static IDictionary<string, int> AlbumsNumbersPerArtist(XmlElement rootNode)
        {
            var albumsPerArtist = new Dictionary<string, int>();

            var albums = rootNode.GetElementsByTagName("album");
            foreach (XmlNode album in albums)
	        {
                var artist = album["artist"].InnerText;
                if (!albumsPerArtist.ContainsKey(artist))
                {
                    albumsPerArtist[artist] = 0;
                }
                
                albumsPerArtist[artist]++;
	        }
      
            return albumsPerArtist;
        }
    }
}
