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
    public class PropertyMatchContextTests
    {
        private PropertyMatchContext _propertyMatchContext;
        [TestInitialize]
        public void TestInitialize()
        {
            _propertyMatchContext = new PropertyMatchContext();
        }

        [TestCleanup]
        public void TestCleanup()
        {
            _propertyMatchContext = null;
        }

        [TestMethod()]
        public void IsMatch_ReturnsTrueWhenMatch_OTBRE()
        {
            var agencyProp = new Property()
            {
                Name = "*Super*-High! APARTMENTS (Sydney)",
                Address = "32 Sir John-Young Crescent, Sydney, NSW",
                AgencyCode = "OTBRE",
                Latitude = -31,
                Longitude= 151
            };
            var databaseProp = new Property()
            {
                Name = "Super High Apartments, Sydney",
                Address = "32 Sir John Young Crescent, Sydney NSW",
                Latitude = -32,
                Longitude = 151
            };
            Assert.IsTrue(_propertyMatchContext.IsMatch(agencyProp, databaseProp));
        }

        [TestMethod()]
        public void IsMatch_ReturnsTrueWhenMatch_OTBRE1()
        {
            var agencyProp = new Property()
            {
                Name = "Super High Apartments, Sydney",
                Address = "32 Sir John Young Crescent, Sydney NSW",
                AgencyCode = "OTBRE",
                Latitude = -31,
                Longitude = 151
            };
            var databaseProp = new Property()
            {
                Name = "Super High Apartments, Sydney",
                Address = "32 Sir John Young Crescent, Sydney NSW",
                AgencyCode = "OTBRE",
                Latitude = -32,
                Longitude = 151
            };
            Assert.IsTrue(_propertyMatchContext.IsMatch(agencyProp, databaseProp));
        }

        [TestMethod()]
        public void IsMatch_ReturnsTrueWhenNoMatch_OTBRE()
        {
            var agencyProp = new Property()
            {
                Name = "*Super*-High! APARTMENTS (Sydney)",
                Address = "32 Sir John-Young Crescent, Sydney, NSW",
                AgencyCode = "OTBRE",
                Latitude = -31,
                Longitude = 151
            };
            var databaseProp = new Property()
            {
                Name = "Super Apartments, Sydney",
                Address = "32 Sir John Young Crescent, Sydney NSW",
                AgencyCode = "OTBRE",
                Latitude = -32,
                Longitude = 151
            };
            Assert.IsFalse(_propertyMatchContext.IsMatch(agencyProp, databaseProp));
        }

        [TestMethod()]
        public void IsMatch_ReturnsTrueWhenMatch_LRE()
        {
            var agencyProp = new Property()
            {
                Name = "*Super*-High! APARTMENTS (Sydney)",
                Address = "32 Sir John-Young Crescent, Sydney, NSW",
                AgencyCode = "LRE",
                Latitude = -33.861500m,
                Longitude = 151.209225m
            };
            var databaseProp = new Property()
            {
                Name = "Super Apartments, Sydney",
                Address = "32 Sir John Young Crescent, Sydney NSW",
                AgencyCode = "LRE",
                Latitude = -33.863281m,
                Longitude = 151.209010m
            };
            Assert.IsTrue(_propertyMatchContext.IsMatch(agencyProp, databaseProp));
        }

        [TestMethod()]
        public void IsMatch_ReturnsTrueWhenNoMatch_LRE()
        {
            var agencyProp = new Property()
            {
                Name = "*Super*-High! APARTMENTS (Sydney)",
                Address = "32 Sir John-Young Crescent, Sydney, NSW",
                AgencyCode = "LRE",
                Latitude = -33.861500m,
                Longitude = 151.209225m
            };
            var databaseProp = new Property()
            {
                Name = "Super Apartments, Sydney",
                Address = "32 Sir John Young Crescent, Sydney NSW",
                AgencyCode = "LRE",
                Latitude = -33.863281m,
                Longitude = 151.210010m
            };
            Assert.IsFalse(_propertyMatchContext.IsMatch(agencyProp, databaseProp));
        }

        [TestMethod()]
        public void IsMatch_ReturnsTrueWhenMatch_CRE()
        {
            var agencyProp = new Property()
            {
                Name = "Property good my",
                Address = "32 Sir John-Young Crescent, Sydney, NSW",
                AgencyCode = "CRE",
                Latitude = -33.861500m,
                Longitude = 151.209225m
            };
            var databaseProp = new Property()
            {
                Name = "My good property",
                Address = "34 Sir John Young Crescent, Sydney NSW",
                AgencyCode = "CRE",
                Latitude = -33.863281m,
                Longitude = 151.220010m
            };
            Assert.IsTrue(_propertyMatchContext.IsMatch(agencyProp, databaseProp));
        }

        [TestMethod()]
        public void IsMatch_ReturnsTrueWhenNoMatch_CRE()
        {
            var agencyProp = new Property()
            {
                Name = "My property",
                Address = "32 Sir John-Young Crescent, Sydney, NSW",
                AgencyCode = "CRE",
                Latitude = -33.861500m,
                Longitude = 151.209225m
            };
            var databaseProp = new Property()
            {
                Name = "My good property",
                Address = "32 Sir John-Young Crescent, Sydney, NSW",
                AgencyCode = "CRE",
                Latitude = -33.861500m,
                Longitude = 151.209225m
            };
            Assert.IsFalse(_propertyMatchContext.IsMatch(agencyProp, databaseProp));
        }
    }
}