using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Test.Project.Library;


namespace Test.Project.Tests
{
    [TestClass]
    public class Citizen_Test
    {
        Citizen Jan = new Citizen()
        {
            Name = "Jan",
            LastName = "Kowalski",
            Document_Number = "00100101010",
            BirthDate = new DateTime(1990, 01, 01),
            Sex = 'M'
        };


        [TestMethod]
        public void Citizen_Creation()
        {

            Assert.IsTrue(Jan.Id == Guid.Empty);
            Assert.IsTrue(Jan.Save());
            Assert.AreEqual(Jan.Name, "Jan");
            Assert.AreEqual(Jan.LastName, "Kowalski");
            Assert.AreEqual(Jan.Sex, (char)Citizen.SexType.Male);
            Assert.AreEqual(Jan.BirthDate, new DateTime(1990, 01, 01));
            Assert.AreEqual(Jan.Document_Number, "00100101010");
            Assert.IsTrue(Jan.Id != Guid.Empty);
        }

        [TestMethod]
        public void Citizen_Age()
        {
            Assert.IsTrue(Jan.Age() >= 23);
        }

        [TestMethod]
        public void Citizen_Adult()
        {
            Assert.IsTrue(Jan.IsAdult());
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Citizen_Should_Throw_Invalid_Sex()
        {
            Jan.Sex = 'Y';
        }

        [TestMethod, ExpectedException(typeof(Exception), "Invalid blank document number")]
        public void Citizen_Should_Throw_Invalid_Document_Number()
        {
            Jan.Document_Number = "This is my document Number";
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Citizen_Should_Throw_Incomplete_Document_Number()
        {
            Jan.Document_Number = "1234567891";
        }

    }
}
