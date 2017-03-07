using System;
using System.Collections.Generic;

namespace SortingAndSearching
{
    public interface ISorter<T> where T : IComparable<T>
    {
        void Sort(IList<T> collection);
    }
}
