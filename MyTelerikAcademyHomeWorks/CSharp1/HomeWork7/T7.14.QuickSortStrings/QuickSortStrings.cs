using System;
using System.Collections.Generic;

class QuickSortStrings
{
    static void Main()
    {
        Console.WriteLine("Sort an array of strings using the quick sort algorithm");

        // Create an unsortArr array of string strArray
        string[] unsortArr = { "za", "et", "xefr", "cwe", "0","mef", "qdsa", "a3e", "123","213r1fe1x" };

        Console.WriteLine("unsortArr array:");
        for (int i = 0; i < unsortArr.Length; i++)
        {
            Console.Write(unsortArr[i] + " ");
        }
        Console.WriteLine();

        // Sort the array

        QuickSort(unsortArr, 0, unsortArr.Length - 1);

        Console.WriteLine("Sorted array:");
        for (int i = 0; i < unsortArr.Length; i++)
        {
            Console.Write(unsortArr[i] + " ");
        }
        Console.WriteLine();
    }

    // A method to sort the array of strings using the QuickSort approach (use interface IComparable)  

    public static void QuickSort(IComparable[] strArray, int leftSide, int rightSide)
    {
        int i = leftSide;
        int j = rightSide;
        IComparable pivot = strArray[(leftSide + rightSide) / 2];

        while (i <= j)
        {
            while (strArray[i].CompareTo(pivot) < 0)
            {
                i++;
            }

            while (strArray[j].CompareTo(pivot) > 0)
            {
                j--;
            }

            if (i <= j)
            {
                // Swap the elements
                IComparable temp = strArray[i];
                strArray[i] = strArray[j];
                strArray[j] = temp;
                i++;
                j--;
            }
        }

        // Recursive calls of QuickSort method
        if (leftSide < j)
        {
            QuickSort(strArray, leftSide, j);
        }

        if (i < rightSide)
        {
            QuickSort(strArray, i, rightSide);
        }

    }
}
