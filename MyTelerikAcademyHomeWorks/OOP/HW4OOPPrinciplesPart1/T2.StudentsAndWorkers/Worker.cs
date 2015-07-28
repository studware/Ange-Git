//  Define class Worker derived from Human   
//  with a new property WeekSalary and WorkHoursPerDay
//  and a method MoneyPerHour() that returns money earned per hour by the worker.
//  Define the proper constructors and properties for this hierarchy. 

namespace T2.StudentsAndWorkers
{
using System;
using System.Text;
using CreaturesClassLib;
    public class Worker: Human 
    {
        private double weekSalary;
        private double workHoursPerDay;

        public Worker(string firstName, string lastName, double weekSalary, double workHoursPerDay)
            : base(firstName, lastName)
        {
            this.WeekSalary = weekSalary;
            this.WorkHoursPerDay = workHoursPerDay;
        }

	    public double WeekSalary
	    {
		    get { return this.weekSalary;}
		    set 
            {
                if (value < 0)
	                        {
                                throw new ArgumentOutOfRangeException("Week Salary should be >= 0!");		 
	                        }                
                this.weekSalary = value;
            }
	    }
        
            public double WorkHoursPerDay
	    {
		    get { return this.workHoursPerDay;}
		    set 
            {
                if (value<=0)
	                        {
                                throw new ArgumentOutOfRangeException("Week Salary should be > 0!");		 
	                        }                
                this.workHoursPerDay = value;
            }
	    }

	    public double MoneyEarnedPerHour()
	    {             
            return this.weekSalary/(this.workHoursPerDay*5);
	    }

        public override string ToString()
        {

            return string.Format("{0,-12} {1,-12} {2,-15} {3} {4,15:f2}", this.FirstName, this.LastName, this.WeekSalary,
            this.WorkHoursPerDay, this.MoneyEarnedPerHour());
        }
    }
}
