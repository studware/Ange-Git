using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Wintellect.PowerCollections;
using System.Threading;
using System.Globalization;
using System.IO;

class ShoppingCenterMain
{
    /// <summary>
    /// Read input from the console, parse commands and manipulate the shopping center data; output the result to the console
    /// </summary>
    public static void Main()
    {
        Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

        ShoppingCenter center = new ShoppingCenter();

        StringBuilder answer = new StringBuilder();

        int commands = int.Parse(Console.ReadLine());
        for (int i = 1; i <= commands; i++)
        {
            string command = Console.ReadLine();
            string commandResult = center.ProcessCommand(command);
            answer.AppendLine(commandResult);
        }

        Console.Write(answer);
    }
}
