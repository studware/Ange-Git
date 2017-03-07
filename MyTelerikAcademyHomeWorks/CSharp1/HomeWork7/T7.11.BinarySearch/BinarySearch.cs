using System;
using System.Collections.Generic;

class BinarySearch
{
    static void Main()
    {
        string inputVar;
        uint n;
        Console.WriteLine("Find the index of given element in a sorted array of integers by using the binary search algorithm ");
        do
        {
            Console.Write("Enter array length: ");
        }
        while (!(uint.TryParse(inputVar = Console.ReadLine(), out n)) || n == 0);

        int[] arrayOfints = new int[n];

        Console.WriteLine("Enter the elements of the array:");
        for (int i = 0; i < n; i++)
        { 
            arrayOfints[i] = int.Parse(Console.ReadLine());
        }

        Array.Sort(arrayOfints);

        Console.WriteLine("Enter the search value:");
        int sVal = int.Parse(Console.ReadLine());

        uint sMin = 0;
        uint sMax = n;
        uint sMid = 0;

        if (sVal < arrayOfints[0] || sVal > arrayOfints[n - 1])
        {
            Console.WriteLine("Search value not found.");
        }
        else
        {
            while (sMax >= sMin)
            {
                /* the midpoint for roughly equal partition */
                sMid = (sMax - sMin) / 2;

                // determine which subarray to search
                if (arrayOfints[sMid] < sVal)
                    // change min index to search upper subarray
                    sMin = sMid + 1;
                else if (arrayOfints[sMid] > sVal)
                    // change max index to search lower subarray
                    sMax = sMid - 1;
                else
                    break;
            }
            Console.WriteLine("The index of {0} in the sorted array is: {1}", sVal, sMid);
        }
    }
}
