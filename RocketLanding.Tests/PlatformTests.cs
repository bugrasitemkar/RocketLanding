using System.Drawing;
using RocketLanding.Extensions;
using RocketLanding.Models;
using Xunit;

namespace RocketLanding.Tests
{
    /// <summary>
    ///     Contains tests for <see cref="Platform"/>
    /// </summary>
    public class PlatformTests
    {
        public class PlatformShould
        {
            /// <summary>
            ///     Given <see cref="Platform"/> is initiated properly
            ///     When called with a valid RockedId and query point and the rocket can land
            ///     Then it should return OK
            /// </summary>
            [Fact]
            public void SuccessfullyReturnCanLand()
            {
                //Arrange
                int rocketId = 1;
                Platform p = new Platform(10, new Point(5, 5));

                //Act
                var canLand = p.CanLandOnPoint(rocketId, new Point(12, 13));

                //Assert
                Assert.True(canLand == Response.OK.GetDisplayName());
            }

            /// <summary>
            ///     Given <see cref="Platform"/> is initiated properly
            ///     When called with a valid RockedId and query point and the rocket can not land due to out of platform
            ///     Then it should return out of platform
            /// </summary>
            [Fact]
            public void SuccessfullyReturnOutOfPlatform()
            {
                //Arrange
                int rocketId = 1;
                Platform p = new Platform(10, new Point(5, 5));

                //Act
                var canLand = p.CanLandOnPoint(rocketId, new Point(16, 17));

                //Assert
                Assert.True(canLand == Response.OutOfPlatform.GetDisplayName());
            }

            /// <summary>
            ///     Given <see cref="Platform"/> is initiated properly
            ///     When called with a valid RockedId and query point and the rocket can not land due to a rocket previously checked
            ///     Then it should return clash
            /// </summary>
            [Fact]
            public void SuccessfullyReturnClash()
            {
                //Arrange
                int firstRocket = 1;
                int secondRocket = 1;

                Platform p = new Platform(10, new Point(0, 0));
                p.CanLandOnPoint(firstRocket, new Point(5, 5));

                //Act
                var secondRocketCanLand = p.CanLandOnPoint(secondRocket, new Point(4, 5));

                //Assert
                Assert.True(secondRocketCanLand == Response.Clash.GetDisplayName());
            }
        }
    }
}
