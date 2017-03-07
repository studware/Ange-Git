using System;

class MaxSum3x3Platform
{
    static void Main()
    {
/*      int[,] matrix = {
                          {7, 1, 3, 3, 2, 1},
                          {1, 3, 9, 8, 5, 6},
                          {4, 6, 7, 9, 1, 0} };
*/
        Console.WriteLine("Read rectangular matrix size N x M, find in it 3 x 3 square with max sum of its elements");
        Console.Write("Enter number of rows of the matrix to be printed: ");
        int rSize = int.Parse(Console.ReadLine());
        Console.Write("Enter number of columns of the matrix to be printed: ");
        int cSize = int.Parse(Console.ReadLine());
        int[,] matrix = new int[rSize, cSize];
        Console.Write("Enter the elements of the matrix to be printed: ");
        for (int i = 0; i < rSize; i++)
        {
            for (int j = 0; j < cSize; j++)
            {
                matrix[i,j]=int.Parse(Console.ReadLine());
            }  
        }
      
        int bestSum = int.MinValue;
        int rStart=0;
        int cStart=0;
        for (int row = 0; row < rSize - 2; row++)
        {
            for (int col = 0; col < cSize - 2; col++)
            {
                int sum = matrix[row, col] + matrix[row, col + 1] + matrix[row, col + 2] + matrix[row + 1, col]
                    + matrix[row + 1, col + 1] + matrix[row + 1, col + 2] + matrix[row + 2, col]
                    + matrix[row + 2, col + 1] + matrix[row + 2, col + 2];
                if (sum > bestSum)
                {
                    bestSum = sum;
                    rStart = row;
                    cStart = col;
                }
            }
        }
        Console.WriteLine("The 3x3 platform with maximal sum={0} is:",bestSum);
        for (int row= rStart; row < rStart+3; row++)
        {
            for (int col= cStart; col < cStart+3; col++)
			    {
			     Console.Write("{0,4}",matrix[row,col]);
			    }  
            Console.WriteLine(); 
        }
        
    }
}
