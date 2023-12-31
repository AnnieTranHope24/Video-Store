﻿using FluentNHibernate.Testing;
using Mappings;
using Model;
using NHibernate;
using NUnit.Framework;
using System;
using VideoStore.Utilities;

namespace MappingTests
{
    [TestFixture]
    public class VideoMapTest
    {
        private ISessionFactory _factory;
        private ISession _session;

        [SetUp]
        public void CreateSession()
        {
            _factory = SessionFactory.CreateSessionFactory<VideoMap>("videostore");
            _session = _factory.GetCurrentSession();
            _session.CreateSQLQuery("delete from videostore.Video")
                .ExecuteUpdate();
            _session.CreateSQLQuery("delete from videostore.StoreToCustomer")
                .ExecuteUpdate();
            _session.CreateSQLQuery("delete from videostore.Store")
                .ExecuteUpdate();
            _session.CreateSQLQuery("delete from videostore.ZipCode")
                .ExecuteUpdate();
        }

        [Test]
        public void TestVideoMapping()
        {
            new PersistenceSpecification<Video>(_session, new DateEqualityComparer())
                .CheckProperty(e => e.NewArrival, false)
                .CheckProperty(e => e.PurchaseDate, DateTime.Now)
                .CheckReference(e => e.Store, new Store() { StreetAddress = "141 E 10th St", PhoneNumber = "6161234567", ZipCode = new ZipCode() { Code = "49423", City = "Holland", State = "MI" } })
                .VerifyTheMappings();
        }
    }
}
