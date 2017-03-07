using System;
using System.Collections.Generic;
using System.Linq;

namespace T1.NestedLoops
{
    public class NestedLoops
    {
        public static void Main()
        {
            Console.WriteLine("Insert a positive integer number:");
            int n = int.Parse(Console.ReadLine());
            int[] arr = new int[n];
            GenerateCombinations(0, arr);
        }

        private static void GenerateCombinations(int index, int[] arr)
        {
            if (index == arr.Length)
            {
                Console.WriteLine(string.Join(", ", arr));
            }
            else
            {
                for (int i = 1; i <= arr.Length; i++)
                {
                    arr[index] = i;
                    GenerateCombinations(index + 1, arr);
                }
            }
        }
    }
}
