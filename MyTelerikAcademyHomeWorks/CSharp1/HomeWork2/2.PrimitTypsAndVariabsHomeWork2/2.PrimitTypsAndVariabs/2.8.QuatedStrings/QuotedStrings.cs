using System;

class QuotedStrings
{
    static void Main(string[] args)
    {
        string quotedStr="The \"use\" of quotations causes difficulties.";
        Console.WriteLine("This string is quoted:");
        Console.WriteLine("{0:9}", quotedStr);
        
        string notQuotedStr=@"The ""use"" of quotations causes difficulties.";
        Console.WriteLine("This string is not quoted:");
        Console.WriteLine("{0:9}", notQuotedStr);    
    }
}

