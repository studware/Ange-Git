using System;

class CombinationsOfInts
{
    static void Main()
    {
        string inputVar;
        int n, k;
        Console.WriteLine(" Read numbers N and K,\n generate all combinations of K distinct elements from the set [1..N]. ");
        do
        {
            Console.Write("Enter array length N: ");
        }
        while (!(int.TryParse(inputVar = Console.ReadLine(), out n)) || n == 0);
        do
        {
            Console.Write("Enter combination length K: ");
        }
        while (!(int.TryParse(inputVar = Console.ReadLine(), out k)) || k == 0 || k > n);

        int[] arrayOfints = new int[k];
        Combination(arrayOfints, n, 0, 0); ;
    }

    static void PrintResult(int[] array)
    {
        int n = array.Length;
        for (int i = 0; i < n; i++)
        {
            Console.Write(array[i] + 1 + (i == n - 1 ? "\n" : " "));
        }
    }

    static void Combination(int[] resArr, int n, int combIndex,int goNext)
    {
        if (combIndex == resArr.Length)
        {
            PrintResult(resArr);
            return;
        }

        for (int j = goNext; j < n; j++)
        {
            resArr[combIndex] = j;
            Combination(resArr, n, combIndex + 1, j+1);
        }
    }
}