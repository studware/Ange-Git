using System;
using System.Collections.Generic;
using System.Linq;

namespace T11.LinkedList
{
    class LinkedListMain
    {
        static void Main()
        {
            Console.WriteLine("Implement the data structure linked list.");
            Console.WriteLine("Define class ListItem<T> with two fields:\nvalue (of type T) and NextItem (of type ListItem<T>).");
            Console.WriteLine("Define additionally a class LinkedList<T> with a single field\nFirstElement (of type ListItem<T>).\n");

            LinkedList<int> myList = new LinkedList<int>();
            myList.Add(10);
            myList.Add(15);
            myList.Add(2);
            myList.Add(8);
            myList.Add(8);
            myList.Add(25);

            Console.WriteLine("The linked list:\n{0}", myList);
            myList.RemoveFirst();
            Console.WriteLine("The linked list after first element removed:\n{0}", myList);
        }
    }
}
