using Microsoft.VisualStudio.TestTools.UnitTesting;
using Domain.CodeChallenge.DataImport.PropertyMatchingStrategies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.CodeChallenge.DataImport.PropertyMatchingStrategies.Tests
{
    [TestClass()]
    public class GenericStrategyTests
    {
        private GenericStrategy _genericStrategy;

        [TestInitialize]
        public void TestInitialize()
        {
            _genericStrategy = new GenericStrategy();
        }

        [TestCleanup]
        public void TestCleanup()
        {
            _genericStrategy = null;
        }

        [TestMethod()]
        public void IsMatch_ReturnsTrueWhenAddressesAreIdentical()
        {
            var agencyProp = new Property()
            {
                Name = "abc",
                Address = "32 Sir John-Young Crescent, Sydney, NSW"
            };
            var databaseProp = new Property()
            {
                Name = "def",
                Address = "32 Sir John-Young Crescent, Sydney, NSW"
            };
            Assert.IsTrue(_genericStrategy.IsMatch(agencyProp, databaseProp));
        }

        [TestMethod()]
        public void IsMatch_ReturnsTrueWhenAddressesAreEqualIgnoringCase()
        {
            var agencyProp = new Property()
            {
                Name = "abc",
                Address = "32 Sir John-Young Crescent, SYDNEY, NSW"
            };
            var databaseProp = new Property()
            {
                Name = "def",
                Address = "32 sir john-Young Crescent, Sydney, NSW"
            };
            Assert.IsTrue(_genericStrategy.IsMatch(agencyProp, databaseProp));
        }

        [TestMethod()]
        public void IsMatch_ReturnsFalseWhenAddressesAreDifferent()
        {
            var agencyProp = new Property()
            {
                Name = "abc",
                Address = "34 Sir George Crescent, Sydney, NSW"
            };
            var databaseProp = new Property()
            {
                Name = "def",
                Address = "32 Sir John-Young Crescent, Sydney, NSW"
            };
            Assert.IsFalse(_genericStrategy.IsMatch(agencyProp, databaseProp));
        }
    }
}