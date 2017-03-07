using System;

class HexDecToDec
{
    static void Main()
    {
        Console.WriteLine("Convert  hexadecimal numbers to their decimal representation");
        Console.WriteLine("The hexadecimal representations of the decimal numbers from 0 to 10000000 are: ");
        int decNumber;
        int hexDecNumber;
        int n;

        for (n = 1; n < 0x41; n++)      // 0x40 is decimal 64
        {
            hexDecNumber = n;
            decNumber = 0;

            int temp = hexDecNumber;
            int mask = 0xF;
            int bitSet=0;

            bitSet = temp & mask;
            decNumber = decNumber | bitSet;
            temp = temp >> 4;
            int pos4 = 4;
            while (temp != 0)
            {
                bitSet = (temp & mask)<<pos4;
                decNumber = decNumber | bitSet;
                temp = temp >> 4;
                pos4 += 4;
            }
            Console.WriteLine("{0,7:X}{1,7}", hexDecNumber, decNumber);
        }
    }
}



