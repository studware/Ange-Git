using System;
class ReadIntAndSum
{
    static void Main()
    {
        Console.Write("Enter integer number a: ");
        string a = Console.ReadLine();
        int k = int.Parse(a);
        Console.Write("Enter integer number b: ");
        string b = Console.ReadLine();
        int m = int.Parse(b);
        Console.Write("Enter integer number c: ");
        string c = Console.ReadLine();
        int n = int.Parse(c);
        Console.WriteLine("a+b+c={0}", k + m + n);
    }
}