using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using NHibernate;
using FluentNHibernate.Testing;
using Model;
using Mappings;

namespace MappingTests
{
    [TestFixture]
    public class TestZipCodeMap
    {
        private ISessionFactory _factory;
        private ISession _session;

        [SetUp]
        public void CreateSession()
        {
            _factory = SessionFactory.CreateSessionFactory<ZipCodeMap>("videostore");
            _session = _factory.GetCurrentSession();
        }

        [Test]
        public void TestAreaMapping()
        {
            new PersistenceSpecification<ZipCode>(_session)
                .CheckProperty(e => e.State, "Illinois")
                .CheckProperty(e => e.City, "Chicago")
                .VerifyTheMappings();
        }
    }
}