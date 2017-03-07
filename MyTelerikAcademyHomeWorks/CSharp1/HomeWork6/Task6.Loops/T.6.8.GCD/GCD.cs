using System;
class GCD
{
    static void Main()
    {
        string strNum1;
        string strNum2;
        double num1;
        double num2;
        double gcd;
        do
            {
                Console.Write("Please, enter a real number: ");
            }
        while ((!double.TryParse(strNum1 = Console.ReadLine(), out num1)) || num1 == 0 );
        do
            {
                Console.Write("Please, enter another real number: ");
            }
        while ((!double.TryParse(strNum2 = Console.ReadLine(), out num2)) || num2 == 0 );
        gcd = num1;
        if (Math.Abs(num1) < Math.Abs(num2))
            {
                num1 = num2;
                num2 = gcd;
            }
        gcd = num1 % num2;
        while (gcd!=0) 
        {
         num1=num2;   
         num2=gcd;
         gcd = num1 % num2;
        }
        gcd = num2;
        Console.WriteLine("GCD of {0} and {1} is {2}", strNum1, strNum2, Math.Abs(gcd));
    }
}
