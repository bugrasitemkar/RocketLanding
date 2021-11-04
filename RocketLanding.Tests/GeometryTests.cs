using System;
using System.Collections.Generic;
using System.Drawing;
using RocketLanding.Utilities;
using Xunit;

namespace RocketLanding.Tests
{
    /// <summary>
    ///     Contains tests for <see cref="Geometry"/>
    /// </summary>
    public class GeometryTests
    {
        public class GeometryShould
        {
            /// <summary>
            ///     Given <see cref="Geometry.ConstructSquare(Point)"/>
            ///     When called with a valid middle point
            ///     Then it should construct a diagonal representation of a square successfully
            /// </summary>
            [Fact]
            public void ConstructSquareFromMiddlePointSuccessfully()
            {
                //Arrange
                Point middlePoint = new Point(3, 3);

                //Act
                var diagonal = Geometry.ConstructSquare(middlePoint);

                //Assert
                Assert.True(diagonal.Item1.X == middlePoint.X - 1);
                Assert.True(diagonal.Item1.Y == middlePoint.Y - 1);
                Assert.True(diagonal.Item2.X == middlePoint.X + 1);
                Assert.True(diagonal.Item2.Y == middlePoint.Y + 1);
            }

            // <summary>
            ///     Given <see cref="Geometry.ConstructSquare(Point, int)"/>
            ///     When called with a valid origin point and length
            ///     Then it should successfully construct a square starting from origin with the given length
            /// </summary>
            [Fact]
            public void ConstructSquareSuccessfully()
            {
                //Arrange
                Point point = new Point(0, 0);

                //Act
                var diagonal = Geometry.ConstructSquare(point, 5);

                //Assert
                Assert.True(diagonal.Item1.X == 0);
                Assert.True(diagonal.Item1.Y == 0);
                Assert.True(diagonal.Item2.X == 5);
                Assert.True(diagonal.Item2.Y == 5);

            }

            public static IEnumerable<object[]> testDataForCheckIfAGivenPointWithinSquare =>
            new List<object[]>
            {
                new object[] { new Point(0,0), 5, new Point(3,3),true },
                new object[] { new Point(3,3), 10, new Point(15,15),false },
            };

            // <summary>
            ///     Given <see cref="Geometry.CheckWithinSquare(Tuple{Point, Point}, Point)"/>
            ///     When called with a valid point to query
            ///     Then it should successfully assert if the given point within square or not
            /// </summary>
            [Theory]
            [MemberData(nameof(testDataForCheckIfAGivenPointWithinSquare))]
            public void CheckIfAGivenPointWithinSquare(Point originOfPlatform, int lengthOfSides,Point query,bool expected)
            {
                //Arrange
                var diagonal = Geometry.ConstructSquare(originOfPlatform, lengthOfSides);

                //Act
                var withinSquare = Geometry.CheckWithinSquare(diagonal, query);

                //Assert
                Assert.True(withinSquare == expected);
            }
        }
    }
}
