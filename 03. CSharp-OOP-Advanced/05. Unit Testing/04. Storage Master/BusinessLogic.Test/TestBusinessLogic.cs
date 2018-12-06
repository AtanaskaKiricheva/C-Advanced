using NUnit.Framework;
using System;
using System.Linq;
using System.Reflection;
using Master.Core;

namespace BusinessLogic.Test
{
    [TestFixture]
    public class TestBusinessLogic
    {
        [Test]
        public void CheckIfClassExists()
        {
            Type classExists = typeof(StorageMaster);

            Assert.AreEqual("StorageMaster", classExists.Name);
        }

        [Test]
        public void TestFields()
        {
            Type master = typeof(StorageMaster);

            FieldInfo storageRegistry = master.GetField("storageRegistry", BindingFlags.NonPublic | BindingFlags.Instance);
            FieldInfo productsPool = master.GetField("productsPool", BindingFlags.NonPublic | BindingFlags.Instance);
            FieldInfo productFactory = master.GetField("productFactory", BindingFlags.NonPublic | BindingFlags.Instance);
            FieldInfo storageFactory = master.GetField("storageFactory", BindingFlags.NonPublic | BindingFlags.Instance);
            FieldInfo currentVehicle = master.GetField("currentVehicle", BindingFlags.NonPublic | BindingFlags.Instance);

            Assert.AreEqual(true, storageRegistry.IsInitOnly);
            Assert.AreEqual(true, productsPool.IsInitOnly);
            Assert.AreEqual(true, productFactory.IsInitOnly);
            Assert.AreEqual(true, storageFactory.IsInitOnly);
            Assert.AreEqual(true, currentVehicle != null);
        }

        [Test]
        public void TestConstructor()
        {
            Assert.DoesNotThrow(() => new StorageMaster());
        }

        [Test]
        public void TestAddProduct()
        {
            StorageMaster master = new StorageMaster();

            Assert.AreEqual("Added Gpu to pool", master.AddProduct("Gpu", 5));
        }


        [Test]
        public void TestRegisterStorage()
        {
            StorageMaster master = new StorageMaster();

            Assert.AreEqual("Registered Pesho", master.RegisterStorage("Warehouse", "Pesho"));
        }

        [Test]
        public void TestSelectVehicle()
        {
            StorageMaster master = new StorageMaster();

            master.RegisterStorage("Warehouse", "Pesho");

            Assert.AreEqual("Selected Semi", master.SelectVehicle("Pesho", 0));
        }

        [Test]
        public void TestLoadVehicleWithIOE()
        {
            StorageMaster master = new StorageMaster();

            master.RegisterStorage("Warehouse", "Pesho");
            master.SelectVehicle("Pesho", 0);
            string[] products = new string[] { "Gpu" };

            Assert.Throws<InvalidOperationException>(() => master.LoadVehicle(products));
        }

        [Test]
        public void TestLoadVehicle()
        {
            StorageMaster master = new StorageMaster();

            master.RegisterStorage("Warehouse", "Pesho");
            master.SelectVehicle("Pesho", 0);
            master.AddProduct("Gpu", 5);
            string[] products = new string[] { "Gpu" };

            Assert.AreEqual("Loaded 1/1 products into Semi", master.LoadVehicle(products));
        }

        [Test]
        public void TestSendVehicleToWithIOE1()
        {
            StorageMaster master = new StorageMaster();

            master.RegisterStorage("Warehouse", "Pesho");

            Assert.Throws<InvalidOperationException>(() => master.SendVehicleTo("Pesho", 0, "Gosho"));
        }

        [Test]
        public void TestSendVehicleToWithIOE2()
        {
            StorageMaster master = new StorageMaster();

            master.RegisterStorage("Warehouse", "Pesho");

            Assert.Throws<InvalidOperationException>(() => master.SendVehicleTo("Gosho", 0, "Pesho"));
        }

        [Test]
        public void TestSendVehicleTo()
        {
            StorageMaster master = new StorageMaster();

            master.RegisterStorage("Warehouse", "Pesho");
            master.RegisterStorage("Warehouse", "Gosho");

            Assert.AreEqual("Sent Semi to Gosho (slot 3)", master.SendVehicleTo("Pesho", 1, "Gosho"));
            Assert.AreEqual("Sent Semi to Gosho (slot 4)", master.SendVehicleTo("Pesho", 0, "Gosho"));
        }


        [Test]
        public void TestUnloadVehicle()
        {
            StorageMaster master = new StorageMaster();

            master.RegisterStorage("Warehouse", "Pesho");

            Assert.AreEqual("Unloaded 1/1 products at Pesho", master.UnloadVehicle("Pesho", 0));
        }

        [Test]
        public void TestGetStorageStatus()
        {
            StorageMaster master = new StorageMaster();

            master.RegisterStorage("Warehouse", "Pesho");

            Assert.AreEqual("Stock (0/10): []\r\nGarage: [Semi|Semi|Semi|empty|empty|empty|empty|empty|empty|empty]", master.GetStorageStatus("Pesho"));
        }

        [Test]
        public void TestGetSummary()
        {
            StorageMaster master = new StorageMaster();

            master.RegisterStorage("Warehouse", "Pesho");

            Assert.AreEqual("Pesho:\r\nStorage worth: $0.00", master.GetSummary());
        }
    }
}
