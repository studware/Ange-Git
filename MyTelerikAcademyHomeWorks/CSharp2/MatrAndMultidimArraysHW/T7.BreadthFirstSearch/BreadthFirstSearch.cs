using System;

class BreadthFirstSearch
{
    public static int maxBranchLength = 0;
    public static int currentBranchLength = 0;

    public static void PrintMatrix(string[,] rectMatrix)
    {
        int maxLength = 0;
        foreach (string element in rectMatrix)
        {
            if (element.Length > maxLength) maxLength = element.Length;
        }
        for (int i = 0; i < rectMatrix.GetLength(0); i++)
        {
            for (int j = 0; j < rectMatrix.GetLength(1); j++)
            {
                Console.Write("{0} ", rectMatrix[i, j].PadLeft(rectMatrix[i, j].Length +
                    (maxLength - rectMatrix[i, j].Length) / 2).PadRight(maxLength));
            }
            Console.WriteLine();
        }
    }

    public static void SearchBranch(string[,] rectMatrix, int i, int j)
    {
        string elemValue = rectMatrix[i, j];
        rectMatrix[i, j] = " ";
        currentBranchLength++;
        for (int concat = -1; concat <= 1; concat += 2)
        {
            if (IsValid(rectMatrix, i + concat, j) && rectMatrix[i + concat, j] == elemValue)
            {
                SearchBranch(rectMatrix, i + concat, j);
            }
            if (IsValid(rectMatrix, i, j + concat) && rectMatrix[i, j + concat] == elemValue)
            {
                SearchBranch(rectMatrix, i, j + concat);
            }
        }
    }

    public static bool IsValid(string[,] rectMatrix, int a, int b)
    {
        return a >= 0 && a < rectMatrix.GetLength(0) && b >= 0 && b < rectMatrix.GetLength(1);
    }

    static void Main()
    {
        System.Console.WriteLine("Finds largest area of equal neighbor elements \nin a rectangular matrix and prints its size");
        //Console.Write("Enter row size: ");
        //int row = int.Parse(Console.ReadLine());
        //Console.Write("Enter column size: ");
        //int col = int.Parse(Console.ReadLine());
        //string[,] rectMatrix = new string[row, col];
        //Console.WriteLine("Enter values of the matrix");
        //for (int i = 0; i < row; i++)
        //{
        //    for (int j = 0; j < col; j++)
        //    {
        //        rectMatrix[i, j] = Console.ReadLine();
        //    }
        //}


        string[,] rectMatrix = {
                             {"1", "3", "2", "2", "2", "4",},
                             {"3", "3", "3", "2", "4", "4",},
                             {"4", "3", "1", "2", "3", "3",},
                             {"4", "3", "1", "3", "3", "1",},
                             {"4", "3", "3", "3", "1", "1",},
                             
                        };

        Console.WriteLine("Source matrix:");
        PrintMatrix(rectMatrix);
        Console.WriteLine();

        for (int i = 0; i < rectMatrix.GetLength(0); i++)
        {
            for (int j = 0; j < rectMatrix.GetLength(1); j++)
            {
                if (rectMatrix[i, j] != " ")
                {
                    currentBranchLength = 0;
                    SearchBranch(rectMatrix, i, j);
   //               Current branch length ready
                    if (currentBranchLength > maxBranchLength)
                    {
                        maxBranchLength = currentBranchLength;
                    }
                }
            }
        }
        Console.WriteLine("maxBranchLength = {0}", maxBranchLength);
    }
}
