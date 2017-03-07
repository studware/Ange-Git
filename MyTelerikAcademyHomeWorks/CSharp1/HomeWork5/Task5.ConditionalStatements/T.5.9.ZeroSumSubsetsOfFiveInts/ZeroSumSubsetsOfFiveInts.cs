using System;
class ZeroSumSubsetsOfFiveInts
{
    static void Main()
    {
        Console.WriteLine("Please enter five integer numbers (on separate lines:)");
        int[] varNum = new int[5];
        int i;
        int j;
        int k;
        int m;
        bool hasZeroSums = false;
        for (i = 0; i < 5; i++)
        {
            varNum[i] = int.Parse(Console.ReadLine());
        }
        Console.WriteLine("The sums of the following subsets are equal to 0:");
        for (i = 0; i < 5; i++)
        {
            if (varNum[i] == 0)
            {
                hasZeroSums = true;
                Console.WriteLine(varNum[i]);
            }
        }
        for (i = 0; i < 4; i++)
        {
            for (j = i + 1; j < 5; j++)
            {
                if ((varNum[i] + varNum[j]) == 0)
                {
                    hasZeroSums = true;
                    Console.WriteLine("{0} \t {1}", varNum[i], varNum[j]);
                }
            }
        }
        for (i = 0; i < 3; i++)
        {
            for (j = i + 1; j < 4; j++)
            {
                for (k = j + 1; k < 5; k++)
                {
                    if ((varNum[i] + varNum[j] + varNum[k]) == 0)
                    {
                        hasZeroSums = true;
                        Console.WriteLine("{0} \t {1} \t {2}", varNum[i], varNum[j], varNum[k]);
                    }
                }

            }
        }
        for (i = 0; i < 2; i++)
        {
            for (j = i + 1; j < 3; j++)
            {
                for (k = j + 1; k < 4; k++)
                {
                    for (m = k + 1; m < 5; m++)
                    {
                        if ((varNum[i] + varNum[j] + varNum[k] + varNum[m]) == 0)
                        {
                            hasZeroSums = true;
                            Console.WriteLine("{0} \t {1} \t {2} \t {3}", varNum[i], varNum[j], varNum[k], varNum[m]);
                        }
                    }
                }

            }
        }
        if ((varNum[0] + varNum[1] + varNum[2] + varNum[3] + varNum[4]) == 0)
        {
            hasZeroSums = true;
            Console.WriteLine("{0} \t {1} \t {2} \t {3} \t {4}", varNum[0], varNum[1], varNum[2], varNum[3], varNum[4]);
        }
        if (hasZeroSums == false)
        {
            Console.WriteLine();
            Console.WriteLine("There are NOT zero sum subsets in this set.");
        }
    }
}