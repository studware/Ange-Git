using System;

class FindSumSequence
{
    static void Main()
    {
        Console.WriteLine("Find in given array of integers a sequence of given sum S (if present)");
        string inputVar;
        uint n;
        int sum = 0; ;
        int tempSum = 0;
        int start = 0;
        int end = 0;
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
        Console.WriteLine("Enter the sum:");
        sum = int.Parse(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            for (int j = i; j < n; j++)
            {
                tempSum += arrayOfints[j];
                if (tempSum == sum)
                {
                    start = i;
                    end = j;
                }
                else if (tempSum>sum)
                {
                    tempSum = 0;
                    break;
                }
            }
        }
        if (start == 0 && end == 0)
        {
            Console.WriteLine("There is not a sequence with sum={0}", sum);
        }
        else
        {
            Console.WriteLine("The following sequense gives a sum={0}:", sum);
            for (int i = start; i < end; i++)
            {
                Console.Write("{0}, ", arrayOfints[i]);
            }
            Console.WriteLine("{0}", arrayOfints[end]);
        }
    }
}
