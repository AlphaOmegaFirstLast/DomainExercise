using Microsoft.VisualStudio.TestTools.UnitTesting;
using Domain.CodeChallenge.DataImport;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.CodeChallenge.DataImport.PropertyMatchingStrategies;

namespace Domain.CodeChallenge.DataImport.Tests
{
    [TestClass()]
    public class PropertyMatchingStrategyFactoryTests
    {
        [TestMethod()]
        public void Create_ReturnsCorrectStrategyForOTBRE()
        {
            var agentCode = "OTBRE";
            Assert.IsInstanceOfType(PropertyMatchingStrategyFactory.Create(agentCode),typeof(PunctuationStrategy));
        }

        [TestMethod()]
        public void Create_ReturnsCorrectStrategyForLRE()
        {
            var agentCode = "LRE";
            Assert.IsInstanceOfType(PropertyMatchingStrategyFactory.Create(agentCode), typeof(LocationStrategy));
        }

        [TestMethod()]
        public void Create_ReturnsCorrectStrategyForCRE()
        {
            var agentCode = "CRE";
            Assert.IsInstanceOfType(PropertyMatchingStrategyFactory.Create(agentCode), typeof(BackwardNameStrategy));
        }

        [TestMethod()]
        public void Create_ReturnsGenericStrategyForOtherAgencies()
        {
            var agentCode = "OtherAgencyCode";
            Assert.IsInstanceOfType(PropertyMatchingStrategyFactory.Create(agentCode), typeof(GenericStrategy));
        }
    }
}