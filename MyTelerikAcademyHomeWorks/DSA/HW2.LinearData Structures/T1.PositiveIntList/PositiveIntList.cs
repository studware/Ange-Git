using System;
using System.Collections.Generic;
using System.Linq;

namespace T1.PositiveIntList
{
    class PositiveIntList
    {
        static void Main()
        {
            Console.WriteLine("Enter sequence of positive integer numbers wich ends when empty line entered.");
            Console.WriteLine("Calculate the sum and average of the sequence. Keep the sequence in List<int>.");
            Console.WriteLine("Enter positive integer numbers (or empty line for end):");
            string input="";
            int number;
            List<int> numList = new List<int>();
            input=Console.ReadLine();
            while(input!="")
            {
                if((int.TryParse(input, out number)==true)&&number>=0)
                {
                    numList.Add(number);
                    input=Console.ReadLine();
                }
                else
                {
                    Console.WriteLine("Please, enter only positive integer numbers (or empty line for end):");
                    input = Console.ReadLine();
                }                
            }

            int listCount=numList.Count;
            if(listCount==0)
                {
                 Console.WriteLine("The list is empty.");
                }
            else
                {
                Console.WriteLine("List of the {0} unsigned integer numbers you just entered:", listCount);
                int i=0;
                while(i < listCount-1)
                    {
                       Console.Write("{0}, ", numList[i]);
                       i++;
                    }
                Console.WriteLine(numList[listCount-1]);
                double sumOfNumbers = numList.Sum();
                Console.WriteLine("There sum is: {0}", sumOfNumbers);
                Console.WriteLine("The average is: {0}", sumOfNumbers/listCount);
                }
        }
    }
}
