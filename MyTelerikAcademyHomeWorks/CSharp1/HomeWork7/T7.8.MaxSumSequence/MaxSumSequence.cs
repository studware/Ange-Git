using System;

class MaxSumSequence
{
    static void Main()
    {
        string inputVar;
        uint n;
        Console.WriteLine("Find the sequence of maximal sum in given array");
        do
        {
            Console.Write("Enter array length: ");
        }
        while (!(uint.TryParse(inputVar = Console.ReadLine(), out n)) || n == 0);

        int[] arrayOfints = new int[n];

        Console.WriteLine("Enter the elements of the array (please, enter at least one positive number):");
        for (int i = 0; i < n; i++)
        {
            arrayOfints[i] = int.Parse(Console.ReadLine());
        }

        int previousMax  = arrayOfints[0];
        int endMax = arrayOfints[0];
        int start = 0;
        int tempStart = 0;
        int end = 0;

        for(int i = 1; i < n; i++)
        {
            endMax+=arrayOfints[i];
            if(arrayOfints[i] > endMax)
            {
                    endMax = arrayOfints[i];
                    tempStart = i;
            }

            if(endMax > previousMax )
            {
                    previousMax  = endMax;
                    start = tempStart;
                    end = i;
            }
        }
        Console.WriteLine("The maximal sum sequence starts from index {0} and ends with index {1}:",start,end);
        endMax = 0;
        for (int i = start; i <= end; i++)
		{
            endMax += arrayOfints[i];
            Console.WriteLine(arrayOfints[i]);
		}
        Console.WriteLine("The sum is: {0}",endMax);
    }
}
