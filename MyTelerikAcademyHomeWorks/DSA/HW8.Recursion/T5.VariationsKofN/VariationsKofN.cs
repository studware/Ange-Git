using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T5.VariationsKofN
{
    class VariationsKofN
    {
        static StringBuilder sb = new StringBuilder();

        public static void Main()
        {
            Console.WriteLine("Insert number of variation elements k:");
            int k = int.Parse(Console.ReadLine());
            Console.WriteLine("Insert set of n strings separated by comma:");
            string[] input = Console.ReadLine().Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);
            string[] arr = new string[k];
            GenerateVariations(0, input.Length, arr, input);

            sb.Remove(sb.Length - 2, 2);
            Console.WriteLine(sb.ToString());
        }

        private static void GenerateVariations(int index, int n, string[] arr, string[] input)
        {
            int start;
            if (index == arr.Length)
            {
                sb.Append("(");
                sb.Append(string.Join(" ", arr));
                sb.Append("), ");
            }
            else
            {

                for (int i = 0; i < n; i++)
                {
                    arr[index] = input[i];
                    GenerateVariations(index + 1, n, arr, input);
                }
            }
        }
    }
}
