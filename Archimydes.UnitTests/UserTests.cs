using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Archimydes.DataAccessLayer;
using System.ComponentModel.DataAnnotations;

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

        [Test]
        public void Given_A_User_When_Password_The_Default_Value_Is_Null()
        {
            var sut = new User();
            Assert.That(sut.Password, Is.Null);
        }

        [TestCase("password")]
        [TestCase("")]
        [TestCase(("archymedis"))]
        public void Given_A_User_When_Password_The_Default_Value_Is_Input_Value(string value)
        {
            var sut = new User() { Password = value };
            Assert.That(sut.Password, Is.EqualTo(value));
        }

        [Test]
        public void Given_A_User_When_Role_The_Default_Value_Is_Null()
        {
            var sut = new User();
            Assert.That(sut.Role, Is.Null);
        }

        [TestCase("User")]
        [TestCase("")]
        [TestCase(("Admin"))]
        public void Given_A_User_When_Role_The_Default_Value_Is_Input_Value(string value)
        {
            var sut = new User() { Role = value };
            Assert.That(sut.Role, Is.EqualTo(value));
        }

        [Test]
        public void Given_A_User_When_Token_The_Default_Value_Is_Null()
        {
            var sut = new User();
            Assert.That(sut.Token, Is.Null);
        }

        [TestCase("token")]
        [TestCase("")]
        [TestCase(("hashed token"))]
        public void Given_A_User_When_Token_The_Default_Value_Is_Input_Value(string value)
        {
            var sut = new User() { Token = value };
            Assert.That(sut.Token, Is.EqualTo(value));
        }

        [Test]
        public void Given_A_User_When_CreatedDateTime_The_Default_Value_Is_Null()
        {
            var sut = new User();
            Assert.That(sut.CreatedDateTime, Is.EqualTo(default(DateTime)));
        }

        [TestCase("03/23/1992")]
        public void Given_A_User_When_CreatedDateTime_The_Default_Value_Is_Input_Value(DateTime value)
        {
            var sut = new User() { CreatedDateTime = value };
            Assert.That(sut.CreatedDateTime, Is.EqualTo(value));
        }

        [Test]
        public void Given_A_User_When_ModifiedDateTime_The_Default_Value_Is_Null()
        {
            var sut = new User();
            Assert.That(sut.ModifiedDateTime, Is.EqualTo(new DateTime(1, 1, 1, 0, 0, 0, DateTimeKind.Utc)));
        }

        [TestCase("03/23/1992")]
        public void Given_A_User_When_ModifiedDateTime_The_Default_Value_Is_Input_Value(DateTime value)
        {
            var sut = new User() { ModifiedDateTime = value };
            Assert.That(sut.ModifiedDateTime, Is.EqualTo(value));
        }

        [Test]
        public void Given_A_User_When_Stories_The_Default_Length_Is_Zero()
        {
            var sut = new User();
            Assert.That(sut.Stories.Count, Is.Zero);
        }

        [Test]
        public void Given_A_User_When_Stories_The_Default_Value_Is_Input_Value()
        {
            var story = new Story() {Complexity = "High", CreatedDateTime = new DateTime(2020, 03, 23)};
            var sut = new User() {Stories = new List<Story>()};
            sut.Stories.Add(story);
            Assert.That(sut.Stories.Count, Is.EqualTo(1));
        }
    }
}
