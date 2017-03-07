using System;

class BinToHexDec
{
    static void Main()
    {
        Console.WriteLine("Convert binary numbers to their hexadecimal representation");
        Console.WriteLine("The hexadecimal representations of the binary numbers from 0 to 0100 0000 are: ");
        int binNumber = 0;

        for (int n = 0; n < 65; n++)        //      0100 0000 is the binary for 64 decimal
        {
            int hexDecNumber = 0;
            binNumber = n;
            int temp = binNumber;
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
            for (int k = 0; k < 8 - position; k++)
            {
                printStr = "0" + printStr;
            }
            Console.WriteLine("{0,10}\t{1,3:X}", printStr, hexDecNumber);
        }
    }
}