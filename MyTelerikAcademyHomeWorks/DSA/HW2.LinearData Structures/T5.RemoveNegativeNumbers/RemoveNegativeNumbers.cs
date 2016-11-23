using System;
using System.Collections.Generic;

namespace T5.RemoveNegativeNumbers
{
    class RemoveNegativeNumbers
    {
        static void Main()
        {
            Console.WriteLine("Write a program that removes from given sequence all negative numbers\n");

            LinkedList<double> numbersList = new LinkedListWithInit<double> { 45.2, 4.87, 4, 4.45, -5, -5.34, -5, 256, 3.38, 3, 2, 4, -48.2, 4, 4, -8.2, 0 };
            Console.WriteLine("The original sequence of numbers is:\n");
            Console.WriteLine(String.Join(", ", numbersList));
            Console.WriteLine("\n");
            
            RemoveNegativeUtil.PositiveNumbersSubSet(numbersList);
 
            Console.WriteLine("The subsequence of the positive numbers is:\n");
            Console.WriteLine(String.Join(", ", numbersList));
            Console.WriteLine("\n");
        }
    }
}