//  Read in MSDN about the keyword event in C# and how to publish events.
//  Re-implement the above using .NET events and following the best practices.


namespace T8.TimerUsingEvents
{
using System;
using System.Linq;
    class TestCallBack
    {
        private static TimerEventHandler invoke;

        static void Call()
        {
            invoke = new TimerEventHandler();
            invoke.ToInvokeMethod += delegate { Console.WriteLine(DateTime.Now); };
            invoke.Start(1000);//delay between the callbacks
        }

        static void Main()
        {
            Call();
            Console.Read();
        }
    }
}
