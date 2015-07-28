

namespace T3to5StudentData
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    class StudentDataManipulations
    {
        class Student
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public int Age { get; set; }
        }
        static void Main()
        {
            var students = new Student[] 
            {
                new Student{FirstName = "Elka", LastName = "Ivanova", Age = 24},
                new Student{FirstName = "Pooh", LastName = "Bear", Age = 3},
                new Student{FirstName = "Robert", LastName = "Redford", Age = 77},
                new Student{FirstName = "Jennifer", LastName = "Laurence", Age = 23},
                new Student{FirstName = "Elka", LastName = "Todorova", Age = 36},
            };
            Console.WriteLine("Students List:\nFirst Name\tLast Name\tAge");
            WriteQueryResult(students);

            /* Task 3.Write a method that from a given array of students finds all students whose first name 
               is before its last name alphabetically. Use LINQ query operators. */
            //lambda            var firstBeforeLastName = students.Where(st=>st.FirstName.CompareTo(st.LastName) < 0);

            var firstBeforeLastName =
                from st in students
                where st.FirstName.CompareTo(st.LastName) < 0
                select st;
            Console.WriteLine("\nStudents with first name before lastname alphabetically (LINQ):");
            WriteQueryResult(firstBeforeLastName);

            /* Task 4.Write a LINQ query that finds the first name and last name of all students with age between 18 and 24. */
            //lambda    var ageBetween18And24 = students.Where(st => st.Age < 24 && st.Age > 18);

            var ageBetween18And24 =
                from st in students
                where (st.Age < 24 && st.Age > 18)
                select st;

            Console.WriteLine("\nStudents with age between 18 and 24 (LINQ):");
            WriteQueryResult(ageBetween18And24);

            /* Task 5.Using the extension methods OrderBy() and ThenBy() with lambda expressions sort the students
                by first name and last name in descending order. Rewrite the same with LINQ. */
            //  lambda            var sortByFirstLastName = students.OrderByDescending(st => st.FirstName).ThenByDescending(st => st.LastName);

            var sortByFirstLastName=
                from st in students
                orderby st.FirstName descending,
                st.LastName descending
                select st;
                
            Console.WriteLine("\nStudents sorted descending by first name then by last name (lambda):");
            WriteQueryResult(sortByFirstLastName);

            Console.WriteLine("\nAlternative examples using lambda/linq are commented in code.");
        }

        private static void WriteQueryResult(IEnumerable<Student> queryResultSet)
        {
            foreach (var stud in queryResultSet)
            {
                Console.WriteLine("{0,-15} {1,-10} {2,8}", stud.FirstName, stud.LastName, stud.Age);
            }
        }
    }
}
