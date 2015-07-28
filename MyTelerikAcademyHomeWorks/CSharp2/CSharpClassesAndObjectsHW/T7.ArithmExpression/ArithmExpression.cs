using System;
using System.Collections.Generic;

class Rpn
{
    public static void Main()
    {
        Console.WriteLine("Write a program that calculates the value of given arithmetical expression\n");
        Console.WriteLine("Please, input the expression in reverse polish notation (Exit with Ctrl/C) :");

        char[] delimit = new char[] { ' ', '\t' };
        for (; ; )
        {
           string s = Console.ReadLine();
           if (s == null) break;

 //           string s = "2.3 5 +";

            Stack<string> tks = new Stack<string>       // the token string: push it into stack
                 (s.Split(delimit, StringSplitOptions.RemoveEmptyEntries));
            if (tks.Count == 0) continue;
            try
            {
                double result = evalRpn(tks);        
                if (tks.Count != 0) throw new Exception();
                Console.WriteLine(result);
            }
            catch (Exception e) { Console.WriteLine("error"); }
        }
    }

    // Evaluate Expression in Reverse Polish Notation
    private static double evalRpn(Stack<string> tks)
    {
        string token = tks.Pop();
        double x, y;
        if (!Double.TryParse(token, out x))
        {
            y = evalRpn(tks); 
            x = evalRpn(tks);
            if (token == "+") x += y;
            else if (token == "-") x -= y;
            else if (token == "*") x *= y;
            else if (token == "/") x /= y;
            else throw new Exception();
        }
        return x;
    }
}