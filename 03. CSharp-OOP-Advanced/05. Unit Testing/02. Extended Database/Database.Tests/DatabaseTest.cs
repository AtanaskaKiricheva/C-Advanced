using Exercise.Entities;
using NUnit.Framework;
using System;

namespace DatabaseTests.Tests
{
    [TestFixture]
    public class DatabaseTest
    {
       [Test]
       public void TestDatabaseConstructor()
        {
            Database database = new Database();

            Assert.AreEqual(0, database.People.Count);
        }

        [Test]
        public void TestAddWithException()
        {
            Database database = new Database();
            Person person = new Person("Pesho", 12);

            database.Add(person);

            Assert.Throws<InvalidOperationException>(() => database.Add(person));
        }

        [Test]
        public void TestAddWithoutException()
        {
            Database database = new Database();
            Person person = new Person("Pesho", 12);

            database.Add(person);

            Assert.AreEqual(1, database.People.Count);
        }

        [Test]
        public void TestRemove()
        {
            Database database = new Database();
            Person person = new Person("Pesho", 12);

            database.Add(person);
            database.Remove(person);

            Assert.AreEqual(0, database.People.Count);
        }

        [Test]
        public void TestFindByUsernameWithIOE()
        {
            Database database = new Database();
            Person person = new Person("Pesho", 12);
            Person person2 = new Person("Gosho", 12);

            database.Add(person);

            Assert.Throws<InvalidOperationException>(() => database.FindByUsername(person2));
        }

        [Test]
        public void TestFindByUsernameWithAE()
        {
            Database database = new Database();
            Person person = new Person(null, 12);

            database.Add(person);

            Assert.Throws<ArgumentException>(() => database.FindByUsername(person));
        }

        [Test]
        public void TestFindByUsername()
        {
            Database database = new Database();
            Person person = new Person("Pesho", 12);

            database.Add(person);

            Assert.AreEqual(person, database.FindByUsername(person));
        }

        [Test]
        public void TestFindByIdWithIOE()
        {
            Database database = new Database();
            Person person = new Person("Pesho", 12);
            Person person2 = new Person("Gosho", 12);

            database.Add(person);

            Assert.Throws<InvalidOperationException>(() => database.FindById(person2));
        }

        [Test]
        public void TestFindByIdWithAE()
        {
            Database database = new Database();
            Person person = new Person("Pesho", -12);

            database.Add(person);

            Assert.Throws<ArgumentException>(() => database.FindById(person));
        }

        [Test]
        public void TestFindById()
        {
            Database database = new Database();
            Person person = new Person("Pesho", 12);

            database.Add(person);

            Assert.AreEqual(person, database.FindById(person));
        }

    }
}
