using System;
using System.Collections.Generic;

namespace T3.IntListSorted
{
    class IntListSorted
    {
        static void Main()
        {
            Console.WriteLine("Read sequence of integers (List<int>) ending with empty line.");
            Console.WriteLine("Sort them in an increasing order.");
            Console.WriteLine("Enter integer numbers (or empty line for end):");
            string input = "";
            int number;
            List<int> numList = new List<int>();
            input = Console.ReadLine();
            while (input != "")
            {
                if ((int.TryParse(input, out number) == true))
                {
                    numList.Add(number);
                    input = Console.ReadLine();
                }
                else
                {
                    Console.WriteLine("Please, enter only positive integer numbers (or empty line for end):");
                    input = Console.ReadLine();
                }
            }

            int listCount = numList.Count;
            if (listCount == 0)
            {
                Console.WriteLine("The list is empty.");
            }
            else
            {
                int count = 0;
                
                Console.WriteLine("List of the integer numbers you entered: ");
                while (count < listCount)
                {
                    Console.Write("{0} ", numList[count]);
                    count++;
                }

                numList.Sort();
                count = 0;
                Console.WriteLine("\nList of integer numbers, sorted: ", listCount);
                while (count < listCount)
                {
                    Console.Write("{0} ", numList[count]);
                    count++;
                }
                Console.WriteLine();
            }
        }
    }
}
