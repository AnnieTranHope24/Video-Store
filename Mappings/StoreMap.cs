using FluentNHibernate.Mapping;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mappings
{
    public class StoreMap : ClassMap<Store>
    {
        public StoreMap()
        {
            Id(x => x.Id);
            Map(x => x.StreetAddress);
            Map(x => x.PhoneNumber);

            HasMany<Video>(x => x.Videos).Cascade.All().Inverse();
        }
    }
}
