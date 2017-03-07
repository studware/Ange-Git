using System;

class BinOfShort
{
    static void BinRepresOfShort(short start, short end)
    {
        short decNumber = 0;

        for (short n = start; n <= end; n++)
        {
            decNumber = n;
            Console.Write("");
            string binaryStr = "";
            for (int i = 0; i < 16; i++)
            {
                int temp = decNumber&1;
                binaryStr = temp+binaryStr;
                decNumber>>=1;
            }
            Console.WriteLine("{0}\t{1,10}", n, binaryStr);
        }
    }
    
    static void Main()
    {
        Console.WriteLine("Binary representation of 16-bit signed integers from -10 to 10: \n");

        BinRepresOfShort(-10, 10);

//        BinRepresOfShort(short.MinValue, short.MinValue + 25);
       
//        BinRepresOfShort(32745, 32766);
    }
}


