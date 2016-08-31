using System;

namespace Printer
{
    public class PrintVariable
    {
        public static void Main()
        {
            var printer = new PrinterOfVariables.BooleanPrinter();
            printer.PrintBooleanAsString(true);
            printer.PrintBooleanAsString(false);
        }
    }
}