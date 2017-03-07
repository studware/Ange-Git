using System;
using System.Collections.Generic;
using System.Linq;

namespace SortingAndSearching
{
    public class SortableCollection<T> where T : IComparable<T>
    {
        private readonly IList<T> items;
        private Random rand = new Random();

        public SortableCollection()
        {
            this.items = new List<T>();
        }

        public SortableCollection(IEnumerable<T> items)
        {
            this.items = new List<T>(items);
        }

        public IList<T> Items
        {
            get
            {
                return this.items;
            }
        }

        public void Sort(ISorter<T> sorter)
        {
            sorter.Sort(this.items);
        }

        public bool LinearSearch(T item)
        {
            foreach (var element in items)
            {
                if (element.Equals(item))
                {
                    return true;
                }
            }
            return false;
        }

        public bool BinarySearch(T item)
        {
            Sort(new MergeSorter<T>());
            int MaxElement = items.Count - 1;
            int MinElement = 0;
            while (MaxElement.CompareTo(MinElement) > 0)
            {
                int Midpoint = (MinElement + MaxElement) / 2;
                if (items[Midpoint].CompareTo(item) < 0)
                {
                    MinElement = Midpoint + 1;
                }
                else if (items[Midpoint].CompareTo(item) > 0)
                {
                    MaxElement = Midpoint - 1;
                }
                else
                {
                    return true;
                }
            }
            return false;
        }

        public void Shuffle()
        {
            int n = items.Count;
            for (var i = 0; i < n; i++)
            {
                // Exchange a[i] with random element in a[i..n-1]
                int r = i + rand.Next(0, n - i);
                var temp = items[i];
                items[i] = items[r];
                items[r] = temp;
            }
        }

        public void PrintAllItemsOnConsole()
        {
            for (int i = 0; i < this.items.Count; i++)
            {
                if (i == 0)
                {
                    Console.Write(this.items[i]);
                }
                else
                {
                    Console.Write(" " + this.items[i]);
                }
            }

            Console.WriteLine();
        }
    }
}
