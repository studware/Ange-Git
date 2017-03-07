using System;

class AddBigNumbers
{
    static void AddBigInt(int c1, int c2, string[][] bigIntArray)
    { 
        int max=Math.Max(c1,c2);
        int min=Math.Min(c1,c2);
        int temp = 0;
        int carry = 0;

        for (int i = 0; i < min; i++)
			{
			    temp=Convert.ToInt32(bigIntArray[0][i])+Convert.ToInt32(bigIntArray[1][i])+carry;
                carry=temp/10;
                bigIntArray[2][i]=(temp%10).ToString();
			}
        if (c1 == c2 && carry != 0)
        {
            bigIntArray[2][min] = "1";
            carry = 0;
        }
        else
        {
            if (c1 == max)
            {
                for (int i = min; i <= max; i++)
                {
                    temp = Convert.ToInt32(bigIntArray[0][i]) + carry;
                    carry = temp / 10;
                    bigIntArray[2][i] = (temp % 10).ToString();
                }
            }
            else if (c2 == max)
            {
                for (int i = min; i <= max; i++)
                {
                    temp = Convert.ToInt32(bigIntArray[1][i]) + carry;
                    carry = temp / 10;
                    bigIntArray[2][i] = (temp % 10).ToString();
                }
            }
        }
        return;
    }
    
    static void Main()
    {
        Console.WriteLine("Add two positive integer numbers as arrays of digits \n(each arr[i] contains a digit, i<10 000, last digit in arr[0]).");

        Console.Write("Enter first positive integer number with up to 10 000 digits: ");
        int num1=int.Parse(Console.ReadLine());
        Console.Write("Enter second positive integer number with up to 10 000 digits: ");
        int num2=int.Parse(Console.ReadLine());

// Allocate a jagged array with aray1,array2 and result, each with 1 more element for keeping the carry
 
        string[][] jagged = new string [3][];

        int n1=0;               //  convert first number to the first row of the string array
        int work=num1;
        string[] digits = { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };
        while (work>0)
        {
            n1++;
            work=work/10;
        }
        jagged[0] = new string[n1 + 1];                        // first number row
        work = num1;
        for (int i = 0; i < n1; i++)
        {
            jagged[0][i] = digits[work%10];
            work = work / 10;
        }
        jagged[0][n1]="0";

        int n2=0;               //  convert second number to the second row of the string array
        work=num2;
        while (work > 0)
        {
            n2++;
            work = work / 10;
        }
        jagged[1] = new string[n2 + 1];                        // first number row
        work = num2;
        for (int i = 0; i < n2; i++)
        {
            jagged[1][i] = digits[work % 10];
            work = work / 10;
        }
        jagged[1][n2]="0";

        int max = Math.Max(n1,n2);
        int min= Math.Min(n1,n2);

        jagged[2] = new string[max + 1];                        // third (result) row

//***************        Call the method to sum the big integers' arrays      ************************** 

        AddBigInt(n1, n2, jagged);      // call the method to sum the arrays

//*******  Print both input arrays and the result (arrays reversed, represented as integer numbers)  **********

        Console.WriteLine("The result is (reversed):");
        Console.WriteLine();

        Array.Reverse(jagged[0], 0, n1);
        for (int i = 0; i < n1; i++)
        {
            Console.Write(jagged[0][i]);
        }
        Console.Write(" + ");

        Array.Reverse(jagged[1], 0, n2);
        for (int i = 0; i < n2; i++)
        {
            Console.Write(jagged[1][i]);
        }
        Console.Write(" = ");

        Array.Reverse(jagged[2], 0, max+1);

        if (jagged[2][0] != "0")
        {
            Console.Write(jagged[2][0]);
        }
        for (int i = 1; i <= max; i++)
        {
            Console.Write(jagged[2][i]);
        }
        Console.WriteLine();
    }
}
