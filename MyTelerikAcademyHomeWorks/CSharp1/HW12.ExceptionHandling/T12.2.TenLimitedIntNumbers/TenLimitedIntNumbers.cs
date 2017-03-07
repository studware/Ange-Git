using System;

class TenLimitedIntNumbers
{
/*    Write a method ReadNumber(int start, int end) that enters an integer number in given range [start…end].
    If an invalid number or non-number text is entered, the method should throw an exception.
    Using this method write a program that enters 10 numbers:
			a1, a2, … a10, such that 1 < a1 < … < a10 < 100 */

    static int ReadNumber(int start, int end)
    {
        int number = 0;
        if (!int.TryParse(Console.ReadLine(), out number))
        {
            throw new FormatException("Not an integer!");
        }
        if (number <= start || number >= end)
        {
            throw new ArgumentOutOfRangeException(String.Format("Number out of range ({0}, {1}):", start, end));
        }
        return number;
    }
    
    static void Main()
    {
        Console.WriteLine("Enter 10 int numbers such that 1 < a1 < … < a10 < 100 and method to check them");
        Console.WriteLine("and throw exception when invalid number or non-number text entered\n");
        int start = 1;
        int end = 100;
        int[] intNumbers = new int[10];
        int correct = 0;
        string numbersToPrint="";
        Console.WriteLine("\nEnter 10 integer numbers between:");
        for (int i = 0; i < 10; i++)
        {
            Console.WriteLine("{0} and {1}:", start, end);
            try
            {
                intNumbers[i] = ReadNumber(start, end);
                start = intNumbers[i];
                numbersToPrint=numbersToPrint+intNumbers[i]+" ";
                correct++;
            }
              catch (FormatException)
            {
                Console.WriteLine("Invalid number: Not an integer!");
            }
            catch (ArgumentOutOfRangeException orex)
            {
                Console.Error.WriteLine("Invalid number: " + orex.Message);
            }
            finally
            {
                
            }
        }
        if (correct > 0)
                {
                    Console.WriteLine("\nYou entered the following increasing numbers from 1 to 100:");
                    Console.WriteLine(numbersToPrint);
                    if (correct < 10)
                        {
                            Console.WriteLine("{0} inputs were wrong.", 10 - correct);
                        }
                }
        else
        { 
            Console.WriteLine("Sorry, no one input was correct!");
        }
    }
}
