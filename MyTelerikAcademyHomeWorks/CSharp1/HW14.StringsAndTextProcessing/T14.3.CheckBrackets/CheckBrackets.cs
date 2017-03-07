using System;
using System.Collections.Generic;

class CheckBrackets
{
    static bool CheckBr(string exprString)
    {
        List<char> bracketsList = new List<char>();
        bool correct = true;
        foreach (char symbol in exprString)
        {
            if (symbol == '(')
            {
                bracketsList.Add(symbol);
            }
            else if (symbol == ')')
            {
                if (bracketsList.Count > 0)
                {
                    bracketsList.Remove('(');
                }
                else
                {
                    correct = false;
                    return correct;
                }
            }
        }
        if (bracketsList.Count == 0)
        {
            correct = true;
            return correct;
        }
        else
        {
            correct = false;
            return correct;
        }
    }
    static void Main()
    {
        Console.WriteLine("Check if in a given expression the brackets are put correctly\n");
        Console.Write("Enter an expresion: ");
        string inpStr = Console.ReadLine();
        Console.WriteLine("The brackets are put correctly? {0}", CheckBr(inpStr));
    }
}
