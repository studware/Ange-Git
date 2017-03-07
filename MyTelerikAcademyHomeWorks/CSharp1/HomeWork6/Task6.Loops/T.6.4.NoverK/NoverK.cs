using System;
class NoverK
{
    static void Main()
    {
        string strNum;
        int k;
        int n;
        int i;
        decimal kFactorial=1;
        decimal nFactorial=1;

        do
        {
            Console.Write("Please, enter an integer number n > 1: ");
        }
        while (!int.TryParse(strNum = Console.ReadLine(), out n) || n <= 1);

        do
        {
            Console.Write("Please, enter an integer number k > n: ");
        }
        while (!int.TryParse(strNum = Console.ReadLine(), out k) || k <=n);

        for (i = 1; i <= n; i++)
        { 
            nFactorial*=i;
        }
        for (i = 1; i <= k; i++)
        { 
            kFactorial*=i;
        }
        Console.WriteLine("{0}!/{1}! = {2}", n, k, nFactorial/kFactorial);
    }
}
