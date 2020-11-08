using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Archimydes.DataAccessLayer;
using NUnit.Framework;

namespace Archimydes.UnitTests
{
    [TestFixture]
    internal class StoryTests
    {
        [Test]
        public void Given_A_Story_When_UserStoryID_The_Default_Value_Is_Null()
        {
            var sut = new Story();
            Assert.That(sut.UserStoryID, Is.Zero);
        }

        [TestCase(1)]
        [TestCase(0)]
        public void Given_A_Story_When_UserStoryID_The_Default_Value_Is_Equal_To_Input(int value)
        {
            var sut = new Story() { UserStoryID = value };
            Assert.That(sut.UserStoryID, Is.EqualTo(value));
        }

        [Test]
        public void Given_A_Story_When_UserId_The_Default_Value_Is_Null()
        {
            var sut = new Story();
            Assert.That(sut.UserId, Is.Zero);
        }

        [TestCase(1)]
        [TestCase(0)]
        public void Given_A_Story_When_UserId_The_Default_Value_Is_Equal_To_Input(int value)
        {
            var sut = new Story() { UserId = value };
            Assert.That(sut.UserId, Is.EqualTo(value));
        }

        [Test]
        public void Given_A_Story_When_Summary_The_Default_Value_Is_Null()
        {
            var sut = new Story();
            Assert.That(sut.Summary, Is.Null);
        }

        [TestCase("Create a SignUp Api")]
        [TestCase("")]
        [TestCase(null)]
        public void Given_A_Story_When_Summary_The_Value_Is_Equal_To_Input(string value)
        {
            var sut = new Story() { Summary = value };
            Assert.That(sut.Summary, Is.EqualTo(value));
        }

        [Test]
        public void Given_A_Story_When_Description_The_Default_Value_Is_Null()
        {
            var sut = new Story();
            Assert.That(sut.Description, Is.Null);
        }

        [TestCase("Create a SignUp Api using three fields email, password and name")]
        [TestCase("")]
        [TestCase(null)]
        public void Given_A_Story_When_Description_The_Value_Is_Equal_To_Input(string value)
        {
            var sut = new Story() { Description = value };
            Assert.That(sut.Description, Is.EqualTo(value));
        }

        [Test]
        public void Given_A_Story_When_Type_The_Default_Value_Is_Null()
        {
            var sut = new Story();
            Assert.That(sut.Type, Is.Null);
        }

        [TestCase("Feature")]
        [TestCase("Bug")]
        [TestCase(null)]
        public void Given_A_Story_When_Type_The_Value_Is_Equal_To_Input(string value)
        {
            var sut = new Story() { Type = value };
            Assert.That(sut.Type, Is.EqualTo(value));
        }

        [Test]
        public void Given_A_Story_When_Complexity_The_Default_Value_Is_Null()
        {
            var sut = new Story();
            Assert.That(sut.Complexity, Is.Null);
        }

        [TestCase("High")]
        [TestCase("Low")]
        [TestCase(null)]
        public void Given_A_Story_When_Complexity_The_Value_Is_Equal_To_Input(string value)
        {
            var sut = new Story() { Complexity = value };
            Assert.That(sut.Complexity, Is.EqualTo(value));
        }

        [Test]
        public void Given_A_Story_When_CreatedDateTime_The_Default_Value_Is_Null()
        {
            var sut = new Story();
            Assert.That(sut.CreatedDateTime, Is.EqualTo(default(DateTime)));
        }

        [TestCase("03/23/1992")]
        public void Given_A_Story_When_CreatedDateTime_The_Default_Value_Is_Input_Value(DateTime value)
        {
            var sut = new Story() { CreatedDateTime = value };
            Assert.That(sut.CreatedDateTime, Is.EqualTo(value));
        }

        [Test]
        public void Given_A_Story_When_ModifiedDateTime_The_Default_Value_Is_Null()
        {
            var sut = new Story();
            Assert.That(sut.ModifiedDateTime, Is.EqualTo(new DateTime(1, 1, 1, 0, 0, 0, DateTimeKind.Utc)));
        }

        [TestCase("03/23/1992")]
        public void Given_A_Story_When_ModifiedDateTime_The_Default_Value_Is_Input_Value(DateTime value)
        {
            var sut = new Story() { ModifiedDateTime = value };
            Assert.That(sut.ModifiedDateTime, Is.EqualTo(value));
        }

        [Test]
        public void Given_A_Story_When_EstimatedTime_The_Default_Value_Is_Null()
        {
            var sut = new Story();
            Assert.That(sut.EstimatedTime, Is.EqualTo(null));
        }

        [TestCase("03/23/1992")]
        public void Given_A_Story_When_EstimatedTime_The_Default_Value_Is_Input_Value(DateTime value)
        {
            var sut = new Story() { EstimatedTime = value };
            Assert.That(sut.EstimatedTime, Is.EqualTo(value));
        }
    }
}
