namespace T8.AddBigNumbers
{
    using System;
    using System.Linq;
    class NumbersAsArray
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Write method to add 2 positive integer numbers represented as arrays of digits");
            Console.WriteLine("(each array element arr[i] contains a digit; the last digit is kept in arr[0]).");
            Console.WriteLine("Each of the numbers that will be added could have up to 10 000 digits.\n");
            Console.Write("Enter the first number: ");
            BigNumber first = new BigNumber(Console.ReadLine());
            Console.Write("Enter the second number: ");
            BigNumber second = new BigNumber(Console.ReadLine());
            Console.WriteLine(first + second);
        }
    }
}