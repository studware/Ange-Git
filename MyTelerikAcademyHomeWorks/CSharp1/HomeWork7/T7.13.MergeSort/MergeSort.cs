using System;
class MergeSort
{
    static void MergeSortInt(int arrLen, int[] arrInt)
    {
        int cnt = arrLen;
        if (cnt == 2)       
        {
            int tmp;
            if (arrInt[0] > arrInt[1])
            {
                tmp = arrInt[0];
                arrInt[0] = arrInt[1];
                arrInt[1] = tmp;
            }
        }
        else if (cnt > 2)                     
        {
            cnt = arrLen / 2;
            int[] leftSide = new int[cnt];
            int[] rightSide = new int[cnt + 1];
            for (int i = 0; i < cnt; i++)
            {
                leftSide[i] = arrInt[i];
            }
            for (int i = cnt; i < arrLen; i++)
            {
                rightSide[i - cnt] = arrInt[i];
            }

            MergeSortInt(cnt, leftSide);
            MergeSortInt(arrLen - cnt, rightSide);

            int leftIndx = 0;                                       
            int rightIndx = 0;
            while ((leftIndx + rightIndx) < arrLen)
            {
            if (leftIndx == cnt)
                arrInt[leftIndx + rightIndx] = rightSide[rightIndx++];
            else if (rightIndx == (arrLen-cnt))
                arrInt[leftIndx + rightIndx] = leftSide[leftIndx++];
            else
                arrInt[leftIndx + rightIndx] = (leftSide[leftIndx] < rightSide[rightIndx]? leftSide[leftIndx++]: rightSide[rightIndx++]);
 
            }
        }
    }

    static void Main()
    {
        Console.WriteLine("Sort an array of integers using the MergeSort algorithm");
        Console.Write("Enter array length: ");
        int n = int.Parse(Console.ReadLine());
        Console.WriteLine("Enter the array elements: ");
        int[] arrOfInt = new int[n];
        for (int i = 0; i < n; i++)
        {
            arrOfInt[i] = int.Parse(Console.ReadLine());
        }

        MergeSortInt(n, arrOfInt);

        Console.WriteLine("The sorted array is:");
        for (int i = 0; i < n; i++)
        {
            Console.Write("{0} ",arrOfInt[i]);
        }
        Console.WriteLine();
    }
}
