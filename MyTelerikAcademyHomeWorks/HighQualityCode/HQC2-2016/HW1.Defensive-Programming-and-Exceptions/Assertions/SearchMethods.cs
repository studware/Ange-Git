using System;
using System.Diagnostics;
    
namespace Assertions
{
    public static class SearchMethods
    {
        public static int BinarySearch<T>(T[] arr, T value) where T : IComparable<T>
        {
            return BinarySearch(arr, value, 0, arr.Length - 1);
        }

        private static int BinarySearch<T>(T[] arr, T value, int startIndex, int endIndex)
            where T : IComparable<T>
        {
            Debug.Assert(arr != null, "Array is null.");
            Debug.Assert(value != null, "Search value is null.");
            Debug.Assert(startIndex >= 0 && startIndex < arr.Length, "Start index out of range.");
            Debug.Assert(endIndex >= 0 && endIndex < arr.Length, "End index out of range.");
            Debug.Assert(HelperClass.IsArraySorted(arr), "Array is not sorted.");
            Debug.Assert(startIndex <= endIndex, "Start index cannot be bigger than end index.");

            while (startIndex <= endIndex)
            {
                int midIndex = (startIndex + endIndex) / 2;
                if (arr[midIndex].Equals(value))
                {
                    return midIndex;
                }
                if (arr[midIndex].CompareTo(value) < 0)
                {
                    // Search on the right half
                    startIndex = midIndex + 1;
                }
                else
                {
                    // Search on the left half
                    endIndex = midIndex - 1;
                }
            }
            
            // Searched value not found - check if value exists
            Debug.Assert(!HelperClass.ValueExists(arr, value), "The searched value exists in the array but BinarySearch returns -1.");
            return -1;
        }
    }
}
