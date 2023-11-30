using FluentNHibernate.Mapping;
using Model;

namespace Mappings
{
    public class AreaMap : ClassMap<Area>
    {
        public AreaMap() 
        {
            Id(x => x.Id);
            Map(x => x.Name); 
            
            HasMany<ZipCode>(x => x.ZipCodes).Inverse().Cascade.All();
        }
    }
}
