using System.Collections.Generic;
using System.Drawing;

namespace RocketLanding.Persistance
{
    /// <summary>
    ///     Persistance for previously checked locations
    /// </summary>
    public static class CheckedLocations
    {
        private static Dictionary<int, Point> Locations;

        static CheckedLocations()
        {
            Locations = new Dictionary<int, Point>();
        }

        /// <summary>
        ///     Saves or Updated the checked locations
        /// </summary>
        /// <param name="rocketId"></param>
        /// <param name="queryPoint"></param>
        public static void SaveOrUpdateLocations(int rocketId, Point queryPoint)
        {
            if (Locations.ContainsKey(rocketId))
            {
                Locations[rocketId] = queryPoint;
            }
            else
            {
                Locations.Add(rocketId, queryPoint);
            }
        }

        /// <summary>
        ///     Returns checked locations dictionary
        /// </summary>
        /// <returns></returns>
        public static Dictionary<int, Point> GetCheckedLocations()
        {
            return Locations;
        }
    }
}
