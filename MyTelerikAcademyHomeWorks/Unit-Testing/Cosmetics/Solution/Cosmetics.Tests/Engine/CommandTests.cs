namespace Cosmetics.Tests
{
    using Cosmetics.Engine;
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;

    [TestFixture]
    public class CommandTests
    {		
        [Test]
        public void Parse_WhenInputStringFormatIsValid_ShouldReturnNewCommand()
        {
            // Arrange
            var validInput = "CreateShampoo Cool Nivea 0.50 men 500 everyday";

            // Act
            var executionResult = Command.Parse(validInput);

            // Assert
            Assert.IsInstanceOf<Command>(executionResult);
        }

        [Test]
        public void Parse_WhenInputStringFormatIsValid_ShouldSetCorrectlySetNameProperty()
        {
            // Arrange
            var validInput = "CreateShampoo Cool Nivea 0.50 men 500 everyday";
            string expectedNamePropertyValue = "CreateShampoo";

            // Act
            var executionResult = Command.Parse(validInput);

            // Assert
            Assert.AreEqual(expectedNamePropertyValue,executionResult.Name);
        }

        [Test]
        public void Parse_WhenInputStringFormatIsValid_ShouldSetCorrectlySetParametersProperty()
        {
            // Arrange
            var validInput = "CreateShampoo Cool Nivea 0.50 men 500 everyday";
            var expectedParametersPropertyValue = new List<string> 
                                                                {"Cool", "Nivea", "0.50", 
                                                                "men", "500", "everyday" };
            // Act
            var executionResult = Command.Parse(validInput);

            // Assert
           CollectionAssert.AreEqual(expectedParametersPropertyValue,executionResult.Parameters);
        }

        [Test]
        public void Parse_WhenInputParamIsNull_ShouldThrowNullReferenseException()
        {
            Assert.Throws<NullReferenceException>(() => Command.Parse(null));
        }

        [Test]
        public void Parse_WhenInputParamHasInvalidName_ShouldThrowArgumentNullException_WithCorrectMessage()
        {
            //Arrange
            var invalidInput = " Cool Nivea 0.50 men 500 everyday";

            //Act&Assert
            Assert.That(() => Command.Parse(invalidInput), Throws.ArgumentNullException.With.Message.Contains("Name"));
        }

        [Test]
        public void Parse_WhenInputParamHasInvalidParameters_ShouldThrowArgumentNullException_WithCorrectMessage()
        {
            //Arrange
            var invalidInput = "CreateShampoo ";

            //Act&Assert
            Assert.That(() => Command.Parse(invalidInput), Throws.ArgumentNullException.With.Message.Contains("List"));
        }
    }
}
