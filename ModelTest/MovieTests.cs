using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Model;

namespace ModelTest
{
    [TestClass]
    public class MovieTests
    {
        [TestMethod]
        public void TestConstructor()
        {
            Movie movie = new Movie();

            Assert.IsNotNull(movie.Reservations);
            Assert.AreEqual(0, movie.Reservations.Count);
            Assert.IsNotNull(movie.Genres);
            Assert.AreEqual(0, movie.Genres.Count);
            Assert.IsNotNull(movie.Roles);
            Assert.AreEqual(0, movie.Roles.Count);
        }

        [TestMethod]
        public void ShouldEqualsWhenTitleAndYearEqual()
        {
            Movie movie = new Movie()
            {
                Title = "Red",
                Year = 2023
            };

            Movie comparison = new Movie()
            {
                Title = "Red",
                Year = 2023
            };

            Assert.AreEqual(true, movie.Equals(comparison));
        }

        [TestMethod]
        public void ShouldNotEqualsWhenTitleAndYearNotEqual()
        {
            Movie movie = new Movie()
            {
                Title = "Blue",
                Year = 2023

            };

            Movie comparison = new Movie()
            {
                Title = "Red",
                Year = 2023

            };

            Assert.AreEqual(false, movie.Equals(comparison));
        }

        [TestMethod]
        public void TestGetHashCode()
        {
            Movie movie = new Movie();
            Assert.IsNotNull(movie.GetHashCode());
        }
    }
}
