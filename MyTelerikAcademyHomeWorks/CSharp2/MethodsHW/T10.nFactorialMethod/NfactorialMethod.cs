using System;
using System.Numerics;

class NfactorialMethod
{
    static BigInteger Factorial(int n)
    {
        BigInteger nFactorial = 1;

        for (int i = 1; i <= n; i++)
        {
            nFactorial*=i; 
        }
        return nFactorial;
    }
 
    static void Main()
    {
        Console.WriteLine("Calculate n! for each n in the range [1..100]");
        for (int n = 0; n <= 100; n++)
        {
            BigInteger nf = Factorial(n); 
            Console.WriteLine("{0}! = {1:N}", n, nf);
        } 
    }
}


/*   static int NfactTrailZeros(int n)
    {
        int primeDiv5 = 5;
        int maxDivider = 5;
        int count = 0;
        while (maxDivider <= n)
        {
            count += n / maxDivider;
            maxDivider *= primeDiv5;
        }
        return count;
    }
  */ 