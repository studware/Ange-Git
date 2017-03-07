using System;
    class SumOfNnumbers
    {
        static void Main()
        {
            Console.WriteLine("Get n, get more n numbers, calculate and print their sum.");
            string inputVar;
            uint n;
            decimal sum = 0M;
            decimal num;
            do
            {
                Console.Write("Enter a positive integer number: ");
            }
            while(!(uint.TryParse(inputVar=Console.ReadLine(), out n)));
            for (int i = 0; i < n; i++)
            {
                do
                {
                    Console.Write("Enter a number: ");
                }
                while (!(decimal.TryParse(inputVar = Console.ReadLine(), out num)));
                sum += num;
            }
            Console.WriteLine("The sum of the {0} read numbers is {1}", n, sum);
        }
    }
