using System;
using System.Collections.Generic;

namespace T2.OddCountValues
{
    class OddCountValues
    {
        static void Main()
        {
            Console.WriteLine("Extract from given sequence of strings all elements that occur odd times\n");
            IDictionary<string, int> stringsCount = new Dictionary<string, int>();
            string[] str = { "C#", "SQL", "PHP", "PHP", "SQL", "SQL" };

            foreach (var s in str)
            {
                int count = 1;
                if (stringsCount.ContainsKey(s))
                {
                    count = stringsCount[s] + 1; 
                }

                stringsCount[s] = count;
            }
            Console.Write("Strings that occur odd number of times:\n\n{ ");
            bool hasOdd = false;
            foreach (KeyValuePair<string,int> c in stringsCount)
            {
                if (((int)c.Value)%2!=0)
	            {
		            Console.Write("{0}, ", c.Key);
                    hasOdd = true;
	            }
            }
            Console.WriteLine("}\n");
            if (!hasOdd)
            {
            Console.WriteLine("No such strings!\n");                    
            }
        }
    }
}
