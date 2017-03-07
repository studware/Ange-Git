using System;

namespace Algo9.BinaryTrees
{
    class BinaryTrees
    {
        /// <summary>
        /// Finds the count of binary trees which can be built by n elements; the word file is included in the homework .rar file
        /// </summary>
        /// <param name="n">number of elements</param>
        /// <returns>countOfTrees[i], i=1, 2, ...., n - number of trees/subtrees containing i nodes</returns>
        private static long BinaryTreesCount(int n)
        {
            // Dynamic programming (calculate a recurrence formula):
            // trees[0] = 1;
            // trees[n] = sum( trees[i] * trees[n-i-1] ) for each i in [0..n-1]
            // i = number of nodes in the left subtree
            // n-i-1 = number of nodes in the right subtree

            long[] countOfTrees = new long[n + 1];
            countOfTrees[0] = 1;
            for (int nodes = 1; nodes <= n; nodes++)
            {
                countOfTrees[nodes] = 0;
                for (int i = 0; i < nodes; i++)
                {
                    int leftSubtreeSize = i;
                    int rightSubtreeSize = nodes - i - 1;
                    // Use C# keyword "checked" to ensure integer overflow is not possible
                    checked
                    {
                        countOfTrees[nodes] +=
                        countOfTrees[leftSubtreeSize] * countOfTrees[rightSubtreeSize];
                    }
                }
            }
            return countOfTrees[n];
        }

        /// <summary>
        /// Calculates the number of ball colors in the input string
        /// </summary>
        /// <param name="balls">Input array of balls with different colors</param>
        /// <returns>number of colors</returns>
        private static long ColorCounting(char[] balls)
        {
            /* We calculate directly the formula n! / (c1! * c2! * ... ck!)
               where c1, c2, .. ck are the number of the balls for each color
             * I.e. we divide the permutations' count of n elements by the
             * multiplied numbers of permutations of the c1, c2, ...., ck
             * numbers of balls for each color */


            int n = balls.Length;
            long result = Factorial(n);

            int[] ballCounts = new int['Z' + 1];
            foreach (var ball in balls)
            {
                ballCounts[ball]++;
            }
            for (int i = 'A'; i <= 'Z'; i++)
            {
                int ballsOfGivenColor = ballCounts[i];
                long factorial = Factorial(ballsOfGivenColor);
                result /= factorial;
            }

            return result;
        }

        /// <summary>
        /// Computes factorial of n
        /// </summary>
        /// <param name="n">the input number</param>
        /// <returns>factorial of n</returns>
        private static long Factorial(int n)
        {
            // Use C# keyword "checked" to ensure integer overflow is not possible
            checked
            {
                long result = 1;
                for (int i = 2; i <= n; i++)
                {
                    result *= i;
                }
                return result;
            }
        }

        /// <summary>
        /// Finds the overall count of binary trees of n nodes which differ by the colors of nodes
        /// </summary>
        static void Main()
        {
            string ballsInput = Console.ReadLine();
            char[] balls = ballsInput.ToCharArray();

            long countOfTrees = BinaryTreesCount(balls.Length);

            long colorsCount = ColorCounting(balls);

            checked
            {
                decimal totalTrees = (decimal)countOfTrees * colorsCount;
                Console.WriteLine(totalTrees);
            }
        }
    }
}