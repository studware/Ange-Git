using System;

class IntsInStringSum
{
    static void Main()
    {
        Console.WriteLine("Read  positive integer values written into string, separated by spaces,\nand calculate their sum");
        
        string intVal = "   43 68 9 23 318 10   ";
        int sum = 0;
        intVal = intVal.Trim();
        string[] posInts = intVal.Split(' ');
        for (int i = 0; i < posInts.Length; i++)
        {
            sum = sum + int.Parse(posInts[i]);
        }
        Console.WriteLine(sum);
    }
}

