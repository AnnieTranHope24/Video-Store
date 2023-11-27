using FluentNHibernate.Testing;
using Mappings;
using Model;
using NHibernate;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        }

        [Test]
        public void TestStoreMapping()
        {
            new PersistenceSpecification<Store>(_session)
                .CheckProperty(e => e.StreetAddress, "141 10th St Holland, MI")
                .CheckProperty(e => e.PhoneNumber, "6162345678")
                .VerifyTheMappings();
        }
    }
}
