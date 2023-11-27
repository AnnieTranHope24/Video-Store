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
    public class TestArea
    {
        private ISessionFactory _factory;
        private ISession _session;

        [SetUp]
        public void CreateSession()
        {
            _factory = SessionFactory.CreateSessionFactory<AreaMap>("videostore");
            _session = _factory.GetCurrentSession();
        }

        [Test]
        public void TestAreaMapping()
        {
            new PersistenceSpecification<Area>(_session)
                .CheckProperty(e => e.Name, "Holland")
                .VerifyTheMappings();
        }
    }
}
