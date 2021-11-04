using System.Drawing;
using RocketLanding.Persistance;
using Xunit;

namespace RocketLanding.Tests
{
    /// <summary>
    ///     Contains tests for <see cref="CheckedLocations"/>
    /// </summary>
    public class CheckedLocationTests
    {
        public class CheckedLocationsShould
        {
            /// <summary>
            ///     Given <see cref="CheckedLocations.SaveOrUpdateLocations(int, Point)"/>
            ///     When called with a valid RockedId and query point
            ///     Then it persist the data
            /// </summary>
            [Fact]
            public void PersistCheckedLocations()
            {
                //Arrange
                Point queryPoint = new Point(3, 4);
                int RockedId = 1;

                //Act
                CheckedLocations.SaveOrUpdateLocations(RockedId, queryPoint);
                var checkedLocation = CheckedLocations.GetCheckedLocations();

                //Assert

                Assert.True(checkedLocation.ContainsKey(RockedId));
                Assert.True(checkedLocation[RockedId] == queryPoint);
            }


            /// <summary>
            ///     Given <see cref="CheckedLocations.SaveOrUpdateLocations(int, Point)"/>
            ///     When called with a valid rocked Id and query point and the rocked Id has queried before
            ///     Then it should update the record with Rocket Id with the new query point
            /// </summary>
            [Fact]
            public void UpdatePreviousRocketRecords()
            {
                //Arrange
                Point firstQuery = new Point(3, 4);
                Point secondQuery = new Point(5, 5);
                int RockedId = 1;

                //Act
                CheckedLocations.SaveOrUpdateLocations(RockedId, firstQuery);
                CheckedLocations.SaveOrUpdateLocations(RockedId, secondQuery);

                var checkedLocation = CheckedLocations.GetCheckedLocations();

                //Assert
                Assert.True(checkedLocation.ContainsKey(RockedId));
                Assert.True(checkedLocation[RockedId] == secondQuery);
            }
        }
    }
}
