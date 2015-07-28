using System;

class DecimalToBinary
{
    static void Main()
    {
        Console.WriteLine("Convert decimal numbers to their binary representation");
        Console.WriteLine("The binary representations of the decimal numbers from 0 to 100 are: ");
        int decNumber=0;

        for (int n = 0; n < 101; n++)
        {
            int binNumber = 0;
            decNumber = n;
            int temp = decNumber;
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
            for (int k = 0; k < 8 - position; k++)
            {
                printStr = "0" + printStr;
            }
            Console.WriteLine("{0}\t{1,10}",decNumber,printStr);
        }
    }
}


