using System;
using System.Text;
using System.Text.RegularExpressions;

class ReplaceBannedWords
{
    static void Main()
    {
        Console.WriteLine("Replaces the forbidden words in text with asterisks");

        string text = "Microsoft announced its next generation PHP compiler today. It is based on .NET Framework 4.0 and is implemented as a dynamic language in CLR.";
        string wordsString = "PHP, CLR, Microsoft";

        Console.WriteLine("Original text: {0}", text);
        Console.WriteLine("Banned words: {0}\n", wordsString);
        char[] coma = new char[] { ',',' ' };
        string[] words = wordsString.Split(coma,StringSplitOptions.RemoveEmptyEntries);

        StringBuilder redPencilText = new StringBuilder();
        redPencilText.Append(text);
        for (int i = 0; i < words.Length; i++)
        {
            redPencilText = redPencilText.Replace(words[i], new string('*', words[i].Length));
        }
        Console.WriteLine("The red-pencil text is:\n{0}",redPencilText);
    }
}
