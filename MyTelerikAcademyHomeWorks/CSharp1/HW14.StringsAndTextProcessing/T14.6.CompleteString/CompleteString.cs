using System;

class CompleteString
{
    static void Main()
    {
        Console.WriteLine("Enter some text (max 20 characters):");
        string text=(Console.ReadLine()).PadRight(20, '*');
        Console.WriteLine("The completed text is: {0}",text);
    }
}
