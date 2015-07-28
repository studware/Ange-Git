using System;

class SubsSetSumFixedLength
{
    static void Main()
    {
        string inputVar;
        long n;
        Console.WriteLine("Find if there exists a subset of array arrayOflongs /nwith sum S and count of elements k");
        do
        {
            Console.Write("Enter array length: ");
        }
        while (!(long.TryParse(inputVar = Console.ReadLine(), out n)) || n == 0);

        long[] arrayOflongs = new long[n];

        Console.WriteLine("Enter the elements of the array:");
        for (int i = 0; i < n; i++)
        {
            arrayOflongs[i] = long.Parse(Console.ReadLine());
        }
        Console.WriteLine("Enter the sum value:");
        long sum = long.Parse(Console.ReadLine());
        Console.WriteLine("Enter the length value:");
        long k = long.Parse(Console.ReadLine());

        int cnt = 0;                                    // count of subsets with the given sum
        string sbsetSum = "";                           // the sum of the i-th subset prepared to be printed
        int sbsetSumsCnt = (int)Math.Pow(2, n) - 1;       // max count of sbsetSums for this array
        Console.WriteLine("Subsets with sum of {0} : ", sum);   // prepare for the output
        for (int i = 1; i <= sbsetSumsCnt; i++)             //iteration through all possible subsets (excluding 0 subset) 
        {
            sbsetSum = "";
            long tempSum = 0;                           // the sum of the i-th subset computed
            long kCnt = 0;
            for (int j = 0; j <= n; j++)
            {
                int mask = 1 << j;          // the bit mask of the j-th element in the binary number 
                int bit = (i & mask) >> j;  // apply the mask to the i-th subset, then shift it to the rightmost (zero) position
                if (bit == 1)               // check if the j-th element takes part in this subset (bit==1)
                {
                    tempSum = tempSum + arrayOflongs[j];            // yes, add the j-th element to the computed subset sum
                    sbsetSum = sbsetSum + " " + arrayOflongs[j];    // and prepare the output string
                    kCnt++;     //  increment the current subset elements' count
                }
            }
            // all input array elements processed for the current subset, now check if their sum is equal to the given sum: 
            if ((tempSum == sum) && (kCnt==k))
            {
                cnt++;      // increment the count of the subsets satisfying the condition
                Console.WriteLine(" {0} ", sbsetSum);    // print current subset
            }
        }
        Console.WriteLine("Count of subsets with the sum of {0}: {1}", sum, cnt);    // print count of subsets with sum =orresponding bit given sum 
    }
}
