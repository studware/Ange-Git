using System;

class FloatOrDouble
{
    static void Main()
    {
        //  Declare float or double real variables
        
        decimal highPrecision = 34.567839023m;  // m suffix required; if 34.567839023 is in a set of numbers,
        // some of them could happen to exceed the precision and/or limits of double type, so we choose decimal (most precise)
        double fastDouble = 34.567839023;       // if we only discuss this number, it can be double;
        // this will run faster and will save memory
        float floatNum = 12.345f;                // a simple real type; f suffix required
        double doubleNum = 8923.1234857;        // the default type of real numbers; no suffix required
        float floatNumMoreDigits = 3456.091f;             // 7 digits, just at the limit!  

        Console.WriteLine("High precision number, choose decimal, 128 bits (most precise): " + highPrecision);
        Console.WriteLine("Same num, dble prec. in another context (faster, saves memory) :" + fastDouble);
        Console.WriteLine("A simple real type, 32 bits : \t\t\t\t\t" + floatNum);
        Console.WriteLine("Double, 64 bits, the default type of real numbers : \t\t" + doubleNum);
        Console.WriteLine("Float, 7-dig.-at the limit!(Depends on context, could be double)  : " + floatNumMoreDigits);
    }
}

