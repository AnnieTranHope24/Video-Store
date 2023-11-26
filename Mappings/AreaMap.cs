using FluentNHibernate.Mapping;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mappings
{
    public class AreaMap : ClassMap<Area>
    {
        public AreaMap() 
        {
            Schema("videostore");
            Id(x => x.Id).GeneratedBy.Identity();
            Map(x => x.Name);

            HasManyToMany<ZipCode>(x => x.ZipCodes)
                .Table("AreaZipCodes")
                .ParentKeyColumn("AreaID")
                .ChildKeyColumn("ZipCodeID")
                .Cascade.All()
                .Inverse();
        }
    }
}
