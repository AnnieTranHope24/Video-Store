using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using NHibernate;
using FluentNHibernate.Testing;
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
            _factory = SessionFactory.CreateSessionFactory<MovieMap>("videostore");
            _session = _factory.GetCurrentSession();
        }

        [Test]
        public void TestAreaMapping()
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
            new PersistenceSpecification<Movie>(_session)
                .CheckProperty(e => e.Id, 1)
                .CheckProperty(e => e.Year, 2020)
                .CheckProperty(e => e.Title, "MovieTitle")
                .CheckProperty(e => e.OriginalTitle, "OriginalMovieTitle")
                .CheckProperty(e => e.RunningTimeInMinutes, 40)
                .CheckProperty(e => e.Director, "Director")
                .CheckProperty(e => e.Rating, "A rating")
                .CheckProperty(e => e.IMDBRating, 10)
                .CheckProperty(e => e.NumberOfRatings, 1)
                .VerifyTheMappings();
        }
    }
}