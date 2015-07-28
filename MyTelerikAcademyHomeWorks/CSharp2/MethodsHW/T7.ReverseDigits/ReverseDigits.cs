using System;

class ReverseDigits
{
        static decimal Reverse(decimal number)
    {
        if (number == 0)
        {
            return number;
        } 
        string workStr = number.ToString();
        char[] charArr=workStr.ToCharArray();
        Array.Reverse(charArr);
        workStr=new string(charArr);
        decimal result = Convert.ToDecimal(workStr);
        return result;
    }

    static void Main()
    {
        Console.WriteLine("Write a method that reverses the digits of given decimal number");
        decimal num, revNum;

        Console.Write("Enter a number of type decimal: ");
        num = decimal.Parse(Console.ReadLine());
        revNum = Reverse(num);
        Console.WriteLine("{0} reversed is: {1}", num, revNum);
    }
}
