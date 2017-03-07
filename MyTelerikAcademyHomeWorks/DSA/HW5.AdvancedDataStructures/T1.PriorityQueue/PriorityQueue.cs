using System;
using System.Linq;
using System.Collections.Generic;
using Wintellect.PowerCollections;
 
namespace T1.PriorityQueue
{
    class PriorityQueue<T> where T : IComparable<T>
    {
        private readonly List<T> elements = new List<T>();
 
        public int Count
        {
            get { return this.elements.Count; }
        }
 
        public void Enqueue(T value)
        {
            this.elements.Add(value);
 
            for (int i = this.Count - 1; this.HasParent(i); i = this.ParentIndex(i))
            {
                if (this.elements[this.ParentIndex(i)].CompareTo(this.elements[i]) > 0)
                {
                    this.Swap(i, this.ParentIndex(i));
                }
                else break;
            }
        }
 
        public T Dequeue()
        {
            var result = this.Peek();
            this.elements[0] = this.elements[this.Count - 1];
            this.elements.RemoveAt(this.Count - 1);
            for (int i = 0, smallerChild; this.HasLeftChild(i); i = smallerChild)
            {
                smallerChild = this.LeftIndex(i);
                if (this.HasRightChild(i) && this.elements[this.LeftIndex(i)].CompareTo(this.elements[this.RightIndex(i)]) > 0)
                {
                    smallerChild = this.RightIndex(i);
                }
                if (this.elements[i].CompareTo(this.elements[smallerChild]) > 0)
                {
                    this.Swap(i, smallerChild);
                }
                else break;
            }
 
            return result;
        }
 
        private bool HasParent(int i)
        {
            return i > 0;
        }
 
        private int ParentIndex(int i)
        {
            return (i - 1) / 2;
        }
 
        private int LeftIndex(int i)
        {
            return (i * 2) + 1;
        }
 
        private int RightIndex(int i)
        {
            return (i * 2) + 2;
        }
 
        private bool HasLeftChild(int i)
        {
        return this.LeftIndex(i) < this.Count;
        }
 
        private bool HasRightChild(int i)
        {
            return this.RightIndex(i) < this.Count;
        }
 
        private void Swap(int i, int j)
        {
            T prev = this.elements[i];
            this.elements[i] = this.elements[j];
            this.elements[j] = prev;
        }
 
        public T Peek()
        {
            return this.elements[0];
        }
 
        public ICollection<T> Flush()
        {
            var result = new List<T>();
 
            while (this.Count != 0)
            result.Add(this.Dequeue());
 
            return result;
        }
    }
}