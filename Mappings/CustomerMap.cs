using FluentNHibernate.Mapping;
using Model;

namespace Mappings
{
    public class CustomerMap : ClassMap<Customer>
    {
        public CustomerMap() 
        {
            Id(x => x.Id);
            Map(x => x.EmailAddress);
            Map(x => x.StreetAddress);
            Map(x => x.Password);
            Map(x => x.Phone);
        }
    }
}
