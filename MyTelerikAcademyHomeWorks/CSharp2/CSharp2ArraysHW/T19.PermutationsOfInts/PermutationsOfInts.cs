using System;

class PermutationsOfInts
{
    static void Main()
    {
        string inputVar;
        int n;
        Console.WriteLine(" Read number n, generate \n and print all permutations of the numbers [1....n]");
        do
        {
            Console.Write("Enter array length: ");
        }
        while (!(int.TryParse(inputVar = Console.ReadLine(), out n)) || n == 0);

        int[] arrayOfints = new int[n];
        bool[] repeated = new bool[arrayOfints.Length];

        Permutation(arrayOfints, repeated, 0);
    }
    
    static void PrintResult(int[] array)
    {
        int n = array.Length;
        for (int i = 0; i < n; i++) Console.Write(array[i] + 1 + (i == n - 1 ? "\n" : " "));
    }

    static void Permutation(int[] arr, bool[] repFlag, int i)
    {
        if (i == arr.Length)
        {
            PrintResult(arr);
            return;
        }

        for (int j = 0; j < arr.Length; j++)
        {
            if (repFlag[j]) continue;
            arr[i] = j;
            repFlag[j] = true;
            Permutation(arr, repFlag, i + 1);
            repFlag[j] = false;
        }
    }  
}