/*  
    Define a class InvalidRangeException<T> that holds information about an error condition related to invalid range.
    It should hold error message and a range definition [start … end].
    Write a sample application that demonstrates the InvalidRangeException<int> and InvalidRangeException<DateTime> 
    by entering numbers in the range [1..100] and dates in the range [1.1.1980 … 31.12.2013].   */

namespace T3.RangeExceptions
{
using System;

    class RangeExceptions
    {
        static void Main()
        {
            int checkedValue = 125;
            DateTime date = DateTime.MinValue;

            try
            {
                int startValue = 1;
                int endValue = 100;

                if (!(startValue < checkedValue && checkedValue < endValue))
                    throw new InvalidRangeException<int>(startValue, endValue);
            }

            catch (InvalidRangeException<int> re)
            {
                Console.WriteLine("{0} of integer number {1}", re.Message, checkedValue);
                Console.WriteLine("Range start: {0}; end {1};", re.StartValue, re.EndValue);
            }

            Console.WriteLine();

            try
            {
                DateTime startDate = new DateTime(2020, 1, 1);
                DateTime endDate = new DateTime(2050, 12, 31);

                if (!(startDate < date && date < endDate))
                    throw new InvalidRangeException<DateTime>(startDate, endDate);
            }

            catch (InvalidRangeException<DateTime> re)
            {
                Console.WriteLine("{0} of date and time: {1}", re.Message, date);
                Console.WriteLine("Range start: {0}; end {1};", re.StartValue, re.EndValue);
            }
        }
    }
}
