using System;

class SwapBitSequences
{
    static void Main()
    {
        Console.WriteLine("Exchange bits 3, 4 and 5 with bits 24, 25 and 26 of given 32-bit unsigned integer.");

        int p; // position of bit sequence 1 to swap
        int q; // position of bit sequence 2 to swap
        int k;      // number of consecutive bits in each sequence
        uint numN;    // the number whose bits are to be swapped
        uint newN;    // the bit-swapped number 

        bool checkInput1, checkInput2, checkInput3, checkInput4;

        Console.Write("Please, enter the position of the first set of bits to be swapped (unsigned integer): ");
        string inputInt = Console.ReadLine();
        checkInput1 = int.TryParse(inputInt, out p);

        Console.Write("Please, enter the position of the second set of bits to be swapped (unsigned integer): ");
        inputInt = Console.ReadLine();
        checkInput2 = int.TryParse(inputInt, out q);

        Console.Write("Please, enter the number of bits to be swapped: ");
        inputInt = Console.ReadLine();
        checkInput3 = (int.TryParse(inputInt, out k));

        Console.Write("Please, enter an unsigned integer number to swap the bits of: ");
        inputInt = Console.ReadLine();
        checkInput4 = uint.TryParse(inputInt, out numN);

        if (checkInput1 && checkInput2 && checkInput3 && checkInput4)
        {
            if (k != 0 && (Math.Abs(q - p) > k) && (Math.Max(q, p) + k < 32))
            {
                uint workVar = ((numN >> p) ^ (numN >> q)) & (~(1U << k)); // XOR temporary variable
                newN = numN ^ ((workVar << p) | (workVar << q));
                Console.WriteLine("The unsigned integer number was: {0} (HexDec {0:X})", numN);
                Console.WriteLine("The result is: {0} (HexDec {0:X}) ", newN);
            }
            else
            {
                Console.WriteLine("Bit sequiences overlap, or exceed the length of uint, or 0 sequence!");
            }
        }
        else
        {
            Console.WriteLine("Wrong input!");
        }
    }
}
