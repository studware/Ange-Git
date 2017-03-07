using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T3.CombinationsNoDuplicates
{
    class CombinationsNoDuplicates
    {
        public static void Main()
        {
            Console.WriteLine("Insert number of combination elements k:");
            int k = int.Parse(Console.ReadLine());
            Console.WriteLine("Insert number of set elements n:");
            int n = int.Parse(Console.ReadLine());
            int[] arr = new int[k];
            GenerateCombinations(0, n, arr);
        }

        private static void GenerateCombinations(int index, int n, int[] arr)
        {
            int start;
            if (index == arr.Length)
            {
                Console.WriteLine(string.Join(", ", arr));
            }
            else
            {
                if (index != 0)
                {
                    start = arr[index - 1] + 1;
                }
                else
                {
                    start = 1;
                }

                for (int i = start; i <= n; i++)
                {
                    arr[index] = i;
                    GenerateCombinations(index + 1, n, arr);
                }
            }
        }
    }
}
