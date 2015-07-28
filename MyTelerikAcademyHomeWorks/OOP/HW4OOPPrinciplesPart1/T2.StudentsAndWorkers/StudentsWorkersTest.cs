// Initialize a list of 10 students and sort them by grade in ascending order 
// (use LINQ or OrderBy() extension method).
//  Initialize a list of 10 workers and sort them by money per hour in descending order.
//  Merge the lists and sort them by first name and last name.

namespace T2.StudentsAndWorkers
{
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CreaturesClassLib;

    class StudentsWorkersTest
    {
        static void Main()
        {
            // Creating students
            List<Student> students = new List<Student>
            {
                new Student("Adelina", "Ivanova", 3.54),
                new Student("Yan", "Bibiyan", 3.50),
                new Student("Rishard", "Gere", 4.25),
                new Student("Jenifer", "Lourence", 6),
                new Student("Kalin", "Vrachanski", 5.75),
                new Student("Zajchenctzeto", "Bjalo", 4.20),
                new Student("Njakoj", "Si", 3.33),
                new Student("Hitar", "Petar", 5.55),
                new Student("Princessa", "Iya", 5.54),
                new Student("Nikoleta", "Doneva", 4.00)
            };

            Console.WriteLine("\nInitial list of students:");

            foreach (var item in students)
            {
                Console.WriteLine(item);
            }

            //  creating workers
            List<Worker> workers = new List<Worker>()
            {
                new Worker("Krasimir", "Dimitrov", 459, 42),
                new Worker("Lilia", "Ivanova", 186, 18),
                new Worker("Asen", "Manolov", 304, 25),
                new Worker("Elena", "Petrova", 956, 50),
                new Worker("Alexander", "Ivanov", 389, 30),
                new Worker("Angel", "Peshev", 111, 15),
                new Worker("Svetoslava", "Stoyanova", 222, 20),
                new Worker("Angelina", "Dimitrova", 333, 36),
                new Worker("Evlampi", "Trichkov", 444, 40),
                new Worker("Karamphilka", "Blumberg", 555, 48)
            };

            Console.WriteLine("{0}Initial list of workers:\n" +
            "     Worker\t\tWeekSalary  WorkHoursPerDay  MoneyEarnedPerHour\n", new string('-', 80));

            foreach (var item in workers)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("{0}\nStudents sorted by grade ascending:", new string('-', 80));

//  sort students by grade ascending           
            var studentsSortedByGradeAsc = from st in students
                                           orderby st.Grade
                                           select st;

            foreach (var item in studentsSortedByGradeAsc)
            {
                Console.WriteLine(item);                
            }

            Console.WriteLine("{0}\nWorkers sorted by money per hour descending: \n", new string('-', 80));

//  sort workers by money per hour descending 
            var workersSortedByEarnDesc = from w in workers
                                          orderby w.MoneyEarnedPerHour()
                                          descending
                                          select w;

            foreach (var item in workersSortedByEarnDesc)
            {
                Console.WriteLine(item);                
            }

            Console.WriteLine("{0}\nStudents and workers merged then sorted by first name and last name: \n", new string('-', 80));
            //  merge the lists and sort then by first name and last name
            IEnumerable<Human> people =
                                (students as IEnumerable<Human>).Union(workers);

            var orderedHumans =
                                from human in people
                                orderby human.FirstName ascending, human.LastName ascending
                                select human;
            foreach (var human in orderedHumans)
            {
                Console.WriteLine("{0,-16} {1,-12}", human.FirstName, human.LastName);
            }
            Console.WriteLine("\nPlease, scroll up to see the output.");
        }
    }
}
