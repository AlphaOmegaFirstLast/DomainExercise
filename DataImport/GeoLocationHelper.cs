using System;
using System.Collections.Generic;
using System.Device.Location;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.CodeChallenge.DataImport
{
    public static class GeoLocationHelper
    {
        const double DistanceToLatLongDegreeRatio = 111000; // meters (base on the assumption in the test: 111km)
        //const double DegreeToRadiantFactor = Math.PI / 180d;
        //const double EarthRadius = 6371000;

        public static double CalculateFlatDistance(decimal latitude1, decimal longitude1, decimal latitude2, decimal longitude2)
        {
            var lat1 = (double)latitude1;
            var lat2 = (double)latitude2;
            var long1 = (double)longitude1;
            var long2 = (double)longitude2;
            var deltaLat = (lat1 - lat2);
            var deltaLong = (long1 - long2);
            return Math.Sqrt(deltaLat * deltaLat + deltaLong * deltaLong) * DistanceToLatLongDegreeRatio;
        }

        //public static double CalculateGreatCircleDistance(decimal latitude1, decimal longitude1, decimal latitude2, decimal longitude2)
        //{
        //    var lat1 = GetRadiant(latitude1);
        //    var lat2 = GetRadiant(latitude2);
        //    var long1 = GetRadiant(longitude1);
        //    var long2 = GetRadiant(longitude2);
        //    var deltaLat = lat1 - lat2;
        //    var deltaLong = long1 - long2;
        //    var a = Math.Pow(Math.Sin(deltaLat / 2d), 2) + Math.Cos(lat1) * Math.Cos(lat2) * Math.Pow(Math.Sin(deltaLong / 2d), 2);
        //    var c = 2 * Math.Asin(Math.Min(1, Math.Sqrt(a)));
        //    return c * EarthRadius;
        //}

        //private static double GetRadiant(decimal degree)
        //{
        //    return (double)degree * DegreeToRadiantFactor;
        //}

        // This is an easier way to calculate distance using .net Framework
        //public static double CalculateGreatCircleDistance(decimal latitude1, decimal longitude1, decimal latitude2, decimal longitude2)
        //{
        //    var coord1 = new GeoCoordinate((double)latitude1, (double)longitude1);
        //    var coord2 = new GeoCoordinate((double)latitude2, (double)longitude2);
        //    return coord1.GetDistanceTo(coord2);
        //}
    }
}
