using System;

class CountLetters
{
    static void Main()
    {
        Console.WriteLine("Print different letters in string with info how many times each letter is found\n");

        string text = "The successful musical My Fair Lady was based on this Bernard Shaw classic.";
        Console.WriteLine("Original text:\n{0}\n", text);

        int[] counts = new int['z' - 'a' + 1];

        foreach (char ch in text.ToLower())
        {
            if ('a' <= ch && ch <= 'z') counts[ch - 'a']++;
        }

        for (int i = 0; i < counts.Length; i++)
        {
            if (counts[i] != 0) Console.WriteLine("{0}: {1}", (char)(i + 'a'), counts[i]);
        }
        Console.WriteLine();
    }
}