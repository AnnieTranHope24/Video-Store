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
    public class CommunicationMethodTests
    {
        [TestMethod]
        public void TestConstructor()
        {
            //Given
            CommunicationMethod method = new CommunicationMethod();

            //Then
            Assert.IsNotNull(method.Customers);
            Assert.AreEqual(0, method.Customers.Count);
        }

        [TestMethod]
        public void ShouldNotEqualsWhenCompareWithNull()
        {
            //Given
            CommunicationMethod method = new CommunicationMethod()
            {
                Name = "annie"

            };
            Customer comparison = null;

            //Then
            Assert.IsFalse(method.Equals(comparison));
        }

        [TestMethod]
        public void ShouldEqualsWhenNameEqual()
        {
            //Given
            CommunicationMethod method = new CommunicationMethod()
            {
                Name = "annie"

            };

            CommunicationMethod comparison = new CommunicationMethod()
            {
                Name = "annie"

            };

            //Then
            Assert.IsTrue(method.Equals(comparison));
        }

        [TestMethod]
        public void ShouldNotEqualsWhenNameNotEqual()
        {
            //Given
            CommunicationMethod method = new CommunicationMethod()
            {
                Name = "tran"

            };

            CommunicationMethod comparison = new CommunicationMethod()
            {
                Name = "annie"

            };

            //Then
            Assert.IsFalse(method.Equals(comparison));
        }

        [TestMethod]
        public void TestGetHashCode()
        {
            //Given
            CommunicationMethod method = new CommunicationMethod()
            {
                Id = 3
            };

            //Then
            Assert.IsTrue(method.GetHashCode().Equals(3));
        }
    }
}
