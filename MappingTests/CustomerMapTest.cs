﻿using FluentNHibernate.Testing;
using Mappings;
using Model;
using NHibernate;
using NUnit.Framework;

namespace MappingTests
{
    [TestFixture]
    public class CustomerMapTest
    {
        private ISessionFactory _factory;
        private ISession _session;

        [SetUp]
        public void CreateSession()
        {
            _factory = SessionFactory.CreateSessionFactory<CustomerMap>("videostore");
            _session = _factory.GetCurrentSession();
        }

        [Test]
        public void TestCustomerMapping()
        {
            new PersistenceSpecification<Customer>(_session)
                .CheckProperty(e => e.EmailAddress, "annie.tran@hope.edu")
                .CheckProperty(e => e.StreetAddress, "141 10th St Holland, MI")
                .CheckProperty(e => e.Password, "helloWorld1")
                .CheckProperty(e => e.Phone, "6162345678")
                .CheckProperty(e => e.Name.First, "Annie")
                .CheckProperty(e => e.Name.Last, "Tran")
                .VerifyTheMappings();
        }
    }
}
