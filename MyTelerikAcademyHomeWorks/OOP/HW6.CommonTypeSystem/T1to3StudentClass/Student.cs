/*  Task 1. Define a class Student, which contains data about a student – first, middle and last name, SSN,
    permanent address, mobile phone e-mail, course, specialty, university, faculty. 
    Use an enumeration for the specialties, universities and faculties.
    Override the standard methods, inherited by System.Object: Equals(), ToString(), GetHashCode() and operators == and !=
    Add implementations of the ICloneable interface. 
    Task 2. The Clone() method should deeply copy all object's fields into a new object of type Student.
    Task 3. Implement the IComparable<Student> interface to compare students by names (as first criteria, in lexicographic order)
    and by social security number (as second criteria, in increasing order).
*/

namespace T1to3StudentClass
{
using System;
using System.Text;

//  Task 1
    public class Student: ICloneable, IComparable<Student>
    {
        public string FirstName  { get; set; }
        public string MiddleName  { get; set; }
        public string LastName  { get; set; }
        public string IdSSN  { get; set; }
        public string Address  { get; set; }
        public string Mobile  { get; set; }
        public string Email  { get; set; }
        public string Course  { get; set; }
        public University University { get; set; }
        public Faculty Faculty { get; set; }
        public Specialty Specialty { get; set; }

        public Student(string firstName, string middleName,string lastName, string idSSN, 
                        string address, string mobile, string email, string course, 
                        University university, Faculty faculty, Specialty specialty)
	    {
            this.FirstName=firstName;
            this.MiddleName = middleName;
            this.LastName = lastName;
            this.IdSSN = idSSN;
            this.Address = address;
            this.Mobile = mobile;  
            this.Email = email;  
            this.Course = course; 
            this.University = university;
            this.Faculty = faculty;
            this.Specialty = specialty;

	    }

        public Student(string firstName, string middleName, string lastName, string idSSN)
                        :this(firstName, middleName, lastName, idSSN, null, null, null, null,
                            University.None, Faculty.None, Specialty.None)
        {
        }

        public override bool Equals(object param)
        {
            if (!(param is Student))
            {
                return false;
            }
            Student student = param as Student;
            if (student.FirstName != this.FirstName || student.MiddleName != this.MiddleName ||
                student.LastName != this.LastName || student.IdSSN != this.IdSSN)
            {
                return false;
            }
            return true;
        }

        public static bool operator ==(Student student1, Student student2)
        {
            return student1.Equals(student2);
        }

        public static bool operator !=(Student student1, Student student2)
        {
            return !(student1.Equals(student2));
        }

        public override int GetHashCode()
        {
            return this.FirstName.GetHashCode() ^ this.IdSSN.GetHashCode();
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            var properties = this.GetType().GetProperties();
            sb.Append("******************************************\n");

            foreach (var prop in properties)
            {
                sb.AppendFormat("{0,-10}: {1,-10}\n", prop.Name, prop.GetValue(this));
            }
            return sb.ToString();
        }

//  Task 2       
        public Student Clone()
        {
            return new Student(this.FirstName, this.MiddleName, this.LastName, this.IdSSN, this.Address,
                    this.Mobile, this.Email, this.Course, this.University, this.Faculty, this.Specialty);

        }

        object ICloneable.Clone()
        {
            return this.Clone();
        }

//  Task 3
        public int CompareTo(Student studentX)  
        {
            if (studentX == null)
            {
                return 1;
            }


            else
            {
                if (this.FirstName != studentX.FirstName)
                {
                    return this.FirstName.CompareTo(studentX.FirstName);
                }
                else if (this.MiddleName != studentX.MiddleName)
                {
                    return this.MiddleName.CompareTo(studentX.MiddleName);
                }
                else if (this.LastName != studentX.LastName)
                {
                    return this.LastName.CompareTo(studentX.LastName);
                }
                else if (this.IdSSN != studentX.IdSSN)
                {
                    return this.IdSSN.CompareTo(studentX.IdSSN);
                }
                else
                {
                    return 0;
                }
            }
        }
    }
}
