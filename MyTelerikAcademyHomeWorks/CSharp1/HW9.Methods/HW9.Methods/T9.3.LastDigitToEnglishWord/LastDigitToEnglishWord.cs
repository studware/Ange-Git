using System;

class LastDigitToEnglishWord
{
    static string LastDigitToWord(int digit)
    { 
        string[] digits = {"zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine"};
        digit=digit%10;
        string digitToString=digits[digit];
        return digitToString;
    }
    
    static void Main()
    {
        string lastDigit;
        int number;

        Console.Write("Enter an integer number: ");
        number = int.Parse(Console.ReadLine());
        lastDigit = LastDigitToWord(number);
        Console.WriteLine("The last digit of the number {0} is: {1}", number, lastDigit);
    }
}
