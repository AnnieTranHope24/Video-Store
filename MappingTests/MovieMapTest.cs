using NUnit.Framework;
using NHibernate;
using Model;
using Mappings;

namespace MappingTests
{
    [TestFixture]
    public class TestMovieMap
    {
        private ISessionFactory _factory;
        private ISession _session;

        [SetUp]
        public void CreateSession()
        {
            _factory = SessionFactory.CreateSessionFactory<MovieMap>("imdb");
            _session = _factory.GetCurrentSession();
        }

        [Test]
        public void TestMovieMapping()
        {
            var Movie = new Movie()
            {
                Id = 1,
                Year = 2020,
                Title = "MovieTitle",
                OriginalTitle = "OriginalMovieTitle",
                RunningTimeInMinutes = 40,
                Director = "Director",
                Rating = "A rating",
                IMDBRating = 10,
                NumberOfRatings = 1,
            };

            _session.Save(Movie);

            Assert.AreEqual(_session.Load<Movie>(1), Movie);
        }
    }
}