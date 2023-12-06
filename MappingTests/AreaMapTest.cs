using NUnit.Framework;
using NHibernate;
using FluentNHibernate.Testing;
using Model;
using Mappings;
using System.Collections.Generic;
using System;

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
            _session.CreateSQLQuery("delete from videostore.ZipCode")
                .ExecuteUpdate();
            _session.CreateSQLQuery("delete from videostore.ZipCodeToArea")
                .ExecuteUpdate();
        }

        [Test]
        public void TestAreaMapping()
        {
            new PersistenceSpecification<Area>(_session)
                .CheckProperty(e => e.Name, "Holland")
                .CheckInverseBag(e => e.ZipCodes,
                new List<ZipCode>()
                {
                    new ZipCode()
                    {
                        Code = "49423", City = "Holland", State = "MI"
                    },
                    new ZipCode()
                    {
                        Code = "12345", City = "New York", State = "New York"
                    }
                },
                (area, zipcode) => area.AddZipCode(zipcode)
                )
                .VerifyTheMappings();
        }
    }
}
