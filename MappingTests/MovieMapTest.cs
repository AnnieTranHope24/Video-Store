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
            var Expected = new Movie()
            {
                Year = 1986,
                Title = "Hoosiers",
                OriginalTitle = "Hoosiers",
                RunningTimeInMinutes = 114,
                Rating = "PG",
                IMDBRating = 7.5F,
                NumberOfRatings = 44053,
            };

            Movie Actual = _session.Load<Movie>("tt0091217");

            Assert.AreEqual(Actual, Expected);
        }
    }
}