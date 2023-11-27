using NUnit.Framework;
using NHibernate;
using FluentNHibernate.Testing;
using Model;
using Mappings;

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
        }

        [Test]
        public void TestZipCodeMapping()
        {

            var ZipCode = new ZipCode()
            {
                Code = "49423",
                City = "Holland",
                State = "MI"
            };

            ZipCode Actual = _session.Load<ZipCode>("49423");

            Assert.AreEqual(Actual, ZipCode);
        }
    }
}