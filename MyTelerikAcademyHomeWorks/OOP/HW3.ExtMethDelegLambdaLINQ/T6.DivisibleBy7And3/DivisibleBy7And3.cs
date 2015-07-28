// Write a program that prints from given array of integers all numbers that are divisible by 7 and 3. 
// Use the built-in extension methods and lambda expressions. Rewrite the same with LINQ.
namespace T6.DivisibleBy7And3
{
using System;
using System.Collections.Generic;
using System.Linq;
    static class DivisibleBy7And3
    {
        private static readonly int divider = 7 * 3;
        static void Main()
        {
            int[] numbersToFilter = new[] { 34, 2, 56, 21, 789, 63, 23, 7, 10, 3 };
            Console.WriteLine("Array of integer numbers:\n");
            Console.WriteLine(String.Join(", ", numbersToFilter));

            Console.WriteLine("\nNumbers divisible by 7 and 3 (using Lambda expression):\n");
            Console.WriteLine(String.Join(", ", numbersToFilter.NumbersDivisible_Lambda(divider)));
            Console.WriteLine("\nNumbers divisible by 7 and 3 (using LINQ):\n");
            Console.WriteLine(String.Join(", ", numbersToFilter.NumbersDivisible_LINQ(divider)));
            Console.WriteLine();
        }
        private static IEnumerable<int> NumbersDivisible_LINQ(
        this IEnumerable<int> numbersToFilter, int divider)
        {
            return from num in numbersToFilter
                   where (num % divider == 0)
                   select num;
        }
        private static IEnumerable<int> NumbersDivisible_Lambda(
        this IEnumerable<int> numbersToFilter, int divider)
        {
            return numbersToFilter
            .Where(x => x % divider == 0);
        }
    }
}
