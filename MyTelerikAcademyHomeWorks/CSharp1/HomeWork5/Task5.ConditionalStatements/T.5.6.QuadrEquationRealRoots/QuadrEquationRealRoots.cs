﻿using System;
class QuadrEquation
{
    static void Main()
    {
        Console.WriteLine("Read the coefficients of ax2+bx+c=0 and solve it (real roots only)");
        string inputVar;
        double a;
        double b;
        double c;
        double x1;
        double x2;
        do
        {
            Console.Write("Enter the coefficient a: ");
        }
        while (!double.TryParse(inputVar = Console.ReadLine(), out a) || a == 0.0);
        do
        {
            Console.Write("Enter the coefficient b: ");
        }
        while (!double.TryParse(inputVar = Console.ReadLine(), out b));
        do
        {
            Console.Write("Enter the coefficient c: ");
        }
        while (!double.TryParse(inputVar = Console.ReadLine(), out c));

        string numRoots = "imaginery";

        Console.Write("The quadratic equation roots are: ");

        x1 = x2 = -((double)(b / (2.0 * a)));
        double discrim = b * b - 4.0 * a * c;

        if (discrim == 0.0)
        {
            numRoots = "one";
        }
        else if (discrim > 0.0)
        {
            numRoots ="two"; 
        }
        switch (numRoots)
        {
        case "two":
            {
            x1 += (double)(Math.Sqrt(discrim) / (2.0 * a));
            x2 -= (double)(Math.Sqrt(discrim) / (2.0 * a));
            Console.WriteLine("x1={0} and x2={1}", x1, x2);
            break;
            }
        case "one":
            {
            Console.WriteLine("x1=x2={0}", x1);
            break;
            }
            default:
            {
            Console.WriteLine("complex.");
            break;
            }
        }
    }
}
