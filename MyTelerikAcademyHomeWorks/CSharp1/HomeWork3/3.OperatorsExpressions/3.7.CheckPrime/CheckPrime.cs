using System;

class CheckPrime
{
    static void Main()
    {
    Console.WriteLine("Check if given positive integer number n (n ≤ 100) is prime.");
        Console.Write("Please, enter integer positive number n (n ≤ 100): ");
        string inputByte = Console.ReadLine();
        byte nNum;
// Considering the algorithm of the sqrt(nNum) divisors, assume sqrt(100)=10 as the max divisor for this case
        if (byte.TryParse(inputByte, out nNum))
        {
            if (nNum > 100)
            { 
                Console.WriteLine("Number greater than 100!");
            }
            else
            {
                if (nNum == 2 || nNum == 3 || nNum == 5 || nNum==7)
                {
                    Console.WriteLine("The number {0} is a prime number.", nNum);
                }
                else
                {
                    if (!(nNum % 2 == 0 || nNum % 3 == 0 || nNum % 5 == 0 || nNum % 7 == 0))
                    {
                        Console.WriteLine("The number {0} is a prime number.", nNum);
                    }
                    else
                    {
                        Console.WriteLine("The number {0} is NOT a prime number.", nNum);
                    }
                }
            }   
        }
        else 
        {
            Console.WriteLine("Not a valid unsigned integer number!");
        }
    }
}
