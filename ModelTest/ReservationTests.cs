using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoStore.Utilities;

namespace ModelTest
{
    [TestClass]
    public class ReservationTests
    {
        [TestMethod]
        public void ShouldEqualsWhenMovieCustomerEqual()
        {
            //Given
            Reservation reservation = new Reservation()
            {
                Movie = new Movie() { 
                    Title = "Inception",
                    Year = 2010
                },

                Customer = new Customer()
                {
                    EmailAddress = "annie@gmail.com"
                }

            };

            Reservation comparison = new Reservation()
            {
                Movie = new Movie()
                {
                    Title = "Inception",
                    Year = 2010
                },

                Customer = new Customer()
                {
                    EmailAddress = "annie@gmail.com"
                }

            };

            //Then
            Assert.IsTrue(reservation.Equals(comparison));
        }

        [TestMethod]
        public void ShouldNotEqualsWhenMovieNotEqual()
        {
            //Given
            Reservation reservation = new Reservation()
            {
                Movie = new Movie()
                {
                    Title = "Up",
                    Year = 2010
                },

                Customer = new Customer()
                {
                    EmailAddress = "annie@gmail.com"
                }

            };

            Reservation comparison = new Reservation()
            {
                Movie = new Movie()
                {
                    Title = "Inception",
                    Year = 2010
                },

                Customer = new Customer()
                {
                    EmailAddress = "annie@gmail.com"
                }

            };

            //Then
            Assert.IsFalse(reservation.Equals(comparison));
        }

        [TestMethod]
        public void ShouldNotEqualsWhenCustomerNotEqual()
        {
            //Given
            Reservation reservation = new Reservation()
            {
                Movie = new Movie()
                {
                    Title = "Inception",
                    Year = 2010
                },

                Customer = new Customer()
                {
                    EmailAddress = "hello@gmail.com"
                }

            };

            Reservation comparison = new Reservation()
            {
                Movie = new Movie()
                {
                    Title = "Inception",
                    Year = 2010
                },

                Customer = new Customer()
                {
                    EmailAddress = "annie@gmail.com"
                }

            };

            //Then
            Assert.IsFalse(reservation.Equals(comparison));
        }

        [TestMethod]
        public void TestGetHashCode()
        {
            //Given
            Reservation reservation = new Reservation()
            {
                Id = 3
            };

            //Then
            Assert.IsTrue(reservation.GetHashCode().Equals(3));
        }

        [TestMethod]
        public void TestDefaultReservationDate()
        {
            //Given
            Reservation reservation = new Reservation();

            //Then
            Assert.AreEqual(reservation.ReservationDate, DateFactory.CurrentDate);
        }

        [TestMethod]
        public void TestReservationDateGetterSetter()
        {
            //Given
            Reservation reservation = new Reservation();

            //When
            reservation.ReservationDate = DateFactory.TestDate;

            //Then
            Assert.AreEqual(reservation.ReservationDate, DateFactory.TestDate);
        }
    }
}
