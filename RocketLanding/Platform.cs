using System;
using System.Drawing;
using RocketLanding.Utilities;
using RocketLanding.Models;
using RocketLanding.Persistance;
using RocketLanding.Extensions;

namespace RocketLanding
{
    /// <summary>
    ///     Platform controls for landing rockets
    /// </summary>
    public class Platform
    {
        private Tuple<Point, Point> PlatformDiagonal;

        /// <summary>
        ///     Construction of the Platform
        /// </summary>
        /// <param name="length">Length of one side of the platform</param>
        /// <param name="origin">Origin of start</param>
        public Platform(int length, Point origin)
        {
            PlatformDiagonal = Geometry.ConstructSquare(origin, length);
        }

        /// <summary>
        ///     Checks if a point can be landed on
        /// </summary>
        /// <param name="rocketId">Id for the rocket querying</param>
        /// <param name="queryPoint">Point of query</param>
        /// <returns></returns>
        public string CanLandOnPoint(int rocketId, Point queryPoint)
        {
            bool withinPlatform = Geometry.CheckWithinSquare(PlatformDiagonal, queryPoint);
            if(!withinPlatform)
            {
                return Response.OutOfPlatform.GetDisplayName();
            }

            bool clashPreviousCheckIn = CheckPreviousCheckIns(queryPoint);
            if(clashPreviousCheckIn)
            {
                return Response.Clash.GetDisplayName();
            }

            CheckedLocations.SaveOrUpdateLocations(rocketId, queryPoint);

            return Response.OK.GetDisplayName();
        }

        private bool CheckPreviousCheckIns(Point queryPoint)
        {           
            var checkedLocations = CheckedLocations.GetCheckedLocations();
            foreach (var checkedLocation in checkedLocations)
            {
                bool clashPreviousCheckIn = Geometry.CheckWithinSquare(
                    Geometry.ConstructSquare(checkedLocation.Value),queryPoint);

                if (clashPreviousCheckIn)
                {
                    return true;
                }
            }

            return false;
        }        
    }
}
