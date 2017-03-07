using System;

class CompareNumsWithPrecision
{
    static void Main()
    {
        decimal decNum1=5.3m;
        decimal decNum2=6.01m;
        bool compDig; 
        Console.WriteLine("Compare two numbers with precision of 0.000001, for example:");
        compDig=Math.Abs(decNum1-decNum2)<0.000001m;
        Console.WriteLine("The numbers {0} and {1} are {2} with precision of 0.000001", decNum1, decNum2, compDig ? "equal" : "not equal");
        decNum1=5.00000001m;
        decNum2=5.00000003m;
        compDig=Math.Abs(decNum1-decNum2)<0.000001m;
       Console.WriteLine("The numbers {0} and {1} are {2} with precision of 0.000001", decNum1, decNum2, compDig ? "equal" : "not equal");
       
        Console.WriteLine("Please enter two numbers and press ENTER after each:");
        string num1 = Console.ReadLine();
        string num2 = Console.ReadLine();
        
        if ((decimal.TryParse(num1, out decNum1))&&(decimal.TryParse(num2, out decNum2)))
            {
            compDig = Math.Abs(decNum1-decNum2)<0.000001m;
                Console.WriteLine("The numbers {0} and {1} are {2} with precision of 0.000001", num1, num2, compDig ? "equal" : "not equal");
            }
            else
            {
                Console.WriteLine("Not a valid input!");
            }
    }
}

