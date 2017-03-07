using System;

class SelectionSort
{
    static void Main()
    {
        string inputVar;
        uint n;
        Console.WriteLine("Sort an array using \"selection sort\" method");
        do
        {
            Console.Write("Enter array length: ");
        }
        while (!(uint.TryParse(inputVar = Console.ReadLine(), out n)) || n == 0);

        int[] arrayOfints = new int[n];

        Console.WriteLine("Now enter the elements of the array:");
        for (int i = 0; i < n; i++)
        {
            arrayOfints[i] = int.Parse(Console.ReadLine());
        }

        int minIndex = 0;
        int temp;
        for (int i = 0; i < n - 1; i++)
        {
            minIndex = i;
            for (int j = i + 1; j < n; j++)
            {
                if (arrayOfints[j] < arrayOfints[minIndex])
                {
                    minIndex = j;
                }
            }
            if (minIndex != i)
            {
                temp = arrayOfints[i];
                arrayOfints[i] = arrayOfints[minIndex];
                arrayOfints[minIndex] = temp;
            }
        }
        Console.WriteLine("The array after selection sort ascending:");
        for (int i = 0; i < n; i++)
        {
            Console.Write("{0} ", arrayOfints[i]);
        }
        Console.WriteLine();
    }
}