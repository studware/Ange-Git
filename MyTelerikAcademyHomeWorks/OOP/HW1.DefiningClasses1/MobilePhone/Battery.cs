using System;

namespace MobilePhone
{
public class Battery
    {
        private const string defaultModel="Unknown model";
        private const int defaultHoursIdle=540;
        private const int defaultHoursTalk=8;
        private const BatteryType defaultType = BatteryType.LiIon;

        public enum BatteryType 
        {
            LiIon, NiMH, NiCd, LiPo, AlienTech
        }
/// <summary>
/// fields
/// </summary>
        private string batteryModel;
        private int hoursIdle;
        private int hoursTalk;
        private BatteryType type;
/// <summary>
/// constructors
/// </summary>
        public Battery()
            :this (defaultModel, defaultHoursIdle, defaultHoursTalk, defaultType){ }

        public Battery(string model, int hoursIdle, int hoursTalk, BatteryType type)
            {
                this.BatteryModel = model;
                this.HoursIdle = hoursIdle;
                this.HoursTalk = hoursTalk;
                this.Type = type;
            }
/// <summary>
/// properties
/// </summary>
        public string  BatteryModel
        { 
            get
            {
                return this.batteryModel;
            }
            set
            { 
                if(string.IsNullOrEmpty(value))
                {
                    throw new ApplicationException("Model missing!");
                }
                else
                {
                    this.batteryModel = value;  
                }
            }
        }

        public int  HoursIdle
        { 
            get
            {
                return this.hoursIdle;
            }
            set
            { 
                if(value < 0)
                {
                    throw new ApplicationException("Hours Idle must be a positive number!");
                }
                else
                {
                    this.hoursIdle = value;  
                }
            }
        }

        public int HoursTalk
        {
            get
            {
                return this.hoursTalk;
            }
            set
            {
                if (value < 0)
                {
                    throw new ApplicationException("Hours Talk must be a positive number!");
                }
                else
                {
                    this.hoursTalk = value;
                }
            }
        }

        public BatteryType Type
        {
            get
            {
                return this.type;
            }
            set
            {
                this.type = value;
            }
        }

    }
}
