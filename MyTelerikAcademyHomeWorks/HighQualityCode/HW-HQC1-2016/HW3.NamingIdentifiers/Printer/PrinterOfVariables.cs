using System;

namespace Printer
{
    public class PrinterOfVariables
    {
        private const int MaxCount = 6;

        public class BooleanPrinter
        {
            public BooleanPrinter()
            {
            }

            public void PrintBooleanAsString(bool booleanValue)
            {
                Console.WriteLine(booleanValue);
            }
        }
    }
}