namespace IntergalacticTravel.Tests
{
    using IntergalacticTravel;
    using IntergalacticTravel.Exceptions;
    using IntergalacticTravel.Contracts;
    using NUnit.Framework;
    using System;

    [TestFixture]
    class UnitTests
    {
        [Test]
        public void Pay_WhenTheObjectPassedIsNull_ShouldThrowNullReferenceException()
        {
            // Arrange
            var someUnit = new Unit(1, "Mimi");        

            // Act&Assert
            Assert.Throws<NullReferenceException>(() => someUnit.Pay(null));
        }
        
        [Test]
        public void Pay_ShouldDecreaseResourcesAmountOfTheOwnerByCostAmount()
        {
            // Arrange
            var mimi = new Unit(1, "Mimi");
            mimi.Resources.BronzeCoins = 25;
            mimi.Resources.SilverCoins = 50;
            mimi.Resources.GoldCoins = 100;

            var cost = new Resources(5, 7, 60);

            // Act
            mimi.Pay(cost);

            // Assert
            Assert.AreEqual(20, mimi.Resources.BronzeCoins);
            Assert.AreEqual(43, mimi.Resources.SilverCoins);
            Assert.AreEqual(40, mimi.Resources.GoldCoins);
        }

        [Test]
        public void Pay_ShouldReturnResourceObjectWithTheAmountOfResourcesInTheCostObject()
        {
            // Arrange
            var mimi = new Unit(1, "Mimi");
            mimi.Resources.BronzeCoins = 25;
            mimi.Resources.SilverCoins = 50;
            mimi.Resources.GoldCoins = 100;

            var cost = new Resources(5, 7, 60);

            // Act
            var returnObject = mimi.Pay(cost);

            // Assert
            Assert.IsInstanceOf<Resources>(returnObject);
            Assert.AreEqual(cost.BronzeCoins, returnObject.BronzeCoins);
            Assert.AreEqual(cost.SilverCoins, returnObject.SilverCoins);
            Assert.AreEqual(cost.GoldCoins, returnObject.GoldCoins);
        }
    }
}
