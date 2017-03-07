using System;

class DecToHexDec
{
    static void Main()
    {
        Console.WriteLine("Convert decimal numbers to their hexadecimal representation");
        Console.WriteLine("The hexadecimal representations of the decimal numbers from 0 to 100 are: ");
        int decNumber = 0;

        for (int n = 0; n < 101; n++)
        {
                int hexDecNumber = 0;
                decNumber = n;
                int temp = decNumber;
                byte position = 0;
                string printStr = "";
                do
                {
                    int bitSet = temp & 1;
                    hexDecNumber = (bitSet << position)| hexDecNumber;
                    temp = temp >> 1;
                    position += 1;
                    printStr = bitSet + printStr;
                } while (temp != 0);
            Console.WriteLine("{0,3}\t{1,3:X}", decNumber, hexDecNumber);
        }
    }
}


