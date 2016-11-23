using System;
using System.Collections.Generic;

namespace T2.StackReverseInts
{
    class StackReverseInts
    {
        static void Main()
        {
            Console.WriteLine("Read N integers from the console and reverse them using a stack");
            Console.WriteLine("Enter integer number (or empty line for end):");
            string input="";
            int number;
            Stack<int> numStack = new Stack<int>();
            Queue<int> numQueue = new Queue<int>();
            input=Console.ReadLine();
            while(input!="")
            {
                if((int.TryParse(input, out number)==true))
                {
                    numStack.Push(number);
                    numQueue.Enqueue(number);
                    input=Console.ReadLine();
                }
                else
                {
                    Console.WriteLine("Please, enter only integer numbers (or empty line for end):");
                    input = Console.ReadLine();
                }                
            }

            int count=numStack.Count;
            if(count==0)
                {
                    Console.WriteLine("No integer numbers were entered.");
                }
            else
                {
                    Console.WriteLine("You entered the following integer numbers: ");
                    int qIndex=0;
                    while(qIndex < count-1)
                        {
                           Console.Write("{0}, ", numQueue.Dequeue());
                           qIndex++;
                        }
                    Console.WriteLine(numQueue.Dequeue());

                    Console.WriteLine("Reversed output of the integer numbers: ");
                    int sIndex=0;
                    while (sIndex < count - 1)
                        {
                           Console.Write("{0} ", numStack.Pop());
                           sIndex++;
                        }
                Console.WriteLine(numStack.Pop());
                }
        }
    }
}