using System;
class GreaterOfTwoNum
{
    static void Main()
    {
        Console.WriteLine("Get two numbers from the console\nand print the greater of them, without if statements");
        string inputNum;
        int num1;
        int num2;
        do
        {
            Console.Write("Enter an integer number: ");
        }
        while (!int.TryParse(inputNum = Console.ReadLine(), out num1));
        do
        {
            Console.Write("Enter second integer number: ");
        }
        while (!int.TryParse(inputNum = Console.ReadLine(), out num2));
        Console.WriteLine("{0} is greater than {1}", Math.Max(num1,num2), Math.Min(num1,num2));
    }
}