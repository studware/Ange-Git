using System;
using System.Globalization;

class PrintDateBG
{
    static void Main()
    {
        Console.WriteLine("Print date and time after 6h 30min and the day of week in Bulgarian\n");

        string dateStr = "24.01.2013 23:00:00";
        Console.WriteLine("Date and time given: {0}", dateStr);

        DateTime dateParsed = DateTime.ParseExact(dateStr, "dd.MM.yyyy HH:mm:ss", CultureInfo.InvariantCulture);

        dateParsed = dateParsed.AddHours(6.5);

        Console.WriteLine("{0} {1}", dateParsed.ToString("dddd", new CultureInfo("bg-BG")), dateParsed);
    }
}