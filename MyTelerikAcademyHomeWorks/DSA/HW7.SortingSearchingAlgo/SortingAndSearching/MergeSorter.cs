using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingAndSearching
{
    public class MergeSorter<T> : ISorter<T> where T : IComparable<T>
    {
        public void Sort(IList<T> collection)
        {
            collection = MergeSort(collection);
        }

        private IList<T> MergeSort(IList<T> list)
        {
            if (list.Count <= 1)
            {
                return list;
            }

            int middle = list.Count / 2;
            IList<T> left = new List<T>();
            for (int i = 0; i < middle; i++)
            {
                left.Add(list[i]);
            }
            IList<T> right = new List<T>();
            for (int i = 0; i < list.Count - middle; i++)
            {
                right.Add(list[i + middle]);
            }
            left = MergeSort(left);
            right = MergeSort(right);

            int leftptr = 0;
            int rightptr = 0;

            IList<T> sorted = new List<T>();
            for (int k = 0; k < list.Count; k++)
            {
                if (rightptr == right.Count || ((leftptr < left.Count) && (left[leftptr].CompareTo(right[rightptr]) <= 0)))
                {
                    sorted.Add(left[leftptr]);
                    leftptr++;
                }
                else if (leftptr == left.Count || ((rightptr < right.Count) && (right[rightptr].CompareTo(left[leftptr]) <= 0)))
                {
                    sorted.Add(right[rightptr]);
                    rightptr++;
                }
            }

            return list;
        }
    }
}
