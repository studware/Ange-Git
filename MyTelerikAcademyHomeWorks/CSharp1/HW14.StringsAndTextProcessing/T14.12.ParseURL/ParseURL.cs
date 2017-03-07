using System;
using System.Web;
class ParseURL
{
    static void Main()
    {
        Console.WriteLine("Write a program that parses an URL address\n");
        Uri locator = new Uri("http://www.devbg.org/forum/index.php");
        Console.WriteLine("\nURL: http://www.devbg.org/forum/index.php\n");
        Console.WriteLine("Protocol  name = {0}", locator.Scheme);
        Console.WriteLine("Server name = {0}", locator.Host);
        Console.WriteLine("Resource name = {0}\n", locator.AbsolutePath);   
    }
}

