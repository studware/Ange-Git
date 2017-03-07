using System;
using System.Text;

class ClasMatrix
{
    public class NewMatrix
    {
        private int rows, cols;
        private int[,] aMatrix;

        public NewMatrix(int r, int c)
        {
            rows = r;
            cols = c;
            aMatrix = new int[rows, cols];
        }
        public int this[int r, int c]
        {
            get
            {
                return aMatrix[r, c];
            }
            set
            {
                aMatrix[r, c] = value;
            }
        }
        public int getRows()
        {
            return rows;
        }

        public int getCols()
        {
            return cols;
        }

        public static NewMatrix operator +(NewMatrix operand1, NewMatrix operand2)
        {
            if (operand1.getRows() != operand2.getRows() || operand1.getCols() != operand2.getCols())
            {
                throw new Exception("Different dimensions");
            }

            NewMatrix addResult = new NewMatrix(operand1.getRows(), operand1.getCols());

            for (int i = 0; i < operand1.aMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < operand2.aMatrix.GetLength(1); j++)
                {
                    addResult[i, j] = operand1[i, j] + operand2[i, j];
                }
            }
            return addResult;
        }

        public static NewMatrix operator -(NewMatrix operand1, NewMatrix operand2)
        {
            if (operand1.getRows() != operand2.getRows() || operand1.getCols() != operand2.getCols())
            {
                throw new Exception("Different dimensions");
            }
            NewMatrix result = new NewMatrix(operand1.getRows(), operand1.getCols());

            for (int i = 0; i < operand1.aMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < operand2.aMatrix.GetLength(1); j++)
                {
                    result[i, j] = operand1[i, j] - operand2[i, j];
                }
            }
            return result;
        }

        public static NewMatrix operator *(NewMatrix operand1, NewMatrix operand2)
        {
            NewMatrix result = new NewMatrix(operand1.getRows(), operand1.getCols());

            for (int i = 0; i < operand1.getRows(); i++)
            {
                for (int j = 0; j < operand1.getRows(); j++)
                {
                    int sum=0;
                    for (int k = 0; k < operand1.getRows(); k++)
                    {
                        sum =sum + (operand1[i, k] * operand2[k, j]);
                    }
                    result[i, j] = sum;
                }
            }
            return result;
        }

        public override string ToString()
        {
            StringBuilder aMatrixToString = new StringBuilder();

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    aMatrixToString.Append(String.Format("{0,4} ", aMatrix[i, j]));
                }
                aMatrixToString.Append("\n");
            }
            return aMatrixToString.ToString();
        }

    }

    static void Main()
    {
        Console.WriteLine("Write a class Matrix, to hold a matrix of integers.\nOverload the operators for matrices, \nindexer for accessing the matrix content and ToString()");
        int size=0;;
        do
        {
            Console.Write("Enter size of the matrix1 and matrix2: ");
            size = int.Parse(Console.ReadLine());
        } while (size <= 0);

        int r1, c1, r2, c2;
        c1=r1=r2=c2=size;
        NewMatrix m1 = new NewMatrix(r1, c1);
        Console.WriteLine("Enter the elements of the matrix1: ");
        for (int i = 0; i < r1; i++)
        {
            for (int j = 0; j < c1; j++)
            {
                m1[i,j] = int.Parse(Console.ReadLine());
            }
        }
        NewMatrix m2 = new NewMatrix(r2, c2);
        
        Console.WriteLine("Enter the elements of the matrix2: ");
        for (int i = 0; i < r2; i++)
        {
            for (int j = 0; j < c2; j++)
            {
                m2[i,j] = int.Parse(Console.ReadLine());
            }
        }

        Console.WriteLine("Test matrices:");
        Console.WriteLine(m1);
        Console.WriteLine(m2);

        Console.WriteLine("Addition:");
        Console.WriteLine(m1+m2);

        Console.WriteLine("Subtraction:");
        Console.WriteLine(m1-m2);

        Console.WriteLine("Multiplication:");
        Console.WriteLine(m1*m2);

    }
}

