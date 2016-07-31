using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace School.Test
{
    [TestClass]
    public class CourseTests
    {
        [TestMethod]
        public void AddingCourseShouldNotThrowException()
        {
            Course course = new Course("Unit Testing");
        }

        [TestMethod]
          public void CourseShouldReturnExpectedCourseName()
          {
            var course = new Course("Unit Testing");
            Assert.AreEqual("Unit Testing", course.Name);
          }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CourseShouldThrowArgumentNullExceptionWhenNameIsNull()
        {
            var course = new Course(null); 
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CourseShouldThrowArgumentNullExceptionWhenNameIsEmptyString()
        {
            var course = new Course(String.Empty); 
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void CourseShouldThrowInvalidOperationExceptionWhenAttemptToAddMoreThanMaxCountOfStudents()
        {
            var course = new Course("Unit Testing");

            for (int i = 1; i < 32; i++)
            {
                Student student=new Student("Student"+i.ToString(), 10000+i);
                course.AddStudent(student); 
            }
        }

        [TestMethod]
        public void CourseShouldAddStudentCorrectly()
        {
            var course = new Course("Unit Testing");
            var student = new Student("Humpty Dumpty", 10000);
            course.AddStudent(student);

            Assert.AreSame(student, course.Students.First());
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CourseShouldThrowExceptionWhenNullStudentAdded()
        {
            var course = new Course("Unit Testing");
            course.AddStudent(null);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void CourseShouldThrowExceptionWhenExistingStudentAdded()
        {
            var course = new Course("Unit Testing");
            Student student = new Student("Humpty Dumpty", 10000);
            course.AddStudent(student);
            course.AddStudent(student);
        }

        [TestMethod]
        public void CourseShouldRemoveStudentCorrectly()
        {
            var course = new Course("Unit Testing");
            var student = new Student("Humpty Dumpty", 10000);
            course.AddStudent(student);
            course.RemoveStudent(student);
            Assert.AreEqual(0, course.Students.Count());
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CourseShouldThrowExceptionOnNullStudentRemoval()
        {
            var course = new Course("Unit Testing");
            course.RemoveStudent(null);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void CourseShouldThrowExceptionOnUnexistingStudentRemoval()
        {
            var course = new Course("Unit Testing");
            Student student = new Student("Humpty Dumpty", 10000);
            course.RemoveStudent(student);
        }
    }
}
