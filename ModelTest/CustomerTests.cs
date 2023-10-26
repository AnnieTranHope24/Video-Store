using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Model;
using System.Net.Mail;
using VideoStore.Utilities;

namespace ModelTest
{
    [TestClass]
    public class CustomerTests
    {
        [TestMethod]
        public void TestConstructor()
        {
            //Given
            Customer customer = new Customer()
            {
                Name = new Name()
                {
                    First = "Stu",
                    Last = "Dent"
                }
            };

            //Then
            Assert.IsNotNull(customer.PreferredStores);
            Assert.AreEqual(0, customer.PreferredStores.Count);
            Assert.IsNotNull(customer.CommunicationTypes);
            Assert.AreEqual(0, customer.CommunicationTypes.Count);
            Assert.IsNotNull(customer.Rentals);
            Assert.AreEqual(0, customer.Rentals.Count);
            Assert.IsNotNull(customer.LateRentals);
            Assert.AreEqual(0, customer.LateRentals.Count);
        }

        [TestMethod]
        public void ShouldGetValidPassword()
        {
            //Given
            Customer customer = new Customer()
            {
                Name = new Name()
                {
                    First = "Stu",
                    Last = "Dent"
                }
            };

            //When
            customer.Password = "HopeCollege2023";

            //Then
            Assert.AreEqual(customer.Password, "HopeCollege2023");
        }

        [TestMethod]
        public void ShouldThrowExceptionWhenPassLenLessThan6()
        {
            //Given
            Customer customer = new Customer()
            {
                Name = new Name()
                {
                    First = "Stu",
                    Last = "Dent"
                }
            };

            //Then
            var ex = Assert.ThrowsException<ArgumentException>(() => customer.Password = "H9");
            Assert.AreEqual(ex.Message, "Password is too short.  It must be at least 6 characters long.");
        }

        [TestMethod]
        public void ShouldThrowExceptionWhenPassNoDigit()
        {
            //Given
            Customer customer = new Customer()
            {
                Name = new Name()
                {
                    First = "Stu",
                    Last = "Dent"
                }
            };

            //Then
            var ex = Assert.ThrowsException<ArgumentException>(() => customer.Password = "HelloWorld");
            Assert.AreEqual(ex.Message, "The password must contain at least 1 number.");
        }

        [TestMethod]
        public void ShouldThrowExceptionWhenPassNoLowerLetter()
        {
            //Given
            Customer customer = new Customer()
            {
                Name = new Name()
                {
                    First = "Stu",
                    Last = "Dent"
                }
            };

            //Then
            var ex = Assert.ThrowsException<ArgumentException>(() => customer.Password = "HELLOWORLD3");
            Assert.AreEqual(ex.Message, "The password must contain at least 1 lowercase letter.");
        }

        [TestMethod]
        public void ShouldThrowExceptionWhenPassNoUpperLetter()
        {
            //Given
            Customer customer = new Customer()
            {
                Name = new Name()
                {
                    First = "Stu",
                    Last = "Dent"
                }
            };

            //Then
            var ex = Assert.ThrowsException<ArgumentException>(() => customer.Password = "helloworld3");
            Assert.AreEqual(ex.Message, "The password must contain at least 1 uppercase letter.");
        }

        [TestMethod]
        public void TestFullName()
        {
            //Given
            Customer customer = new Customer()
            {
                Name = new Name()
                {
                    First = "Stu",
                    Last = "Dent"
                }
            };

            //Then
            Assert.AreEqual("Stu Dent", customer.FullName);
        }

        [TestMethod]
        public void TestLateRentals()
        {
            //Given
            Customer customer = new Customer()
            {
                Name = new Name()
                {
                    First = "Stu",
                    Last = "Dent"
                }
            };

            //When
            Rental lateRental1 = new Rental() { RentalDate = DateFactory.TestDate, DueDate = DateFactory.TestDate.AddDays(10) };
            Rental lateRental2 = new Rental() { RentalDate = DateFactory.TestDate, DueDate = DateFactory.TestDate.AddDays(30) };
            Rental onTimeRental = new Rental() { RentalDate = DateFactory.TestDate, ReturnDate = DateFactory.TestDate.AddDays(10) };
            Rental notYetLateRental = new Rental() { RentalDate = DateFactory.TestDate, DueDate = DateTime.MaxValue };
            customer.Rentals.Add(lateRental1);
            customer.Rentals.Add(lateRental2);
            customer.Rentals.Add(onTimeRental);
            customer.Rentals.Add(notYetLateRental);

            //Then
            Assert.AreEqual(customer.LateRentals.Count, 2);
            Assert.AreEqual(customer.LateRentals[0], lateRental1);
            Assert.AreEqual(customer.LateRentals[1], lateRental2);
        }

        [TestMethod]
        public void TestAddReservation()
        {
            //Given
            Customer customer = new Customer()
            {
                Name = new Name()
                {
                    First = "Stu",
                    Last = "Dent"
                },
                EmailAddress = "annie@hope.edu"
            };
            Movie movie = new Movie() { 
                Title = "Inception",
                Year = 2010
            };

            //When
            Reservation res = customer.AddReservation(movie);

            //Then
            Assert.IsNotNull(res);
            Assert.AreEqual(res.Customer, customer);
            Assert.AreEqual(res.Movie, movie);
            Assert.AreEqual(movie.Reservations.Count, 1);
            Assert.IsTrue(movie.Reservations.Contains(res));
            Assert.AreEqual(customer.Reservation, res);
        }

