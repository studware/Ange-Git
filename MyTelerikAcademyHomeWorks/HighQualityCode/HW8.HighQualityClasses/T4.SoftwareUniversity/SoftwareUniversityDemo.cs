namespace T4.SoftwareUniversity
{
    using System;
    using System.Collections.Generic;

    internal class SoftwareUniversityDemo
    {
        private static void Main()
        {
            LocalCourse localCourse = new LocalCourse("DBMS");
            Console.WriteLine(localCourse);

            localCourse.Lab = "Data Warehouse";
            Console.WriteLine(localCourse);

            localCourse.Students = new List<string>() { "Stephen", "Evelina" };
            Console.WriteLine(localCourse);

            localCourse.TeacherName = "Nikolay Kostov";
            localCourse.AddStudent("Teodora");
            localCourse.AddStudent("Peter");
            Console.WriteLine(localCourse);

            OffSiteCourse offsiteCourse = new OffSiteCourse(
                "JavaScript Applications",
                "Doncho Minkov",
                new List<string>() { "Prokopy", "Maria", "Lazarina" });
            Console.WriteLine();
            Console.WriteLine(offsiteCourse);
            Console.WriteLine();
        }
    }
}