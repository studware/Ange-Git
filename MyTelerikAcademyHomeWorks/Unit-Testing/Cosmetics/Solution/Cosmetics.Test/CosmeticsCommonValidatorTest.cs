using Cosmetics.Common;
using NUnit.Framework;
using System;

namespace Cosmetics.Test
{


    [TestFixture]
    public class CosmeticsCommonValidatorTest
    {
        [Test]
        public void NullParameter_obj_ShouldThrowNullReferenseException()
        {
            Assert.Throws<NullReferenceException>(() => Validator.CheckIfNull(null,
                "CheckIfNull should throw NullReferenceException, when the parameter 'obj' is null."));
        }

        [Test]
        public void NotNullParameter_obj_ShouldNotThrowNullReferenseException()
        {
            Assert.DoesNotThrow(()=>Validator.CheckIfNull("obj not null",
                "CheckIfNull shouldn't throw any Exception, when the parameter 'obj' is NOT null."));
        }

        [Test]
        public void CheckIfStringIsNullOrEmptyShouldThrowNullReferenseExceptionWhenParameter_text_IsNull()
        {
            Assert.Throws<NullReferenceException>(() => Validator.CheckIfStringIsNullOrEmpty(null,
                "CheckIfStringIsNullOrEmpty should throw NullReferenceException, when the parameter 'text' is null."));
        }

        [Test]
        public void CheckIfStringIsNullOrEmptyShouldThrowNullReferenseExceptionWhenParameter_text_IsNEmptyString()
        {
            Assert.Throws<NullReferenceException>(() => Validator.CheckIfStringIsNullOrEmpty(String.Empty,
                "CheckIfStringIsNullOrEmpty should throw NullReferenceException, when the parameter 'text' is empty string."));
        }

        [Test]
        public void CheckIfStringIsNullOrEmptyShould_NOT_ThrowExceptionWhenParameter_text_IsNotNullOrEmpty()
        {
            Assert.DoesNotThrow(() => Validator.CheckIfStringIsNullOrEmpty("text is not null",
                "CheckIfNull shouldn't throw any Exception, when the parameter 'obj' is NOT null."));
        }

        [Test]
        [TestCase("Elly", 10, 5, null)]
        [TestCase("This is a large text whose lenth iz beyond upper limit ", 15, 10, "Greater than max value")]
        public void CheckIfStringLengthIsValidShouldThrowIndexOutOfRangeExceptionOnTextLengthBeyondMinOrMax(string text, int max, int min, string message)
        {
            Assert.Throws<IndexOutOfRangeException>(() => Validator.CheckIfStringLengthIsValid(text, max, min, message));

        } 


        [Test]
        public void CheckIfStringLengthIsValidShouldNotThrowExceptionOnTextLengthInAllowedRange()
        {
            Assert.DoesNotThrow(() => Validator.CheckIfStringLengthIsValid("wezghjk", 15, 0, null));
        }




    }
}
