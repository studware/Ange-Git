using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace T3.CountOfWords
{
    class CountOfWords
    {
        static void Main()
        {
            Console.WriteLine("Count each word in text file appearances. Ignore case.");
            Console.WriteLine("Order the result words by number of occurrences.\n");
            StreamReader sr = new StreamReader(@"../../words.txt");
            using (sr)
            {
                string inputText = sr.ReadToEnd();
                Console.WriteLine("File words.txt:\n{0}",inputText);
                char[] punct = { ' ', '.', ',', '!', '–', '?', '-' };
                string[] words = inputText.ToLower().Split(punct, StringSplitOptions.RemoveEmptyEntries);

                Dictionary<string, int> dictionary = new Dictionary<string, int>();

                foreach (var word in words)
                {
                    int count = 0;
                    if (dictionary.ContainsKey(word))
                    {
                        count = dictionary[word];
                    }
                    dictionary[word] = count + 1;
                }

                Console.WriteLine("\nWords ordered by number of their occurences:\n");
                foreach (KeyValuePair<string, int> element in dictionary.OrderBy(key => key.Value))
                {
                    Console.WriteLine("{0} -> {1}", element.Key, element.Value);
                }
                Console.WriteLine();
            }
        }
    }
}
