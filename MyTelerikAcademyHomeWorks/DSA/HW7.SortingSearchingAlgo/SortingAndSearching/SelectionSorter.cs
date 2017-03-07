using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingAndSearching
{
    public class SelectionSorter<T> : ISorter<T> where T : IComparable<T>
    {
        public void Sort(IList<T> collection)
        {
            int min;
            for (int i = 0; i < collection.Count - 1; i++)
            {
                min = i;
                for (int j = i + 1; j < collection.Count; j++)
                {
                    if (collection[j].CompareTo(collection[min]) < 0)
                    {
                        min = j;
                    }
                }

                T temp = collection[i];
                collection[i] = collection[min];
                collection[min] = temp;
            }
        }
    }
}
