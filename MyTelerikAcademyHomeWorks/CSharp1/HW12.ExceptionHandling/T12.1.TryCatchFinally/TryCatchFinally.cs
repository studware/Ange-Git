using System;

class TryCatchFinally
{
    static void Main()
    {
        Console.WriteLine("Read an integer number, calculate and print its square root.\nUse try-catch-finally to handle exceptions\n");
        int num;
        Console.Write("Enter an integer number: ");
        try
        {
            num = int.Parse(Console.ReadLine());
            double sqreRoot = Math.Sqrt(num);
            if (num < 0)
            {
                throw new System.ArgumentOutOfRangeException(
                    "Invalid number: Sqrt for negative numbers is undefined!");
            }
            Console.WriteLine("The square root of {0} is {1}", num, sqreRoot);
        }

        catch (FormatException)
        {
            Console.WriteLine("Invalid integer number!");
        }
        catch (OverflowException)
        {
            Console.WriteLine("Invalid number: too big to fit in Int32!");
        }
        catch (ArgumentOutOfRangeException)
        {
            Console.WriteLine("Invalid number: Sqrt for negative numbers is undefined!");
        }
        finally
        {
            Console.WriteLine("\nGood bye!");
        }
    }
}
