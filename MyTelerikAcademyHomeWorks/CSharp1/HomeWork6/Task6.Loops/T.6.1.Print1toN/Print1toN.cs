
using System;
    class Print1toN
    {
        static void Main()
        
        {
            string strNum;
            uint n;
            uint i=1;
            do
            {
                Console.Write("Please, enter an unsigned integer number: ");
            }
            while (!uint.TryParse(strNum = Console.ReadLine(), out n));
            while (i<=n)
            {
                Console.WriteLine("Number: {0}", i);
                i++;
            }

        }
    }
