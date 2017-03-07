using System;
using System.Text;

class ReverseCentence
{
    static void Main()
    {
        Console.WriteLine("Reverse the words in given sentence");
        string text = "C# is not C++, not PHP and not Delphi!";
        char[] pattern = new char[] { '.', '!', ',', ' ' };
        string[] words = text.Split(pattern, StringSplitOptions.RemoveEmptyEntries);
        Console.WriteLine("Original text:\n{0}", text);
        Console.WriteLine("Reversed sentence:");
        Array.Reverse(words);
        for (int i = 0; i < words.Length-1; i++)
        {
            Console.Write(words[i]+" ");
        }
        Console.WriteLine(words[words.Length-1]+text[text.Length-1]);
    }
}
