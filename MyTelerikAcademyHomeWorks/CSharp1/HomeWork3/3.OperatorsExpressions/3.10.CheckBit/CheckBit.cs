using System;

    class CheckBit
    {
        static void Main()
        {
            bool checkInput1, checkInput2;
            bool checkBitP;
            int v;  // the number to check
            int p; // byte position;
            int bitMaskP=1;   // initialize the mask

            Console.WriteLine("Find if the bit at position p (counting from 0) in a given integer number v has value of 1.");
            Console.WriteLine("Please, enter an integer number to be checked: ");
            string inputInt = Console.ReadLine();
            checkInput1=int.TryParse(inputInt, out v);
            Console.WriteLine("Please, enter the number of bit (0-31): ");
            inputInt = Console.ReadLine();
            checkInput2=(int.TryParse(inputInt, out p));
            if(checkInput1&&checkInput2&&p<32)
            {
                for (int i = 0; i < p; i++)
                {
                    bitMaskP=bitMaskP << 1;  //shift the mask p positions to the left;
                }
                checkBitP=((v & bitMaskP)!=0);
                Console.WriteLine("The bit {0} of the integer number {1} (HexDec {1:X}) is EQUAL to 1: {2} ", p,v,checkBitP);     
            }
            else
            {
                Console.WriteLine("Wrong data!");
            }
        }
    }
