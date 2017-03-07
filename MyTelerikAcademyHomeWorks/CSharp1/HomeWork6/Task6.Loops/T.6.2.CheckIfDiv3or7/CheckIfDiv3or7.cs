using System;
    class CheckIfDiv3or7
    {
        static void Main()
        {
            string strNum;
            uint n;
            uint i = 1;
            do
            {
                Console.Write("Please, enter an unsigned integer number: ");
            }
            while (!uint.TryParse(strNum = Console.ReadLine(), out n));
            while (i <= n )
            {
                if (!( i % 3 == 0 && i %7 == 0))
                {   
                Console.WriteLine("Number: {0}", i);
                }
                i++;
            }
        }
    }
