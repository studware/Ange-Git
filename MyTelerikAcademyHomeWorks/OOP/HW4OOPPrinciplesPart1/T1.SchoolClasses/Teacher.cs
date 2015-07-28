//  Each class has a set of teachers.
//  Each teacher teaches a set of disciplines.
//  Teachers have name.  Both teachers and students are people.
//  Students, classes, teachers and disciplines could have optional comments (free text block). 

namespace T1.SchoolClasses
{
using System.Collections.Generic;
using System.Text;
using CreaturesClassLib;

    public class Teacher: Human, ICommentable
    {
        private List<Discipline> disciplines;
        public Teacher(string firstName, string lastName)
            :base(firstName, lastName)
        {
            this.disciplines = new List<Discipline>();
        } 
        public List<Discipline> Disciplines
        {
            get
            {
                return new List<Discipline>(disciplines);
            }
        }

        public string Comment { get; private set; }

        public void WriteComment(string text)
        {
            this.Comment = text;
        }

        public void AddDiscipline(Discipline discipline)
        {
            this.disciplines.Add(discipline);
        }

        public void AddDiscipline(params Discipline[] disciplines)
        {
            for (int i = 0; i < disciplines.Length; i++)
            {
            this.disciplines.Add(disciplines[i]);                
            }

        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine(string.Format("Teacher: {0} {1}", this.FirstName, this.LastName));
            foreach (Discipline discipline in disciplines)
            {
                result.AppendLine(" * " + discipline.ToString());
            }
            return result.ToString();
        }
    }
}
