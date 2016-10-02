using System;

namespace Assertions
{
    public class AssertionsTest
    {
        public static void Main()
        {
            int[] sampleArray = new int[] { 3, -1, 15, 4, 17, 2, 33, 0 };
            Console.WriteLine("Sample array = [{0}]", string.Join(", ", sampleArray));

            // SelectionSort(new int[0]); // Uncomment only this line to test sorting empty array 

            // SelectionSort(new int[1]); // Uncomment only this line to test sorting single element array

            // int[] nullArray=null;
            // SelectionSort(nullArray); // Uncomment only these two lines to test sorting null array
            
            SortMethods.SelectionSort(sampleArray);
            Console.WriteLine("Sample array sorted = [{0}]", string.Join(", ", sampleArray));

            Console.WriteLine("\nBinarySearch results (position if found; -1 if not found)\n");
            Console.WriteLine("Searching -1000: {0,4}", SearchMethods.BinarySearch(sampleArray, -1000));
            Console.WriteLine("Searching 0: {0,8}", SearchMethods.BinarySearch(sampleArray, 0));
            Console.WriteLine("Searching 17: {0,7}", SearchMethods.BinarySearch(sampleArray, 17));
            Console.WriteLine("Searching 10: {0,7}", SearchMethods.BinarySearch(sampleArray, 10));
            Console.WriteLine("Searching 1000: {0,5}\n", SearchMethods.BinarySearch(sampleArray, 1000));
        }
    }
}
