using System;
using System.Text.RegularExpressions;

class ReduceConsecutiveLetters
{
    static void Main()
    {
        Console.WriteLine("Replace all series of consecutive identical letters with a single one. Example: \n");

        string text = "Theeee microooooooprocessor operrrrrrrrrrrrrates on numbers annnnnnndddddddddddd symbbbbbbbbols";
        Console.WriteLine("Original text:\n{0}\n", text);
        Console.WriteLine(Regex.Replace(text, @"(\w)\1+", "$1"));
        Console.WriteLine();
    }
}