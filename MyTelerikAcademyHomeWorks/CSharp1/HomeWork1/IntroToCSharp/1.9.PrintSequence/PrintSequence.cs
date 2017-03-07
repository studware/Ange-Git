using System;

class PrintSequence
{
    static void Main()
    {
        int signFlag = 1;     // the flag to reverce the sign
        int seqMem;         // the member of the sequence

        for (seqMem = 2; seqMem <= 10; seqMem++)
        {
            Console.Write(" " + signFlag * seqMem + ",");
            signFlag = -signFlag;
        }
        Console.WriteLine(" " + signFlag * seqMem);
    }
}
