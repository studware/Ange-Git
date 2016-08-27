namespace IntergalacticTravel.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using NUnit.Framework;
    using IntergalacticTravel.Contracts;

    [TestFixture]
    public class TeleportStationTests
    {
        [Test]
        public void Constructor_WhenNewTeleportStationCreatedWithValidParams_ShouldSetUpAllProvidedFields()
        {
            // Arrange

           // ITeleportStation teleportStation = new TeleportStation(); 
            // Act

            // Assert   
        }

        /*TeleportUnit should throw ArgumentNullException, with a message that contains the string "unitToTeleport",
        when IUnit unitToTeleport is null. */
        [Test]
        public void TeleportUnit_WhenUnitToTeleportIsNull_ShouldThrowArgumentNullException_WithMessage_unitToTeleport()
        {
            // Arrange


            // Act&Assert
 //           Assert.Throws<ArgumentNullException>(() => TeleportUnit(null, "command");
        }
    }
}
