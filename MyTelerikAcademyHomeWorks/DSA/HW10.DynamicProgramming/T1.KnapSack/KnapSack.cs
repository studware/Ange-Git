using System;

internal class Knapsack
{
    static void Main()
    {
        string[] productNames = new string[] { "beer", "vodka", "cheese", "nuts", "ham", "whiskey" };
        int[] sizes = new int[] { 3, 8, 4, 1, 2, 8 };
        int[] values = new int[] { 2, 12, 5, 4, 3, 13 };
        int capacity = 10;
        // Assume the array V[i] contains the values of the items
        // Assume the array W[i] contains the weights of the items

        Console.WriteLine("Knapsack, no repetition: Given N products, each weighs W[i] and has value C[i];");
        Console.WriteLine("a knapsack of capacity M. Put inside products with highest cost and weight ≤ M\n");

        int n = values.Length;
        bool[,] used = new bool[capacity + 1, n];
        //  We divide the knapsack into (capacity+1) slots
        int[] M = new int[capacity + 1];

        M[0] = 0;   // put zero products into slot number 0

        for (int j = 1; j <= capacity; j++)
        {
            // M[j] will be max1 (or M[j-1]) if the jth slot is empty)
            int max1 = M[j - 1];

            // M[j] will be max2 if the jth slot is occupied
            // Initialize max2 to some small number
            int max2 = -999999;

            // Mark the previous (j) slot if the jth slot is occupied
            int mark = 0;

            // Keep the index of the last candidate which can be put into the knapsack
            int candidateUsed = 0;

            // Search for an item to occupy the jth slot such that it gives us maximum value
            for (int i = 0; i < n; i++)
            {
                // For each item (i) calculate (V[i] + M[j - S[i]]) then compare it to the current max. 
                // If greater then update the current max. Only those items satisfying
                // the condition (j - S[i] >= 0) are checked because capacity should not be negative
                if (j - sizes[i] >= 0 && !used[j - sizes[i], i] && values[i] + M[j - sizes[i]] > max2)
                {
                    max2 = values[i] + M[j - sizes[i]];
                    mark = j - sizes[i];
                    candidateUsed = i;
                }
            }

            if (max1 > max2)
            {
                M[j] = max1;

                for (int k = 0; k < n; k++)
                {
                    used[j, k] = used[j - 1, k];
                }
            }
            else
            {
                M[j] = max2;

                for (int k = 0; k < n; k++)
                {
                    used[j, k] = used[mark, k];
                }

                used[j, candidateUsed] = true;
            }
        }

        Console.WriteLine("KnapSack capacity: {0}\nList of available products: ",capacity);

        for (int i = 0; i < n; i++)
        {

            Console.WriteLine("Product: {0,10}, Size: {1}, Value: {2}", productNames[i], sizes[i], values[i]);
        }

        Console.WriteLine("\nThe highest total cost of products with total weight <= {0}: {1}", capacity, M[capacity]);

        for (int i = 0; i < n; i++)
        {
            if (used[capacity, i])
            {
                Console.WriteLine("Product: {0,10}, Size: {1}, Value: {2}", productNames[i], sizes[i], values[i]);
            }
        }
    }
}

