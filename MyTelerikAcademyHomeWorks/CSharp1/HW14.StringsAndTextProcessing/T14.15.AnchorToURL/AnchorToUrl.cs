using System;
using System.Text.RegularExpressions;

class AnchorToUrl
{
    static void Main()
    {
        Console.WriteLine("Replace all the tags <a href='…'>…</a> with  [URL=…]…/URL]\n");

        string hyperText = "<p>Please visit <a href=\"http://academy.telerik.com\">our site</a> to choose a training course. Also visit <a href=\"www.devbg.org\">our forum</a> to discuss the courses.</p>";
        
        Console.WriteLine("Original text: {0}\n", hyperText);
        Console.WriteLine(Regex.Replace(hyperText, "<a href=\"(.*?)\">(.*?)</a>", "[URL=$1]$2[/URL]"));

    }
}