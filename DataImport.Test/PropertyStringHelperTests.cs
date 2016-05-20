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
    public class PropertyStringHelperTests
    {
        [TestMethod()]
        public void IsNotEmptyAndEquals_ReturnsFalseWhenNull1()
        {
            string str1 = null;
            var str2 = "abc";
            Assert.IsFalse(str1.IsNotEmptyAndEquals(str2));
        }

        [TestMethod()]
        public void IsNotEmptyAndEquals_ReturnsFalseWhenNull2()
        {
            string str1 = null;
            var str2 = "abc";
            Assert.IsFalse(str2.IsNotEmptyAndEquals(str1));
        }

        [TestMethod()]
        public void IsNotEmptyAndEquals_ReturnsTrueWhenIdentical()
        {
            var str1 = "Identical string";
            var str2 = "Identical string";
            Assert.IsTrue(str1.IsNotEmptyAndEquals(str2));
        }

        [TestMethod()]
        public void IsNotEmptyAndEquals_ReturnsTrueWhenEqualCaseInsensitive()
        {
            var str1 = "Identical string IGNORE caSe!";
            var str2 = "identical STRING ignore case!";
            Assert.IsTrue(str1.IsNotEmptyAndEquals(str2));
        }

        [TestMethod()]
        public void TrimAndRemoveDuplicateWhitespacesTest1()
        {
            var input = "Hello   World";
            var output = "Hello World";
            Assert.AreEqual( output, input.TrimAndRemoveDuplicateWhitespaces());
        }

        [TestMethod()]
        public void TrimAndRemoveDuplicateWhitespacesTest2()
        {
            var input = "This is the test input";
            var output = "This is the test input";
            Assert.AreEqual(output, input.TrimAndRemoveDuplicateWhitespaces());
        }

        [TestMethod()]
        public void TrimAndRemoveDuplicateWhitespacesTest3()
        {
            var input = " This   is the  test input  ";
            var output = "This is the test input";
            Assert.AreEqual(output, input.TrimAndRemoveDuplicateWhitespaces());
        }
    }
}