using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T4.PrintPermutations
{
    class PrintPermutations
    {
        public static void Main()
        {
            Console.WriteLine("Insert number of set elements n:");
            int n = int.Parse(Console.ReadLine());
            int[] arr = new int[n];
            GeneratePermutations(0, n, arr);
        }

        private static void GeneratePermutations(int index, int n, int[] arr)
        {
            int start;
            if (index == arr.Length)
            {
                Console.Write("{");
                Console.Write(string.Join(", ", arr));
                Console.WriteLine("}");
            }
            else
            {
                for (int i = 1; i <= n; i++)
                {
                    bool checkNumber = true;
                    for (int j = 0; j < index; j++)
                    {
                        if (arr[j] == i)
                        {
                            checkNumber = false;
                        }
                    }
                    if (checkNumber)
                    {
                        arr[index] = i;
                        GeneratePermutations(index + 1, n, arr);
                    }
                }
            }
        }
    }
}
