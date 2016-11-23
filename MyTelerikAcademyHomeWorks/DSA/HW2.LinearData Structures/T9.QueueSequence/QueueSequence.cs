using System;
using System.Collections.Generic;

namespace T9.QueueSequence
{
    class QueueSequence
    {
        static void Main()
        {
            int firstElement = InputData();
            MakeSequence(firstElement, 50);
        }

/// <summary>
/// Prints the task; accepts the input data, checks it and if valid returns it; if not valid, loops until valid input  
/// </summary>
/// <returns>an integer number entered by the console</returns>
        private static int InputData()
        {
            Console.WriteLine("Given the sequence:\nS1=N; S2=S1+1; S3=2*S1+1; S4=S1+2; S5=S2+1; S6=2*S2+1; S7=S2+2;... ");
            Console.WriteLine("Using Queue<T> class print its first 50 members for given N.\n");

            Console.Write("Enter first element of the sequence: ");
            string input = "";
            int firstElement;
            do
            {
                input = Console.ReadLine();
            }
            while (!int.TryParse(input, out firstElement));

            return firstElement;
        }
/// <summary>
/// Generates a sequence S1=N; S2=S1+1; S3=2*S1+1; S4=S1+2; S5=S2+1; S6=2*S2+1; S7=S2+2;... using Queue<T> class and prints it
/// </summary>
/// <param name="firstElem">The first element of the sequence</param>
/// <param name="count">The count of elements to be generated and printed</param>
        public static void MakeSequence(int firstElem, int count)
        {
            Queue<int> genericElements = new Queue<int>();
            int n = (count - 1) / 3;
            genericElements.Enqueue(firstElem);
            Console.WriteLine("The first 50 elements of the sequence:\n{0,4}", firstElem);
            for (int i = 0; i < n; i++)
            {
                int seed = genericElements.Dequeue();
                int item1 = seed + 1;
                genericElements.Enqueue(item1);
                int item2 = 2 *seed + 1;
                genericElements.Enqueue(item2);
                int item3 = seed + 2;
                genericElements.Enqueue(item3);
                Console.Write("{0,4}, {1,4}, {2,4}\n", item1, item2, item3);
             }
            int residue = (count - 1) % 3;  //let's fill the sequence to its end
            //  after the (1+count/3)-th element is dequeued, there'll still be elements in the queue
            int lastSeed=genericElements.Dequeue();
            switch (residue)
            {
                case 1:
                    Console.Write("{0,4}\n", lastSeed+1);
                    break;
                case 2:
                    Console.Write("{0,4}, {1,4}\n", lastSeed + 1, (2 * lastSeed + 1));
                    break;
                case 0:
                default:
                    break;
            }
        }
    }
}
