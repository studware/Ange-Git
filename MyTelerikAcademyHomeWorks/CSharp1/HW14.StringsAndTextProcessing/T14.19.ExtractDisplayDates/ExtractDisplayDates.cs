using System;
using System.Globalization;
using System.Text.RegularExpressions;

class ExtractDisplayDates
{
    static void Main()
    {
        Console.WriteLine("Extract all dates of format DD.MM.YYYY. Display in the standard date format for Canada.\n");

        string text = "Static void Main() 12.10.2012, 25.01.2012";

        DateTime date;
        foreach (Match item in Regex.Matches(text, @"\b\d{2}.\d{2}.\d{4}\b"))
            if (DateTime.TryParseExact(item.Value, "dd.MM.yyyy",
                CultureInfo.InvariantCulture, DateTimeStyles.None, out date))
            {
                Console.WriteLine(date.ToString(CultureInfo.GetCultureInfo("en-CA").DateTimeFormat.ShortDatePattern));
            }
    }
}