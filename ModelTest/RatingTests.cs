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
    public class RatingTests
    {
        [TestMethod]
        public void ShouldEqualsWhenIdEqual()
        {
            //Given
            Rating rating = new Rating()
            {
                Id = 1

            };

            Rating comparison = new Rating()
            {
                Id = 1

            };

            //Then
            Assert.IsTrue(rating.Equals(comparison));
        }

        [TestMethod]
        public void ShouldNotEqualsWhenIdNotEqual()
        {
            //Given
            Rating rating = new Rating()
            {
                Id = 2

            };

            Rating comparison = new Rating()
            {
                Id = 1

            };

            //Then
            Assert.IsFalse(rating.Equals(comparison));
        }

        [TestMethod]
        public void TestGetHashCode()
        {
            //Given
            Rating rating = new Rating()
            {
                Id = 3
            };

            //Then
            Assert.IsTrue(rating.GetHashCode().Equals(3));
        }

        [TestMethod]
        public void ShouldSetScore() {
            //Given
            Rating rating = new Rating();
            rating.Score = 2;

            //Then
            Assert.AreEqual(rating.Score, 2);
        }

        [TestMethod]
        public void ShouldThrowExWhenScoreLessThan1()
        {
            //Given
            Rating rating = new Rating();

            //Then
            var ex = Assert.ThrowsException<ArgumentOutOfRangeException>(() => rating.Score = 0);
            Assert.AreEqual(ex.ParamName, $"Value for Rating Score must be at least {1}; value given was {0}");
        }

        [TestMethod]
        public void ShouldThrowExWhenScoreGreaterThan5()
        {
            //Given
            Rating rating = new Rating();

            //Then
            var ex = Assert.ThrowsException<ArgumentOutOfRangeException>(() => rating.Score = 6);
            Assert.AreEqual(ex.ParamName, $"Value for Rating Score must be no more than {5}; value given was {6}");
        }
    }
}
