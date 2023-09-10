using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelTest
{
    [TestClass]
    public class GenreTests
    {
        [TestMethod]
        public void ShouldEqualsWhenNameEquals()
        {
            //Given
            Genre genre = new Genre()
            {
                Name = "annie"

            };

            Genre comparison = new Genre()
            {
                Name = "annie"

            };

            //Then
            Assert.IsTrue(genre.Equals(comparison));
        }

        [TestMethod]
        public void ShouldNotEqualsWhenCompareWithNull()
        {
            //Given
            Genre genre = new Genre()
            {
                Name = "annie"

            };
            Genre comparison = null;

            //Then
            Assert.IsFalse(genre.Equals(comparison));
        }

        [TestMethod]
        public void ShouldNotEqualsWhenNameNotEquals()
        {
            Genre genre = new Genre()
            {
                Name = "annie"

            };

            Genre comparison = new Genre()
            {
                Name = "tran"

            };

            Assert.IsFalse(genre.Equals(comparison));
        }

        [TestMethod]
        public void TestGetHashCode()
        {
            //Given
            Genre genre = new Genre()
            {
                Name = "annie"
            };

            //Then
            Assert.IsTrue(genre.GetHashCode().Equals("annie".GetHashCode()));
        }
    }
}
