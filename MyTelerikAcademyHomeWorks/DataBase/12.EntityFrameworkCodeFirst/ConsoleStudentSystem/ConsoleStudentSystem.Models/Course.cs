namespace ConsoleStudentSystem.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Course
    {
        private ICollection<Student> students;

        public Course() 
        {
            this.students = new HashSet<Student>();
        }
        public int CourseId { get; set; }

        [MaxLength(40)]
        public string Name { get; set; }
        
        [MaxLength(100)]
        public string Description { get; set; }

        public virtual ICollection<Student> Students
        {
            get { return students; }
            set { students = value; }
        }

        public virtual Homework Homework { get; set; }
        
    }
}
