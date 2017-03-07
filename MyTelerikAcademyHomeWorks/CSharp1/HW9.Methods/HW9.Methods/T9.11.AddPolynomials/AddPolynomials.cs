using System;

class AddPolynomials
{
    static void AddCoeff(int c1, int c2, string[][] bigDoubleArray)
    { 
        int max=Math.Max(c1,c2);
        int min=Math.Min(c1,c2);
        double temp = 0;

        for (int i = 0; i < min; i++)
			{
			    temp=Convert.ToDouble(bigDoubleArray[0][i])+Convert.ToDouble(bigDoubleArray[1][i]);
                bigDoubleArray[2][i]=temp.ToString();
			}
        if (c1 == c2)
        {
            return;
        }
        else
        {
            if (c1 == max)
            {
                for (int i = min; i <= max; i++)
                {
                    temp = Convert.ToDouble(bigDoubleArray[0][i]);
                    bigDoubleArray[2][i] = temp.ToString();
                }
            }
            else if (c2 == max)
            {
                for (int i = min; i <= max; i++)
                {
                    temp = Convert.ToDouble(bigDoubleArray[1][i]);
                    bigDoubleArray[2][i] = temp.ToString();
                }
            }
        }
        return;
    }

    static void PrintPolynomial(int n, int row, string[][] jag)
    {
        string outStr;
        if (n > 2)
        {
            outStr = ((jag[row][0] == "0") ? "" : (jag[row][0] + "X↑" + (n - 1)));
            Console.Write(outStr);
        }
        for (int i = 1; i < n - 2; i++)
        {
            outStr=(jag[row][i] == "0") ? "" : (((Convert.ToDouble(jag[row][i]) > 0) ? "+" : ""))
                 + jag[row][i] + "X↑" + (n - i - 1);
            Console.Write(outStr);
        }
        outStr=(jag[row][n - 2] == "0") ? "" : (((Convert.ToDouble(jag[row][n - 2]) > 0) ? "+" : "")
             + jag[row][n - 2] + "X");
        Console.Write(outStr);
        outStr=(jag[row][n - 1] == "0") ? "" : (((Convert.ToDouble(jag[row][n - 1]) > 0) ? "+" : "")
             + jag[row][n - 1]);
        Console.WriteLine(outStr);
    }

    static void Main()
    {
        Console.WriteLine("Write a method that adds two polynomials.");

// *****************    TEST DATA   *************************************

    /*      string[][] jagged = new string[3][];

            int n1 = 4;
            int n2 = 8;
            int max = Math.Max(n1, n2);
            int min = Math.Min(n1, n2);
            jagged[0] = new string[] { "5.9", "-2", "9", "8", "0" };
            jagged[1] = new string[] { "7", "0", "-3.5", "8.12", "2", "1.6", "-43", ".27", "0" };
            jagged[2] = new string[max + 1];

                       int n1 = 4;
                       int n2 = 4;
                       int max = Math.Max(n1, n2);
                       int min = Math.Min(n1, n2);
                       jagged[0] = new string[] { "5", "2", "9", "8", "0" };
                       jagged[1] = new string[] { "7", "0", "3", "8", "0" };
                       jagged[2] = new string[max + 1];

            int n1 = 8;
            int n2 = 4;
            int max=Math.Max(n1,n2);
            int min=Math.Min(n1,n2);
            jagged[0] = new string[] {"1", "4", "7", "9", "9", "9", "9", "9", "0"};
            jagged[1] = new string[] {"9", "2", "9", "8", "0"};
            jagged[2] = new string[max+1];

                       int n1 = 10;
                       int n2 = 2;
                       int max = Math.Max(n1, n2);
                       int min = Math.Min(n1, n2);
                       jagged[0] = new string[] { "9", "9", "9", "9", "9","9", "9", "9", "9", "9", "0" };
                       jagged[1] = new string[] { "9", "9", "0" };
                       jagged[2] = new string[max + 1];
*/

        int n1, n2;
        string strNum;
        do
        {
            Console.Write("Enter the length of the coefficients for polynomial1: ");
        }
        while (!int.TryParse(strNum = Console.ReadLine(), out n1) || n1 < 1);
        do
        {
            Console.Write("Enter the length of the coefficients for polynomial2: ");
        }
        while (!int.TryParse(strNum = Console.ReadLine(), out n2) || n2 < 1);

        int max = Math.Max(n1, n2);
        int min = Math.Min(n1, n2);

        // Allocate a jagged array with aray1,array2 and result

        string[][] jagged = new string[3][] { new string[n1 + 1], new string[n2 + 1], new string[max + 1] };

        Console.WriteLine("Enter the coefficients of the first polynomial, x0 coeff. having 0 index:");  //first (polyn1) row
        for (int i = 0; i < n1; i++)
        {
            jagged[0][i] = Console.ReadLine();
        }

        Console.WriteLine("Enter the coefficients of the first polynomial, x0 coeff. having 0 index:");   // second (polyn2) row
        for (int i = 0; i < n2; i++)
        {
            jagged[1][i] = Console.ReadLine();
        }

        jagged[2] = new string[max + 1];                        // third (resulting polynomial) row
       

        //***************        Call the method to sum the polynomials     ************************** 

        AddCoeff(n1, n2, jagged);      // call the method to sum the polynomials

        //*************  Print the input data as is  ******************

        //*******  Print both polynomials and the result  **********

        Array.Reverse(jagged[0], 0, n1);
        Console.Write("Polynomial1\t= ");
        PrintPolynomial(n1, 0, jagged); 

        Array.Reverse(jagged[1], 0, n2);
        Console.Write("Polynomial2\t= ");
        PrintPolynomial(n2, 1, jagged);
 
        Array.Reverse(jagged[2], 0, max);
        Console.Write("Poly1 + Poly2\t= ");
        PrintPolynomial(max, 2, jagged); 

    }
}