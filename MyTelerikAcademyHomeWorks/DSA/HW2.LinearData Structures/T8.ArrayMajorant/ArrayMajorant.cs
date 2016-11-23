using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace T8.ArrayMajorant
{
    class ArrayMajorant
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Majorant of an array of size N is a value that occurs at least N/2 + 1 times.");
            Console.WriteLine("Write a program to find the majorant of given array (if exists).");

 //         int[] arraySizeN = {2, 2, 3, 3, 2, 3, 4,5,-10};    //  no majorant found
            int[] arraySizeN = {2, 2, 3, 3, 2, 3, 4, 3, 3};

            Console.WriteLine("\nThe given array is:");
            Console.WriteLine(string.Join(" ", arraySizeN));

            int arrSize=arraySizeN.Length;
            var majorant=arraySizeN.ToLookup(num=>num).Where(nums=>nums.Count() >= arrSize/2+1);

            StringBuilder sb = new StringBuilder();
            foreach (var el in majorant)
            {
                sb.AppendLine(el.Key.ToString());
            }

            string result = (sb.ToString() == string.Empty) ? "\nNo majorant!" : ("\nThe majorant is: "+sb.ToString());
            Console.WriteLine(result); 
        }
    }
}