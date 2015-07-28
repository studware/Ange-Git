//  Using delegates write a class Timer that can execute certain method at each t seconds.

namespace T7.Timer
{
using System;
using System.Linq;
using System.Threading;
    
    public delegate void CallBack(Object state);
    class TimerCall
    {
        public static void TimeNow(Object state)
        { 
            Console.WriteLine(DateTime.Now);
        }
        static void Main()
        {
            CallBack callBack = TimeNow;
            Timer time = new Timer(callBack.Invoke, null, 0, 1000);

            Console.Read();
        }
    }
}