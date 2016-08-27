namespace IntergalacticTravel.Tests
{
    using IntergalacticTravel;
    using IntergalacticTravel.Contracts;
    using NUnit.Framework;
    using System.Collections;
    using System.Collections.Generic;

    [TestFixture]
    class BusinessOwnerTests
    {
        [Test]
        public void CollectProfits_ShouldIncreaseOwnerResourses_ByTotalAmountGeneratedFromTeleportStationsInHisPossession()
        {
            // Arrange
            IEnumerable<ITeleportStation> teleportStations = new List<ITeleportStation>();

            var owner = new BusinessOwner(12, "Ivan", teleportStations);
            owner.Resources.Clear();
            var payment = new Resources(20,30,40);
            owner.Resources.Add(payment);

            // Act
            owner.CollectProfits();

            // Assert
            Assert.AreEqual(20, owner.Resources.BronzeCoins);
            Assert.AreEqual(30, owner.Resources.SilverCoins);
            Assert.AreEqual(40, owner.Resources.GoldCoins);
        }
    }
}
