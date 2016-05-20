using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Domain.CodeChallenge.DataImport.PropertyMatchingStrategies.Tests
{
    [TestClass()]
    public class BackwardNameStrategyTests
    {
        private BackwardNameStrategy _backwarNameStrategy;

        [TestInitialize]
        public void TestInitialize()
        {
            _backwarNameStrategy = new BackwardNameStrategy();
        }

        [TestCleanup]
        public void TestCleanup()
        {
            _backwarNameStrategy = null;
        }

        [TestMethod()]
        public void IsMatch_ReturnsTrueWhenReverseNameMatch1()
        {
            var agencyProp = new Property()
            {
                Name = "Apartments Summit The",
                Address = "32 Sir John-Young Crescent, Sydney, NSW"
            };
            var databaseProp = new Property()
            {
                Name = "The Summit Apartments",
                Address = "32 Sir John Young Crescent, Sydney"
            };
            Assert.IsTrue(_backwarNameStrategy.IsMatch(agencyProp, databaseProp));
        }

        [TestMethod()]
        public void IsMatch_ReturnsTrueWhenReverseNameMatch2()
        {
            var agencyProp = new Property()
            {
                Name = "Hello world",
                Address = "32 Sir John-Young Crescent, Sydney, NSW"
            };
            var databaseProp = new Property()
            {
                Name = "World   Hello",
                Address = "32 Sir John Young Crescent, Sydney"
            };
            Assert.IsTrue(_backwarNameStrategy.IsMatch(agencyProp, databaseProp));
        }
    }
}