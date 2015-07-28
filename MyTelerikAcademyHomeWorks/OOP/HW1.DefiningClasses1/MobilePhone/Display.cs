using System;

namespace MobilePhone
{
    public class Display
    {
        private const double defaultDiagSize = 5.9;
        private const int defaultNumOfColors = 1677000;
/// <summary>
/// fields
/// </summary>        
        private double diagSize;
        private int numberOfColors;
/// <summary>
/// constructors
/// </summary>
        public Display()
            :this (defaultDiagSize, defaultNumOfColors) {}

        public Display(double diagSize, int numberOfColors)
        {
            this.DiagSize = diagSize;
            this.NumberOfColors = numberOfColors;
        }
/// <summary>
/// properties
/// </summary>
        public double DiagSize 
        {
            get
            {
              if(diagSize<0)
              {
                  throw new ApplicationException("The diagonal size must be a positive number!");
              }
              else
              {
                return this.diagSize;
              }
            }
            set 
            {
                diagSize = value;
            }
        }
        
        public int NumberOfColors 
        {
            get
            {
              if(numberOfColors<0)
              {
                  throw new ApplicationException("The number of colors must be a positive number!");
              }
              else
              {
                return this.numberOfColors;
              }
            }
            set 
            {
                numberOfColors = value;
            }
        }
    }
}
