using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Domain.CodeChallenge.DataImport.PropertyMatchingStrategies.Tests
{
    [TestClass()]
    public class PunctuationStrategyTests
    {
        private PunctuationStrategy _punctuationStrategy;

        [TestInitialize]
        public void TestInitialize()
        {
            _punctuationStrategy = new PunctuationStrategy();
        }

        [TestCleanup]
        public void TestCleanup()
        {
            _punctuationStrategy = null;
        }

        [TestMethod()]
        public void IsMatch_ReturnsTrueWhenNameAndAddressMatch1()
        {
            var agencyProp = new Property()
            {
                Name = "*Super*-High! APARTMENTS (Sydney)",
                Address = "32 Sir John-Young Crescent, Sydney, NSW"
            };
            var databaseProp = new Property()
            {
                Name = "Super High Apartments, Sydney",
                Address = "32 Sir John Young Crescent, Sydney NSW"
            };
            Assert.IsTrue(_punctuationStrategy.IsMatch(agencyProp, databaseProp));
        }

        [TestMethod()]
        public void IsMatch_ReturnsTrueWhenNameAndAddressMatch2()
        {
            var agencyProp = new Property()
            {
                Name = "*Super*-High!   APARTMENTS (Sydney)",
                Address = "32 Sir John-Young Crescent, Sydney, NSW"
            };
            var databaseProp = new Property()
            {
                Name = "Super High Apartments, Sydney",
                Address = "32 Sir John Young Crescent, Sydney NSW"
            };
            Assert.IsTrue(_punctuationStrategy.IsMatch(agencyProp, databaseProp));
        }

        [TestMethod()]
        public void IsMatch_ReturnsTrueWhenNameAndAddressAreIdentical()
        {
            var agencyProp = new Property()
            {
                Name = "Super High Apartments, Sydney",
                Address = "32 Sir John Young Crescent, Sydney NSW"
            };
            var databaseProp = new Property()
            {
                Name = "Super High Apartments, Sydney",
                Address = "32 Sir John Young Crescent, Sydney NSW"
            };
            Assert.IsTrue(_punctuationStrategy.IsMatch(agencyProp, databaseProp));
        }

        [TestMethod()]
        public void IsMatch_ReturnsFalseWhenNameAddressesAreIdenticalButEmpty()
        {
            var agencyProp = new Property()
            {
                Name = string.Empty,
                Address = string.Empty
            };
            var databaseProp = new Property()
            {
                Name = string.Empty,
                Address = string.Empty
            };
            Assert.IsFalse(_punctuationStrategy.IsMatch(agencyProp, databaseProp));
        }

        [TestMethod()]
        public void IsMatch_ReturnsFalseWhenNameAddressesAreIdenticalButNull()
        {
            var agencyProp = new Property()
            {
                Name = null,
                Address = null
            };
            var databaseProp = new Property()
            {
                Name = null,
                Address = null
            };
            Assert.IsFalse(_punctuationStrategy.IsMatch(agencyProp, databaseProp));
        }

        [TestMethod()]
        public void IsMatch_ReturnsFalseWhenNamesDontMatch()
        {
            var agencyProp = new Property()
            {
                Name = "*Super*-High! APARTMENTS (Sydney)",
                Address = "32 Sir John-Young Crescent, Sydney, NSW"
            };
            var databaseProp = new Property()
            {
                Name = "Super High Apartments, Syd",
                Address = "32 Sir John Young Crescent, Sydney NSW"
            };
            Assert.IsFalse(_punctuationStrategy.IsMatch(agencyProp, databaseProp));
        }

        [TestMethod()]
        public void IsMatch_ReturnsFalseWhenAddressesDontMatch()
        {
            var agencyProp = new Property()
            {
                Name = "*Super*-High! APARTMENTS (Sydney)",
                Address = "32 Sir John-Young Crescent, Sydney, NSW"
            };
            var databaseProp = new Property()
            {
                Name = "Super High Apartments, Sydney",
                Address = "34 Sir John Young Crescent, Sydney NSW"
            };
            Assert.IsFalse(_punctuationStrategy.IsMatch(agencyProp, databaseProp));
        }
    }
}