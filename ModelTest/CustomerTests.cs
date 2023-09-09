using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Model;
using System.Net.Mail;

namespace ModelTest
{
    [TestClass]
    public class CustomerTests
    {
        [TestMethod]
        public void TestConstructor()
        {
            //Given
            Customer customer = new Customer()
            {
                Name = new Name()
                {
                    First = "Stu",
                    Last = "Dent"
                }
            };

            //Then
            Assert.IsNotNull(customer.PreferredStores);
            Assert.AreEqual(0, customer.PreferredStores.Count);
            Assert.IsNotNull(customer.CommunicationTypes);
            Assert.AreEqual(0, customer.CommunicationTypes.Count);
            Assert.IsNotNull(customer.Rentals);
            Assert.AreEqual(0, customer.Rentals.Count);
            Assert.IsNotNull(customer.LateRentals);
            Assert.AreEqual(0, customer.LateRentals.Count);
        }

        [TestMethod]
        public void ShouldEqualsWhenEmailAddrEqual() {
            //Given
            Customer customer = new Customer()
            {
                EmailAddress = "annie@gmail.com"

            };

            Customer comparison = new Customer()
            {
                EmailAddress = "annie@gmail.com"

            };

            //Then
            Assert.IsTrue(customer.Equals(comparison));
        }

        [TestMethod]
        public void ShouldNotEqualsWhenEmailAddrNotEqual()
        {
            //Given
            Customer customer = new Customer()
            {
                EmailAddress = "ngoc@gmail.com"

            };

            Customer comparison = new Customer()
            {
                EmailAddress = "annie@gmail.com"

            };

            //Then
            Assert.IsFalse(customer.Equals(comparison));
        }

        [TestMethod]
        public void TestGetHashCode()
        {
            //Given
            Customer customer = new Customer()
            {
                Id = 3
            };

            //Then
            Assert.IsTrue(customer.GetHashCode().Equals(3));
        }

        [TestMethod]
        public void TestPassword()
        {

        }

        [TestMethod]
        public void TestFullName()
        {
            //Given
            Customer customer = new Customer()
            {
                Name = new Name()
                {
                    First = "Stu",
                    Last = "Dent"
                }
            };

            //Then
            Assert.AreEqual("Stu Dent", customer.FullName);
        }
    }
}
