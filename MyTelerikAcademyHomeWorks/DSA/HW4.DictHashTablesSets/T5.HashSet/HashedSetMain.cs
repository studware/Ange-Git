using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T5.HashSet
{
    class HashedSetMain
    {
        static void Main()
        {
            TheHashedSet<int> set = new TheHashedSet<int>(new int[] { 111, 1, 3, 5, 7, 12 });
            Console.WriteLine("Initial count: {0}", set.Count);
            set.Add(122);
            Console.WriteLine("Added element {0}", set.Find(122));
            Console.WriteLine("Count after 1 element added: {0}", set.Count);
            set.Remove(122);
            Console.WriteLine("Count after 1 element removed: {0}", set.Count);

            Console.WriteLine("Now the set is:");
            foreach (var item in set)
            {
                Console.WriteLine(item);
            }

            TheHashedSet<int> newSet = new TheHashedSet<int>(new int[] { 1, 3, 5, 7, 12, 2222 });

            newSet.UnionWith(set);
            Console.WriteLine("Union with another set:");
            foreach (var item in newSet)
            {
                Console.WriteLine(item);
            }

            newSet=new TheHashedSet<int>(new int[] { 1, 3, 5, 7, 12, 2222 });
            newSet.IntersectWith(set);
            Console.WriteLine("Intersection with another set:");
            foreach (var item in newSet)
            {
                Console.WriteLine(item);
            }
        }
    }
}