using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Archimydes.DataAccessLayer;

namespace Archimydes.UnitTests
{
    [TestFixture]
    internal class UserTests
    {
        [Test]
        public void Given_A_User_When_UserId_The_Default_Value_Is_Null()
        {
            var sut = new User();
            Assert.That(sut.UserId, Is.Zero);
        }

        [TestCase(25)]
        public void Given_A_User_When_UserId_And_Value_Is_Equal_To_Input(int value)
        {
            var sut = new User() {UserId = value};
            Assert.That(sut.UserId, Is.EqualTo(value));
        }

        [Test]
        public void Given_A_User_When_FirstName_The_Default_Value_Is_Null()
        {
            var sut = new User();
            Assert.That(sut.Firstname, Is.Null);
        }

        [TestCase("Archymedis")]
        [TestCase(null)]
        [TestCase("")]
        public void Given_A_User_When_FirstName_The_Default_Value_Is_Equal_To_Input(string value)
        {
            var sut = new User() {Firstname = value};
            Assert.That(sut.Firstname, Is.EqualTo(value));
        }

        [Test]
        public void Given_A_User_When_LastName_The_Default_Value_Is_Null()
        {
            var sut = new User();
            Assert.That(sut.Lastname, Is.Null);
        }

        [TestCase("Archymedis")]
        public void Given_A_User_When_LastName_The_Default_Value_Is_Input_Value(string value)
        {
            var sut = new User() {Lastname = value};
            Assert.That(sut.Lastname, Is.EqualTo(value));
        }

        [Test]
        public void Given_A_User_When_Email_The_Default_Value_Is_Null()
        {
            var sut = new User();
            Assert.That(sut.Email, Is.Null);
        }

        [TestCase("Archymedis@gmail.com")]
        [TestCase("")]
        [TestCase(("aaa@a.com"))]
        public void Given_A_User_When_Email_The_Default_Value_Is_Input_Value(string value)
        {
            var sut = new User() { Email = value };
            Assert.That(sut.Email, Is.EqualTo(value));
        }
    }
}
