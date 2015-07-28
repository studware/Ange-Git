using System;

class VariationsOfInts
{
    static void Main()
    {
        string inputVar;
        int n, k;
        Console.WriteLine(" Read numbers N and K,/n generate all variations of K elements from the set [1..N]. ");
        do
        {
            Console.Write("Enter array length N: ");
        }
        while (!(int.TryParse(inputVar = Console.ReadLine(), out n)) || n == 0);
        do
        {
            Console.Write("Enter variation length K: ");
        }
        while (!(int.TryParse(inputVar = Console.ReadLine(), out k)) || k == 0 || k > n);

        int[] arrayOfints = new int[k];
        Variation(arrayOfints, n, 0);
    }

    static void PrintResult(int[] array)
    {
        int n = array.Length;
        for (int i = 0; i < n; i++)
        {
            Console.Write(array[i] + 1 + (i == n - 1 ? "\n" : " "));
        }
    }

    static void Variation(int[] resArr, int n, int varIndex)
    {
        if (varIndex == resArr.Length)
        {
            PrintResult(resArr);
            return;
        }

        for (int j = 0; j < n; j++)
        {
            resArr[varIndex] = j;
            Variation(resArr, n, varIndex + 1);
        }
    }
}