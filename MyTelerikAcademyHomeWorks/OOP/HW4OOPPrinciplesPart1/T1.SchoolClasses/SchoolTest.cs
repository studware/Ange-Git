//  Таск 1
//  Your task is to identify the classes (in terms of OOP) and their attributes and operations,
//  encapsulate their fields, define the class hierarchy and create a class diagram with Visual Studio.


namespace T1.SchoolClasses
{
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
    class SchoolTest
    {
        static void Main()
        {

            School mySchool = new School("Telerik Academy");

            // Creating students
            Student[] studentsFirstGroup = new Student[]
            {
                new Student("Adelina", "Ivanova", 6543278),
                new Student("Ivan", "Stoqnow", 9856745),
                new Student("Yan", "Bibiyan", 2916789),
                new Student("Rishard", "Gere", 9712387),
                new Student("Jenifer", "Lourence", 1824356),
                new Student("Kalin", "Vrachanski", 8354625)
            };

            Student[] studentsSecondGroup = new Student[]
            {
                new Student("Zajchenctzeto", "Bjalo", 1342032),
                new Student("Njakoj", "Si", 2333224),
                new Student("Hitar", "Petar", 3023555),
                new Student("Princessa", "Iya", 2234554),
                new Student("Nikoleta", "Zlatkova", 7765004),
                new Student("Nikoleta", "Daneva", 3023100)
            };

            // Creating disciplines
            Discipline cSharp = new Discipline("OOP", 30, 34);
            Discipline javaScript = new Discipline("HQPC", 44, 52);
            Discipline html = new Discipline("DSA", 48, 60);
            Discipline css = new Discipline("HTML5");

            // Creating teachers
            Teacher teacher1 = new Teacher("Nikolay", "Kostov");
            Teacher teacher2 = new Teacher("Ivaylo", "Kenov");
            Teacher teacher3 = new Teacher("Doncho", "Minkov");
            Teacher teacher4 = new Teacher("Evlogi", "Hristov");

            // Add teachers
            teacher1.AddDiscipline(javaScript, html, css);
            teacher2.AddDiscipline(cSharp);
            teacher3.AddDiscipline(html);
            teacher4.AddDiscipline(css);

            // Creating classes
            SchoolClass firstClass = new SchoolClass("Computer Science");
            SchoolClass secondClass = new SchoolClass("Web Design");
            firstClass.AddTeacher(teacher1, teacher2);
            secondClass.AddTeacher(teacher1, teacher3, teacher4);
            firstClass.AddStudent(studentsFirstGroup);
            secondClass.AddStudent(studentsSecondGroup);

            // Add classes
            mySchool.AddClass(firstClass);
            mySchool.AddClass(secondClass);

            Console.WriteLine(mySchool);
        }
    }
}
