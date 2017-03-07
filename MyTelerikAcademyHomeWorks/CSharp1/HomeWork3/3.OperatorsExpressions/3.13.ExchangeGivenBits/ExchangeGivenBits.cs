using System;

class ExchangeGivenBits
{
    static void Main()
    {
        Console.WriteLine("Exchange bits 3, 4 and 5 with bits 24, 25 and 26 of given 32-bit unsigned integer.");
        
        int p=3; // position of bit sequence 1 to swap
        int q=24; // position of bit sequence 2 to swap
        int k=3;      // number of consecutive bits in each sequence
        uint numN;    // the number whose bits are to be swapped
        uint newN;    // the bit-swapped number 

        bool checkInput;
        
        Console.Write("Please, enter an unsigned integer number to swap the bits of: ");
        string inputInt = Console.ReadLine();
        checkInput = uint.TryParse(inputInt, out numN);
        
        if (checkInput)
        {
            uint workVar = ((numN >> p) ^ (numN >> q)) & ( ~ (1U << k)); // XOR temporary variable
            newN = numN ^ ((workVar << p) | (workVar << q));
            Console.WriteLine("The unsigned integer number was: {0} (HexDec {0:X})", numN);
            Console.WriteLine("The result is: {0} (HexDec {0:X}) ", newN);         
        }
        else
        {
            Console.WriteLine("Wrong input!");
        }
    }
}
