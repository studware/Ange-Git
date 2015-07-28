using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T18to19.StudentsByGroup
{
    class StudentsByGroup
    {

// T18.Create a program that extracts all students grouped by GroupName and then prints them to the console. Use LINQ.

        static void GroupByGroupsWithLinq()
        {
            var studentsGroupedByGroupsWithLinq =
                from st in students
                group st by st.GroupName into studentsGroup
                orderby studentsGroup.Key
                select studentsGroup;

            foreach (var currentGroup in studentsGroupedByGroupsWithLinq)
            {
                Console.WriteLine("{0}\n-------------", currentGroup.Key);

                foreach (var student in currentGroup)
                {
                    Console.WriteLine(student.FullName);
                }
                Console.WriteLine();
            }
        }

// 19.Rewrite the previous using extension methods.

        static void GroupByGroupsWithLambda()
        {
            var studentsGroupedByGroupsWithLambda = students.GroupBy(x => x.GroupName).OrderBy(x => x.Key);

            foreach (var currentGroup in studentsGroupedByGroupsWithLambda)
            {
                Console.WriteLine("{0}\n-------------",currentGroup.Key);

                foreach (var student in currentGroup)
                {
                    Console.WriteLine(student.FullName);
                }
                Console.WriteLine();
            }
        }

        static Student[] students;

        static void Main()
        {
            students = new Student[]
            {
                new Student("By Ivan", "Mathematics"),
                new Student("Baba Tzotzolana", "Computer Science"),
                new Student("Evlampi Evlampiev", "Computer Science"),
                new Student("Karamphilka Karamphilova", "Physics"),
                new Student("Prokopi Prokopiev", "Computer Science"),
                new Student("Kaka Veska", "Mathematics")
            };

            Console.WriteLine("Students by groups with LINQ:\n");
            GroupByGroupsWithLinq();

            Console.WriteLine("\n----------------------------------------------------------------\n");

            Console.WriteLine("Students by groups with extension methods:\n");
            GroupByGroupsWithLambda();
        }
    }
}
