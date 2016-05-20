using Microsoft.VisualStudio.TestTools.UnitTesting;
using Domain.CodeChallenge.DataImport;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.CodeChallenge.DataImport.Tests
{
    [TestClass()]
    public class GeoLocationHelperTests
    {
        const double ShortDistanceEpsilon = 2; //1 meter
        const double LongDistanceEpsilon = 300; // 300m

        [TestMethod()]
        public void CalculateFlatDistance_LongDistance1()
        {
            var distance = GeoLocationHelper.CalculateFlatDistance(31, 20, 32, 20);
            Assert.AreEqual(111000, distance, LongDistanceEpsilon);
        }

        [TestMethod()]
        public void CalculateFlatDistance_LongDistance2()
        {
            var distance = GeoLocationHelper.CalculateFlatDistance(31, -49, 31, -50);
            Assert.AreEqual(111000, distance, LongDistanceEpsilon);
        }

        [TestMethod()]
        public void CalculateFlatDistance_ShortDistance1()
        {
            var distance = GeoLocationHelper.CalculateFlatDistance(-33.861500m, 151.209460m, -33.863281m, 151.209000m);
            Assert.AreEqual(202.54, distance, ShortDistanceEpsilon);
        }

        [TestMethod()]
        public void CalculateFlatDistance_ShortDistance2()
        {
            var distance = GeoLocationHelper.CalculateFlatDistance(-33.861500m, 151.209225m, -33.863281m, 151.209010m);
            Assert.AreEqual(199.03, distance, ShortDistanceEpsilon);
        }

    }
}