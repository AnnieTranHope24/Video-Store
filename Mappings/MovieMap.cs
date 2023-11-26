using FluentNHibernate.Mapping;
using Model;

namespace Mappings
{
    public class MovieMap : ClassMap<Movie>
    {
        public MovieMap()
        {
            Id(x => x.Id, "TitleID").GeneratedBy.Assigned();
            Map(x => x.Year);
            Map(x => x.Title);
            Map(x => x.OriginalTitle);
            Map(x => x.RunningTimeInMinutes);
            Map(x => x.Director);
            Map(x => x.Rating);
            Map(x => x.IMDBRating);
            Map(x => x.NumberOfRatings);
        }
    }
}
