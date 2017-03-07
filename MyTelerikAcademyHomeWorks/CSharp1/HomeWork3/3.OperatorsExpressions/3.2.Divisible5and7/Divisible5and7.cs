using System;

class Divisible5and7
{
    static void Main()
    {
        Console.WriteLine("Please, enter an integer number: ");
        string inputInt = Console.ReadLine();
        int modOf5and7;
        if (int.TryParse(inputInt, out modOf5and7))
        {
            if ((modOf5and7 % 5 == 0)&&(modOf5and7 % 7 == 0))
            {
                Console.WriteLine("The number {0} IS divisible by 5 and 7 without resudue.", modOf5and7);
            }
            else
            {
                Console.WriteLine("The number {0} IS NOT divisible by 5 and 7 without resudue.", modOf5and7);
            }
        }
        else
        {
            Console.WriteLine("{0} is not an integer number!", inputInt);
        }
    }
}

