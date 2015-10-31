namespace ConsoleStudentSystem.Data
{
    using System;
    using System.Collections.Generic;
    using ConsoleStudentSystem.Models;
    using System.Data.Entity;
    using System.Linq;
    public class StudentSystemContext: DbContext
    {
        public StudentSystemContext() 
            :base("StudentSystem")
        { 
        }
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Homework> Homeworks { get; set; }
    }
}
