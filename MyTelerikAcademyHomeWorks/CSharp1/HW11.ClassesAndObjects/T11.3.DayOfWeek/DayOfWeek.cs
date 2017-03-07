using System;

class DayOfWeek
{
    static void Main()
    {
        Console.WriteLine("Print to the console which day of the week is today:\n");
        DateTime today = DateTime.Now;
        Console.WriteLine("Today it is {0}.\n",today.DayOfWeek);
    }
}
