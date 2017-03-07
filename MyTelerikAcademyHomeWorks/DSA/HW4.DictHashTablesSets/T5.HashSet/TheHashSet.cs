using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T5.HashSet
{
    public class TheHashedSet<T> : IEnumerable<T>
    {
        private TheHashTable<T, T> container;

        public int Count
        {
            get { return this.container.Count; }
            private set { }
        }

        public TheHashedSet(params T[] values)
        {
            this.container = new TheHashTable<T, T>();

            if (values != null)
            {
                for (int i = 0; i < values.Length; i++)
                {
                    this.container.Add(values[i], values[i]);
                }
            }
        }

        public void Add(T value)
        {
            this.container.Add(value, value);
        }

        public void Remove(T value)
        {
            this.container.Remove(value);
        }

        public T Find(T value)
        {
            T lookedValue = container.Find(value);

            return lookedValue;
        }

        public void Clear()
        {
            this.container = new TheHashTable<T, T>();
        }


        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (var item in this.container)
            {
                yield return item.Value;
            }
        }

        public void UnionWith(TheHashedSet<T> otherSet)
        {
            foreach (var item in otherSet)
            {
                if (!this.container.Contains(new KeyValuePair<T, T>(item, item)))
                {
                    this.container.Add(item, item);
                }
            }
        }

        public void IntersectWith(TheHashedSet<T> otherSet)
        {
            TheHashTable<T, T> otherTable = new TheHashTable<T, T>();
            foreach (var item in otherSet)
            {
                if (this.container.Contains(new KeyValuePair<T, T>(item, item)))
                {
                    otherTable.Add(item, item);
                }
            }

            this.container = otherTable;
        }
    }
}