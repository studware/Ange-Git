namespace T8.TimerUsingEvents
{
using System;
using System.Linq;
using System.Timers;
    public delegate void CallBack();

    class TimerEventHandler
    {
        public CallBack ToInvokeMethod;
        private Timer time = new Timer();

        public void Start(int ticks)
        {
            time.Elapsed += new ElapsedEventHandler(ActionEvent);
            time.Interval = ticks;
            time.Enabled = true;
        }

        public void ActionEvent(object sourse, ElapsedEventArgs e)
        {
            ToInvokeMethod.Invoke();
        }
    }
}
