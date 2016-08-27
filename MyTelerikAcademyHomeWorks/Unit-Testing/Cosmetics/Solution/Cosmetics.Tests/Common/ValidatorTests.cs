namespace Cosmetics.Tests
{
    using Cosmetics.Common;
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class ValidatorTests
    {
        [Test]
        public void CheckIfNull_WhenObjParamIsNull_ShouldThrowNullReferenseException()
        {
            Assert.Throws<NullReferenceException>(() => Validator.CheckIfNull(null,
                "CheckIfNull should throw NullReferenceException, when the parameter 'obj' is null."));
        }

        [Test]
        public void CheckIfNull_WhenObjParamIsValid_ShouldNotThrow()
        {
            Assert.DoesNotThrow(()=>Validator.CheckIfNull("obj not null",
                "CheckIfNull shouldn't throw any Exception, when the parameter 'obj' is NOT null."));
        }

        [Test]
        public void CheckIfStringIsNullOrEmpty_WhenTextParam_IsNull_ShouldThrowNullReferenseException()
        {
            Assert.Throws<NullReferenceException>(() => Validator.CheckIfStringIsNullOrEmpty(null,
                "CheckIfStringIsNullOrEmpty should throw NullReferenceException, when the parameter 'text' is null."));
        }

        [Test]
        public void CheckIfStringIsNullOrEmpty_WhenTextParam_IsEmptyStringShouldThrowNullReferenseException()
        {
            Assert.Throws<NullReferenceException>(() => Validator.CheckIfStringIsNullOrEmpty(String.Empty,
                "CheckIfStringIsNullOrEmpty should throw NullReferenceException, when the parameter 'text' is empty string."));
        }

        [Test]
        public void CheckIfStringIsNullOrEmpty_WhenTextParam_IsValidShould_NOT_Throw()
        {
            Assert.DoesNotThrow(() => Validator.CheckIfStringIsNullOrEmpty("text is not null",
                "CheckIfNull shouldn't throw any Exception, when the parameter 'obj' is NOT null."));
        }

        [Test]
        [TestCase("Elly", 10, 5, null)]
        [TestCase("This is a large text whose lenth iz beyond upper limit ", 15, 10, "Greater than max value")]
        public void CheckIfStringLengthIsValid_WhenTextLengthInvalid_ShouldThrowIndexOutOfRangeException(string text, int max, int min, string message)
        {
            Assert.Throws<IndexOutOfRangeException>(() => Validator.CheckIfStringLengthIsValid(text, max, min, message));

        } 


        [Test]
        public void CheckIfStringLengthIsValid_WhenTextLengthIsValidShouldNotThrowException()
        {
            Assert.DoesNotThrow(() => Validator.CheckIfStringLengthIsValid("wezghjk", 15, 0, null));
        }




    }
}
