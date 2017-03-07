﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace T1.Algo1.FriendsInNeed
{
    public class PriorityQueue<T> where T : IComparable<T>
    {
        private BinaryHeap<T> heap;

        public PriorityQueue()
        {
            this.heap = new BinaryHeap<T>();
        }

        public int Count
        {
            get
            {
                return this.heap.Count;
            }
        }

        public void Enqueue(T element)
        {
            this.heap.Add(element);
        }

        public T Peek()
        {
            return this.heap.Peek();
        }

        public T Dequeue()
        {
            var element = this.heap.Remove();
            return element;
        }
    }
}
