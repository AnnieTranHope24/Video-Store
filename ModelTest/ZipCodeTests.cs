using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelTest
{
    [TestClass]
    public class ZipCodeTests
    {
        [TestMethod]
        public void TestGetHashCode() {
            //Given
            ZipCode code = new ZipCode() { 
                Code = "49423"
            };

            //Then
            Assert.AreEqual("49423".GetHashCode(), code.GetHashCode());
        }

        [TestMethod]
        public void ShouldNotEqualsWhenCompareWithNull()
        {
            //Given
            ZipCode code = new ZipCode()
            {
                Code = "49423"
            };

            ZipCode comparison = null;

            //Then
            Assert.IsFalse(code.Equals(comparison));
        }

        [TestMethod]
        public void ShouldEqualsWhenCodeEquals()
        {
            //Given
            ZipCode code = new ZipCode()
            {
                Code = "49423"
            };

            ZipCode comparison = new ZipCode()
            {
                Code = "49423"
            };

            //Then
            Assert.IsTrue(code.Equals(comparison));
        }

        [TestMethod]
        public void ShouldNotEqualsWhenCodeNotEquals()
        {
            //Given
            ZipCode code = new ZipCode()
            {
                Code = "49423"
            };

            ZipCode comparison = new ZipCode()
            {
                Code = "20000"
            };

            //Then
            Assert.IsFalse(code.Equals(comparison));
        }
    }
}
