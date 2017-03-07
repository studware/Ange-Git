using System;
using System.Text;

class EncryptString
{
    static string Encryption(string text, string key)
    {
        var encryptedText = new StringBuilder(text.Length);

        for (int i = 0; i < text.Length; i++)
            encryptedText.Append((char)(text[i] ^ key[i % key.Length]));

        return encryptedText.ToString();
    }

    static string Decrypt(string text, string key)
    {
        return Encryption(text, key);
    }

    static void Main()
    {
        string text = @"The book 'Introduction to Programming with C#' is fundamental computer programming book that focuses on the concepts of the computer programming, data structures and algorithms. It is the recommended start for junior developers and is entirely free.";
        string key = "book";
        Console.WriteLine("The key is: {0}", key);
        Console.WriteLine("The original text is:\n{0}",text);

        Console.WriteLine("\nThe encrypted text is:\n");
        Console.WriteLine(Encryption(text, key));

        Console.WriteLine("\nThe decrypted text is:\n");
        Console.WriteLine(Encryption(Encryption(text, key),key));
        Console.WriteLine("\nScroll up to see the original text and the key.\n");
    }
}
