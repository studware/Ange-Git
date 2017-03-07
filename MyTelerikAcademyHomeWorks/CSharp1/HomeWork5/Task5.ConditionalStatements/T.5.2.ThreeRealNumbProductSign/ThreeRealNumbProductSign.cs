using System;
class ThreeRealNumbProductSign
{
    static void Main()
    {
        Console.WriteLine("Please enter three numbers (on separate lines:)");
        double numOne = double.Parse(Console.ReadLine());
        double numTwo = double.Parse(Console.ReadLine());
        double numThree = double.Parse(Console.ReadLine());

        bool positiveSign = true;
        if (numOne > 0.0)
        {
            if ((numTwo < 0 && numThree > 0) || (numTwo > 0 && numThree < 0))
            {
                positiveSign = false;
            }
        }
        else if (numOne < 0)
        {
            positiveSign = (numTwo < 0) ^ (numThree < 0);     // false if both are negative or both are positive
        }
        if (!(numOne == 0 || numTwo == 0 || numThree == 0))
        {
            Console.WriteLine("Is the product of the three numbers positive? {0}", positiveSign);
        }
        else
        {
            System.Console.WriteLine("The product of the three numbers is 0! Try again.");
        }
    }
}
