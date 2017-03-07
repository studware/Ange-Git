using System;
using System.Text;

class IsoscelesTriangle
{
    static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;
        string copyRight="\u00A9";
        Console.WriteLine("Variant 1: Filled isosceles triangle");
        Console.WriteLine();
        Console.WriteLine("{0,5}", copyRight);
        Console.WriteLine("{0,4}{0}{0}", copyRight);
        Console.WriteLine("{0,3}{0}{0}{0}{0}", copyRight);
        Console.WriteLine();

        Console.WriteLine("Variant 2: Empty isosceles triangle");
        Console.WriteLine("{0,5}", copyRight);
        Console.WriteLine("{0,4}{0,2}", copyRight);
        Console.WriteLine("{0,3}{0,4}", copyRight);
        Console.WriteLine("{0,2}{0,2}{0,2}{0,2}", copyRight);
        Console.WriteLine();
    }
}

