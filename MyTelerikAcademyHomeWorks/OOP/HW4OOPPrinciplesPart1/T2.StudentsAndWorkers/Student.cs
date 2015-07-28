//  Define abstract class Human with a first name and a last name.  
//  Define a new class Student which is derived from Human
//  and has a new field – grade.
//  Define the proper constructors and properties for this hierarchy. 

namespace T2.StudentsAndWorkers
{
using System;
using CreaturesClassLib;
    public class Student: Human
    {
        private double grade;

        public Student(string firstName, string lastName, double grade)
            : base(firstName, lastName)
        {
            this.Grade = grade;            
        }

	    public double Grade
	    {
		    get { return this.grade;}
		    set { this.grade = value;}
	    }

        public override string ToString()
        {
        
            return string.Format("Student: {0,-15} {1,-12} Grade: {2}", this.FirstName, this.LastName, this.Grade);
        }
    }
}
