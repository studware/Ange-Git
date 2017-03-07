using System;
class DigitName
{
    static void Main()
    {
        ushort digit;
        string digitName;
        do
        {
            Console.Write("Please enter digit (from 0 to 9): ");
        }
        while (!ushort.TryParse(digitName = Console.ReadLine(), out digit) || digit > 9);
        switch (digit)
        {
            case 0:
                digitName = "Zero";
                break;
            case 1:
                digitName = "One";
                break;
            case 2:
                digitName = "Two";
                break;
            case 3:
                digitName = "Three";
                break;
            case 4:
                digitName = "Four";
                break;
            case 5:
                digitName = "Five";
                break;
            case 6:
                digitName = "Six";
                break;
            case 7:
                digitName = "Seven";
                break;
            case 8:
                digitName = "Eight";
                break;
            case 9:
                digitName = "Nine";
                break;
        }
        Console.WriteLine("The English for {0} is \"{1}\".", digit, digitName);
    }
}
