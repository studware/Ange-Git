namespace IntergalacticTravel.Tests
{
    using IntergalacticTravel;
    using IntergalacticTravel.Exceptions;
    using NUnit.Framework;
    using System;

    [TestFixture]
    class ResourcesFactoryTests
    {
        [TestCase("create resources gold(20) silver(30) bronze(40)")]
        [TestCase("create resources gold(20) bronze(40) silver(30)")]
        [TestCase("create resources silver(30) bronze(40) gold(20)")]
        [TestCase("create resources silver(30) gold(20) bronze(40)")]
        [TestCase("create resources bronze(40) gold(20) silver(30)")]
        [TestCase("create resources bronze(40) silver(30) gold(20)")]
        public void GetResources_WhenCorrectFormatOfInputNoMatterOfParamsOrder_ShouldReturnNewResourcesObject_WithCorrectPropertiess(string command)
        {
            // Arrange&Act
            var resourcesFactory = new ResourcesFactory();
            var expectedResult = resourcesFactory.GetResources(command);

            // Assert
            Assert.IsInstanceOf<Resources>(expectedResult);
            Assert.AreEqual(20, expectedResult.GoldCoins);
            Assert.AreEqual(30, expectedResult.SilverCoins);
            Assert.AreEqual(40, expectedResult.BronzeCoins);
        }

        [TestCase("create resources x y z")]
        [TestCase("tansta resources a b")]
        [TestCase("absolutelyRandomStringThatMustNotBeAValidCommand")]

        public void GetResources_WhenInvalidCommandPassed_ShouldThrowInvalidOperationException_ContainingStringCommand(string invalidCommand)
        {
            // Arrange
            var resourcesFactory = new ResourcesFactory();

            // Act&Assert
            Assert.Throws<InvalidOperationException>(() => resourcesFactory.GetResources(invalidCommand),"command");
        }

        [TestCase("create resources silver(10) gold(97853252356623523532) bronze(20)")]
        [TestCase("create resources silver(555555555555555555555555555555555) gold(97853252356623523532999999999) bronze(20)")]
        [TestCase("create resources silver(10) gold(20) bronze(4444444444444444444444444444444444444)")]

        public void GetResources_WhenValidCommandWithAmountLargerThanMaxIsPassed_ShouldThrowOverflowException(string invalidCommand)
        {
            // Arrange
            var resourcesFactory = new ResourcesFactory();

            // Act&Assert
            Assert.Throws<OverflowException>(() => resourcesFactory.GetResources(invalidCommand));
        }
    }
}
