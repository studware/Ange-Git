//  Task 17

using System;
using System.Linq;

namespace T17.MaxLengthString
{
    public class MaxLengthString
    {
        public static int longestElement = 0;

        public static void Main()
        {
            Console.WriteLine("Random strings generated:");
            string[] stringArray = GenerateRandomStrings();

            string answerWithExtension = stringArray.Aggregate("", (max, current) => max.Length > current.Length ? max : current);

            Console.WriteLine("The string with maximum length:");

            Console.WriteLine("Answer with Extension:\n{0}",answerWithExtension);

            var answerWithQuery = from st in stringArray
                                  where GetLongerStr(st)
                                  select st;

            Console.WriteLine("Answer with Query:\n{0}",answerWithQuery.Last());
        }

        private static bool GetLongerStr(string str)
        {
            if (str.Length > longestElement)
            {
                longestElement = str.Length;
                return true;
            }
            return false;
        }

        private static string[] GenerateRandomStrings()
        {
            Random rnd = new Random();

            string[] array = new string[rnd.Next(20, 31)];

            for (int i = 0; i < array.Length; i++)
            {
                array[i] = new string((char)rnd.Next(65, 94), rnd.Next(1, 50));
                Console.WriteLine(array[i]);
            }
            Console.WriteLine();

            return array;
        }
    }
}
