using System;
class ExchangeTwoNumbers
{
    static void Main()
    {
        Console.WriteLine("Please enter two numbers (on separate lines:)");
        double numOne = double.Parse(Console.ReadLine());
        double numTwo = double.Parse(Console.ReadLine());

        double tempNum = numTwo;
        if (numOne > numTwo)
        {
            tempNum = numOne;
            numOne = numTwo;
            numTwo = tempNum;
            Console.WriteLine("Now number 1 is: {0} \t number 2 is: {1}.", numOne, numTwo);
        }
        else
        {
            Console.WriteLine("Number 1 is not bigger than number 2, so the numbers were not exchanged.");
        }
    }
}
