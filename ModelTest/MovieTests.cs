using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Model;
using VideoStore.Utilities;

namespace ModelTest
{
    [TestClass]
    public class MovieTests
    {
        [TestMethod]
        public void TestConstructor()
        {
            //Given
            Movie movie = new Movie();

            //Then
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
            //Given
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

            //Then
            Assert.IsTrue(movie.Equals(comparison));
        }

        [TestMethod]
        public void ShouldNotEqualsWhenTitleNotEqual()
        {
            //Given
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

            //Then
            Assert.IsFalse(movie.Equals(comparison));
        }

        [TestMethod]
        public void ShouldNotEqualsWhenYearNotEqual()
        {
            //Given
            Movie movie = new Movie()
            {
                Title = "Blue",
                Year = 2023

            };

            Movie comparison = new Movie()
            {
                Title = "Blue",
                Year = 2025

            };

            //Then
            Assert.IsFalse(movie.Equals(comparison));
        }

        [TestMethod]
        public void TestGetHashCode()
        {
            //Given
            Movie movie = new Movie()
            {
                Id = 3
            };

            //Then
            Assert.IsTrue(movie.GetHashCode().Equals(3));
        }

        [TestMethod]
        public void TestReservations()
        {
            //Given
            Movie movie = new Movie();
            DateFactory.Mode = DateFactoryMode.Test;
            Reservation firstRes = new Reservation()
            { 
                ReservationDate = DateFactory.CurrentDate
            };

            DateFactory.Mode = DateFactoryMode.Production;
            Reservation secondRes = new Reservation()
            {
                ReservationDate = DateFactory.CurrentDate
            };

            //When
            movie.Reservations.Add(firstRes);
            movie.Reservations.Add(secondRes);

            //Then
            Assert.IsNotNull(movie.Reservations);
            Assert.IsTrue(movie.Reservations.Count.Equals(2));
            Assert.IsTrue(DateTime.Compare(movie.Reservations[0].ReservationDate, movie.Reservations[1].ReservationDate) < 0);
        }
    }
}
