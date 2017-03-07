using System;

    class SetTheBit
    {
        static void Main()
        {
            Console.WriteLine( "Given integer number n, value v (0 or 1) and position p.");
            Console.WriteLine("Modify n to hold value v at position p from the binary representation of n.");
//Example: n = 5 (00000101), p=3, v=1  13 (00001101)	n = 5 (00000101), p=2, v=0  1 (00000001)   */

            bool checkInput1, checkInput2, checkInput3;
            int numN;       // the number to set bit of
            int newN=0;       // the result
            byte posP;      // bit position and
            int valueV;     // the value to initialize the mask
            int maskM;      // the mask

            Console.Write("Please, enter an integer number to set a bit of: ");
            string inputInt = Console.ReadLine();
            checkInput1 = int.TryParse(inputInt, out numN);

            Console.Write("Please, enter the number of bit (0-31): ");
            inputInt = Console.ReadLine();
            checkInput3 = (byte.TryParse(inputInt, out posP));

            Console.Write("Please, enter the value (0 or 1): ");
            inputInt = Console.ReadLine();
            checkInput2 = (int.TryParse(inputInt, out valueV));
            
            if (checkInput1 && checkInput2 && checkInput3 && valueV <= 1 && posP < 32)
            {
                
                if (valueV == 1)
                {
                    maskM=valueV << posP;   // shift left the bit to receive the mask
                    newN = numN | maskM;    // OR the number with the mask
                }
                else
                {
                    maskM= 1 << posP;       // first set the bit to 1, then shift left
                    newN = numN & (~maskM); // bit AND  the number with the 1st complement of the mask
                }
                
                Console.WriteLine("The bit {0} of the integer number {1} (HexDec {1:X}) is set to {2} ", posP, numN, valueV);
                Console.WriteLine("Now this integer number is: {0} (HexDec {0:X}) ", newN);
            }
            else
            {
                Console.WriteLine("Wrong data!");
            }
        }
    }