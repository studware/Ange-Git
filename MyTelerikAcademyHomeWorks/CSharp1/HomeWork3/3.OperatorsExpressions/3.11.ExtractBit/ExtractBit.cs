using System;

class ExtractBit
{
    static void Main()
    {
        bool checkInput1, checkInput2;
        int extractBitB;
        int i;  // the number to extract from
        int b; // byte position;
        int bitMaskP = 1;   // initialize the mask
        byte theBit=1;

        Console.WriteLine("Extract from a given integer i the value of a given bit number b.");
        Console.WriteLine("Please, enter an integer number to extract a bit from: ");
        string inputInt = Console.ReadLine();
        checkInput1 = int.TryParse(inputInt, out i);
        Console.WriteLine("Please, enter the number of bit (0-31): ");
        inputInt = Console.ReadLine();
        checkInput2 = (int.TryParse(inputInt, out b));
        if (checkInput1 && checkInput2 && b < 32)
        {
            for (int j = 0; j < b; j++)
            {
                bitMaskP = bitMaskP << 1;  //shift the mask b positions to the left;
            }
            extractBitB = i & bitMaskP;
            if(extractBitB==0)
            {
                theBit=0;
            }
            Console.WriteLine("The extracted bit {0} of the integer number {1} (HexDec {1:X}) is : {2} ", b, i, theBit);
        }
        else
        {
            Console.WriteLine("Wrong data!");
        }
    }
}
