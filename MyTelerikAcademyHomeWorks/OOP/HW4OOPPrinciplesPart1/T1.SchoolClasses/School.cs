//  We are given a school. In the school there are classes of students.

namespace T1.SchoolClasses
{
using System;
using System.Collections.Generic;
using System.Text;

    public class School
    {
        private string name; 
        private List<SchoolClass> schoolClasses;

        public School(string name)
        {
            this.Name=name;
            this.schoolClasses = new List<SchoolClass>();
        }
        
        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }
        public List<SchoolClass> SchoolClasses
        {
            get
            {
                return new List<SchoolClass>(this.schoolClasses);
            }
        }

        public void AddClass(SchoolClass schoolClass)
        {
            this.schoolClasses.Add(schoolClass);
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine(string.Format("Student Class: {0}", this.Name));
            foreach (SchoolClass schoolClass in schoolClasses)
            {
                result.AppendLine(" * " + schoolClass.ToString());
            }
            return result.ToString();
        }
    }
}
