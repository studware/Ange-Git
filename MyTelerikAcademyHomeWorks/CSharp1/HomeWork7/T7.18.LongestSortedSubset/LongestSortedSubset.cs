using System;
using System.Collections.Generic;

class LongestSortedSubset
{
    static void Main()
    { 
        string inputVar;
        int n;
        Console.WriteLine("Find the longest sorted subset of an array of long integers");
        do
        {
            Console.Write("Enter array length: ");
        }
        while (!(int.TryParse(inputVar = Console.ReadLine(), out n)) || n == 0);

        int[] arrayOfints = new int[n];

        Console.WriteLine("Enter the elements of the array:");
        for (int i = 0; i < n; i++)
        {
            arrayOfints[i] = int.Parse(Console.ReadLine());
        }

        int subSetsCnt = (2 << arrayOfints.Length - 1) - 1;
        List<int> sortedResult = new List<int>();
        List<int> workList = new List<int>();
        int minValue;
        int counter = 0;
        int cnt = 0;

        for (int i = 0; i <= subSetsCnt; i++)
        {
            counter = 0;
            minValue = int.MinValue;
            for (int k = 0; k < arrayOfints.Length; k++)
            {
                if ((((i >> k) & 1) == 1) && (minValue <= arrayOfints[k]))
                {
                    minValue = arrayOfints[k];
                    workList.Add(arrayOfints[k]);
                    counter++;
                }
            }

            if (counter > cnt)
            {
                sortedResult.Clear();
                cnt = counter;
                for (int j = 0; j < workList.Count; j++)
                {
                    sortedResult.Add(workList[j]);
                }
            }
            workList.Clear();
        }

        for (int i = 0; i < sortedResult.Count; i++)
        {
            Console.Write(sortedResult[i] + " ");
        }
        Console.WriteLine();
    }
}