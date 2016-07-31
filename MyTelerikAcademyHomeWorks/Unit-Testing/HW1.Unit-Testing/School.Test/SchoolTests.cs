using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace School.Test
{
    [TestClass]
    public class SchoolTests
    {
        [TestMethod]
        public void AddingSchoolShouldNotThrowException()
        {
            School school = new School("TelerikAcademyByProgress");
        }

        [TestMethod]
        public void SchoolShouldReturnExpectedSchoolName()
          {
            var school = new School("Telerik Academy By Progress");
            Assert.AreEqual("Telerik Academy By Progress", school.Name);
          }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void SchoolShouldThrowArgumentNullExceptionWhenNameIsNull()
        {
            var school = new School(null); 
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void SchoolShouldThrowArgumentNullExceptionWhenNameIsEmptyString()
        {
            var school = new School(String.Empty); 
        }

        [TestMethod]
        public void SchoolShouldAddStudentCorrectly()
        {
            var school = new School("Telerik Academy By Progress");
            var student = new Student("Humpty Dumpty", 10000);
            school.AddStudent(student);

            Assert.AreSame(student, school.Students.First());
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void SchoolShouldThrowExceptionWhenNullStudentAdded()
        {
            var school = new School("Telerik Academy By Progress");
            school.AddStudent(null);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void SchoolShouldThrowExceptionWhenExistingStudentAdded()
        {
            var school = new School("Telerik Academy By Progress");
            Student student = new Student("Humpty Dumpty", 10000);
            school.AddStudent(student);
            school.AddStudent(student);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void SchoolShouldThrowExceptionWhenAddingStudentWithDuplicateId()
        {
            var school = new School("Telerik Academy By Progress");
            var student = new Student("Humpty Dumpty", 10000);
            var otherStudent = new Student("Chimijimi Chamijomi", 10000);
            school.AddStudent(student);
            school.AddStudent(otherStudent);
        }

        [TestMethod]
        public void SchoolShouldRemoveStudentCorrectly()
        {
            var school = new School("Telerik Academy By Progress");
            var student = new Student("Humpty Dumpty", 10000);
            school.AddStudent(student);
            school.RemoveStudent(student);
            Assert.AreEqual(0, school.Students.Count());
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void SchoolShouldThrowExceptionOnNullStudentRemoval()
        {
            var school = new School("Telerik Academy By Progress");
            school.RemoveStudent(null);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void SchoolShouldThrowExceptionOnUnexistingStudentRemoval()
        {
            var school = new School("Telerik Academy By Progress");
            Student student = new Student("Humpty Dumpty", 10000);
            school.RemoveStudent(student);
        }
            
        [TestMethod]
        public void SchoolShouldAddCourseCorrectly()
        {
            var school = new School("Telerik Academy By Progress");
            var course = new Course("Unit Testing");
            school.AddCourse(course);

            Assert.AreSame(course, school.Courses.First());
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void SchoolShouldThrowExceptionWhenNullCourseAdded()
        {
            var school = new School("Telerik Academy By Progress");
            school.AddCourse(null);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void SchoolShouldThrowExceptionWhenExistingCourseAdded()
        {
            var school = new School("Telerik Academy By Progress");
            Course course = new Course("Unit Testing");
            school.AddCourse(course);
            school.AddCourse(course);
        }

        [TestMethod]
        public void SchoolShouldRemoveCourseCorrectly()
        {
            var school = new School("Telerik Academy By Progress");
            var course = new Course("Unit Testing");
            school.AddCourse(course);
            school.RemoveCourse(course);
            Assert.AreEqual(0, school.Courses.Count());
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void SchoolShouldThrowExceptionOnNullCourseRemoval()
        {
            var school = new School("Telerik Academy By Progress");
            school.RemoveCourse(null);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void SchoolShouldThrowExceptionOnUnexistingCourseRemoval()
        {
            var school = new School("Telerik Academy By Progress");
            Course course = new Course("Unit Testing");
            school.RemoveCourse(course);
        }
    }
}
