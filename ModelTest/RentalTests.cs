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
    public class RentalTests
    {
        [TestMethod]
        public void TestDefaultRentalDate()
        {
            //Given
            Rental rental = new Rental();

            //Then
            Assert.AreEqual(rental.RentalDate, DateFactory.CurrentDate);
        }

        [TestMethod]
        public void TestDueDateVideoNotNewArrival()
        {
            //Given
            Video video = new Video()
            {
                Id = 2,
                NewArrival = false
            };
            Customer cust = new Customer();
            Rental rental = new Rental(video, cust);

            //Then
            Assert.AreEqual(rental.DueDate, rental.RentalDate.AddDays(7.0));
        }

        [TestMethod]
        public void TestDueDateVideoNewArrival()
        {
            //Given
            Video video = new Video()
            {
                Id = 2,
                NewArrival = true
            };
            Customer cust = new Customer();
            Rental rental = new Rental(video, cust);

            //Then
            Assert.AreEqual(rental.DueDate, rental.RentalDate.AddDays(3.0));
        }

        [TestMethod]
        public void ShouldReturnNullWhenNoReservation()
        {
            //Given
            Video video = new Video()
            {
                Id = 2,
                NewArrival = true,
                Movie = new Movie()
            };
            Customer cust = new Customer();
            Rental rental = new Rental(video, cust);

            //Then
            Assert.IsNull(rental.Return());
            Assert.AreEqual(rental.ReturnDate, DateFactory.CurrentDate);
        }

        [TestMethod]
        public void ShouldReturnReturnReceipt()
        {
            //Given
            DateFactory.Mode = DateFactoryMode.Test;
            Video video = new Video()
            {
                Id = 2,
                NewArrival = true,
                Movie = new Movie()
                {
                    Title = "Red",
                    Year = 2023
                },
                Store = new Store() {
                    StreetAddress = "100 E 12th St",
                    ZipCode = new ZipCode()
                    {
                        Code = "5000"
                    }
                }
            };
            Reservation reservation = new Reservation()
            {
                Customer = new Customer()
                {
                    EmailAddress = "ngoc@gmail.com"
                },
                Movie = video.Movie
            };
            reservation.Customer.PreferredStores.Add(video.Store);
            video.Movie.Reservations.Add(reservation);

            Rental rental = new Rental()
            {
                Video = video,
                Customer = reservation.Customer,
                RentalDate = DateFactory.CurrentDate,
            };

            ReturnReceipt expect = new ReturnReceipt()
            {
                NextRental = reservation.Customer.Rent(video),
                FulfilledReservation = reservation,
            };

            //When
            var res = rental.Return();

            //Then
            Assert.AreEqual(rental.ReturnDate, DateFactory.CurrentDate);
            Assert.AreEqual(res.NextRental, expect.NextRental);
            Assert.AreEqual(res.FulfilledReservation, expect.FulfilledReservation);
            Assert.IsNotNull(res);
        }

        [TestMethod]
        public void ShouldNotEqualsWhenCompareWithNull()
        {
            //Given
            Rental rental = CreateRental(3, "ngoc@gmail.com", DateFactory.CurrentDate);
            Rental comparison = null;

            //Then
            Assert.IsFalse(rental.Equals(comparison));
        }

        [TestMethod]
        public void ShouldEquals()
        {
            //Given
            DateFactory.Mode = DateFactoryMode.Test;
            Rental rental = CreateRental(3, "ngoc@gmail.com", DateFactory.CurrentDate);
            Rental comparison = CreateRental(3, "ngoc@gmail.com", DateFactory.CurrentDate);

            //Then
            Assert.IsTrue(rental.Equals(comparison));
        }

        [TestMethod]
        public void ShouldNotEqualsWhenVideoNotEqual()
        {
            //Given
            DateFactory.Mode = DateFactoryMode.Test;
            Rental rental = CreateRental(3, "ngoc@gmail.com", DateFactory.CurrentDate);
            Rental comparison = CreateRental(4, "ngoc@gmail.com", DateFactory.CurrentDate);

            //Then
            Assert.IsFalse(rental.Equals(comparison));
        }

        [TestMethod]
        public void ShouldNotEqualsWhenCustomerNotEqual()
        {
            //Given
            DateFactory.Mode = DateFactoryMode.Test;
            Rental rental = CreateRental(3, "ngoc@gmail.com", DateFactory.CurrentDate);
            Rental comparison = CreateRental(3, "annie@gmail.com", DateFactory.CurrentDate);

            //Then
            Assert.IsFalse(rental.Equals(comparison));
        }

        [TestMethod]
        public void ShouldNotEqualsWhenRentalDateNotEqual()
        {
            //Given
            Rental rental = CreateRental(3, "ngoc@gmail.com", DateFactory.CurrentDate);
            Rental comparison = CreateRental(3, "ngoc@gmail.com", DateFactory.CurrentDate.AddDays(3));

            //Then
            Assert.IsFalse(rental.Equals(comparison));
        }

        [TestMethod]
        public void TestGetHashCode()
        {
            //Given
            Rental rental = new Rental()
            {
                Id = 3
            };

            //Then
            Assert.IsTrue(rental.GetHashCode().Equals(3));
        }
        private static Rental CreateRental(int videoId, String custEmailAddr, DateTime rentalDate)
        {
            return new Rental()
            {
                Video = new Video()
                {
                    Id = videoId
                },
                Customer = new Customer()
                {
                    EmailAddress = custEmailAddr

                },
                RentalDate = rentalDate
            };
        }
    }
}
