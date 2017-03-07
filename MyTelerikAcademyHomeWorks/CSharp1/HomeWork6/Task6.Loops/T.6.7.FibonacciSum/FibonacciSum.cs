using System;
using System.Numerics;

class FibonacciSum
{
    static void Main()
    {
        string strNum;
        uint n;
        do
        {
            Console.Write("Please, enter an unsigned integer number n > 0: ");
        }
        while (!uint.TryParse(strNum = Console.ReadLine(), out n) || n <= 0);
        BigInteger beforePrevious = 0;
        BigInteger previousNum = 1;
        BigInteger fibonacciNum = 1;
        BigInteger fibonacciSum = 1;
        if (n > 2)
        {
            Console.WriteLine(" 1.\t {0} \n 2.\t {1}", beforePrevious, previousNum);
            for (int i = 3; i <= n; i++)
            {
                Console.WriteLine(" {0}.\t {1}", i, fibonacciNum);
                fibonacciSum += fibonacciNum;
                beforePrevious = previousNum;
                previousNum = fibonacciNum;
                fibonacciNum = beforePrevious + previousNum;
            }
        }
        else if (n == 2)
        {
            fibonacciSum = beforePrevious + previousNum;
        }
        else if (n == 1)
        {
            fibonacciSum = beforePrevious;
        }
        Console.WriteLine("The sum of the first {0} Fibonacci numbers is: {1}", n, fibonacciSum);
    }
}
