using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

class PrintWordsAlphabetically
{
    static void Main()
    {
        Console.WriteLine("Read words, separated by spaces, print the list in an alphabetical order.\n");

        string text = "The low-cost computers on integrated circuits has transformed modern society.";
        Console.WriteLine("The original text is:\n{0}\n\nThe result is:\n", text);

        var words = new List<string>();

        foreach (Match item in Regex.Matches(text, @"\w+"))
        {
            words.Add(item.Value);
        }

        words.Sort();

        foreach (string item in words)
        {
            Console.WriteLine(item);
        }
        Console.WriteLine();
    }
}