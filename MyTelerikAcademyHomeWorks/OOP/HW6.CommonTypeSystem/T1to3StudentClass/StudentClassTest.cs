/*  Define a class Student, which contains data about a student – first, middle and last name, SSN,
    permanent address, mobile phone e-mail, course, specialty, university, faculty. 
    Use an enumeration for the specialties, universities and faculties.
    Override the standard methods, inherited by System.Object: Equals(), ToString(), GetHashCode() and operators == and !=
    Add implementations of the ICloneable interface. 
    The Clone() method should deeply copy all object's fields into a new object of type Student.
    Implement the IComparable<Student> interface to compare students by names (as first criteria, in lexicographic order)
    and by social security number (as second criteria, in increasing order).
*/

namespace T1to3StudentClass
{
using System;
using System.Collections.Generic;

    class StudentClassTest
    {
        static void Main()
        {
            Student student1 = new Student("Obi", "Wan", "Kenobi", "123456789",
                        "Komplex Ljulin block 123 ap.8 SOFIA", "+35999999999", "obi@amail.dom", "I",
                        University.AUBG, Faculty.SoftwareEngineering, Specialty.ComputerScience);
            Student student2 = new Student("Pippi", "Long", "Stocking", "364589302",
                                   null, null, null, null,
                                   University.None, Faculty.None, Specialty.None);
            Student student3 = new Student("Richard", "Lion", "Heart", "834657429",
                                   "Picadilly Square 15 LONDON", "+35998644454", "Richard@gmail.en", "IV",
                                   University.AUBG, Faculty.SoftwareEngineering, Specialty.ComputerScience);
            Student student4 = new Student("Adelina", "Byron", "Lovelace", "224586987",
                                   "5th. Avenue 256 New York", "+359765689", "ada@othermail.ny", "II",
                                   University.HumboldtUniversity, Faculty.History, Specialty.ComparativeLinguistics);

            Console.WriteLine("{0}\n{1}\n{2}\n{3}\n", student1, student2, student3, student4);

            Student student5 = new Student("Richard", "Lion", "Heart", "834657429",
                       "Picadilly Square 15 LONDON", "+35998644454", "Richard@gmail.en", "IV",
                       University.AUBG, Faculty.ComputerEngineering, Specialty.Electronics);

            Console.WriteLine("TASK 1");
            Console.WriteLine("{0} {1} == {2} {3}?", student2.FirstName, student2.LastName, student1.FirstName, student1.LastName);
            Console.WriteLine(student2 == student1);
            Console.WriteLine("Are they equal? {0}\n", student2.Equals(student1));
            Console.WriteLine("{0} {1} != {2} {3}?", student3.FirstName, student3.LastName, student5.FirstName, student5.LastName);
            Console.WriteLine(student3 != student5);
            Console.WriteLine("Are they equal? {0}\n", student3.Equals(student5));

            Console.WriteLine("TASK2");
            Console.WriteLine(student2);
            Student student2Copy = student2.Clone();
            Console.WriteLine("{0} {1}{2} has been DEEPLY CLONED.\n", student2.FirstName, student2.MiddleName, student2.LastName);
            student2.IdSSN = "12345678";
            student2.Address = "Nelson blvd. 81, Oslo";
            student2.Mobile = "345566899987";
            student2.Email = "pippi@norway.mail";
            student2.Course = "II";
            student2.University = University.MPEI;
            student2.Faculty = Faculty.ElectricalEngineering;
            student2.Specialty = Specialty.PowerEngineering;
            Console.WriteLine("{0} {1}{2} - ORIGINAL has been CHANGED:\n", student2.FirstName, student2.MiddleName, student2.LastName);
            Console.WriteLine(student2);
            Console.WriteLine("{0} {1}{2} - COPY DIDN'T CHANGE:\n", student2.FirstName, student2.MiddleName, student2.LastName);
            Console.WriteLine(student2Copy);

            Console.Write("Are the references to the original and the deep copy equal? ");
            Console.WriteLine(ReferenceEquals(student2, student2Copy));

            List<Student> sortedStudents = new List<Student>();
            sortedStudents.Add(student1);
            sortedStudents.Add(student2);
            sortedStudents.Add(student3);
            sortedStudents.Add(student4);
            sortedStudents.Add(student5);
            sortedStudents.Add(student2Copy);

            sortedStudents.Sort();

            Console.WriteLine("\nTASK3 - SortedStudents:\n");
            foreach (Student st in sortedStudents)
            {
                Console.WriteLine("{0} {1} {2} {3}", st.FirstName, st.MiddleName, st.LastName, st.IdSSN);
            }
        }
    }
}
