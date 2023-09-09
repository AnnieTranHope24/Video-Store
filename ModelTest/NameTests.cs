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
    public class NameTests
    {
        [TestMethod]
        public void TestGetHashCode()
        {
            //Given
            Name name = new Name()
            {
                Title = "Dr",
                First = "Annie",
                Middle = "Ngoc",
                Last = "Tran",
                Suffix = "II"
            };

            //Then
            Assert.IsTrue(name.GetHashCode().Equals("Dr Annie Ngoc Tran II".GetHashCode()));
        }
    }
}
