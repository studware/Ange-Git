using System;

class UnicodeCharVar
{
    static void Main()
    {
        char unicodeChar = '\u0048';
        Console.WriteLine(@"A character variable with Unicode code '\u00{0:X}': {1}", 72, unicodeChar);
    }
}

