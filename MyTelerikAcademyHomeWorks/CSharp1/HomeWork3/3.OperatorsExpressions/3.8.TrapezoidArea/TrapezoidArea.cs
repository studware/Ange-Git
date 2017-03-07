using System;

class TrapezoidArea
{
    static void Main()
    {
        Console.WriteLine("Calculate trapezoid's area by given sides a and b and height h.");
        Console.Write("Please, enter side a in mm: ");
        string inputFloat = Console.ReadLine();
        float aSide, bSide, hHeight;    // sides and height of the trapezoid
        float calcArea;                 //  result - calculated trapezoid's area

        if (float.TryParse(inputFloat, out aSide))
        {
            Console.Write("Please, enter side b in mm: ");
            inputFloat = Console.ReadLine();
            if (float.TryParse(inputFloat, out bSide))
            {
                Console.Write("Please, enter height in mm: ");
                inputFloat = Console.ReadLine();
                if (float.TryParse(inputFloat, out hHeight))
                {
                    calcArea = ((aSide + bSide) * hHeight) / 2;
                    if (calcArea <= 0)
                    {
                        Console.WriteLine("Not a valid input!");
                    }
                    else
                    {
                        Console.WriteLine("The area of the trapezoid is {0}mm", calcArea);
                    }
                }
                else
                {
                    Console.WriteLine("Not a valid input!");
                }
            }
            else
            {
                Console.WriteLine("Not a valid input!");
            }
        }
        else
        {
            Console.WriteLine("Not a valid input!");
        }
    }
}