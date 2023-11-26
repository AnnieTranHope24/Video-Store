using FluentNHibernate.Mapping;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mappings
{
    public class MovieMap : ClassMap<Movie>
    {
        public MovieMap()
        {
            Id(x => x.Id).GeneratedBy.Assigned();
            Map(x => x.Year);
            Map(x => x.Title);
            Map(x => x.OriginalTitle);
            Map(x => x.RunningTimeInMinutes);
            Map(x => x.Director);
            Map(x => x.Rating);
            Map(x => x.IMDBRating);
            Map(x => x.NumberOfRatings);

            HasMany(x => x.videos).Cascade.All().Inverse();
        }
    }
}
