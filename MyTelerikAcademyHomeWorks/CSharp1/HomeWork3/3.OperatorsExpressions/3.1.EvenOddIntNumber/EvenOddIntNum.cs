using System;

class EvenOddIntNum
{
    static void Main()
    {
        Console.WriteLine("Please, enter an integer number: ");
        string inputInt = Console.ReadLine();
        int evenOddNum;
        if (int.TryParse(inputInt, out evenOddNum))
        {
            if (evenOddNum % 2 == 0)
            {
                Console.WriteLine("The number {0} is even.", evenOddNum);
            }
            else
            {
                Console.WriteLine("The number {0} is odd.", evenOddNum);
            }
        }
        else
        {
            Console.WriteLine("{0} is not an integer number!", inputInt);
        }
    }
}

