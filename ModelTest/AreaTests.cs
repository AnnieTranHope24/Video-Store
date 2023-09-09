using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace ModelTest
{
    [TestClass]
    public class AreaTests
    {
        [TestMethod]
        public void TestContructor()
        {
            //Given
            Area area = new Area();

            //Then
            Assert.IsNotNull(area.ZipCodes);
            Assert.AreEqual(0, area.ZipCodes.Count);
        }

        [TestMethod]
        public void ShouldEqualsWhenNameEqual()
        {
            Area area = new Area()
            {
                Name = "Foo"

            };

            Area comparison = new Area()
            {
                Name = "Foo"

            };

            Assert.IsTrue(area.Equals(comparison));
        }

        [TestMethod]
        public void ShouldNotEqualsWhenEmailAddrNotEqual()
        {
            //Given
            Area area = new Area()
            {
                Name = "Foo"

            };

            Area comparison = new Area()
            {
                Name = "NotFoo"

            };

            //Then
            Assert.IsFalse(area.Equals(comparison));
        }

        [TestMethod]
        public void TestGetHashCode()
        {
            //Given
            Area area = new Area()
            {
                Id = 3
            };

            //Then
            Assert.IsTrue(area.GetHashCode().Equals(3));
        }

        [TestMethod]
        public void ShouldAddZipCode() {
            //Given
            Area area = new Area()
            {
                Id = 3
            };
            ZipCode code = new ZipCode()
            {
                Code = "49423"
            };

            //When
            area.AddZipCode(code);

            //Then
            Assert.IsTrue(area.ZipCodes.Contains(code));
        }

        [TestMethod]
        public void ShouldRemoveZipCode()
        {
            //Given
            Area area = new Area()
            {
                Id = 3
            };
            ZipCode zipCode = new ZipCode()
            {
                Code = "49423"
            };
            area.AddZipCode(zipCode);

            //When
            area.RemoveZipCode(zipCode);

            //Then
            Assert.AreEqual(0, area.ZipCodes.Count);    
        }

        [TestMethod]
        public void ShouldThrowArgumentException()
        {
            //Given
            Area area = new Area()
            {
                Id = 3
            };
            ZipCode code = new ZipCode()
            {
                Code = "49423"
            };

            //Then
            var ex = Assert.ThrowsException<ArgumentException>(() => area.RemoveZipCode(code));
            Assert.AreEqual(ex.Message, $"RemoveZipCode: The zip code with code {code.Code} does not exist in the area with name {area.Name}");
        }
    }
}
