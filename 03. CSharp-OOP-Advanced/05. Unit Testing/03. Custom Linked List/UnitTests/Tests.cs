using CustomLinkedList;
using NUnit.Framework;
using System;

namespace UnitTests
{
    [TestFixture]
    public class Tests
    {
        [Test]
        public void TestConstructor()
        {
            DynamicList<string> dynamicList = new DynamicList<string>();

            Assert.AreEqual(0, dynamicList.Count);
        }

        [Test]
        public void TestAddMethod()
        {
            DynamicList<string> dynamicList = new DynamicList<string>();

            dynamicList.Add("pesho");

            Assert.AreEqual(1, dynamicList.Count);
        }

        [Test]
        public void TestRemoveAtWithAORException()
        {
            DynamicList<string> dynamicList = new DynamicList<string>();

            dynamicList.Add("pesho");

            Assert.Throws<ArgumentOutOfRangeException>(() => dynamicList.RemoveAt(1));
        }

        [Test]
        public void TestRemoveAt()
        {
            DynamicList<string> dynamicList = new DynamicList<string>();

            dynamicList.Add("pesho");
            dynamicList.Add("gosho");
            dynamicList.Add("kiro");

            Assert.AreEqual("gosho", dynamicList.RemoveAt(1));
        }

        [Test]
        public void TestRemove()
        {
            DynamicList<string> dynamicList = new DynamicList<string>();

            dynamicList.Add("pesho");
            dynamicList.Add("gosho");
            dynamicList.Add("kiro");

            Assert.AreEqual(2, dynamicList.Remove("kiro"));
        }

        [Test]
        public void TestRemoveWithInvalidIndex()
        {
            DynamicList<string> dynamicList = new DynamicList<string>();

            dynamicList.Add("pesho");
            dynamicList.Add("gosho");
            dynamicList.Add("kiro");
            dynamicList.RemoveAt(1);

            Assert.AreEqual(-1, dynamicList.Remove("gosho"));
        }

        [Test]
        public void TestIndexOf()
        {
            DynamicList<string> dynamicList = new DynamicList<string>();

            dynamicList.Add("pesho");

            Assert.AreEqual(0, dynamicList.IndexOf("pesho"));
        }

        [Test]
        public void TestIndexOfWithInvalidIndex()
        {
            DynamicList<string> dynamicList = new DynamicList<string>();

            dynamicList.Add("pesho");

            Assert.AreEqual(-1, dynamicList.IndexOf("gosho"));
        }

        [Test]
        public void TestContainsForTrue()
        {
            DynamicList<string> dynamicList = new DynamicList<string>();

            dynamicList.Add("pesho");

            Assert.AreEqual(true, dynamicList.Contains("pesho"));
        }

        [Test]
        public void TestContainsForFalse()
        {
            DynamicList<string> dynamicList = new DynamicList<string>();

            dynamicList.Add("pesho");

            Assert.AreEqual(false, dynamicList.Contains("gosho"));
        }

        [Test]
        public void TestIndexing()
        {
            DynamicList<string> dynamicList = new DynamicList<string>();

            dynamicList.Add("pesho");

            Assert.AreEqual("pesho", dynamicList[0]);
        }

        [Test]
        public void TestIndexingGetterWithAORException()
        {
            DynamicList<string> dynamicList = new DynamicList<string>();

            dynamicList.Add("pesho");

            Assert.Throws<ArgumentOutOfRangeException>(() => { var a = dynamicList[2]; });
        }

        [Test]
        public void TestIndexingSetter()
        {
            DynamicList<string> dynamicList = new DynamicList<string>();

            dynamicList.Add("pesho");
            dynamicList[0] = "gosho";

            Assert.AreEqual("gosho", dynamicList[0]);
        }

        [Test]
        public void TestIndexingSetterWithAORException()
        {
            DynamicList<string> dynamicList = new DynamicList<string>();

            dynamicList.Add("pesho");

            Assert.Throws<ArgumentOutOfRangeException>(() => { dynamicList[2] = "gosho"; });
        }
    }
}
