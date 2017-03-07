using System;

class PrintInDifferentFotmats
{
    static void Main()
    {
        Console.WriteLine("Read number, print aligned right in 15 symbols as decimal, hexadecimal n,\n% and scientific notation");
        int n;
        string inputn;
        do
            {
                Console.Write("Enter a number: ");    
            }
        while(!int.TryParse(inputn=Console.ReadLine(), out n));
        
        Console.WriteLine("Decimal:");
        Console.WriteLine("{0,15}", n);
        Console.WriteLine("Hexadecimal:");
        Console.WriteLine("{0,15:X}", n);
        double nPercent=((double)(n))/100;
        Console.WriteLine("Percentage:");
        Console.WriteLine("{0,15:P}", nPercent);
        Console.WriteLine("Scientific:");
        Console.WriteLine("{0,15:E}", n);
    }
}
