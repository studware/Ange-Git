using System;
using System.Collections.Generic;
using System.Text;

class WordsCountInString
{
    static void Main()
    {
        Console.WriteLine("List all different words in text with info how many times each word is found\n");

        string text = "The micro-processor incorporates the functions of a micro-computer's\ncentral processing unit on a single integrated circuit,\nor at most a few integrated circuits, else the micro-processor\noperates on numbers and symbols";
        Console.WriteLine("Original text:\n{0}\n", text);
        Dictionary<string, int> Words = new Dictionary<string, int>();
        var letters = new StringBuilder();
        foreach (var word in text.ToLower())
        {
            if (Char.IsLetter(word))
            {
                letters.Append(word);
            }
            else if (letters.Length > 0)
            {
                if (Words.ContainsKey(letters.ToString()))
                {
                    Words[letters.ToString()]++;
                }
                else
                {
                    Words.Add(letters.ToString(), 1);
                }
                letters.Clear();
            }
        }

        foreach (var word in Words)
        {
            Console.WriteLine("{0,-12} - {1,3} times found", word.Key, word.Value);
        }
        Console.WriteLine();
    }
}