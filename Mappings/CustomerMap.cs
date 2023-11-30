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
            Component(x => x.Name, m =>
            {
                m.Map(x => x.Title);
                m.Map(x => x.First);
                m.Map(x => x.Middle);
                m.Map(x => x.Last);
                m.Map(x => x.Suffix);
            });

            References(x => x.ZipCode);
            HasMany<Store>(x => x.PreferredStores)
                .Inverse()
                .Cascade.All();
        }
    }
}
