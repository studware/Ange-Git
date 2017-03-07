using System;
using System.Text;

class ReverseString
{

    public static string RevString(string inputStr)
    {
        StringBuilder reversed = new StringBuilder();
        for (int i = inputStr.Length-1; i >= 0; i--)
        {
            reversed.Append(inputStr[i]);
        }
        return reversed.ToString();
    }

    static void Main()
    {
        Console.WriteLine("Read a string, reverse it and print the result at the console"); 
     
        Console.Write("Enter a string: ");
        string stringToReverse = Console.ReadLine();
        Console.WriteLine("\nThe reversed string is: {0}", RevString(stringToReverse));
    }
}
