using System;
class NFactorialTrailingZeros
{
    static void Main()
    {
        string strNum;
        uint n;
        do
        {
            Console.Write("Please, enter an unsigned integer number 0 < N <= 50000: ");
        }
        while ((!uint.TryParse(strNum = Console.ReadLine(), out n)) || n == 0 || n > 50000);
        uint primeDiv5 = 5;
		uint maxDivider=5;
        uint count=0;
           while (maxDivider<=n)
            {
                count+=n/maxDivider;
                maxDivider*=primeDiv5;
            }
           Console.WriteLine("{0} factorial has {1} trailing zeros.", n, count);
    }
}
