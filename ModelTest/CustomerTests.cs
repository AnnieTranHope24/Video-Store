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
            Customer customer = new Customer()
            {
                Name = new Name()
                {
                    First = "Stu",
                    Last = "Dent"
                }
            };

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
            Customer customer = new Customer()
            {
                EmailAddress = "annie@gmail.com"

            };

            Customer comparison = new Customer()
            {
                EmailAddress = "annie@gmail.com"

            };

            Assert.AreEqual(true, customer.Equals(comparison));
        }

        [TestMethod]
        public void ShouldNotEqualsWhenEmailAddrNotEqual()
        {
            Customer customer = new Customer()
            {
                EmailAddress = "ngoc@gmail.com"

            };

            Customer comparison = new Customer()
            {
                EmailAddress = "annie@gmail.com"

            };

            Assert.AreEqual(false, customer.Equals(comparison));
        }

        [TestMethod]
        public void TestGetHashCode()
        {
            Customer customer = new Customer();
            Assert.IsNotNull(customer.GetHashCode());
        }

        [TestMethod]
        public void TestPassword()
        {

        }

        [TestMethod]
        public void TestFullName()
        {
            Customer customer = new Customer()
            {
                Name = new Name()
                {
                    First = "Stu",
                    Last = "Dent"
                }
            };

            Assert.AreEqual("Stu Dent", customer.FullName);
        }
    }
}