        [TestMethod] public void TestAllow()
        {
            //Given
            Customer customer = new Customer()
            {
                Name = new Name()
                {
                    First = "Stu",
                    Last = "Dent"
                },
                EmailAddress = "annie@hope.edu"
            };
            CommunicationMethod method = new CommunicationMethod()
            {
                Name = "Call"
            };

            //When
            customer.Allow(method);

            //Then
            Assert.IsTrue(customer.CommunicationTypes.Contains(method));
            Assert.IsTrue(method.Customers.Contains(customer));
        }

        [TestMethod] 
        public void TestDeny() {
            //Given
            Customer customer = new Customer()
            {
                Name = new Name()
                {
                    First = "Stu",
                    Last = "Dent"
                },
                EmailAddress = "annie@hope.edu"
            };
            CommunicationMethod method = new CommunicationMethod()
            {
                Name = "Call"
            };
            customer.Allow(method);

            //When
            customer.Deny(method);

            //Then
            Assert.IsTrue(!customer.CommunicationTypes.Contains(method));
            Assert.IsTrue(!(method.Customers.Contains(customer)));
        }

        [TestMethod]
        public void ShouldRemoveThenAddPreferredStore()
        {
            //Given
            Customer customer = new Customer()
            {
                Name = new Name()
                {
                    First = "Stu",
                    Last = "Dent"
                },
                EmailAddress = "annie@hope.edu"
            };
            Store store = new Store()
            {
                StreetAddress = "141 E 12th St",
                ZipCode = new ZipCode()
                {
                    Code = "49423"
                }
            };
            Store anotherStore = new Store();
            customer.PreferredStores.Add(store);
            customer.PreferredStores.Add(anotherStore);
            
            //When
            customer.AddPreferredStore(store, 0);

            //Then
            Assert.IsTrue(customer.PreferredStores.Contains(store));
            Assert.AreEqual(customer.PreferredStores[1], store);
        }

        [TestMethod]
        public void ShouldInsertPreferredStore()
        {
            //Given
            Customer customer = new Customer()
            {
                Name = new Name()
                {
                    First = "Stu",
                    Last = "Dent"
                },
                EmailAddress = "annie@hope.edu"
            };
            Store store = new Store()
            {
                StreetAddress = "141 E 12th St",
                ZipCode = new ZipCode()
                {
                    Code = "49423"
                }
            };
            Store anotherStore = new Store();
            customer.PreferredStores.Add(anotherStore);

            //When
            customer.AddPreferredStore(store, 0);

            //Then
            Assert.IsTrue(customer.PreferredStores.Contains(store));
            Assert.AreEqual(customer.PreferredStores[0], store);
        }

        [TestMethod]
        public void ShouldRemovePreferredStore()
        {
            //Given
            Customer customer = new Customer()
            {
                Name = new Name()
                {
                    First = "Stu",
                    Last = "Dent"
                },
                EmailAddress = "annie@hope.edu"
            };
            Store store = new Store()
            {
                StreetAddress = "141 E 12th St",
                ZipCode = new ZipCode()
                {
                    Code = "49423"
                }
            };
            customer.PreferredStores.Add(store);

            //When
            customer.RemovePreferredStore(store);

            //Then
            Assert.IsFalse(customer.PreferredStores.Contains(store));
            Assert.AreEqual(customer.PreferredStores.Count, 0);
        }

        [TestMethod]
        public void ShouldThrowExcWhenRemovePreferredStore()
        {
            //Given
            Customer customer = new Customer()
            {
                Name = new Name()
                {
                    First = "Stu",
                    Last = "Dent"
                },
                EmailAddress = "annie@hope.edu"
            };
            Store store = new Store()
            {
                StreetAddress = "141 E 12th St",
                ZipCode = new ZipCode()
                {
                    Code = "49423"
                }
            };

            //Then
            var ex = Assert.ThrowsException<ArgumentException>(() => customer.RemovePreferredStore(store));
            Assert.AreEqual(ex.Message, $"Attempt to remove store {store} from customer {customer.FullName}'s list of preferred stores when it does not exist");
        }

        [TestMethod]
        public void ShouldNotEqualsWhenCompareWithNull()
        {
            //Given
            Customer customer = new Customer()
            {
                EmailAddress = "annie@gmail.com"

            };
            Customer comparison = null;

            //Then
            Assert.IsFalse(customer.Equals(comparison));
        }

        [TestMethod]
        public void ShouldEqualsWhenEmailAddrEqual() {
            //Given
            Customer customer = new Customer()
            {
                EmailAddress = "annie@gmail.com"

            };

            Customer comparison = new Customer()
            {
                EmailAddress = "annie@gmail.com"

            };

            //Then
            Assert.IsTrue(customer.Equals(comparison));
        }

        [TestMethod]
        public void ShouldNotEqualsWhenEmailAddrNotEqual()
        {
            //Given
            Customer customer = new Customer()
            {
                EmailAddress = "ngoc@gmail.com"

            };

            Customer comparison = new Customer()
            {
                EmailAddress = "annie@gmail.com"

            };

            //Then
            Assert.IsFalse(customer.Equals(comparison));
        }

        [TestMethod]
        public void TestGetHashCode()
        {
            //Given
            Customer customer = new Customer()
            {
                Id = 3
            };

            //Then
            Assert.IsTrue(customer.GetHashCode().Equals(3));
        }
    }
}
