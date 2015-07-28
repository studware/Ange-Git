namespace T1.HelperMethods
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// The class Student describes the type Student
    /// </summary>
    public class Student
    {
        private string firstName; 
        private string lastName;
        private DateTime dateOfBirth;
        private string town = string.Empty;
        private string comment = string.Empty;

        public Student()
        {
        }

        public Student(string firstName, string lastName)
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
                if (value == null)
                {
                    throw new ArgumentNullException(this.firstName, "First name is null!");
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
                if (value == null)
                {
                    throw new ArgumentNullException(this.lastName, "Last name is null!");
                }

                this.lastName = value;
            }
        }
        
        public DateTime DateOfBirth
        {
            get
            {
                return this.dateOfBirth;
            }

            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Date of birth is null!");
                }

                this.dateOfBirth = value;
            }
        }

        public string Town { get; set; }

        public string Comment { get; set; }

        /// <summary>
        /// The method compares the birth date of given student to other student's birthdate
        /// </summary>
        /// <param name="The other student whose birth date will be compared"></param>
        /// <returns>true - if the student is older then the other student</returns>
        public bool IsOlderThan(Student otherStudent)
        {
            return this.DateOfBirth < otherStudent.DateOfBirth;
        }
    }
}