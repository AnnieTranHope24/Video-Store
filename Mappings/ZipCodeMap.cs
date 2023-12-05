using FluentNHibernate.Mapping;
using Model;

namespace Mappings
{
    public class ZipCodeMap : ClassMap<ZipCode>
    {
        public ZipCodeMap()
        {
            Id(x => x.Code, "Code").GeneratedBy.Assigned();
            Map(x => x.City);
            Map(x => x.State);

        }
    }
}
