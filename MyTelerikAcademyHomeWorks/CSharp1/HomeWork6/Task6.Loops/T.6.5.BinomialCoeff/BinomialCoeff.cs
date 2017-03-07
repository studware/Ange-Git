using System;
using System.Numerics;
class BinomialCoeff
{
    static void Main()
    {
        string strNum;
        int k;
        int n;
        int i;
        do
        {
            Console.Write("Please, enter an integer number n > 1: ");
        }
        while (!int.TryParse(strNum = Console.ReadLine(), out n) || n <= 1);

        do
        {
            Console.Write("Please, enter an integer number k > n: ");
        }
        while (!int.TryParse(strNum = Console.ReadLine(), out k) || k <= n);

        BigInteger nFactorial = 1;
        for (i = 1; i <= n; i++)
        {
            nFactorial *= i;
        }

        BigInteger knFactorial = 1;
        for (i = k - n + 1 ; i <= k; i++)
        {
            knFactorial *= i;
        }
        BigInteger binomCoeff = nFactorial * knFactorial;

        Console.WriteLine("{0}!*{1}!/{2}! = {3}", n, k, k-n, binomCoeff);
    }
}
