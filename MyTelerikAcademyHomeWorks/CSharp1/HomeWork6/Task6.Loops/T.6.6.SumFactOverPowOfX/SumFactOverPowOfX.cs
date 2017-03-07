using System;
class SumFactOverPowOfX
{
    static void Main()
    {
        string strNum;
        int n;
        int x;
        decimal fact = 1M;
        decimal powX = 1M;
        decimal sum = 1M;
        do
        {
            Console.Write("Please, enter an unsigned integer number n: ");
        }
        while (!int.TryParse(strNum = Console.ReadLine(), out n));

        do
        {
            Console.Write("Please, enter an integer number x, not equal to 0: ");
        }
        while (!(int.TryParse(strNum = Console.ReadLine(), out x)) || x == 0);

        if (n == 0)
        {
            sum += 1M / (decimal)x;     //  0!=1
        }
        else
        {
            for (int i = 1; i <= n; i++)
            {
                fact *= (decimal)i;
                powX *= (decimal)x;
                sum += fact / powX;
            }
        }
        Console.WriteLine("For n={0}, x={1} the sum is: {2}", n, x, sum);
    }
}
