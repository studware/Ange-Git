using System;
using System.Text.RegularExpressions;

class ExtractEmailAddresses
{
    static void Main()
    {
        Console.WriteLine("Extract all email addresses from given text\n");

        string text = "Extract all email addresses from nakov@telerik.com. System.Globalization,nakov@abv.bg hello";

        foreach (var detail in Regex.Matches(text, @"\w+@\w+\.\w+"))
        {
            Console.WriteLine(detail);
        }
    }
}