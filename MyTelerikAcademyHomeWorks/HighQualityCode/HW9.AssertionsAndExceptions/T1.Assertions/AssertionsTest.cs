namespace T1.Assertions
{
    using System;

    public class AssertionsTest
    {
        public static void Main()
        {
            int[] sampleArray = new int[] { 18, 10, 2, 8, -5, 333, 33, 0 };
            Console.WriteLine("Sample array = [{0}]", string.Join(", ", sampleArray));
            SortMethods.SelectionSort(sampleArray);
            Console.WriteLine("Sample array sorted = [{0}]", string.Join(", ", sampleArray));

            // SelectionSort(new int[0]); // Uncomment only this line to test sorting empty array 
               
            // int[] nullArray=null;
            // SelectionSort(nullArray); // Uncomment only these two lines to test sorting null array

            Console.WriteLine("\nBinarySearch results (position if found; -1 if not found)\n");
            Console.WriteLine("Searching -6: \t{0}", SearchMethods.BinarySearch(sampleArray, -6));
            Console.WriteLine("Searching 0: \t{0}", SearchMethods.BinarySearch(sampleArray, 0));
            Console.WriteLine("Searching 8: \t{0}", SearchMethods.BinarySearch(sampleArray, 8));
            Console.WriteLine("Searching 35: \t{0}", SearchMethods.BinarySearch(sampleArray, 35));
            Console.WriteLine("Searching 334: \t{0}\n", SearchMethods.BinarySearch(sampleArray, 334));
        }
    }
}
