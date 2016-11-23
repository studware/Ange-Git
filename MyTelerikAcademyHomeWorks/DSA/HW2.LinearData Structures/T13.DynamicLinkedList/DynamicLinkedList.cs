using System;
using System.Collections.Generic;
using System.Linq;

namespace T13.DynamicLinkedList
{
    class DynamicLinkedList
    {
        static void Main()
        {
            Console.WriteLine("Implement the ADT queue as dynamic linked list.");
            Console.WriteLine("Use generics (LinkedQueue<T>) to store different data types.\n");
            
            MyQueue testQueue = new MyQueue();

            testQueue.Enqueue("Barbequeue");
            testQueue.Enqueue(256);
            testQueue.Enqueue(38.59);

            Console.WriteLine("Let's print the contents of the queue:");
            Console.WriteLine("{0}", testQueue);
            Console.WriteLine("\nNow let's dequeue until empty queue.");
            Console.WriteLine("The queue elements are:");


            var element = testQueue.Dequeue();

            while (element != null)
            {
                Console.WriteLine(element);
                element = testQueue.Dequeue();
            }
        }
    }
}
