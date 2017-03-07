using System;
using System.Collections.Generic;

class Dictionary
{
    static void Main()
    {
        Console.WriteLine("Make a dictionary to accept a word and translate it");
        Console.WriteLine("Enter a word: ");
        string word = Console.ReadLine();
        var dict = new Dictionary<string, string>(){
            { ".NET", "platform for applications from Microsoft"},
            { "CLR", "managed execution environment for .NET"},
            { "namespace", "hierarchical organization of classes"},
            { "URI", "unified resource identifier"},
            { "CSS", "cascading style sheet"},
        };
        try
        {
            Console.WriteLine("{0} - {1}", word, dict[word]);
        }
        catch (KeyNotFoundException)
        {
            Console.WriteLine("The word \"{0}\" does not exist in the dictioanry", word);
        }
    }
}