using System;
using System.Numerics;

class Catalan
{
    static void Main()
    {
        string strNum;
        int n;
        int twoN;
        int i;
        do
        {
            Console.Write("Please, enter an unsigned integer number n: ");
        }
        while ((!int.TryParse(strNum = Console.ReadLine(), out n)) || n <= 0);

        BigInteger nFactorial = 1;
        for (i = 1; i <= n; i++)
        {
            nFactorial *= i;
        }

        BigInteger dividend = 1;
        twoN = 2 * n;

        for (i = n + 2; i <= twoN; i++)
        {
            dividend *= i;
        }
        decimal catalan = (decimal)dividend/(decimal)nFactorial;

        Console.WriteLine("The {0}-th Catalan number is: {1}", n,catalan);

    }
}
