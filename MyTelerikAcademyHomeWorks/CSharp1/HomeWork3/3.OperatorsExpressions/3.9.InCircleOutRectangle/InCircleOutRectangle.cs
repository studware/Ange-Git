using System;

    class InCircleOutRectangle
{
    static void Main()
    {
        Console.WriteLine("Check for given point (x, y) if it is within the circle K( (1,1), 3) and out of the rectangle R(top=1, left=-1, width=6, height=2).");
        Console.Write("Please, enter x-coordinate: ");
        string inputFloat = Console.ReadLine();
        float xAbs, yAbs;   //  absolute point coordinates 
        float xCoord, yCoord;           // point coordinates relative to the circle's center
        float xCenter = 1.0f;           // coordinates of the circle center
        float yCenter = 1.0f;           //
        float r = 3.0f;                 //  radius of the circle
        bool xRightInput, yRightInput;
        
        xRightInput=float.TryParse(inputFloat, out xAbs);
        Console.Write("Please, enter y-coordinate: ");
        inputFloat = Console.ReadLine();
        yRightInput=float.TryParse(inputFloat, out yAbs);
        if (xRightInput && yRightInput)
        {
            xCoord = xAbs - xCenter;
            yCoord = yAbs - yCenter;
            if (((xCoord * xCoord) + (yCoord * yCoord)) < r * r)    // in circle ?
            {
                if (!((xAbs > -1.0f && xAbs < 5.0f ) && (yAbs > -1.0f && yAbs < 1.0f))) // yes, check the rectangle
                {
                    Console.WriteLine("Success! The point ({0}, {1}) is within circle K and out of the rectangle R.", xAbs, yAbs);
                }
                else
                {
                    Console.WriteLine("The point ({0}, {1}) is within circle K, but it is in the rectangle R too.", xAbs, yAbs);
                }
            }
            else
            {
                Console.WriteLine("The point ({0}, {1}) is NOT within circle K(0, 5) and could be in/out of the rectangle R.", xAbs, yAbs);
            }
        }
        else
        {
            Console.WriteLine("Not valid coordinates!");
        }
    }
}