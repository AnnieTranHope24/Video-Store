using FluentNHibernate.Mapping;
using Model;

namespace Mappings
{
    public class StoreMap : ClassMap<Store>
    {
        public StoreMap()
        {
            Id(x => x.Id);
            Map(x => x.StreetAddress);
            Map(x => x.PhoneNumber);
        }
    }
}
