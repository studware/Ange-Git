//  In the school there are classes of students
//  Students have name and unique class number. 
//  Students, classes, teachers and disciplines could have optional comments (free text block).

namespace T1.SchoolClasses
{
using CreaturesClassLib;
    public class Student: Human, ICommentable
    {
        private int classNumber;

        public Student(string firstName, string lastName, int classNumber)
            : base(firstName, lastName)
        {
            this.ClassNumber = classNumber;            
        }

	    public int ClassNumber
	    {
		    get { return this.classNumber;}
		    set { this.classNumber = value;}
	    }

        public string Comment { get; private set; }

        public void WriteComment(string text)
        {
            this.Comment = text;
        }

        public override string ToString()
        {
        
            return string.Format("Student: {0,-15} {1,-15} ID: {2}", this.FirstName, this.LastName, this.ClassNumber);
        }
    }
}
