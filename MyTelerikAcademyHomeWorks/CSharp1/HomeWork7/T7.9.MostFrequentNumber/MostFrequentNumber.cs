using System;

class MostFrequentNumber
{
    static void Main()
    {
        string inputVar;
        uint n;
        Console.WriteLine("Find the most frequent number in an array");
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
        Array.Sort(arrayOfints);
        for (int i = 0; i < n; i++)
        {
            Console.WriteLine("{0},",arrayOfints[i]); 
        }
        Array.Sort(arrayOfints);
        int cnt = 1;
        int maxCnt = 0;
        int mostFrq = arrayOfints[0];
        int finalValue = mostFrq;

        for (int i = 1; i < n; i++)
        {
            if (arrayOfints[i] == mostFrq)
            {
                cnt += 1;
            }
            else
            {
                mostFrq = arrayOfints[i];
                cnt=1;
            }
            if (maxCnt < cnt)
            {
                maxCnt = cnt;
                finalValue = arrayOfints[i - 1];
            }
        }
        Console.WriteLine("The most frequent number is {0}; it occurs {1} times.",finalValue,maxCnt);
    }
}
