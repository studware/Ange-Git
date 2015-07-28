using System;
using System.Collections.Generic;

class QuickSortStrings
{
    static void Main()
    {
        Console.WriteLine("Sort an array of integers using the quick sort algorithm");

        // Create an unsortArr array of integers intArray
        int[] unsortArr = { 200, 38, 15, 2048, 0, 159, 15963, 2, 88, 41 };

        Console.WriteLine("Unsorted array:");
        for (int i = 0; i < unsortArr.Length; i++)
        {
            Console.Write(unsortArr[i] + " ");
        }
        Console.WriteLine();

        // Sort the array

        QuickSortInt(unsortArr, 0, unsortArr.Length - 1);

        Console.WriteLine("Sorted array:");
        for (int i = 0; i < unsortArr.Length; i++)
        {
            Console.Write(unsortArr[i] + " ");
        }
        Console.WriteLine();
    }

    // A method to sort the array of integers using the QuickSort approach  

    public static void QuickSortInt(int[] intArray, int leftSide, int rightSide)
    {
        int i = leftSide;
        int j = rightSide;
        int pivot = intArray[(leftSide + rightSide) / 2];

        while (i <= j)
        {
            while (intArray[i].CompareTo(pivot) < 0)
            {
                i++;
            }

            while (intArray[j].CompareTo(pivot) > 0)
            {
                j--;
            }

            if (i <= j)
            {
                // Swap the elements
                int temp = intArray[i];
                intArray[i] = intArray[j];
                intArray[j] = temp;
                i++;
                j--;
            }
        }

        // Recursive calls of QuickSort method
        if (leftSide < j)
        {
            QuickSortInt(intArray, leftSide, j);
        }

        if (i < rightSide)
        {
            QuickSortInt(intArray, i, rightSide);
        }

    }
}
