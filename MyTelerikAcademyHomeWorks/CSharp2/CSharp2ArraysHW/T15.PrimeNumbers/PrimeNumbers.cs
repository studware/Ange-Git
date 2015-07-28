using System;
using System.Collections.Generic;
using System.Linq;

class primeNumbers
{
    static void Main()
    {
        Console.WriteLine("Find all prime numbers in the range [1...10 000 000]");
        int n = 10000000;
        var iterNum = 1;
        // Enumerable class provides methods for querying objects that implement IEnumerable<T>
        List<int> arr = Enumerable.Range(2, n-1).ToList();
 
        double k=Math.Sqrt(n);   //  The upper limit to check
        while (iterNum <= k)
        {
            int work = iterNum;
            int work2 = arr.First(i => i > work);   // return the first element i > work
            arr.RemoveAll(i => i != work2 && i % work2 == 0);   // remove all elements (i != work2 && i % work2 == 0)
            iterNum = work2;        // next iteration
        }
 
        // Print the result
        int[] arrOut = arr.ToArray();
        for (int i = 0; i < arrOut.Length; i++)
        {
            Console.WriteLine(arrOut[i]);
        }
    }
}