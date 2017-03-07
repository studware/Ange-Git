using System;
using System.Collections.Generic;

class ArrayMaxSequence
{
    static void Main()
    { 
        Console.WriteLine("Find the maximal sequence of equal elements in an array");
        string inputVar;
        uint n;
        List<int> eqSeq = new List<int>();  // The result sequence
        int initialStart = 0;
        int initialLength = 1;
        int maxStart = 0;                   // the start index of the max sequence of equal elements
        int maxLength = 1;                  // the length of the max sequence of equal elements
        do
        {
            Console.Write("Enter array length: ");
        }
        while (!(uint.TryParse(inputVar = Console.ReadLine(), out n))||n==0);
        
        int[] arrayOfints = new int[n];

        Console.WriteLine("Now enter the elements of the array:");
        for (int i = 0; i < n; i++)
        {
            arrayOfints[i] = int.Parse(Console.ReadLine());
        }

        for (int i = 0; i < n-1; i++)
        {
            if (arrayOfints[i] == arrayOfints[i + 1])
            {
                initialLength++;

                if (initialLength > maxLength)
                {
                    maxLength = initialLength;
                    maxStart = initialStart;
                }
            }
            else
            {
                initialLength = 1;
                initialStart = i + 1;
            }
        }

        for (int i = maxStart; i < maxStart + maxLength; i++)
        {
            eqSeq.Add(arrayOfints[i]);
        }
        initialLength=eqSeq.Count;
        Console.WriteLine("The max sequence counts {0} equal elements:", initialLength);
        for (int i = 0; i < initialLength; i++)
        {
            Console.Write("{0} ",eqSeq[i]);
        }
        Console.WriteLine();
    }
}
