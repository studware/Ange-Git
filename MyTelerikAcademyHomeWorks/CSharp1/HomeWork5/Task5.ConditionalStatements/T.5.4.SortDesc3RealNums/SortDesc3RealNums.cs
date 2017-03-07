using System;
class SortDesc3RealNums
{
    static void Main()
    {
        Console.WriteLine("Please enter three real numbers (on separate lines:)");
        double numOne = double.Parse(Console.ReadLine());
        double numTwo = double.Parse(Console.ReadLine());
        double numThree = double.Parse(Console.ReadLine());

        double temp = numOne;

        if (numOne < numTwo)
        {
            numOne = numTwo;
            numTwo = temp;
        }
        if (numTwo < numThree)
        {
            temp = numTwo;
            numTwo = numThree;
            numThree = temp;
        }
        if (numOne < numTwo)
        {
            temp = numOne;
            numOne = numTwo;
            numTwo = temp;
        }
        Console.WriteLine("Sorted numbers: {0}, {1}, {2}", numOne, numTwo, numThree);
    }
}
