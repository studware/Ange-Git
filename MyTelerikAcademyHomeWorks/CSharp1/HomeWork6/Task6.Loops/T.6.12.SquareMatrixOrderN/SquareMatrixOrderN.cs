using System;
class SquareMatrixOrderN
{
    static void Main()
    {
        string strNum;
        uint n;
        uint i;
        uint j;
        do
        {
            Console.Write("Please, enter an unsigned integer number 0 < N < 20: ");
        }
        while ((!uint.TryParse(strNum = Console.ReadLine(), out n)) || n == 0 || n >= 20);

        for (i = 1; i <= n; i++)
        {
            for (j = i; j < i + n; j++)
            {
                Console.Write("{0, 5}", j);
            }
            Console.WriteLine();
        }
    }
}
