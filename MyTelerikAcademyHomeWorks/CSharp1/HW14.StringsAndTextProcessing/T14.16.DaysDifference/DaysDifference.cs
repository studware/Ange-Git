using System;
using System.Globalization;

class DaysDifference
{
    static void Main()
    {
        Console.WriteLine("Calculate number of days between two dates: day.month.year\n");

        string date1 = "27.02.2006";
        string date2 = "3.03.2006";

        DateTime date1Date = DateTime.ParseExact(date1, "d.MM.yyyy", 
            CultureInfo.InvariantCulture);
        DateTime date2Date = DateTime.ParseExact(date2, "d.MM.yyyy", 
            CultureInfo.InvariantCulture);
        Console.Write("The number of days between {0} and {1} is ", date1, date2);
        Console.WriteLine((date2Date - date1Date).TotalDays);
    }
}