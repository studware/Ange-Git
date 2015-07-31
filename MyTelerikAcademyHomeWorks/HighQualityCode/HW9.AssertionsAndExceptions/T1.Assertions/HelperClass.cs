namespace T1.Assertions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    public static class HelperClass
    {
        public static bool IsArraySorted<T>(IEnumerable<T> arr) where T : IComparable<T>
        {
            if (arr.Count() > 0)
            {
                var firstElement = arr.First();
                return arr.Skip(1).All(x =>
                {
                    bool m = firstElement.CompareTo(x) < 0;
                    firstElement = x;
                    return m;
                });
            }
            else
            {
                return true;
            }
        }

        public static bool ValueExists<T>(IEnumerable<T> arr, T value) where T : IComparable<T>
        {
            return arr.Any(x => x.Equals(value));
        }

        public static bool IsMinValue<T>(IEnumerable<T> arr, T minValue, int startInd, int endInd) where T : IComparable<T>
        {
            return arr.Skip(startInd)
                .Take(endInd - startInd)
                .Min()
                .CompareTo(minValue) > -1;
        }
    }
}
