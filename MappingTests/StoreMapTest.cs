﻿using FluentNHibernate.Testing;
using Mappings;
using Model;
using NHibernate;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace MappingTests
{
    [TestFixture]
    public class StoreMapTest
    {
        private ISessionFactory _factory;
        private ISession _session;

        [SetUp]
        public void CreateSession()
        {
            _factory = SessionFactory.CreateSessionFactory<StoreMap>("videostore");
            _session = _factory.GetCurrentSession();
            _session.CreateSQLQuery("delete from videostore.StoreToCustomer")
                .ExecuteUpdate();
            _session.CreateSQLQuery("delete from videostore.Store")
                .ExecuteUpdate();
            _session.CreateSQLQuery("delete from videostore.ZipCode")
                .ExecuteUpdate();
            _session.CreateSQLQuery("delete from videostore.Video")
                .ExecuteUpdate();
        }

        [Test]
        public void TestStoreMapping()
        {
            new PersistenceSpecification<Store>(_session)
                .CheckProperty(e => e.StreetAddress, "141 10th St Holland, MI")
                .CheckProperty(e => e.PhoneNumber, "6162345678")
                .CheckReference(e => e.ZipCode, new ZipCode() { Code = "49423", City = "Holland", State = "MI"})
                .CheckInverseList(e => e.Videos,
                new List<Video>()
                {
                    new Video()
                    {
                        NewArrival = false,
                        PurchaseDate = DateTime.Now, 
                    },
                    new Video()
                    {
                        NewArrival = false,
                        PurchaseDate = DateTime.Now
                    }
                },
                (store, video) => store.AddVideo(video)
                )
                .VerifyTheMappings();
        }
    }
}
