using System;
using System.Collections.Generic;
using System.Linq;

/// <summary>
/// Finds the subsequence of all numbers in given List<int> that occur odd number of times.
/// </summary>
/// <returns>Same LinkedList<int> with odd times occuring elements removed.</returns>

namespace T6.RemoveOddCountNumbers
{
    class RemoveOddCntNumbers
    {
        static void Main()
        {
            Console.WriteLine("Remove from given sequence all numbers that occur odd number of times\n");

            List<int> intNumbers = new List<int> {4, 2, 2, 5, 2, 3, 2, 3, 1, 5, 2};
            Console.WriteLine("Original list of numbers:");
            foreach (var item in intNumbers)
            {
                Console.Write("{0} ", item);
            }
            Console.WriteLine();
            var oddCountElements = intNumbers.ToLookup(n => n).Where(ng => ng.Count() % 2 != 0);
            foreach (var item in oddCountElements)
            {
                intNumbers.RemoveAll(n => n == item.Key);
            }
            Console.WriteLine("\nList of numbers with odd occurences removed:");
            foreach (var item in intNumbers)
            {
                Console.Write("{0} ", item);
            }
            Console.WriteLine();
        }
    }
}
