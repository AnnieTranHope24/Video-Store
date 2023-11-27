using FluentNHibernate.Testing;
using Mappings;
using Model;
using NHibernate;
using NUnit.Framework;

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
            _session.CreateSQLQuery("delete from videostore.Store")
                .ExecuteUpdate();
            _session.CreateSQLQuery("delete from videostore.ZipCode")
                .ExecuteUpdate();              
        }

        [Test]
        public void TestStoreMapping()
        {
            new PersistenceSpecification<Store>(_session)
                .CheckProperty(e => e.StreetAddress, "141 10th St Holland, MI")
                .CheckProperty(e => e.PhoneNumber, "6162345678")
                .CheckReference(e => e.ZipCode, new ZipCode() { Code = "49423", City = "Holland", State = "MI"})
                .VerifyTheMappings();
        }
    }
}
