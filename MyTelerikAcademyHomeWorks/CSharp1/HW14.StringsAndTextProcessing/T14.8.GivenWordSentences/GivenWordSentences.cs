using System;
using System.Text.RegularExpressions;

class GivenWordSentences
{
    static void Main()
    {
        Console.WriteLine("Extract from a given text all sentences containing given word");

        string text = "We are living in a yellow submarine. We don't have anything else. Inside the submarine is very tight. So we are drinking all the day. We will move out of it in 5 days.";
        string word = "in";
        Console.WriteLine("Original text: {0}", text); 
        Console.WriteLine("Search word: {0}\n", word);
        char[] dot=new char[] {'.'};
        string[] sentences = text.Split(dot, StringSplitOptions.RemoveEmptyEntries);
        for (int i = 0; i < sentences.Length; i++)
        {
            Match match=Regex.Match(sentences[i], "\\b"+word+"\\b", RegexOptions.IgnoreCase);
            if (match.Success)
            {
                Console.WriteLine(sentences[i]);
            }
        }
    }
}
