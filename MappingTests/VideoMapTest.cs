using FluentNHibernate.Testing;
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
        }

        [Test]
        public void TestVideoMapping()
        {
            new PersistenceSpecification<Video>(_session, new DateEqualityComparer())
                .CheckProperty(e => e.NewArrival, false)
                .CheckProperty(e => e.PurchaseDate, DateTime.Now)
                .VerifyTheMappings();
        }
    }
}
