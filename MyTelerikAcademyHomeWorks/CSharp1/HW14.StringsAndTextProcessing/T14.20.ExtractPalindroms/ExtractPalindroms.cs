using System;

class ExtractPalindroms
{
    static void Main()
    {
        Console.WriteLine("Extract from a given text all palindromes\n");

        string text = "Is lamal a camel? I listen to the ABBA songs with pleasure and wow,\nI have to write some exe, then go to the swimminglocolgnimmiws";
        Console.WriteLine("Original text:\n{0}\n", text);
        char[] splitSymbols = { ' ', '.', ',', '!', '\r', '\n' };
        string[] words = text.Split(splitSymbols, StringSplitOptions.RemoveEmptyEntries);
     
     
        foreach (string word in words)
        {
            bool palindrome = true;
            int halfLength=word.Length / 2;
            for (int i = 0; i < halfLength; i++)
            {
                if (word[i] != word[word.Length-1-i])
                {
                    palindrome = false;
                    break;
                }
            }
            if (palindrome&&word.Length>1)
            {
                Console.WriteLine(word);
            }
        }
        Console.WriteLine();
    }
}