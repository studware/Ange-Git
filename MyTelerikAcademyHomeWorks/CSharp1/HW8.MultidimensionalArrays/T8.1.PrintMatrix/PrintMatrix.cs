using System;
     
    class PrintmatrixToPrint
    {
        static void Main()
        {
            Console.WriteLine("Fill and print a matrix of size (n, n) in 4 ways");
            Console.Write("Enter size of the matrix to be printed: ");
            int mSize = int.Parse(Console.ReadLine());
            int[,] matrixToPrint = new int[ mSize,  mSize];

            int element = 1;

            Console.WriteLine("\nTask a:");
            for (int col = 0; col <  mSize; col++)
            {
                for (int row = 0; row <  mSize; row++)
                {
                    matrixToPrint[row, col] = element;
                    element++;
                }
            }
            for (int row = 0; row < mSize; row++)
            {
                for (int col = 0; col <  mSize; col++)
                {
                    Console.Write("{0,4}", matrixToPrint[row, col]);
                }
                Console.WriteLine();
            }

            element = 1;
            Console.WriteLine("\nTask b: ");
            for (int col = 0; col <  mSize; col++)
            {
                if (col % 2 == 0)
                {
                    for (int row = 0; row <  mSize; row++)
                    {
                        matrixToPrint[row, col] = element;
                        element++;
                    }
                }
                else
                {
                    for (int row =  mSize - 1; row >= 0; row--)
                    {
                        matrixToPrint[row, col] = element;
                        element++;
                    }
                }
            }
     
            for (int row = 0; row <  mSize; row++)
            {
                for (int col = 0; col <  mSize; col++)
                {
                    Console.Write("{0,4}", matrixToPrint[row, col]);
                }
                Console.WriteLine();
            }
            Console.WriteLine();
     
            element = 1;
            Console.WriteLine("\nTask c: ");
            for (int row = 0; row <=  mSize - 1; row++)
            {
                for (int col = 0; col <= row; col++)
                {
                    matrixToPrint[ mSize - row + col - 1, col] = element;
                    element++;
                }
            }
     
            for (int row =  mSize - 2; row >= 0; row--)
            {
                for (int col = row; col >= 0; col--)
                {
                    matrixToPrint[row - col,  mSize - col - 1] = element;
                    element++;
                }
            }
     
            for (int row = 0; row <  mSize; row++)
            {
                for (int col = 0; col <  mSize; col++)
                {
                    Console.Write("{0,4}", matrixToPrint[row, col]);
                }
                Console.WriteLine();
            }
     
            element = 1;
            int end= mSize;
            int start=0;
            Console.WriteLine("\nTask d:");
            do
            {
                for (int row = start; row < end; row++)
                {
                    matrixToPrint[row, start] = element;
                    element++;
                }
                for (int col = start + 1; col < end; col++)
                {
                    matrixToPrint[end-1, col] = element;
                    element++;
                }
                for (int row = end - 2; row >= start; row--)
                {
                    matrixToPrint[row, end - 1] = element;
                    element++;
                }
     
                for (int col = end - 2; col >= start + 1; col--)
                {
                    matrixToPrint[start, col] = element;
                    element++;
                }
                start++;
                end--;
            }          
            while (end - start > 0);
            for (int row = 0; row <  mSize; row++)
            {
                for (int col = 0; col <  mSize; col++)
                {
                    Console.Write("{0,4}", matrixToPrint[row, col]);
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
    }
