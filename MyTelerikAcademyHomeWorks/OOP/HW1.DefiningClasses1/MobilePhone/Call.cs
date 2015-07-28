using System;
using System.Text;

namespace MobilePhone
{
    public class Call
    {
//fields
        private DateTime dateAndTime;
        private string dialedPhone;
        private double callDuration;
/// <summary>
/// constructor
/// </summary>
        public Call(DateTime dateAndTime, string dialedPhone, int callDuration)
        {
            this.DateAndTime = dateAndTime;
            this.DialedPhone = dialedPhone;
            this.CallDuration = callDuration;
        }
/// <summary>
/// properties
/// </summary>
        public DateTime DateAndTime 
        {
            get { return this.dateAndTime; }
            set { this.dateAndTime = value; }
        }
        
        public string DialedPhone 
        {
            get { return this.dialedPhone; }
            set  
            {   if(value == null)
                    throw new ArgumentNullException("Dialed phone number can not be null!");
                dialedPhone = value; 
            }
        }
        
        public double CallDuration 
        {
            get { return this.callDuration; }
            set  
            {   if(value.Equals(TimeSpan.Zero))
                    throw new ArgumentNullException("Duration can not be zero!");
                callDuration = value; 
            }
        }

        public override string ToString()
        {
            StringBuilder callString = new StringBuilder();
            callString.AppendFormat("On {0} \t Phone: {1} \t Duration: {2}\n", this.dateAndTime, this.dialedPhone, this.callDuration);
            return callString.ToString();
        }
    }
}
