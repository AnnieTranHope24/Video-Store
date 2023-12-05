using FluentNHibernate.Mapping;
using Model;

namespace MappingTests
{
    public class VideoMap : ClassMap<Video>
    {
        public VideoMap() 
        {
            Id(x => x.Id);
            Map(x => x.PurchaseDate);
            Map(x => x.NewArrival);

            References(x => x.Store).Cascade.All();
        }
    }
}