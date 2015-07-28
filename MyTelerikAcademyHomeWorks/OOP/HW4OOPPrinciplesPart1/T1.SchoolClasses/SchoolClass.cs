//  In the school there are classes of students
//  Each class has a set of teachers.
//  Each teacher teaches a set of disciplines.
//  Classes have unique text identifier.
//  Students, classes, teachers and disciplines could have optional comments (free text block). 

namespace T1.SchoolClasses
{   
using System;
using System.Collections.Generic;
using System.Text;
using CreaturesClassLib;

    public class SchoolClass: ICommentable
    {
        private string classID;
        private List<Teacher> listOfTeachers;
        private List<Student> listOfStudents;
        public SchoolClass(string classID)
        {
            this.ClassID = classID;
            this.listOfTeachers = new List<Teacher>();
            this.listOfStudents = new List<Student>();
        }
        public string ClassID
        {
            get
            {
                return this.classID;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Text Identifier cannot be null or empty");
                }
                this.classID = value;
            }
        }
        public List<Teacher> ListOfTeachers
        {
            get
            {
                return new List<Teacher>(this.listOfTeachers);
            }
        }
        public List<Student> ListOfStudents
        {
            get
            {
                return new List<Student>(this.listOfStudents);
            }
        }

        public string Comment { get; private set; }

        public void WriteComment(string text)
        {
            this.Comment = text;
        }

        public void AddTeacher(params Teacher[] teachers)
        {
            for (int i = 0; i < teachers.Length; i++)
            {
                this.listOfTeachers.Add(teachers[i]);
            }
        }
        public void AddTeacher(Teacher teacher)
        {
            this.listOfTeachers.Add(teacher);
        }
        public void AddStudent(Student student)
        {
            this.listOfStudents.Add(student);
        }
        public void AddStudent(params Student[] students)
        {
            for (int i = 0; i < students.Length; i++)
            {
                this.listOfStudents.Add(students[i]);
            }
        }
        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine(string.Format("Class: {0}", this.ClassID));
            foreach (Teacher teacher in this.ListOfTeachers)
            {
                result.Append(" *" + teacher.ToString());
            }
            foreach (Student st in this.ListOfStudents)
            {
                result.AppendLine(" *" + st.ToString());
            }
            return result.ToString();
        }       
    }
}
