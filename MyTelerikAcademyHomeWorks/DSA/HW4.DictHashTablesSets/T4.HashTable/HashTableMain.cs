using System;
using System.Collections.Generic;

namespace T4.HashTable
{
    class HashTableMain
    {
        static void Main()
        {
            HashTable<string, string> hashTable = new HashTable<string, string>();
            hashTable.Add("1", "Apple");
            hashTable.Add("2", "Lemon");
            hashTable.Add("3", "Grapefruit");
            hashTable.Add("4", "Grape");
            hashTable.Add("5", "Tangerine");
            hashTable.Add("6", "Cherry");
            hashTable.Add("7", "Pumpkin");
            hashTable.Add("8", "Mango");
            hashTable.Add("9", "Banana");
            hashTable.Add("10", "Apricot");

            Console.WriteLine(hashTable.Find("8"));
            Console.WriteLine("Count: {0}", hashTable.Count);

            hashTable.Remove("2");
            Console.WriteLine("Count: {0}", hashTable.Count);
            Console.WriteLine(hashTable["5"]);

            Console.WriteLine("\nKeys: ");
            foreach (var item in hashTable.Keys)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("\nIteration with foreach:");
            foreach (var item in hashTable)
            {
                Console.WriteLine("{0}: {1}", item.Key, item.Value);
            }

        }
    }
}