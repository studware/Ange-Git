using System;

class SumWithAccuracy
{
    static void Main()
    {
        Console.WriteLine("Calculate the sum (with accuracy of 0.001): 1 + 1/2 - 1/3 + 1/4 - 1/5 + ...");
        double sum = 1.0;
        double previousSum = 2.0; 
        double i;
        for (i = 2; i<1001; i++)
        {
            previousSum = sum;
            if (i % 2 == 0)
            {
                sum = sum + 1.0/i;
            }
            else
            {
                sum = sum - 1.0/i;
            }
        }
        Console.WriteLine("The sum calculated with accuracy of 0.001 is: {0:F3} incl. the {1}-th member", sum, i-1);
    }

}

