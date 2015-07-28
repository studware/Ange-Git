using System;

class GetMaxPrg
{
    static int GetMax(int a, int b)
    {
        if (a > b) return a;
        else return b;
    }
    
    static void Main()
    {
        int num1;
        int num2;
        int maxNum;

        Console.Write("Enter an integer number: ");
        num1=int.Parse(Console.ReadLine());
        Console.Write("Enter second integer number: ");
        num2=int.Parse(Console.ReadLine());

        maxNum = GetMax(num1, num2);

        Console.Write("Enter third integer number: ");
        num1 = int.Parse(Console.ReadLine());

        maxNum = GetMax(maxNum, num1);

        Console.WriteLine("{0} is the maximal number.",maxNum);
    }
}
