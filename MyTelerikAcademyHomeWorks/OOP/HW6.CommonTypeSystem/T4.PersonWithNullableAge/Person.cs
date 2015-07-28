/*  Create a class Person with two fields – name and age. 
    Age can be left unspecified (may contain null value. 
    Override ToString() to display the information of a person and if age is not specified – to say so.
    Write a program to test this functionality. */

namespace T4.PersonWithNullableAge
{
using System;

    class Person
    {
        public string Name { get; set; }
        public byte? Age { get; set; }

        public Person(string name): this(name, null)
        { 
        }

        public Person(string name, byte? age)
        {
            if (name == String.Empty || name == null || name.Length < 2)
            {
                throw new ArgumentOutOfRangeException("Person name should be at least two characters long!");
            }
            else 
            {
                this.Name = name;
            }

            if ((age <=0 )||( age > 125 ))
            {
                throw new ArgumentOutOfRangeException("Person age should be in the range between 0 and 125!");
            }
            else 
            {
                this.Age = age;
            }        
        }

        public override String ToString()
        {
            return String.Format("{0,-20}: age {1}", 
                this.Name, 
                this.Age.ToString()!="" ? this.Age.ToString() : "not specified");
        }
    }
}
