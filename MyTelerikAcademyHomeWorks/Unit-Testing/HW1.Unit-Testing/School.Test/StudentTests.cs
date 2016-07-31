using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace School.Test
{
    [TestClass]
    public class StudentTests
    {
        [TestMethod]
        public void AddingTheFirstStudentShouldNotThrowException()
        {
            Student firstStudentInTheSchool = new Student("Humpty Dumpty", 10000);
        }

        [TestMethod]
          public void StudentShouldReturnExpectedId()
          {
            var student = new Student("Humpty Dumpty", 10000);
            Assert.AreEqual(10000, student.ID);
          }

        [TestMethod]
          public void StudentShouldReturnExpectedName()
          {
            var student = new Student("Humpty Dumpty", 10000);
            Assert.AreEqual("Humpty Dumpty", student.Name);
          }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void StudentShouldThrowArgumentNullExceptionWhenNameIsNull()
        {
            var student = new Student(null,10000); 
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void StudentShouldThrowArgumentNullExceptionWhenNameIsEmptyString()
        {
            var student = new Student(String.Empty,10000); 
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void StudentShouldThrowArgumentExceptionWhenInvalidLowId()
        {
            var student = new Student("Humpty-Dumpty",9999); 
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void StudentShouldThrowArgumentExceptionWhenInvalidHighId()
        {
            var student = new Student("Humpty-Dumpty", 100000); 
        }

        [TestMethod]
        public void StudentAttendingCourseShouldNotThrowException()
        {
            Student student = new Student("Humpty Dumpty", 10000);
            Course course = new Course("Unit Testing");
            student.AttendCourse(course);
        }
        
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void StudentAttendingNullCourseShouldThrowArgumentNullException()
        {
            Student student = new Student("Humpty Dumpty", 10000);
            student.AttendCourse(null);
        }
        [TestMethod]
        public void StudentLeavingCourseShouldNotThrowException()
        {
            Student student = new Student("Humpty Dumpty", 10000);
            Course course = new Course("Unit Testing");
            student.AttendCourse(course);
            student.LeaveCourse(course);
        }
        
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void StudentLeavingNullCourseShouldThrowArgumentNullException()
        {
            Student student = new Student("Humpty Dumpty", 10000);
            student.LeaveCourse(null);
        }
    }
}
