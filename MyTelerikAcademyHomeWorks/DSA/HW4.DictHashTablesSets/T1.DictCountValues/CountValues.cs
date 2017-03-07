using System;
using System.Collections.Generic;

namespace T1.DictCountValues
{
    class CountValues
    {
        static void Main()
        {
            Console.WriteLine("Count in array of double values the number of occurrences of each value");
            IDictionary<double, int> valuesCount=new Dictionary<double, int>();
            double[] numbers = { 3, 4, 4, -2.5, 3, 3, 4, 3, -2.5 };

            foreach (var num in numbers)
            {
                int count = 1;
                if (valuesCount.ContainsKey(num))
                {
                    count = valuesCount[num] + 1;
                }
                valuesCount[num] = count;
            }
            Console.WriteLine("Value\t\tCount");
            foreach (var pair in valuesCount)
            {
                Console.WriteLine("{0}\t\t{1}",pair.Key,pair.Value);
            }
        }
    }
}
