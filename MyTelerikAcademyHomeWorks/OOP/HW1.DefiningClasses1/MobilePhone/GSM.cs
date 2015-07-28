using System;
using System.Collections.Generic;
using System.Text;

namespace MobilePhone
{
    public class GSM
    {
/// <summary>
/// static field and property IPhone4S 
/// </summary>
        private static readonly GSM iPhone4S = new GSM("iPhone 4S","Apple", 1300.00m, "Jan Bibijan",
                                                        new Battery("Apple",12,583, Battery.BatteryType.NiCd),
                                                        new Display(4.7, 16000000));
        
        private const decimal callPricePerSecond = 0.37m;

        private const decimal defaultPrice = 1254m;
        private const string defaultOwner = "Princess Ija";
/// <summary>
/// fields
/// </summary>       
        private string model;
        private string manufacturer;
        private decimal? price=null;
        private string owner;
        private Battery gsmBattery;
        private Display gsmDisplay;

        private List<Call> CallHistory;

/// <summary>
/// default constructor
/// </summary>
        public GSM(string model, string manufacturer)
            :this(model, manufacturer, defaultPrice, defaultOwner, new Battery(), new Display()) {}
/// <summary>
/// constructor with all arguments
/// </summary>
        public GSM(string model, string manufacturer, decimal price, string owner, Battery gsmBattery, Display gsmDisplay)
        {
            this.Model = model;
            this.Manufacturer = manufacturer;
            this.Price = price;
            this.Owner = owner;
            this.GsmBattery = gsmBattery;
            this.GsmDisplay = gsmDisplay;

            this.CallHistory = new List<Call>();
        }
/// <summary>
/// properties
/// </summary>
        public string Model 
        {
            get
            {
                return this.model;
            }
            set 
            { 
                if(string.IsNullOrEmpty(value))
                {
                    throw new ApplicationException("Model must be specified!");
                }
                else
                {
                    this.model = value;
                }
            }
        }

        public string Manufacturer 
        {
            get
            {
                return this.manufacturer;
            }
            set 
            { 
                if(string.IsNullOrEmpty(value))
                {
                    throw new ApplicationException("Manufacturer must be specified!");
                }
                else
                {
                    this.manufacturer = value;
                }
            }
        }

        public decimal? Price 
        {
            get
            {
                return this.price;
            }
            set 
            { 
                if(value < 0 || value > 1000000)
                {
                    throw new ArgumentOutOfRangeException("Price must be a positive value, less than 1,000,000!");
                }
                else
                {
                    this.price = value;
                }
            }
        }

        public string Owner
        {
            get { return this.owner; }
            set { this.owner = value; }
        }

        public Battery GsmBattery
        {
            get { return this.gsmBattery; }
            set { this.gsmBattery = value; }
        }
        
        public Display GsmDisplay
        {
            get { return this.gsmDisplay; }
            set { this.gsmDisplay = value; }
        }
/// <summary>
/// the static field constructor
/// </summary>
        public static GSM IPhone4S
        { 
            get 
            {
                return iPhone4S; 
            }
        }

        public override string ToString()
        {
            StringBuilder gsmString = new StringBuilder();

            gsmString.AppendFormat("GSM Model: \t {0}\n", this.model);
            gsmString.AppendFormat("Manufacturer: \t {0}\n", this.manufacturer);
            gsmString.AppendFormat("GSM Price: \t {0}\n", this.price);
            gsmString.AppendFormat("GSM Owner: \t {0}\n", this.owner);
            gsmString.AppendFormat("Battery: Model - {0}  HoursIdle - {1}  HoursTalk - {2}  Type - {3}\n", 
                                    this.GsmBattery.BatteryModel, this.GsmBattery.HoursIdle, this.GsmBattery.HoursTalk, this.GsmBattery.Type);
            gsmString.AppendFormat("Display: Size - {0} \t Number Of Colors - {1}\n", 
                                    this.GsmDisplay.DiagSize, this.GsmDisplay.NumberOfColors);
            gsmString.AppendLine(new string('_', 80));

            return gsmString.ToString();
        }
/// <summary>
/// here the methods begin: the first one adds a call 
/// </summary>
        public void AddCall(DateTime dateAndTime, string callPhoneNumber, int duration)
        {
            this.CallHistory.Add(new Call(dateAndTime, callPhoneNumber, duration));    
        }
/// <summary>
/// remove a call
/// </summary>
        public void DeleteCall(int position)
        { 
            if(this.CallHistory.Count<position||position-1<0)
            {
                throw new ApplicationException("There is not such call log!");
            }
            this.CallHistory.RemoveAt(position - 1);
        }
/// <summary>
/// Display the call history
/// </summary>
        public void ShowCallHistory()
        {
            Console.WriteLine("Call History:");
            int callNumber = 1;
            foreach (var call in this.CallHistory)
            {
                Console.Write(callNumber++);
                Console.Write(". ");
                Console.WriteLine(call.ToString());
            }
        }
/// <summary>
/// Clear the call history
/// </summary>
        public void ClearCallHistory()
        {
            this.CallHistory.Clear();
        }
/// <summary>
/// Calculate the total calls' price
/// </summary>
        public decimal TotalCallPrice()
        {
            double totalDuration = 0;
            foreach (var gsmCall in this.CallHistory)
            {
                totalDuration += gsmCall.CallDuration;
            }

            return (decimal)totalDuration * callPricePerSecond;
        }
    }
}
