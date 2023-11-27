using FluentNHibernate.Mapping;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
