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
    public class StoreTests
    {
        [TestMethod]
        public void TestConstructor()
        {
            //Given
            Store store = new Store()
            {
                StreetAddress = "141 E 12th St",
                ZipCode = new ZipCode()
                {
                    Code = "49423"
                }
            };

            //Then
            Assert.IsNotNull(store.Managers);
            Assert.AreEqual(0, store.Managers.Count);
            Assert.IsNotNull(store.Videos);
            Assert.AreEqual(0, store.Videos.Count);
        }

        [TestMethod]
        public void TestRemoveManager()
        {
            //Given
            Store store = new Store()
            {
                StreetAddress = "141 E 12th St",
                ZipCode = new ZipCode()
                {
                    Code = "49423"
                }
            };
            Employee newManager = new Employee()
            {
                Name = new Name()
                {
                    First = "Annie",
                    Last = "Tran"
                },
                DateOfBirth = DateFactory.TestDate
            };
            store.AddManager(newManager);

            //When
            store.RemoveManager(newManager);

            //Then
            Assert.IsFalse(store.Managers.Contains(newManager));
            Assert.AreEqual(store.Managers.Count, 0);
        }

        [TestMethod]
        public void TestAddVideo() {
            //Given
            Store store = new Store()
            {
                StreetAddress = "141 E 12th St",
                ZipCode = new ZipCode()
                {
                    Code = "49423"
                }
            };
            Video video = new Video();

            //When
            store.AddVideo(video);

            //Then
            Assert.AreEqual(video.Store, store);
            Assert.IsTrue(store.Videos.Contains(video));    
        }

        [TestMethod]
        public void ShouldRemoveVideo()
        {
            //Given
            Store store = new Store()
            {
                StreetAddress = "141 E 12th St",
                ZipCode = new ZipCode()
                {
                    Code = "49423"
                }
            };
            Video video = new Video();
            store.AddVideo(video);

            //When
            store.RemoveVideo(video);

            //Then
            Assert.IsFalse(store.Videos.Contains(video));
            Assert.AreEqual(store.Videos.Count, 0); 
        }

        [TestMethod]
        public void ShouldThrowExcRemoveVideo()
        {
            //Given
            Store store = new Store()
            {
                StreetAddress = "141 E 12th St",
                ZipCode = new ZipCode()
                {
                    Code = "49423"
                }
            };
            Video video = new Video();

            //Then
            var ex = Assert.ThrowsException<ArgumentException>(() => store.RemoveVideo(video));
            Assert.AreEqual(ex.Message, $"Attempted to remove video with ID {video.Id} from store with ID {store.Id}; the store does not own this video");
        }

        [TestMethod]
        public void ShouldNotEqualsWhenCompareWithNull()
        {
            //Given
            Store store = new Store()
            {
                StreetAddress = "141 E 12th St",
                ZipCode = new ZipCode()
                {
                    Code = "49423"
                }

            };
            Store comparison = null;

            //Then
            Assert.IsFalse(store.Equals(comparison));
        }

        [TestMethod]
        public void ShouldEqualsWhenStAddrZipCodeEqual()
        {
            //Given
            Store store = new Store()
            {
                StreetAddress = "141 E 12th St",
                ZipCode = new ZipCode()
                {
                    Code = "49423"
                }

            };
            Store comparison = new Store()
            {
                StreetAddress = "141 E 12th St",
                ZipCode = new ZipCode()
                {
                    Code = "49423"
                }

            };

            //Then
            Assert.IsTrue(store.Equals(comparison));
        }

        [TestMethod]
        public void ShouldNotEqualsWhenStAddrNotEqual()
        {
            //Given
            Store store = new Store()
            {
                StreetAddress = "141 E 12th St",
                ZipCode = new ZipCode()
                {
                    Code = "49423"
                }

            };
            Store comparison = new Store()
            {
                StreetAddress = "100 E 12th St",
                ZipCode = new ZipCode()
                {
                    Code = "49423"
                }

            };

            //Then
            Assert.IsFalse(store.Equals(comparison));
        }

        [TestMethod]
        public void ShouldNotEqualsWhenZipCodeNotEqual()
        {
            //Given
            Store store = new Store()
            {
                StreetAddress = "141 E 12th St",
                ZipCode = new ZipCode()
                {
                    Code = "49423"
                }

            };
            Store comparison = new Store()
            {
                StreetAddress = "100 E 12th St",
                ZipCode = new ZipCode()
                {
                    Code = "5000"
                }

            };

            //Then
            Assert.IsFalse(store.Equals(comparison));
        }
        [TestMethod]
        public void TestGetHashCode()
        {
            //Given
            Store store = new Store()
            {
                Id = 3
            };

            //Then
            Assert.IsTrue(store.GetHashCode().Equals(3));
        }
    }
}
