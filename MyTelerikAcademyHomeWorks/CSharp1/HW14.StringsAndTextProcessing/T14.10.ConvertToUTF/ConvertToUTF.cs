using System;
using System.Text;

class ConvertToUTF
{
    static void Main()
    {
        Console.WriteLine("Convert a string to a sequence of C# Unicode character literals");
        Console.WriteLine("Enter a string (Enter will assume 'Hi!') : ");
        string inputStr = Console.ReadLine();
        if (inputStr == "")
        {
            inputStr = "Hi!";
        }

        StringBuilder utfString = new StringBuilder(inputStr.Length * 6);

        foreach (char c in inputStr)
        {
            int code=(int)c;
            utfString.AppendFormat("\\u{0:X4}",code);
        }
        Console.WriteLine("The Unicode of the string {0} is: {1}", inputStr,utfString.ToString());
    }
}