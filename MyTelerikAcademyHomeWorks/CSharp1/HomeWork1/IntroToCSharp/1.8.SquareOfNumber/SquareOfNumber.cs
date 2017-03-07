using System;

class SquareOfNumber
{
    static void Main()
    {
        // 12345 is an integer number, and its square will not exceed the range of the int type; 
        // but we cast it explicitly  *//

        Console.WriteLine("Square of number 12345 is: " + (int)(12345 * 12345));
    }
}

