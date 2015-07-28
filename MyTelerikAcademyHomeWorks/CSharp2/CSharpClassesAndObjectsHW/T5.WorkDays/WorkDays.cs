using System;
using System.Collections.Generic;

class WorkDays
{
            
        static int WorkDaysFromNow(DateTime today, DateTime inpDate)
    {
        int workdays = 0;
        List<DateTime> officialHolidays = new List<DateTime>() {
                                                                DateTime.Parse("06.09.2014"),
                                                                DateTime.Parse("22.09.2014"),
                                                                DateTime.Parse("24.12.2014"),
                                                                DateTime.Parse("25.12.2014"),
                                                                DateTime.Parse("26.12.2014"),
                                                                DateTime.Parse("01.01.2015"),
                                                                DateTime.Parse("03.03.2015"),
                                                                DateTime.Parse("10.04.2015"),
                                                                DateTime.Parse("13.04.2015"),
                                                                DateTime.Parse("01.05.2015"),
                                                                DateTime.Parse("06.05.2015"),
                                                                DateTime.Parse("24.05.2015"),
                                                                DateTime.Parse("06.09.2015"),
                                                                DateTime.Parse("22.09.2015"),
                                                                DateTime.Parse("24.12.2015"),
                                                                DateTime.Parse("25.12.2015"),
                                                                DateTime.Parse("26.12.2015"),
                                                                DateTime.Parse("01.01.2016"),
                                                                DateTime.Parse("03.03.2016"),
                                                                
                                                                };
 
        for (DateTime date = today; date <= inpDate; date = date.AddDays(1))
        {            
            if ((date.DayOfWeek != DayOfWeek.Saturday) && (date.DayOfWeek != DayOfWeek.Sunday)
                && (officialHolidays.IndexOf(date) == -1))
            {
                workdays++;
            }
        }
 
        return workdays;
    }
 
    static void Main()
    {
        Console.WriteLine("Calculate the number of workdays between today and given date,\npassed as parameter");

        DateTime date;
        DateTime dateNow=DateTime.Now;
        string strNum;
        int workDays = 0;
        do
        {
            Console.Write("Enter a date in format dd.mm.yyyy: ");
        }
        while (!DateTime.TryParse(strNum = Console.ReadLine(), out date));
        if (date > dateNow)
        {
            workDays = WorkDaysFromNow(dateNow, date);
        }
        else
        { 
            workDays = WorkDaysFromNow(date, dateNow);
        }

            Console.WriteLine("Work days between {0:d} and {1:d}: {2}", dateNow, date, workDays);
    }
}
