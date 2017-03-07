using System;

class LeapYear
{
    static void Main()
    {
        Console.WriteLine("Read a year from the console and check whether it is leap");
        int year;
        string strNum;
        do
        {
            Console.Write("Enter year: ");
        }
        while (!int.TryParse(strNum = Console.ReadLine(), out year) || year <= 0);
        Console.WriteLine("Is {0} leap year? {1}", year, DateTime.IsLeapYear(year));
    }
}
