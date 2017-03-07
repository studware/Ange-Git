using System;

class ConvertAnyToAny
{
    //**************   Convert the number numInX from numeral system of base X  ********************//
    //**************   to any other numeral system of base Y (2 ≤ s, d ≤  16)   ********************// 
    static string FromXtoY(string numInX, int baseX, int baseY)
    {
        int numInDecimal = BaseXToBase10(numInX, baseX);             // convert a number n from base X to decimal
        string result=FromDecimalToX(numInDecimal, baseY);          // convert a number from decimal to base X 
        return result;      
    }

    // Convert a decimal number to a number of base Y 
    static string FromDecimalToX(int numDec, int yBase)
    {
        string numInX = "";
        char nextChar;

        while (numDec != 0)
        {
            int residue=numDec % yBase;
            if ((residue) >= 10)
            {
                nextChar = (char)('A' + residue - 10);
            }
            else
            {
                nextChar = (char)(char)('0' + residue);
            }
            numInX = nextChar + numInX;
           numDec /= yBase;
        }
        return numInX;
    }

    // Convert a number of base X to decimal
    static int BaseXToBase10(string numX, int s)
    {
        int numDec = 0;
        int num=0;
        int pos = 1;
        for (int i = numX.Length - 1; i >= 0; i--)
        {
            if (numX[i] >= 'A')
            {
                num = numX[i] - 'A' + 10;
            }
            else
            {
                num= numX[i] - '0';
            }
            numDec += num * pos;
            pos *= s;
        }
        return numDec;
    }

    static void Main()
    {
        Console.WriteLine("Convert from any numeral system of given base s");
        Console.WriteLine("to any other numeral system of base d (2 ≤ s, d ≤  16)\n");
        Console.WriteLine(FromXtoY("7777", 8, 16));
    }
}