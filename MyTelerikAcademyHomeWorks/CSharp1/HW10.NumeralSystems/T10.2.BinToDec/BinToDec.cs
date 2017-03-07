using System;

class BinToDec
{
    static void Main()
    {
        Console.WriteLine("Convert  numbers to their decimal representation");
        Console.WriteLine("The decimal representations of the binary numbers from 0 to 1000000 are: ");
        int decNumber = 0;
        int binNumber; 
        int n;

        for (n = 1; n < 65; n++)       // binary 1000000 is 64
        {
            int pos=1;
            binNumber = n;
            decNumber = 0;

            int temp = binNumber;
            int mask=1;
            byte pow2 = 2;
            string printStr = "";
            int bitSet = binNumber & mask;
            if (bitSet == 1)
            {
                decNumber += 1;
            }
            temp >>= 1;
            printStr = bitSet + printStr;
            while (temp != 0)
            {
                bitSet = temp & mask;
                if(bitSet==1)
                {
                    decNumber += pow2;
                }
                temp = temp >> 1;
                pow2 *= 2;
                pos += 1;
                printStr = bitSet + printStr;
            } 
            Console.WriteLine("{0,7}{1,7}", printStr,decNumber);
        }
    }
}


