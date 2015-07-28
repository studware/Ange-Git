//  Disciplines have name, number of lectures and number of exercises.
//  Students, classes, teachers and disciplines could have optional comments (free text block).

namespace T1.SchoolClasses
{
using System;
using System.Text;
using CreaturesClassLib;

    public class Discipline: ICommentable
    {
        private string name;
        private int numLectures;
        private int numExercises;

        public Discipline(string name)
        {
            this.Name = name;
        }

        public Discipline(string name, int numLectures, int numExercises)
            :this(name)
        {
            this.NumLectures = numLectures;
            this.NumExercises = numExercises;
        }

        public string Name
        {
            get { return this.name; }
            set 
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Discipline Name cannot be null nor empty!");                    
                }                
                this.name = value; 
            }
        }
        
        public int NumLectures
        {
            get { return this.numLectures; }
            set 
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Number of Lectures cannot have negative value!");                    
                }                
                this.numLectures = value; 
            }
        }
        
        public int NumExercises
        {
            get { return this.numExercises; }
            set 
            {
                if (value < 0)
                {
                    throw new ArgumentNullException("Number of Exercises cannot have negative value!");                    
                }                
                this.numExercises = value; 
            }
        }

        public string Comment { get; private set; }

        public void WriteComment(string text)
        {
            this.Comment = text;
        }

        public override string ToString()
        {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine(string.Format("Discipline: {0}", this.Name));
        sb.AppendLine(string.Format(" lectures: {0}", this.NumLectures));
        sb.AppendLine(string.Format(" exercises: {0}", this.NumExercises));

        return sb.ToString();
        }
    }
}
