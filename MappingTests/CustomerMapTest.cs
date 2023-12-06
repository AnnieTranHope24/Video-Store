using FluentNHibernate.Testing;
using Mappings;
using Model;
using NHibernate;
using NUnit.Framework;
using System.Collections.Generic;

namespace MappingTests
{
    [TestFixture]
    public class CustomerMapTest
    {
        private ISessionFactory _factory;
        private ISession _session;

        [SetUp]
        public void CreateSession()
        {
            _factory = SessionFactory.CreateSessionFactory<CustomerMap>("videostore");
            _session = _factory.GetCurrentSession();
            _session.CreateSQLQuery("delete from videostore.Customer")
                .ExecuteUpdate();
            _session.CreateSQLQuery("delete from videostore.ZipCode")
                .ExecuteUpdate();
            _session.CreateSQLQuery("delete from videostore.StoreToCustomer")
                .ExecuteUpdate();
        }

        [Test]
        public void TestCustomerMapping()
        {
            new PersistenceSpecification<Customer>(_session)
                .CheckProperty(e => e.EmailAddress, "ryan.mcfall@hope.edu")
                .CheckProperty(e => e.StreetAddress, "141 10th St Holland, MI")
                .CheckProperty(e => e.Password, "helloWorld1")
                .CheckProperty(e => e.Phone, "6162345678")
                .CheckProperty(e => e.Name, new Name() { Title = "Dr.", First = "Ryan", Last = "McFall", Middle = "Lee", Suffix = "I" })
                .CheckReference(e => e.ZipCode, new ZipCode() { Code = "49423", City = "Holland", State = "MI" })
                .CheckInverseList(e => e.PreferredStores,
                new List<Store>()
                {
                    new Store()
                    {
                        StreetAddress = "141 10th St Holland, MI",
                        ZipCode = new ZipCode(){ Code = "22772", City = "Holland", State = "MI" },
                        

                    },
                    new Store()
                    {
                        StreetAddress = "115 10th St Holland, MI",
                        ZipCode = new ZipCode(){ Code = "12345", City = "Holland", State = "MI" }
                    }
                },
                (customer, store) => customer.AddPreferredStore(store)
                )
                .VerifyTheMappings();
        }
    }
}
