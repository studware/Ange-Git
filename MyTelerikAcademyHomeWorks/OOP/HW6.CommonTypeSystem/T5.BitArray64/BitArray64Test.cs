/*  Define a class BitArray64 to hold 64 bit values inside an ulong value. 
    Implement IEnumerable<int> and Equals(…), GetHashCode(), [], == and !=.     */


namespace T5.BitArray64
{
using System;

    class BitArray64Test
    {
        static void Main()
        {
            ulong uLongNumber1 = 888;
            BitArray64 number = new BitArray64(uLongNumber1);

            Console.WriteLine("Bits of the number {0}", uLongNumber1);
            foreach (var bit in number)
            {
                Console.Write(bit);
            }
            Console.WriteLine();
            Console.WriteLine("Bit at position 60 is {0}", number[60]);
            Console.WriteLine("Hash code of {0} is {1}", uLongNumber1, number.GetHashCode());

            ulong uLongNumber2 = 123456789;
            BitArray64 otherNumber = new BitArray64(uLongNumber2);
            Console.WriteLine("\nBits of the number {0}", uLongNumber2);
            foreach (var bit in otherNumber)
            {
                Console.Write(bit);
            }
            Console.WriteLine();

            Console.WriteLine("\n{0} == {1} ? {2}", uLongNumber1, uLongNumber2, number == otherNumber);
            Console.WriteLine("\n{0} != {1} ? {2}", uLongNumber1, uLongNumber2, number != otherNumber);
            Console.WriteLine("\n{0} equals {1} ? {2}\n", uLongNumber1, uLongNumber2, number.Equals(otherNumber));
        }
    }
}
