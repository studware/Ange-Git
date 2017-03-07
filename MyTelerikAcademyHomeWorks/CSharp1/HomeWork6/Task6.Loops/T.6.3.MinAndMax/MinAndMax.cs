using System;
class MinAndMax
{
    static void Main()
    {
        string strNum;
        uint n;
		int minNumber;
		int maxNumber;
        int i=1;
        do
        {
            Console.Write("Please, enter an unsigned integer number: ");
        }
        while (!uint.TryParse(strNum = Console.ReadLine(), out n) || n < 1);
        Console.Write("Please, enter an integer number: ");
        int number = Convert.ToInt32(Console.ReadLine()); 
        minNumber = number;
        maxNumber = number;

        while (i < n)
        {
            Console.Write("Please, enter an integer number: ");
            number = Convert.ToInt32(Console.ReadLine());
            if (minNumber > number)
            {
                minNumber = number;
            }
            if (maxNumber < number)
            {
                maxNumber = number;
            }
            i++;
        }
        Console.WriteLine("Minimal number: {0}\t\tMaximal number: {1}", minNumber, maxNumber);
    }
}
