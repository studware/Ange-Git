using System;
using System.Text;

class ASCIItable
{
    static void Main()
    {
        Console.OutputEncoding = Encoding.Unicode;
        Console.WriteLine("Extended ASCII Code Table");
        for (int i = 0; i < 31; i++)
        {
            Console.WriteLine("DEC {0}\t HEX {1}\t\tControl Char \t HTML &#{0}", i, i.ToString("X"));
        }
        for (int i = 32; i < 256; i++)
        {
            Console.WriteLine("DEC {0}\t HEX {1} \t ASCII {2} \t HTML &#{0}", i, i.ToString("X"), (char)i);
        }
    }
}

