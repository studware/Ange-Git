//  Implement a set of extension methods for IEnumerable<T> 
//  that implement the following group functions: sum, product, min, max, average.

namespace T1and2.Extensions
{
using System;
using System.Collections.Generic;

    public  static class IEnumerableExtension
    {
        public static T Sum<T> (this IEnumerable<T> collectionToSum) 
        {
            dynamic sum = 0;
            foreach (var item in collectionToSum)
            {
                sum += item;                
            }
            return sum;
        }
        
        public static T Product<T> (this IEnumerable<T> collectionToMultiply)
        {
            dynamic product = 1;
            foreach (var item in collectionToMultiply)
            {
                product*= item;
            }
            return product;
        }

        public static T Min<T>(this IEnumerable<T> collectionToFindMin) where T: IComparable<T>
        {
            dynamic min = (dynamic)double.MaxValue;
            foreach (var item in collectionToFindMin)
            {
                min=item < min ? item : min;
            }
            return min;
        }
        public static T Max<T>(this IEnumerable<T> collectionToFindMax) where T: IComparable<T>
        {
            dynamic max = (dynamic)double.MinValue;
            foreach (var item in collectionToFindMax)
            {
                max=item < max ? max : item;
            }
            return max;
        }
        
        public static int Count<T>(this IEnumerable<T> collectionToFindCount)
        {
            int count = 0;
            foreach (var item in collectionToFindCount)
            {
                count+=1;
            }
            return count;
        }

        public static double Average<T>(this IEnumerable<T> collectionToFindAverage)
        {
            dynamic cntDenominator = 1.0 / collectionToFindAverage.Count();
            double average = cntDenominator * collectionToFindAverage.Sum();
            return average;
        }
    }
}
