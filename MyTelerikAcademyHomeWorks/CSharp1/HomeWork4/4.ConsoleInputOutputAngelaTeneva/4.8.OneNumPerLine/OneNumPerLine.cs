using System;

    class OneNumPerLine
    {
        static void Main()
        {
            Console.WriteLine("Read an integer number n, print all numbers [1..n], each on a single line.");
            Console.Write("Enter a positive integer number: ");
            uint n= uint.Parse(Console.ReadLine())+1;
            for (int i = 1; i < n; i++)
                {
                    Console.WriteLine("{0}", i);
                }
        }
    }
