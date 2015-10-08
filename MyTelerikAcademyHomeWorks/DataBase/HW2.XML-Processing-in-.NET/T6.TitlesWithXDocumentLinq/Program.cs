namespace T6.TitlesWithXDocumentLinq
{
using System;
using System.Linq;
using System.Xml.Linq;
    internal class Program
    {
        private static void Main()
        {
            XDocument xmlDoc = XDocument.Load("../../../catalogue.xml");
            var songs =
              from song in xmlDoc.Descendants("song")
              select new
              {
                  songTitle = song.Element("title").Value,
              };

            Console.WriteLine("List of Songs' Titles using Linq:");
            foreach (var song in songs)
            {
                Console.WriteLine(song.songTitle);
            }
        }
    }
}
