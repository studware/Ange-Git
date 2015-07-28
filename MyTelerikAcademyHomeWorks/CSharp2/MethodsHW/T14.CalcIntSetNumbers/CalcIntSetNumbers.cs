using System;

class CalcIntSetNumbers
{
    static int Minimum(params int[] numbers)
    {
        int minNum = numbers[0];
        int length = numbers.Length;
        for (int i = 0; i < length; i++)
        {
            if (length > 0)
            {
                if (numbers[i] < minNum)
                {
                    minNum = numbers[i];
                }
            }
            else
            {
                return 0;
            }
        }
        return minNum;
    }
    static int Maximum(params int[] numbers)
    {
        int maxNum = numbers[0];
        int length = numbers.Length;
        for (int i = 0; i < length; i++)
        {
            if (length > 0)
            {
                if (numbers[i] > maxNum)
                {
                    maxNum = numbers[i];
                }
            }
            else
            {
                return 0;
            }
        }
        return maxNum;
    }

    static double Average(int sum, params int[] numbers)
    {
        int cnt = numbers.Length;
        return (double)sum / cnt;
    }

    static int Sum(params int[] numbers)
    {
        int sum = 0;
        foreach (int number in numbers)
        {
            sum = sum + number;
        }
        return sum;
    }

    static int Product(params int[] numbers)
    {
        int product = 1;
        foreach (int number in numbers)
        {
            product *= number;
        }
        return product;
    }
    static void Main()
    {
        Console.WriteLine("Minimum value in the set is: {0}", Minimum(1, 2, -4, 10,12));
        Console.WriteLine("Maximum value in the set is: {0}", Maximum(1, 2, -4, 10, 12));
        int sum = Sum(1, 2, -4, 10, 12);
        Console.WriteLine("Sum of the elements in the set is: {0}",sum );
        Console.WriteLine("Average of the elements in the set is: {0}", Average(sum, 1, 2, -4, 10, 12));
        Console.WriteLine("Product of the elements in the set is: {0}", Product(1, 2, -4, 10, 12));

/*        Console.WriteLine("Minimum value in the set is: {0}", Minimum(0, 0, 0, 0, 0));
        Console.WriteLine("Maximum value in the set is: {0}", Maximum(0, 0, 0, 0, 0));
        int sum = Sum(0, 0, 0, 0, 0);
        Console.WriteLine("Sum of the elements in the set is: {0}", sum);
        Console.WriteLine("Average of the elements in the set is: {0}", Average(sum,0, 0, 0, 0, 0 ));
       Console.WriteLine("Product of the elements in the set is: {0}", Product(0, 0, 0, 0, 0)); 
*/ 
    }
}

