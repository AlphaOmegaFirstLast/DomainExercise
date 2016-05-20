using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Domain.CodeChallenge.DataImport.PropertyMatchingStrategies.Tests
{
    [TestClass()]
    public class LocationStrategyTests
    {
        private LocationStrategy _locationStrategy;

        [TestInitialize]
        public void TestInitialize()
        {
            _locationStrategy = new LocationStrategy();
        }

        [TestCleanup]
        public void TestCleanup()
        {
            _locationStrategy = null;
        }

        [TestMethod()]
        public void IsMatch_ReturnsTrueForIgnorableDistances()
        {
            var agencyProp = new Property()
            {
                Latitude = -33.804610m,
                Longitude = 151.005784m,
                AgencyCode = "LRE"
            };
            var databaseProp = new Property()
            {
                Latitude = -33.804579m,
                Longitude = 151.005527m,
                AgencyCode = "LRE"
            };
            Assert.IsTrue(_locationStrategy.IsMatch(agencyProp, databaseProp));
        }

        [TestMethod()]
        public void IsMatch_ReturnsTrueForIgnorableDistances_BoundryCondition()
        {
            // distance : 199.126m 
            var agencyProp = new Property()
            {
                Latitude = -33.861500m,
                Longitude = 151.209225m,
                AgencyCode="LRE"
            };
            var databaseProp = new Property()
            {
                Latitude = -33.863281m,
                Longitude = 151.209010m,
                AgencyCode = "LRE"
            };
            Assert.IsTrue(_locationStrategy.IsMatch(agencyProp, databaseProp));
        }

        [TestMethod()]
        public void IsMatch_ReturnsFalseForConsiderableDistances1()
        {
            var agencyProp = new Property()
            {
                Latitude = -33.804579m,
                Longitude = 151.005527m,
                AgencyCode = "LRE"
            };
            var databaseProp = new Property()
            {
                Latitude = -33.808652m,
                Longitude = 151.005249m,
                AgencyCode = "LRE"
            };
            Assert.IsFalse(_locationStrategy.IsMatch(agencyProp, databaseProp));
        }

        [TestMethod()]
        public void IsMatch_ReturnsFalseForConsiderableDistances2()
        {
            var agencyProp = new Property()
            {
                Latitude = -33.804579m,
                Longitude = 151.005527m,
                AgencyCode = "LRE"
            };
            var databaseProp = new Property()
            {
                Latitude = -33.807652m,
                Longitude = 151.105249m,
                AgencyCode = "LRE"
            };
            Assert.IsFalse(_locationStrategy.IsMatch(agencyProp, databaseProp));
        }

        [TestMethod()]
        public void IsMatch_ReturnsFalseForConsiderableDistances_BoundryCondition()
        {
            // distance 201.58m
            var agencyProp = new Property()
            {
                Latitude = -33.863443m,
                Longitude = 151.210959m,
                AgencyCode = "LRE"
            };
            var databaseProp = new Property()
            {
                Latitude = -33.863621m,
                Longitude = 151.208781m,
                AgencyCode = "LRE"
            };
            Assert.IsFalse(_locationStrategy.IsMatch(agencyProp, databaseProp));
        }

        [TestMethod()]
        public void IsMatch_ReturnsFalseForNonRelevantAgencies()
        {
            var agencyProp = new Property()
            {
                Latitude = -33.804610m,
                Longitude = 151.005784m,
                AgencyCode = "LRE"
            };
            var databaseProp = new Property()
            {
                Latitude = -33.804579m,
                Longitude = 151.005527m,
                AgencyCode = "XYZ"
            };
            Assert.IsFalse(_locationStrategy.IsMatch(agencyProp, databaseProp));
        }
    }
}