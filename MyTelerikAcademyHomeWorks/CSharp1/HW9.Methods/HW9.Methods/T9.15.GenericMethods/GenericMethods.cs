using System;

class GenericMethods
{
    static T Minimum<T>(params T[] numbers)
    {
        dynamic minNum = numbers[0];
        int length = numbers.Length;
        for (int i = 0; i < length; i++)
        {
            if (numbers[i] < minNum)
            {
                minNum = numbers[i];
            }
        }
        return minNum;
    }
    static T Maximum<T>(params T[] numbers)
    {
        dynamic maxNum = numbers[0];
        int length = numbers.Length;
        for (int i = 0; i < length; i++)
        {
            if (numbers[i] > maxNum)
            {
                maxNum = numbers[i];
            }
        }
        return maxNum;
    }

    static T Average<T>(dynamic sum, params T[] numbers)
    {
        int cnt = numbers.Length;
        return sum/cnt;
    }

    static T Sum<T>(params T[] numbers)
    {
        dynamic sum = 0;
        foreach (T number in numbers)
        {
            sum = sum + number;
        }
        return sum;
    }

    static T Product<T>(params T[] numbers)
    {
        dynamic product = 1;
        foreach (T number in numbers)
        {
            product *= number;
        }
        return product;
    }
    
    static void Main()
    {
        Console.WriteLine("Modify the CalcIntSetNumbers class for any number type");
        Console.WriteLine("(integer, decimal, float, byte, etc.) using generic method ");

/*       Console.WriteLine("Minimum value in the set is: {0}", Minimum(1.5, 2.5, -4, 10, 12));
        Console.WriteLine("Maximum value in the set is: {0}", Maximum(1.5, 2.5, -4, 10, 12));
        double sum = Sum(1.5, 2.5, -4, 10, 12);
        Console.WriteLine("Sum of the elements in the set is: {0}", sum);
        Console.WriteLine("Average of the elements in the set is: {0}", Average(sum, 1.5, 2.5, -4, 10, 12));
        Console.WriteLine("Product of the elements in the set is: {0}", Product(1.5, 2.5, -4, 10, 12));
 
            Console.WriteLine("Minimum value in the set is: {0:N}", Minimum(4444444444, 8888888887, 2.0));
            Console.WriteLine("Maximum value in the set is: {0:N}", Maximum(4444444444, 8888888887, 2.0));
            dynamic sum = Sum(4444444444, 8888888887, 2.0);
            Console.WriteLine("Sum of the elements in the set is: {0:N}", sum);
            Console.WriteLine("Average of the elements in the set is: {0:N}", Average(sum, 4444444444, 8888888887, 2.0));
            Console.WriteLine("Product of the elements in the set is: {0:N}", Product(4444444444, 8888888887, 2.0)); 
*/          
        Console.WriteLine("Minimum value in the set is: {0}", Minimum(98, 100, 2.0, 5));
        Console.WriteLine("Maximum value in the set is: {0}", Maximum(98, 100, 2.0, 5));
        dynamic sum = Sum(98, 100, 2.0, 5);
        Console.WriteLine("Sum of the elements in the set is: {0}", sum);
        Console.WriteLine("Average of the elements in the set is: {0}", Average(sum, 98, 100, 2.0, 5));
       Console.WriteLine("Product of the elements in the set is: {0}", Product(98, 100, 2.0, 5)); 
    }
}
