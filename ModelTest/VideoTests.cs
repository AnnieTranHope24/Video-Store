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
    public class VideoTests
    {
        [TestMethod]
        public void TestPurchaseDate() {
            //Given
            Video video = new Video();

            //Then
            Assert.AreEqual(video.PurchaseDate, DateFactory.CurrentDate);
        }

        [TestMethod]
        public void ShouldEqualsWhenIDEqual()
        {
            Video video = new Video()
            {
                Id = 1

            };

            Video comparison = new Video()
            {
                Id = 1

            };

            Assert.IsTrue(video.Equals(comparison));
        }

        [TestMethod]
        public void ShouldNotEqualsWhenIDNotEqual()
        {
            Video video = new Video()
            {
                Id = 1

            };

            Video comparison = new Video()
            {
                Id = 2

            };

            Assert.IsFalse(video.Equals(comparison));
        }

        [TestMethod]
        public void TestGetHashCode()
        {
            //Given
            Video video = new Video()
            {
                Id = 3
            };

            //Then
            Assert.IsTrue(video.GetHashCode().Equals(3));
        }
    }
}
