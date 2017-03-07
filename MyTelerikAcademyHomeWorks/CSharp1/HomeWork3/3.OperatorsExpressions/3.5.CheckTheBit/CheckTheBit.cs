using System;

    class CheckTheBit
{
    static void Main()
    {
        Console.WriteLine("Find if the bit 3 (counting from 0) of a given integer is 1 or 0.");
        Console.WriteLine("Please, enter an integer number: ");
        string inputInt = Console.ReadLine();
        int checkNum;
        int mask3=0x8; // the bit 3 set to 1 is 2pow3=8

        if (int.TryParse(inputInt, out checkNum))
        {
            if ((checkNum & mask3) == mask3)
            {
                Console.WriteLine("The bit 3 of the integer number {0} (HexDec {0:X}) is EQUAL to 1.", checkNum);
            }
            else
            { 
                Console.WriteLine("The bit 3 of the integer number {0} (HexDec {0:X}) is NOT EQUAL to 1.", checkNum);
            }
        }
        else
        {
            Console.WriteLine("{0} is not an integer number!", inputInt);
        }
    }
}
