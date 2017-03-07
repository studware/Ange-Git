using System;

class SpiralNumbers
{
    static void Main()
    {
        string strNum;
        int n;
        do
        {
            Console.Write("Please, enter an unsigned integer number 0 < N < 20: ");
        }
        while ((!int.TryParse(strNum = Console.ReadLine(), out n)) || n <= 0 || n >= 20);
        int i=n;
        int j=n;
        int[,] spiralMatrix = new int[n,n];
        int final=n*n; 
        int rowStart = 0;
        int rowEnd = n-1;
        int colStart=0;
        int colEnd=n-1;
        int current = 0;
        spiralMatrix[0,0]=0;
        string dir="right";
        do
        {
            switch (dir)
            {
                case "right":
                    for (j = colStart; j <= colEnd; j++)
                    {
                        current++;
                        spiralMatrix[rowStart, j] =current;
                    }
                    dir = "down";
                    rowStart++;
                    break;
                case "down":
                    for (i = rowStart; i <= rowEnd; i++)
                    {
                        current++;
                        spiralMatrix[i, colEnd] = current;
                    }
                    dir = "left";
                    colEnd--;
                    break;
                case "left":
                    for (j = colEnd; j >= colStart; j--)
                    {
                        current++;
                        spiralMatrix[rowEnd, j] = current;
                    }
                    dir = "up";
                    rowEnd--;
                    break;
                case "up":
                    for (i = rowEnd; i >= rowStart; i--)
                    {
                        current++;
                        spiralMatrix[i, colStart] = current;
                    }
                    dir = "right";
                    colStart++;
                    break;
                default:
                    Console.WriteLine("Unknown error");
                    break;
            }
        } while (current < final);
        for (i = 0; i < n; i++)
        {
            for (j = 0; j < n; j++)
            {
                Console.Write("{0,3} ", spiralMatrix[i,j]);
            }
            Console.WriteLine();
        }
    }
}