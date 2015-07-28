namespace T3.RangeExceptions
{
using System;

    public class  InvalidRangeException<T>: ApplicationException
    {
        public const string exceptionMessage = "Range violation ";

        public T StartValue {get; private set;}
        public T EndValue {get; private set;}

        public InvalidRangeException(T startValue, T endValue, Exception causeException = null)
                                    : base(exceptionMessage, causeException)
        {
            this.StartValue = startValue;;
            this.EndValue = endValue;
        }
    }
}

