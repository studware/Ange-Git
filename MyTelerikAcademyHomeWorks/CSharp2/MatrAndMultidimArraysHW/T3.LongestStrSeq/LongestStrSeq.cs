using System;

class LongestStrSeq
{
    static void Main()
    {
        Console.WriteLine("Find the longest sequence of equal strings in a matrix N x M");

        //Console.Write("Enter number of rows of the matrix: ");
        //int rSize = int.Parse(Console.ReadLine());
        //Console.WriteLine("Enter number of columns of the matrix to be printed: ");
        //int cSize = int.Parse(Console.ReadLine());
        //string[,] matrix = new string[rSize, cSize];
        //Console.WriteLine("Enter the elements of the matrix to be printed: ");
        //for (int i = 0; i < rSize; i++)
        //{
        //    for (int j = 0; j < cSize; j++)
        //    {
        //        matrix[i, j] = Console.ReadLine();
        //    }
        //}

        string[,] matrix ={
                             {"ha", "fifi", "ho", "hi",},
                             {"fo", "ha", "hi", "xx",},
                             {"xxx", "ho","ha", "xx",},
                        };

        int rSize = matrix.GetLength(0);
        int cSize = matrix.GetLength(1);

        Console.WriteLine("\nOriginal matrix:");

        for (int row = 0; row < rSize; row++)
        {
            for (int col = 0; col < cSize; col++)
            {
                Console.Write("{0}\t", matrix[row, col]);
            }
            Console.WriteLine();
        }
        
        int seqRow = 0, seqCol = 0;
        int max = 0;
        int[, ,] dim3 = new int[rSize,cSize, 4];
        int dirX = 1;
        int dirY = 0;
        int LeftDiag = 3;
        int RightDiag = 2;

        for (int i = 0; i < rSize; ++i)
        {
            for (int j = 0; j < cSize; ++j)
            {
                for (int k = 0; k < 4; ++k)
                {
                    dim3[i, j, k] = 1;
                }

                if (i > 0 && matrix[i, j].Equals(matrix[i - 1, j]))
                {
                    dim3[i, j, dirY] = dim3[i - 1, j, dirY] + 1;
                }
                if (j > 0 && matrix[i, j].Equals(matrix[i, j - 1]))
                {
                    dim3[i, j, dirX] = dim3[i, j - 1, dirX] + 1;
                }
                if (i > 0 && j > 0 && matrix[i, j].Equals(matrix[i - 1, j - 1]))
                {
                    dim3[i, j, RightDiag] = dim3[i - 1, j - 1, RightDiag] + 1;
                }
                if (i > 0 && j < rSize - 1 && matrix[i, j].Equals(matrix[i - 1, j + 1]))
                {
                    dim3[i, j, LeftDiag] = dim3[i - 1, j + 1, LeftDiag] + 1;
                }

                for (int k = 0; k < 4; ++k)
                {
                    if (dim3[i, j, k] > max)
                    {
                        max = dim3[i, j, k];
                        seqRow = i;
                        seqCol = j;
                    }
                }
            }
        }

        Console.WriteLine("\nThe length of the longest sequence of equal strings is : " + max);
        Console.WriteLine("The string is: " + matrix[seqRow, seqCol]);
    }
}