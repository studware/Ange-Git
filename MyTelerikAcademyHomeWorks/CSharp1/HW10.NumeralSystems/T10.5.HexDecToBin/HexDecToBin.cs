using System;

class HexDecToBin
{
    static void Main()
    {
        Console.WriteLine("Convert  hexadecimal numbers to their binary representation");
        Console.WriteLine("The binary representations of the hexadecimal numbers from 0 to 0x40 are: ");
        int hexDecNumber = 0;

        for (int n = 0; n < 0x41; n++)      //      0x40 hexadecimal is binary 01000000
        {
            int binNumber = 0;
            hexDecNumber = n;
            int temp = hexDecNumber;
            byte position = 0;
            string printStr = "";
            do
            {
                int bitSet = temp & 1;
                binNumber = (bitSet << position) | binNumber;
                temp = temp >> 1;
                position += 1;
                printStr = bitSet + printStr;
            } while (temp != 0);
            for (int k = 0; k < 8-position; k++)
            {
                printStr = "0" + printStr;
            }
            Console.WriteLine("{0:X}\t{1,10}", hexDecNumber, printStr);
        }
    }
}
