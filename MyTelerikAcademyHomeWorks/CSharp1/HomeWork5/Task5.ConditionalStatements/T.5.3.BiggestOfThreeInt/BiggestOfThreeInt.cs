using System;

class BiggestOfThreeInt
{
    static void Main()
    {
        Console.WriteLine("Please enter three numbers (on separate lines:)");
        int numOne = int.Parse(Console.ReadLine());
        int numTwo = int.Parse(Console.ReadLine());
        int numThree = int.Parse(Console.ReadLine());
        int biggest = numOne;
        if (biggest < numTwo)
        {
            if (numTwo < numThree)
            {
                biggest = numThree;
            }
            else
            {
                biggest = numTwo;
            }
        }
        else if (biggest < numThree)
            {
                biggest = numThree;
            }
        if (!(numOne == numTwo && numOne == numThree))
        {
            Console.WriteLine("The biggest number is: {0}", biggest); ;
        }
        else
        {
            Console.WriteLine("The numbers are equal.");
        }
    }
}
