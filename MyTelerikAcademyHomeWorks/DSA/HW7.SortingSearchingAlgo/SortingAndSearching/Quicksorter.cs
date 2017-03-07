using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingAndSearching
{
    public class Quicksorter<T> : ISorter<T> where T : IComparable<T>
    {
        public void Sort(IList<T> collection)
        {
            QuickSort(collection, 0, collection.Count - 1);
        }

        private void QuickSort(IList<T> elements, int left, int right)
        {
            int i = left, j = right;
            T middle = elements[(left + right) / 2];

            // if you want to see whole process
            //for (int k = 0; k < elements.Length; k++)
            //{
            //    Console.Write(elements[k] + " ");
            //}
            //Console.Write("\"{0}\"", middle);
            //Console.WriteLine();

            while (i <= j)
            {
                while (elements[i].CompareTo(middle) < 0)
                {
                    i++;
                }

                while (elements[j].CompareTo(middle) > 0)
                {
                    j--;
                }

                if (i <= j)
                {
                    T tmp = elements[i];
                    elements[i] = elements[j];
                    elements[j] = tmp;

                    i++;
                    j--;
                }
            }

            // Recursive calls
            if (left < j)
            {
                QuickSort(elements, left, j);
            }

            if (i < right)
            {
                QuickSort(elements, i, right);
            }
        }
    }
}
