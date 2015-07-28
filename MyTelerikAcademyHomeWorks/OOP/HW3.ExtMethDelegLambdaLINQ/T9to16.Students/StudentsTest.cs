namespace T9to16.Students
{
using System;
using System.Collections.Generic;
using System.Linq;

    class StudentsTest
    {
        public static List<Student> listOfStudents = new List<Student>(){
                    new Student("Ivan", "Draganov", "34745606","+359212345123", "draganov@gmail.com", 3, 3, 3, 3, 5, 4, 1),
                    new Student("Peter", "Petrov", "88888844", "+359212345123", "peter@abv.bg", 2, 2, 3, 2, 5),
                    new Student("Anelia", "Koseva", "34678706","+359898111222", "aneli@abv.bg", 2, 6, 5, 6, 4),
                    new Student("Evlampi", "Lampov", "98787634","+359888345654", "lampi@yahoo.com", 3, 6, 6, 6, 4, 6, 5),
                    new Student("Lili", "Markova", "34546789","+359212345123", "lili@abv.bg", 2, 2, 2, 3, 4),
                    new Student("Prokopy", "Prokopiev", "87656767","+359333444555", "pro@gmail.com",2, 5, 6, 6, 4, 6, 3),
                    new Student("Baj", "Ganyo", "99999999","0289899908", "ganyo@gmail.com", 3, 3, 3, 3, 4, 3, 6)
                };
        static void Main(string[] args)
        {
            Task9();
            Task10();
            Task11();
            Task12();
            Task13();
            Task14();
            Task15();
            Task16();
        }

        private static void Task9()
        {
            Console.WriteLine("T.9: Students from group 2 ordered by FirstName ascending (using LINQ):");
            var groupNumber2Students =
                                        from student in listOfStudents
                                        where student.GroupNumber == 2
                                        orderby student.FirstName
                                        select student;

            foreach (var student in groupNumber2Students)
            {
                Console.WriteLine(student);
            }
        }

        private static void Task10()
        {
            Console.WriteLine("\nT.10: Students from group 2 ordered by FirstName ascending (extension methods):");

            List<Student> studentsFromGroup2 = listOfStudents.GetListOfStudentsInExactGroup(2);

            foreach (var student in studentsFromGroup2)
            {
                Console.WriteLine(student);
            }

        }

        private static void Task11()
        {
            Console.WriteLine("\nT.11: All students that have email in abv.bg (using string methods and LINQ):");

            var studentsWithMailInABV = from student in listOfStudents
                                        where student.Email.Substring(student.Email.LastIndexOf("@")) == "@abv.bg"
                                        select student;

            foreach (var student in studentsWithMailInABV)
            {
                Console.WriteLine(student);
            }
        }

        private static void Task12()
        {
            Console.WriteLine("\nT.12: All students with phones in Sofia (using LINQ):");

            var StudentsWithPhonesInSofia = from student in listOfStudents
                                            where student.Telephone.StartsWith("+3592") || student.Telephone.StartsWith("02")
                                            select student;

            foreach (var student in StudentsWithPhonesInSofia)
            {
                Console.WriteLine(student);
            }

        }

        private static void Task13()
        {
            Console.WriteLine("\nT.13: All students having at least one mark (6)\ninto a new anonymous class with properties FullName and Marks\n");

            var studentsWithAtLeastOneSix =
                        from student in listOfStudents
                        where student.Marks.Contains(6)
                        select new
                        {
                            FullName = string.Format("{0,-10} {1,-10}", student.FirstName, student.LastName),
                            Marks = student.Marks
                        };

            foreach (var student in studentsWithAtLeastOneSix)
            {
                Console.WriteLine(student.FullName + " - marks: " + string.Join(", ", student.Marks));
            }
        }

        private static void Task14()
        {
            Console.WriteLine("\nT.14: Like in task13 extract the students\nwith exactly two marks 2 using extension methods");

            List<Student> studentsFromGroup2 = listOfStudents.GetListOfStudentsWithNumberOfMarks(2, 2);

            foreach (var student in studentsFromGroup2)
            {
                Console.WriteLine(student);
            }
        }

        private static void Task15()
        {
            Console.WriteLine("\nT.15:Extract all marks of the students enrolled in 2006.\n(They have 06 as their 5-th and 6-th digit in the FN)\n");

            var MarksFromStudentsEnrolledIn2006 = from student in listOfStudents
                                                  where student.FacultyNumber.EndsWith("06")
                                                  select new
                                                  {
                                                      FullName = string.Format("{0,-10} {1,-10}", student.FirstName, student.LastName),
                                                      Marks = student.Marks
                                                  };

            foreach (var student in MarksFromStudentsEnrolledIn2006)
            {
                Console.WriteLine(student.FullName + " - marks: " + string.Join(", ", student.Marks));
            }
        }

        private static void Task16()
        {
            Console.WriteLine("\nT.16:Create a class Group with properties GroupNumber and DepartmentName.");
            Console.WriteLine("Introduce a property Group in the Student class.");
            Console.WriteLine("Extract all students from Mathematics department. Use the Join operator.\n");

            List<Group> groups = new List<Group>()
            {
                new Group(1, "Physics"),
                new Group(2, "Arts"),
                new Group(3, "Mathematics"),
                new Group(4, "Law"),
                new Group(5, "Medicine"),
                new Group(6, "Biology"),
            };

            var StudentsFromGroupMathematics = from student in listOfStudents
                                               join grp in groups on student.GroupNumber equals grp.GroupNumber
                                               where grp.DepartmentName == "Mathematics"
                                               select student;

            foreach (var student in StudentsFromGroupMathematics)
            {
                Console.WriteLine(student);
            }
        }
    }
}
