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
    public class EmployeeTests
    {
        [TestMethod]
        public void TestDefaultDateHired()
        {
            //Given
            Employee employee = new Employee();

            //Then
            Assert.AreEqual(employee.DateHired, DateFactory.CurrentDate);
        }

        [TestMethod]
        public void TestDateHiredGetterSetter()
        {
            //Given
            Employee employee = new Employee();

            //When
            employee.DateHired = DateFactory.TestDate;

            //Then
            Assert.AreEqual(employee.DateHired, DateFactory.TestDate);
        }

        [TestMethod]
        public void ShouldReturnDateOfBirth()
        {
            //Given
            Employee employee = new Employee()
            {
                Name = new Name()
                {
                    First = "Annie",
                    Last = "Tran"
                },
                DateOfBirth = DateFactory.TestDate
            };

            //Then
            Assert.AreEqual(employee.DateOfBirth, DateFactory.TestDate);
        }

        [TestMethod]
        public void ShouldThrowArgumentExIfLessThan16()
        {
            //Given
            Employee employee = new Employee()
            {
                Name = new Name()
                {
                    First = "Annie",
                    Last = "Tran"
                },
            };

            //Then
            var ex = Assert.ThrowsException<ArgumentException>(() => employee.DateOfBirth = DateFactory.CurrentDate);
            Assert.AreEqual(ex.Message, $"Cannot set birthdate to {DateFactory.CurrentDate} for employee {employee.Name}; would make employee under sixteen at date of hire {employee.DateHired}");
        }

        [TestMethod]
        public void ShouldTrueIfIsManager()
        {
            //Given
            Employee employee = new Employee()
            {
                Name = new Name()
                {
                    First = "Annie",
                    Last = "Tran"
                },
            };
            Store store = new Store();
            store.AddManager(employee);
            employee.Store = store;

            //Then
            Assert.IsTrue(employee.IsManager);
        }

        [TestMethod]
        public void ShouldFalseIfNotIsManager()
        {
            //Given
            Employee employee = new Employee()
            {
                Name = new Name()
                {
                    First = "Annie",
                    Last = "Tran"
                },
            };
            Store store = new Store();
            employee.Store = store;

            //Then
            Assert.IsFalse(employee.IsManager);
        }

        [TestMethod]
        public void ShouldSetSupervisor()
        {
            //Given
            Employee employee = new Employee()
            {
                Name = new Name()
                {
                    First = "Annie",
                    Last = "Tran"
                },
            };
            Employee supervisor = new Employee()
            {
                Name = new Name()
                {
                    First = "Ngoc",
                    Last = "Tran"
                },
            };

            //When
            employee.Supervisor = supervisor;

            //Then
            Assert.AreEqual(employee.Supervisor, supervisor);
        }

        [TestMethod]
        public void ShouldSetSupervisorToNull()
        {
            //Given
            Employee employee = new Employee()
            {
                Name = new Name()
                {
                    First = "Annie",
                    Last = "Tran"
                },
            };

            //When
            employee.Supervisor = null;

            //Then
            Assert.AreEqual(employee.Supervisor, null);
        }

        [TestMethod]
        public void ShouldThrowExceptionIfSetSupervisorThemselves()
        {
            //Given
            Employee employee = new Employee()
            {
                Name = new Name()
                {
                    First = "Annie",
                    Last = "Tran"
                },
            };

            //Then
            var ex = Assert.ThrowsException<ArgumentException>(() => employee.Supervisor = employee);
            Assert.AreEqual(ex.Message, $"Invalid attempt to set employee {employee} as supervisor for employee {employee}");
        }

        [TestMethod]
        public void ShouldNotEqualsWhenCompareWithNull()
        {
            //Given
            Employee employee = new Employee()
            {
                Name = new Name()
                {
                    First = "Annie",
                    Last = "Tran"
                },
                DateOfBirth = DateFactory.TestDate
            };
            Employee comparison = null;

            //Then
            Assert.IsFalse(employee.Equals(comparison));
        }

        [TestMethod]
        public void ShouldEqualsWhenNameAndBirthdayEqual()
        {
            //Given
            Employee employee = new Employee()
            {
                Name = new Name()
                {
                    First = "Annie",
                    Last = "Tran"
                },
                DateOfBirth = DateFactory.TestDate
            };
            Employee comparison = new Employee()
            {
                Name = new Name()
                {
                    First = "Annie",
                    Last = "Tran"
                },
                DateOfBirth = DateFactory.TestDate
            };

            //Then
            Assert.IsTrue(employee.Equals(comparison));
        }

        [TestMethod]
        public void ShouldNotEqualsWhenFirstNameNotEqual()
        {
            //Given
            Employee employee = new Employee()
            {
                Name = new Name()
                {
                    First = "Annie",
                    Last = "Tran"
                },
                DateOfBirth = DateFactory.TestDate
            };
            Employee comparison = new Employee()
            {
                Name = new Name()
                {
                    First = "Ngoc",
                    Last = "Tran"
                },
                DateOfBirth = DateFactory.TestDate
            };

            //Then
            Assert.IsFalse(employee.Equals(comparison));
        }

        [TestMethod]
        public void ShouldNotEqualsWhenLastNameNotEqual()
        {
            //Given
            Employee employee = new Employee()
            {
                Name = new Name()
                {
                    First = "Annie",
                    Last = "Tran"
                },
                DateOfBirth = DateFactory.TestDate
            };
            Employee comparison = new Employee()
            {
                Name = new Name()
                {
                    First = "Annie",
                    Last = "Nguyen"
                },
                DateOfBirth = DateFactory.TestDate
            };

            //Then
            Assert.IsFalse(employee.Equals(comparison));
        }

        [TestMethod]
        public void ShouldNotEqualsWhenBirthdayNotEqual()
        {
            //Given
            Employee employee = new Employee()
            {
                Name = new Name()
                {
                    First = "Annie",
                    Last = "Tran"
                },
                DateOfBirth = DateFactory.TestDate
            };
            Employee comparison = new Employee()
            {
                Name = new Name()
                {
                    First = "Annie",
                    Last = "Tran"
                },
                DateOfBirth = new DateTime(1999, 1, 1, 0, 0, 0)
        };

            //Then
            Assert.IsFalse(employee.Equals(comparison));
        }

        [TestMethod]
        public void TestGetHashCode()
        {
            //Given
            Employee employee = new Employee()
            {
                Id = 3
            };

            //Then
            Assert.IsTrue(employee.GetHashCode().Equals(3));
        }
    }
}
