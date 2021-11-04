using System;
using System.Drawing;

namespace RocketLanding.Utilities
{
    /// <summary>
    ///     Geometric calculations
    /// </summary>
    public static class Geometry
    {
        /// <summary>
        ///     Checks if a point within a square of given diagonal
        /// </summary>
        /// <param name="diagonal"></param>
        /// <param name="query"></param>
        /// <returns></returns>
        public static bool CheckWithinSquare(Tuple<Point, Point> diagonal, Point query)
        {
            bool xAxis = diagonal.Item1.X <= query.X && query.X <= diagonal.Item2.X;
            if (!xAxis)
            {
                return false;
            }

            bool yAxis = diagonal.Item1.Y <= query.Y && query.Y <= diagonal.Item2.Y;
            if (!yAxis)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        ///     Construct a square from immeadiate neighboring points of given middle point
        /// </summary>
        /// <param name="middlePoint"></param>
        /// <returns>Diagonal representation of a square</returns>
        public static Tuple<Point,Point> ConstructSquare(Point middlePoint)
        {
            return new Tuple<Point, Point>(
                        new Point(middlePoint.X - 1, middlePoint.Y - 1),
                        new Point(middlePoint.X + 1, middlePoint.Y + 1));
        }

        /// <summary>
        ///     Construct a square from origin (upper-left) and length
        /// </summary>
        /// <param name="origin"></param>
        /// <returns>Diagonal representation of a square</returns>
        public static Tuple<Point, Point> ConstructSquare(Point origin, int length)
        {
            return new Tuple<Point, Point>(
                        origin,
                        new Point(origin.X + length, origin.Y + length));
        }
    }
}
