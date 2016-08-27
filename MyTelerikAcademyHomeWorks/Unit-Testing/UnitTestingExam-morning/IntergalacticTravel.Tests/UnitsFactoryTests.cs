namespace IntergalacticTravel.Tests
{
    using IntergalacticTravel;
    using IntergalacticTravel.Exceptions;
    using NUnit.Framework;

    [TestFixture]
    class UnitsFactoryTests
    {
        [Test]
        public void GetUnit_WhenValidCommandIsPassed_ShouldReturnNewProcyonUnit ()
        {
            // Arrange
            var validCommand = "create unit Procyon Gosho 1";
  
            // Act
            var factory = new UnitsFactory();
            var expectedResult = factory.GetUnit(validCommand);

            // Assert
            Assert.IsInstanceOf<Procyon>(expectedResult);
        }

        [Test]
        public void GetUnit_WhenValidCommandIsPassed_ShouldReturnNewLuytenUnit()
        {
            // Arrange
            var validCommand = "create unit Luyten Pesho 2";
  
            // Act
            var factory = new UnitsFactory();
            var expectedResult = factory.GetUnit(validCommand);

            // Assert
            Assert.IsInstanceOf<Luyten>(expectedResult);
        }
    
        [Test]
        public void GetUnit_WhenValidCommandIsPassed_ShouldReturnNewLacailleUnit()
        {
            // Arrange
            var validCommand = "create unit Lacaille Tosho 3";
  
            // Act
            var factory = new UnitsFactory();
            var expectedResult = factory.GetUnit(validCommand);

            // Assert
            Assert.IsInstanceOf<Lacaille>(expectedResult);
        }
        
        [TestCase("1 unit fdjfgkhf Tosho 3")]
        [TestCase("")]
        [TestCase(null)]
        [TestCase("create unit Procyon 3")]
        [TestCase("Procyon Tosho 3")]
        [TestCase("create unit Procyon k'wo da e")]

        public void GetUnit_WhenInvalidFormatOfCommandPassed_ShouldThrowInvalidUnitCreationCommandException(string invalidCommand)
        {
            // Arrange
            var factory = new UnitsFactory();        

            // Act&Assert
           Assert.Throws<InvalidUnitCreationCommandException>(() => factory.GetUnit(invalidCommand));
        }
    }
}
