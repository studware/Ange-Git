using System;
using System.Text.RegularExpressions;

class TurnUpperCase
{
    static void Main()
    {
        Console.WriteLine("Change text in all regions surrounded by <upcase> and </upcase> to uppercase.");
        Console.WriteLine("The tags cannot be nested\n");

        /*  Sample text: We are living in a <upcase>yellow submarine</upcase>.
            We don't have <upcase>anything</upcase> else.   */

        Console.Write("Enter the text: ");
        string text = Console.ReadLine();
        text = Regex.Replace(text, "(<upcase>)(.*?)(</upcase>)", m => m.Groups[2].Value.ToUpper());
        Console.WriteLine(text);
    }
}
