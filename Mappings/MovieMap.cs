using FluentNHibernate.Mapping;
using Model;

namespace Mappings
{
    public class MovieMap : ClassMap<Movie>
    {
        public MovieMap()
        {
            Id(x => x.Id, "TitleID").GeneratedBy.Assigned();
            Map(x => x.Year, "YearReleased");
            Map(x => x.Title);
            Map(x => x.OriginalTitle);
            Map(x => x.RunningTimeInMinutes);
            Map(x => x.Rating, "MPAARating");
            Map(x => x.IMDBRating);
            Map(x => x.NumberOfRatings, "IMDBNumberRatings");
        }
    }
}
