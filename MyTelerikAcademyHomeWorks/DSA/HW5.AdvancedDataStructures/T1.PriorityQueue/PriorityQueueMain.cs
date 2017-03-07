using System;
using System.Linq;
using System.Collections.Generic;
using Wintellect.PowerCollections;

namespace T1.PriorityQueue     
{
    class PriorityQueueMain
    {
        public static void Main()
        {
            Console.WriteLine("Implement a class PriorityQueue<T> based on the data structure 'binary heap'\n");
        //    var items = new[] { "g", "d", "f", "e", "t", "c", "b" };
            var items = new[] { "27", "36", "-2", "8", "18", "0" };
            Console.Write("Initial data: ");
            foreach (var item in items)
            {
                Console.Write(" {0}", item);
            }

            var queue = new PriorityQueue<string>();
            var bag = new OrderedBag<string>();
            var list = new List<string>();

            foreach (var item in items)
            {
                queue.Enqueue(item);
                bag.Add(item);
                list.Add(item);
            }

            Console.WriteLine("\nResults:\nPriority Queue: " + string.Join(" ", queue.Flush()));
            Console.WriteLine("Ordered Bag: " + string.Join(" ", bag));
            Console.WriteLine("List after OrderBy: " + string.Join(" ", list.OrderBy(x => x)));
            list.Sort();
            Console.WriteLine("List after Sort: " + string.Join(" ", list));
        }
    }
}
