using System;

class MaxSumKElems
{
    static void Main()
    {
        string inputVar;
        uint n, k;
        int workSum = 0;   
        int maxSum = 0;         // the resulting max sum of  k consecutive elements             
        int maxStart = 0;       // the start index of the max sum sequence of k consecutive elements
        Console.WriteLine("Find k consecutive elements with max sum in an array");
        do
        {
            Console.Write("Enter array length: ");
        }
        while (!(uint.TryParse(inputVar = Console.ReadLine(), out n)) || n == 0);
        do
        {
            Console.Write("Enter subset length: ");
        }
        while (!(uint.TryParse(inputVar = Console.ReadLine(), out k)) || k == 0);

        int[] arrayOfints = new int[n];

        Console.WriteLine("Now enter the elements of the array:");
        for (int i = 0; i < n; i++)
        {
            arrayOfints[i] = int.Parse(Console.ReadLine());
        }
        for (int i = 0; i < n - k + 1; i++)
        {
            for (int j = i; j < i+k; j++)
            {
                workSum += arrayOfints[j];
            }
            if (workSum > maxSum)
            {
                maxSum = workSum;
                maxStart = i;
                workSum = 0;
            }
            else 
            {
                workSum = 0;
            }
        }
        Console.WriteLine("The sequence of {0} consecutive elements with max sum:", k);
        for (int i = maxStart; i < maxStart+k-1; i++)
        {
            Console.Write("{0} + ", arrayOfints[i]);
        }
        Console.WriteLine("{0} = {1}", arrayOfints[maxStart + k - 1], maxSum);
    }
}