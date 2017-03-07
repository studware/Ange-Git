using System;

class RectangleArea
{
    static void Main()
    {
        Console.WriteLine("This program calculates rectangle’s area by given width and height.");
        Console.WriteLine("Please, enter width: ");

        string inputInt = Console.ReadLine();
        uint rectWidth, rectHeight, rectArea;
        
        if (uint.TryParse(inputInt, out rectWidth))
        {
            Console.WriteLine("Please, enter height: ");
            inputInt = Console.ReadLine();
            if (uint.TryParse(inputInt, out rectHeight))
            {
                if ((rectArea = rectWidth * rectHeight) != 0)
                {
                    Console.WriteLine("The Rectangle's area is {0}.", rectArea);
                }
                else
                {
                    Console.WriteLine("Zero dimension! Try again.");
                }
            }
            else
            {
                Console.WriteLine("Not an unsigned integer!");
            }
        }
        else
        {
            Console.WriteLine("Not an unsigned integer!");
        }
    }
}
