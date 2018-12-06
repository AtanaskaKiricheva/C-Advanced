using Exercise.Entities;
using NUnit.Framework;
using System;

namespace DatabaseTests.Tests
{
    [TestFixture]
    public class DatabaseTest
    {
        [Test]
        public void TestConstructorWithLessIntegers()
        {
            Assert.Throws<InvalidOperationException>(() => new Database(new int[] { 1, 2, 3 }));
        }

        [Test]
        public void TestConstructorWithMoreIntegers()
        {
            Assert.Throws<InvalidOperationException>(() => new Database(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17 }));
        }

        [Test]
        public void TestConstructorWithEnoughIntegers()
        {
            Database database = new Database(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 });

            Assert.AreEqual(16, database.Integers.Length);
        }

        [Test]
        public void TestAddMethod()
        {
            Database database = new Database(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 });

            database.Add(17);

            Assert.AreEqual(17, database.Integers.Length);
        }

        [Test]
        public void TestRemoveWithException()
        {
            Database database = new Database(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 });

            database.Remove();
            database.Remove();
            database.Remove();
            database.Remove();
            database.Remove();
            database.Remove();
            database.Remove();
            database.Remove();
            database.Remove();
            database.Remove();
            database.Remove();
            database.Remove();
            database.Remove();
            database.Remove();
            database.Remove();
            database.Remove();

            Assert.Throws<InvalidOperationException>(() => database.Remove());
        }

        [Test]
        public void TestRemoveWithoutException()
        {
            Database database = new Database(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 });

            database.Remove();

            Assert.AreEqual(15, database.Integers.Length);
        }

        [Test]
        public void TestFetch()
        {
            Database database = new Database(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 });

            int[] expected = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 };

            Assert.AreEqual(expected, database.Fetch());
        }
    }
}
