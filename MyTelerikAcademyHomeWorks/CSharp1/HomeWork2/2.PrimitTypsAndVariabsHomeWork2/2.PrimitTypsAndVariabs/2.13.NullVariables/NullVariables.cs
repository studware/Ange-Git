using System;

class NullVariables
{
    static void Main()
    {
        int? nullInt = null;
        Console.WriteLine("Integer Number: {0}", nullInt.GetValueOrDefault()); 
        double? nullDouble = null;
        Console.WriteLine("Double Number: {0}", nullDouble.GetValueOrDefault());
        nullInt = 18;
        Console.WriteLine("Integer Number: {0}", nullInt);
        nullDouble = 13478263;
        Console.WriteLine("Double Number: {0}", nullDouble);
    }
}

