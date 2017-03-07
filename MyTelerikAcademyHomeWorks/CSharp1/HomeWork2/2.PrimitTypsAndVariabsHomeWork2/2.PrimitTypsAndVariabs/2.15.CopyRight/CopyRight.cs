using System;
using System.Text;

class CopyRight
{
    static void Main()
    {
        Console.OutputEncoding = Encoding.Unicode;
        int unicode = 0xA9;
        Console.WriteLine("\nThe CopyRight symbol is: {0}", (char)unicode);
    }
}