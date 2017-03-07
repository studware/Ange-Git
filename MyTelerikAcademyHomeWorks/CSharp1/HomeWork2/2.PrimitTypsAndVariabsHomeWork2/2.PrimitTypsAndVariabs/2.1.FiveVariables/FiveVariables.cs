
using System;

class FiveVariables
{
    static void Main()
    {
        //  Declare some variables
        ushort unsignedNum = 52130; // could be any longer type of integer
        sbyte littleSigned=-115;    // could be any longer type of signed integer
        int integerNum=4825932;     // could be any longer type of signed/unsigned integer
        byte littleUnsigned=97;     // could be sbyte as well; or any longer type of signed/unsigned integer
        short signedShort=-10000;   // could be any longer type of signed integer
        Console.WriteLine("Positive integer number, < 65535, ushort, 16 bits: \t\t" + unsignedNum);
        Console.WriteLine("Little negative integer number, (abs) < 127, sbyte, 8 bits :\t" + littleSigned);
        Console.WriteLine("An integer number, > 65535 and < 2 billions, int, 32 bits : \t" + integerNum);
        Console.WriteLine("Little positive integer number, < 255, byte, 8 bits : \t\t" + littleUnsigned);
        Console.WriteLine("Signed integer number, (abs) < 327677, short, 16 bits  : \t" + signedShort);
    }
}

