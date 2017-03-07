using System;

class Menu3choices
{
    static void Reverse(string number)
    {
        string reversed;
        string workStr = number.ToString();
        char[] charArr = workStr.ToCharArray();
        Array.Reverse(charArr);
        workStr = new string(charArr);
        if (workStr.EndsWith("-"))
        {
            reversed = "-" + workStr.Substring(0, workStr.Length - 1);
        }
        else
        {
            reversed = "" + workStr;
        }
        Console.WriteLine("The number {0} reversed is {1}", number, reversed);
    }

    static double CalcAverage(double[] array)
    {
        double sum = 0;
        int cnt = 0;
        for (int i = 0; i < array.Length; i++)
        {
            sum += array[i];
            cnt++;
        }
        return sum / cnt;
    }

    static double EquationResult(double a, double b)
    {
        double result;
        result = -b / a;
        if (b >= 0)
        {
            Console.WriteLine("The equation is: {0}X+{1}=0", a, b);
        }
        else
        { 
            Console.WriteLine("The equation is: {0}X{1}=0", a, b);
        }
            
            Console.WriteLine("The result is: X = {0}",result);
            return result;
    }

    static void Main()
    {
        Console.WriteLine("Options are: ");
        Console.WriteLine("Reverse the digits of given var number:\t\t  1");
        Console.WriteLine("Calculate the average of a sequence of integers:  2");
        Console.WriteLine("Solve a linear equation a * x + b = 0:\t\t  3");
	
        Console.WriteLine("Your choice is: ");
        byte ch = byte.Parse(Console.ReadLine());

        switch (ch)
        { 
            case 1:
                Console.Write("Enter a number: ");
                var num = Console.ReadLine();
                Reverse(num);
                break;
            case 2:
//               double[] arr = { 1234, 65, -56, 45.7654, -455.654, 8 };    // the result is: 140.185233333333
               double[] arr={1,2,3,4,5,6,7,8,9,10};                         //  5.5
//                double[] arr={114,2156563.2567};                          // 1078338.62835
//                double[] arr={1};                          // 1078338.62835
                Console.WriteLine("The average of the numbers:");
                for (int i = 0; i < arr.Length-1; i++)
                {
                    Console.WriteLine("{0}, ",arr[i]); 
                }
                Console.Write("{0} is:",arr[arr.Length-1]);
                Console.WriteLine("\t{0}",CalcAverage(arr) );
                break;
            case 3:
//                double a = 8.25;
//                double a = 0;
//                double b = -16.5;
                double a = 2.5;
                double b = 1;

                double x = EquationResult(a,b);
                break;
        }
    }
}
