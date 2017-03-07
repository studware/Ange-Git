using System;
using System.IO;

class MaxSumPlatform
{
    static double Max2x2Sum(double[,] matrix, int dim)
    {
        double bestSum = int.MinValue;
        int rStart = 0;
        int cStart = 0;
        for (int row = 0; row < dim - 1; row++)
        {
            for (int col = 0; col < dim - 1; col++)
            {
                double sum = matrix[row, col] + matrix[row, col + 1] + matrix[row + 1, col] + matrix[row + 1, col + 1];
                if (sum > bestSum)
                {
                    bestSum = sum;
                    rStart = row;
                    cStart = col;
                }
            }
        }
        return bestSum;
    }
    
    static void Main()
    {
        string fileName1 = @"../../Matrix.txt";
        string line = "";
        string max2Sum="";
        int dim = 0;
        try
        {
            StreamReader streamReader = new StreamReader(fileName1);
            dim = int.Parse(streamReader.ReadLine());
            string[] lineStr = new string[dim];
            double[,] matrix = new double[dim, dim];
            for (int i = 0; i < dim; i++)
            {
                line = streamReader.ReadLine(); 
                lineStr=line.Split(' ');
                for (int j = 0; j < dim; j++)
                {
                    matrix[i, j] = double.Parse(lineStr[j]); 
                }
            }
            streamReader.Close();
            max2Sum=Convert.ToString(Max2x2Sum(matrix, dim));

            StreamWriter streamWriter = new StreamWriter(@"../../maxSum2.txt", false);
            streamWriter.WriteLine(max2Sum, true);
            streamWriter.Close();
        }
        catch (Exception ex)
            {
                Console.Error.WriteLine("Input/Output operation failed", ex.Message);
            }
            finally
            {
              Console.WriteLine("The maximal sum of a 2x2 platform is: {0}", max2Sum);  
            }
    }
}

