using System;
using Wintellect.PowerCollections;

namespace T2.OrderedMultiDictionary
{
    public class ElementsOrdered
    {
        private const int MaxValue = 1000000;

        public static void Main(string[] args)
        {
            Console.WriteLine("Data structure to store/fast retrieve all articles in given price range [x…y]");
            Console.WriteLine("Please, wait.........");
            OrderedMultiDictionary<double, Article> articles = new OrderedMultiDictionary<double, Article>(true);
            Random randomNumberGenerator = new Random();
            double randomNumber;
            for (int i = 0; i < 2000000; i++)
            {
                randomNumber = randomNumberGenerator.NextDouble() * MaxValue;
                Article article = new Article("barcode" + i, "vendor" + i, "article" + i, randomNumber);
                articles.Add(article.Price, article);
            }

            Console.Write("Enter price from = ");
            double from = double.Parse(Console.ReadLine());
            Console.Write("Enter price to = ");
            double to = double.Parse(Console.ReadLine());
            var articlesInRange = articles.Range(from, true, to, true);
            foreach (var pair in articlesInRange)
            {
                foreach (var article in pair.Value)
                {
                    Console.WriteLine("{0} => {1}", Math.Round(article.Price, 2), article);
                }
            }
        }
    }
}
