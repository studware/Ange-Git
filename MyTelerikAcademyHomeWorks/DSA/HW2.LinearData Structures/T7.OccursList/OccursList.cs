using System;
using System.Collections.Generic;
using System.Linq;

namespace T7.OccursList
{
    /// <summary>
    /// Finds in an array of integers how many times each of them occurs using GroupBy and IDictionary.\n"
    /// </summary>
    class OccursList
    {
        static IDictionary<T, int> GroupByOccursNumbers<T>(IEnumerable<T> dictItems)
        {
            return dictItems.GroupBy(it => it).ToDictionary(itGroup => itGroup.Key, itGroup => itGroup.Count());
        }

        static void Main()
        {
            Console.WriteLine("Find in array of integers (all in range [0..1000]) how many times each of them occurs.\n");

            int[] intNumbers = {3, 4, 4, 2, 3, 3, 4, 3, 2};

            Console.WriteLine("Original list of numbers:");
            Console.WriteLine(string.Join(" ", intNumbers));

            Console.WriteLine("\nList of numbers by occurrences:");
            Console.WriteLine(string.Join(" ", GroupByOccursNumbers(intNumbers)));
        }
    }
}