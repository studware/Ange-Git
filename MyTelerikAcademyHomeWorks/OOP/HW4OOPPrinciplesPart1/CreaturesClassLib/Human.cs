//  Tasks 1 and 2: Define abstract class Human with a first name and a last name
//  (the class Human is a parent abstract class for the teachers and students( described as "people" in Task 1)
//  We create the class CreatureClassLib to hold the abstract class Human and to be referenced by Task1 and Task2 projects

namespace CreaturesClassLib
{
    using System;
    public abstract class Human
    {
        private string firstName;
        private string lastName;
        protected Human(string firstName, string lastName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
        }
        public string FirstName
        {
            get
            {
                return this.firstName;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("First name cannot be null or empty");
                }
                this.firstName = value;
            }
        }

        public string LastName
        {
            get
            {
                return this.lastName;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Last name cannot be null or empty");
                }
                this.lastName = value;
            }
        }
    }
}
