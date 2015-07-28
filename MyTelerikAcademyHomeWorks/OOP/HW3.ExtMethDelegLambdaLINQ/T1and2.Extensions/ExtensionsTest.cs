using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T1and2.Extensions
{
    class ExtensionsTest
    {
        static void Main()
        {
            //  Task 1
            StringBuilder sb = new StringBuilder();
            sb.Append("Winnie the Pooh, Winnie the Pooh, ");
            sb.Append("A tubby, little cubby all stuffed with fluff. "); 
            sb.Append("He's Winnie the Pooh, Winnie the Pooh, ");
            sb.Append(" A willy, nilly, silly old bear.");
            Console.WriteLine("StringBuilder Substring Extension method - original text:\n{0}",sb);

            Console.WriteLine("\nThe 62-length substring starting at the 18th character:\n{0}", sb.Substring(17, 62));

            //  Task2
            Console.WriteLine("\nEnumerable items:\n");
//            int[] sampleCollection = new int[]{1,34,2,55,7,8,2,9,5,36};
            int[] sampleCollection = new int[]{1,2,2,2,2,1,2,1,1,10};
            for (int i = 0; i < sampleCollection.Length; i++)
            {
                Console.Write("{0} ", sampleCollection[i]); 
            }
            Console.WriteLine();
            Console.WriteLine("Their sum is: {0}", sampleCollection.Sum());
            Console.WriteLine("Their product is: {0}", sampleCollection.Product());
            Console.WriteLine("Their minimum value is: {0}", sampleCollection.Min());
            Console.WriteLine("Their maximum value is: {0}", sampleCollection.Max());
            Console.WriteLine("Their count is: {0}", sampleCollection.Count());
            Console.WriteLine("Their average is: {0}", sampleCollection.Average());
        }
    }
}
