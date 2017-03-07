using System;

namespace T2.MinEditDistance
{
    class MinEditDistance
    {
        const decimal DELETE_COST = 0.9m;
        const decimal INSERT_COST = 0.8m;
        const decimal REPLACE_COST = 1.0m;

        static decimal Compute(string firstWord, string secondWord)
        {
            decimal[,] table = new decimal[2, secondWord.Length + 1];

            for (int col = 1; col <= secondWord.Length; ++col)
            {
                table[0, col] = col * DELETE_COST;
            }
            
            // fill the table
            int row;
            for (row = 1; row <= firstWord.Length; ++row)
            {
                int thisRow = row % 2;
                int prevRow = 1 - thisRow;

                table[thisRow, 0] = row * INSERT_COST;

                for (int col = 1; col <= secondWord.Length; ++col)
                {
                    decimal cost = (secondWord[col - 1] == firstWord[row - 1]) ? 0 : REPLACE_COST;

                    decimal minCostCol = table[thisRow, col - 1] + DELETE_COST;
                    decimal minCost2 = table[prevRow, col - 1] + cost;
                    decimal minCostRow = table[prevRow, col] + INSERT_COST;

                    table[thisRow, col] = Math.Min(Math.Min(minCostRow, minCostCol), minCost2);
                }

            }

            return table[1 - (row % 2), secondWord.Length];
        }
        
        static void Main()
        {
            Console.WriteLine("Write a program to calculate the 'Minimum Edit Distance' (MED) between two words");

            Console.WriteLine("developer - enveloped: {0}", Compute("developer", "enveloped"));
            Console.WriteLine("aunt - ant: {0}", Compute("aunt", "ant"));
            Console.WriteLine("Sam - Samantha: {0}", Compute("Sam", "Samantha"));
            Console.WriteLine("flomax - volmax: {0}", Compute("flomax", "volmax"));
        }
    }
}
