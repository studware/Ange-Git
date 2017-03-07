using System;

class PointInCircle
{
    static void Main()
    {
        Console.WriteLine("Check if given point (x,  y) is within a circle K(O, 5).");
        Console.Write("Please, enter x-coordinate: ");
        string inputFloat = Console.ReadLine();
        float xCoord, yCoord;
        float r=5.0f;   //  radius of the circle

        if (float.TryParse(inputFloat, out xCoord))
        {
            Console.Write("Please, enter y-coordinate: ");
            inputFloat = Console.ReadLine();
            if (float.TryParse(inputFloat, out yCoord))
            {
                if (((xCoord * xCoord) + (yCoord * yCoord)) < r * r)
                {
                    Console.WriteLine("The point ({0}, {1}) is within a circle K(0, 5).", xCoord, yCoord);
                }
                else
                {
                    Console.WriteLine("The point ({0}, {1}) is NOT within a circle K(0, 5).", xCoord, yCoord);
                }
            }
            else 
            {
                Console.WriteLine("Not valid coordinates!");
            }
        }
        else
        {
            Console.WriteLine("Not valid coordinates!");
        }
    }
}
