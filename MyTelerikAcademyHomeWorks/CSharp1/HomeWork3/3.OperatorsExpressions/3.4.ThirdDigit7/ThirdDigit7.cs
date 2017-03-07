using System;

    class ThirdDigit7
{
    static void Main()
    {
        Console.WriteLine("Check for given integer if its third digit (right-to-left) is 7.");
        Console.WriteLine("Please, enter an integer number: ");
        string inputInt = Console.ReadLine();
        int checkNum;
        if (int.TryParse(inputInt, out checkNum))
        {
            checkNum = Math.Abs(checkNum);
            if ( checkNum > 99)
            {
                checkNum /= 100;
                if (checkNum % 10 == 7)
                {
                    Console.WriteLine("The number {0} HAS its third digit =7 (right-to-left).", inputInt);
                }
                else
                {
                    Console.WriteLine("The number {0} HAS NOT its third digit =7 (right-to-left).", inputInt);
                }
            }
            else 
            { 
                Console.WriteLine("{0} has less than 3 digits!", inputInt);
            }
        }
        else
        {
            Console.WriteLine("{0} is not an integer number!", inputInt);
        }
    }
}
