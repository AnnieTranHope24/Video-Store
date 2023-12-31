﻿using NUnit.Framework;
using NHibernate;
using FluentNHibernate.Testing;
using Model;
using Mappings;
using VideoStore.Utilities;

namespace MappingTests
{
    [TestFixture]
    public class ZipCodeMapTest
    {
        private ISessionFactory _factory;
        private ISession _session;

        [SetUp]
        public void CreateSession()
        {
            _factory = SessionFactory.CreateSessionFactory<ZipCodeMap>("videostore");
            _session = _factory.GetCurrentSession();
            _session.CreateSQLQuery("delete from videostore.ZipCode")
                .ExecuteUpdate();
        }

        [Test]
        public void TestZipCodeMapping()
        {
            new PersistenceSpecification<ZipCode>(_session, new DateEqualityComparer())
                .CheckProperty(e => e.Code, "49423")
                .CheckProperty(e => e.City, "Holland")
                .CheckProperty(e => e.State, "MI")
                .VerifyTheMappings();
        }
    }
}