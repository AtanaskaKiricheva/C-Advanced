using System;
using NUnit.Framework;
using Exercise.Entities;
using System.Reflection;

namespace PersonTest.Test
{
    [TestFixture]
    public class TestPerson
    {
        [Test]
        public void TestConstructorWithNormalNumber()
        {
            Person person = new Person("Pesho", 12);

            Assert.AreEqual("Pesho", person.Username);
            Assert.AreEqual(12, person.Id);
        }

        [Test]
        public void TestConstructorWithLongNumber()
        {
            string type = typeof(Person).GetField("id", BindingFlags.NonPublic | BindingFlags.Instance).FieldType.Name;

            Assert.AreEqual("Int64", type);
        }

    }
}
