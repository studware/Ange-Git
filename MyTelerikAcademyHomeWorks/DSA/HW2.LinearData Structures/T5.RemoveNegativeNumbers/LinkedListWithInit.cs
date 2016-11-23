using System;
using System.Collections.Generic;

namespace T5.RemoveNegativeNumbers
{
    public class LinkedListWithInit<T> : LinkedList<T>
    {
        public void Add(T item)
        {
            ((ICollection<T>)this).Add(item);
        }
    }
}