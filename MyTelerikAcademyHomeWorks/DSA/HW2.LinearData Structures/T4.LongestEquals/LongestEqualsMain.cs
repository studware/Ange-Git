using System;
using System.Collections.Generic;

/*  Write a method that finds the longest subsequence of equal numbers in given List<int> and returns the result as new List<int>.
 *  Write a program to test whether the method works correctly   */

namespace T4.LongestEquals
{
    class LongestEqualsMain
    {
        public static void Main()
        {
            Console.WriteLine("Write a method that finds the longest subsequence of equal numbers");
            Console.WriteLine("in given List<int> and returns the result as new List<int>.");
            Console.WriteLine("Write a program to test whether the method works correctly\n");
            List<int> numbersList = new List<int> {45, 4, 4, 4, 4, -5, -5, -5, -5 -5, 256, 3, 3, 3, 2, 4, 4, 4, 4, 4, 4, 4, 4, 8, 0};
            List<int> longestEquals = LongestEqualsUtils.LongestEqualNumbersSubSet(numbersList);

            Console.WriteLine("The longest subsequence of equal numbers is:\n");

            for (int i = 0; i < longestEquals.Count; i++)
            {
                Console.Write("{0} ", longestEquals[i]);
            }
            Console.WriteLine("\n");
        }
    }
}
