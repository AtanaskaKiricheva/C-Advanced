using NUnit.Framework;
using Master.Entities.Factories;
using Master.Entities.Products;
using Master.Entities.Storage;
using Master.Entities.Vehicles;
using System;
using System.Linq;
using System.Reflection;

namespace Structure.Test
{
    [TestFixture]
    public class TestStructure
    {
        //Factories

        //Test ProductFactory
        [Test]
        public void ValidProductFactory()
        {
            ProductFactory productFactory = new ProductFactory();

            var product = productFactory.CreateProduct("Gpu", 2.5);

            Assert.AreEqual("Gpu", product.GetType().Name);
        }

        [Test]
        public void InvalidProductFactory()
        {
            ProductFactory productFactory = new ProductFactory();

            Assert.Throws<InvalidOperationException>(() => productFactory.CreateProduct("Lalala", 2.5));
        }

        //Test Storage Factory
        [Test]
        public void ValidStorageFactory()
        {
            StorageFactory storageFactory = new StorageFactory();

            var storage = storageFactory.CreateStorage("Warehouse", "Pesho");

            Assert.AreEqual("Pesho", storage.Name);
        }

        [Test]
        public void InvalidStorageFactory()
        {
            StorageFactory storageFactory = new StorageFactory();

            Assert.Throws<InvalidOperationException>(() => storageFactory.CreateStorage("Lalala", "Pesho"));
        }

        //Test Vehicle Factory
        [Test]
        public void ValidVehicleFactory()
        {
            VehicleFactory vehicleFactory = new VehicleFactory();

            var vehicle = vehicleFactory.CreateVehicle("Semi");

            Assert.AreEqual("Semi", vehicle.GetType().Name);
        }

        [Test]
        public void InvalidVehicleFactory()
        {
            VehicleFactory vehicleFactory = new VehicleFactory();

            Assert.Throws<InvalidOperationException>(() => vehicleFactory.CreateVehicle("Lalala"));
        }

        // Test Products

        //Test Product
        [Test]
        public void CheckIfProductClassExists()
        {
            Type productExists = typeof(Product);

            Assert.AreEqual("Product", productExists.Name);
        }

        [Test]
        public void TestProductsFields()
        {
            Type productExists = typeof(Product);
            FieldInfo field = productExists.GetField("price", BindingFlags.Instance | BindingFlags.NonPublic);

            Assert.AreEqual("price", field.Name);
        }

        [Test]
        public void TestProductProperties()
        {
            Type productExists = typeof(Product);
            PropertyInfo property1 = productExists.GetProperty("Price");
            PropertyInfo property2 = productExists.GetProperty("Weight");

            Assert.AreEqual(true, property1.SetMethod.IsPrivate);
        }

        [Test]
        public void ProductPriceProperty()
        {
            Product Gpu = new Gpu(2.5);

            Assert.AreEqual(2.5, Gpu.Price);
        }

        [Test]
        public void ProductPricePropertyShouldThrow()
        {
            Assert.Throws<InvalidOperationException>(() => { Product Gpu = new Gpu(-2.5); });
        }

        //Test Gpu
        [Test]
        public void GpuInheritance()
        {
            Gpu gpu = new Gpu(2.5);

            Assert.IsInstanceOf<Product>(gpu);
        }

        [Test]
        public void TestGpuFields()
        {
            Gpu gpu = new Gpu(5);

            Assert.AreEqual(0.7, gpu.Weight);
        }

        //Test HDD
        [Test]
        public void HDDInheritance()
        {
            HardDrive hardDrive = new HardDrive(2.5);

            Assert.IsInstanceOf<Product>(hardDrive);
        }

        [Test]
        public void TestHddFields()
        {
            HardDrive hdd = new HardDrive(5);

            Assert.AreEqual(1, hdd.Weight);
        }

        //Test Ram
        [Test]
        public void RamInheritance()
        {
            Ram ram = new Ram(2.5);

            Assert.IsInstanceOf<Product>(ram);
        }

        [Test]
        public void TestRamFields()
        {
            Ram ram = new Ram(5);

            Assert.AreEqual(0.1, ram.Weight);
        }

        //Test SSD
        [Test]
        public void SSDInheritance()
        {
            SolidStateDrive solidStateDrive = new SolidStateDrive(2.5);

            Assert.IsInstanceOf<Product>(solidStateDrive);
        }

        [Test]
        public void TestSSDFields()
        {
            SolidStateDrive solidStateDrive = new SolidStateDrive(5);

            Assert.AreEqual(0.2, solidStateDrive.Weight);
        }


        //Test Storage

        //test fields and consts
        //Test Storage
        [Test]
        public void CheckIfStorageClassExists()
        {
            Type productExists = typeof(Storage);

            Assert.AreEqual("Storage", productExists.Name);
        }

        [Test]
        public void TestStorageFields()
        {
            Type productExists = typeof(Storage);
            FieldInfo field1 = productExists.GetField("garage", BindingFlags.Instance | BindingFlags.NonPublic);
            FieldInfo field2 = productExists.GetField("products", BindingFlags.Instance | BindingFlags.NonPublic);

            Assert.AreEqual("garage", field1.Name);
            Assert.AreEqual("products", field2.Name);
            Assert.AreEqual(true, field1.IsInitOnly);
            Assert.AreEqual(true, field2.IsInitOnly);
        }

        [Test]
        public void TestStorageName()
        {
            Warehouse warehouse = new Warehouse("Pesho");

            Assert.AreEqual("Pesho", warehouse.Name);
        }

        [Test]
        public void TestStorageCapacity()
        {
            Warehouse warehouse = new Warehouse("Pesho");

            Assert.AreEqual(10, warehouse.Capacity);
        }

        [Test]
        public void TestStorageGarageSlots()
        {
            Warehouse warehouse = new Warehouse("Pesho");

            Assert.AreEqual(10, warehouse.GarageSlots);
        }

        [Test]
        public void TestStorageIsFull()
        {
            Warehouse warehouse = new Warehouse("Pesho");

            Assert.AreEqual(false, warehouse.IsFull);
        }

        [Test]
        public void TestStorageGarageForIReadonly()
        {
            Warehouse warehouse = new Warehouse("Pesho");

            Assert.AreEqual(true, typeof(Warehouse).GetProperty("Garage").CanWrite == false);
        }

        [Test]
        public void TestStorageProductForIReadonly()
        {
            Warehouse warehouse = new Warehouse("Pesho");

            Assert.AreEqual(true, typeof(Warehouse).GetProperty("Products").CanWrite == false);
        }

        [Test]
        public void TestGetVehicle()
        {
            Storage storage = new Warehouse("Pesho");

            Assert.AreEqual("Semi", storage.GetVehicle(0).GetType().Name);
        }

        [Test]
        public void TestGetVehicleWithIOE1()
        {
            Storage storage = new Warehouse("Pesho");

            Assert.Throws<InvalidOperationException>(() => { storage.GetVehicle(11); });
        }

        [Test]
        public void TestGetVehicleWithIOE2()
        {
            Storage storage = new Warehouse("Pesho");

            Assert.Throws<InvalidOperationException>(() => { storage.GetVehicle(5); });
        }

        [Test]
        public void TestSendVehicle()
        {
            Storage storage = new Warehouse("Pesho");
            Storage destination = new Warehouse("Gosho");

            Assert.AreEqual(3, storage.SendVehicleTo(2, destination));
            Assert.Throws<InvalidOperationException>(() => { storage.SendVehicleTo(3, destination); });
        }

        [Test]
        public void TestSendVehicleWithIOE()
        {
            Storage storage = new Warehouse("Pesho");
            Storage destination = new Warehouse("Gosho");

            Assert.Throws<InvalidOperationException>(() => { storage.SendVehicleTo(3, destination); });
        }

        [Test]
        public void TestSendVehicleWithIOE2()
        {
            Storage storage = new Warehouse("Pesho");
            Storage destination = new DistributionCenter("Gosho");

            storage.SendVehicleTo(0, destination);
            storage.SendVehicleTo(1, destination);

            Assert.Throws<InvalidOperationException>(() => { storage.SendVehicleTo(2, destination); });
        }

        [Test]
        public void TestUnloadVehicle()
        {
            Storage storage = new DistributionCenter("Pesho");

            Assert.AreEqual(0, storage.UnloadVehicle(1));
        }

        //Test Automated
        [Test]
        public void AutomatedInheritsStorage()
        {
            AutomatedWarehouse automatedWarehouse = new AutomatedWarehouse("Pesho");

            Assert.IsInstanceOf<Storage>(automatedWarehouse);
        }

        [Test]
        public void TestAutomatedField()
        {
            Type type = typeof(AutomatedWarehouse);
            FieldInfo field = type.GetField("DefaultVehicles", BindingFlags.Static | BindingFlags.NonPublic);

            Assert.AreEqual(true, field.IsInitOnly);
        }

        //Test Distribution
        [Test]
        public void DistributionInheritsStorage()
        {
            DistributionCenter distributionCenter = new DistributionCenter("Pesho");

            Assert.IsInstanceOf<Storage>(distributionCenter);
        }

        [Test]
        public void TestDistrField()
        {
            Type type = typeof(DistributionCenter);
            FieldInfo field = type.GetField("DefaultVehicles", BindingFlags.Static | BindingFlags.NonPublic);

            Assert.AreEqual(true, field.IsInitOnly);
        }

        //Test Warehouse
        [Test]
        public void WarehouseInheritsStorage()
        {
            Warehouse warehouse = new Warehouse("Pesho");

            Assert.IsInstanceOf<Storage>(warehouse);
        }

        [Test]
        public void TestWarehouseField()
        {
            Type type = typeof(Warehouse);
            FieldInfo field = type.GetField("DefaultVehicles", BindingFlags.Static | BindingFlags.NonPublic);

            Assert.AreEqual(true, field.IsInitOnly);
        }


        //Test Vehicles

        [Test]
        public void CheckIfVehicleClassExists()
        {
            Type productExists = typeof(Vehicle);

            Assert.AreEqual("Vehicle", productExists.Name);
        }

        [Test]
        public void TestVehicleFields()
        {
            Type productExists = typeof(Vehicle);
            FieldInfo field1 = productExists.GetField("trunk", BindingFlags.Instance | BindingFlags.NonPublic);

            Assert.AreEqual("trunk", field1.Name);
            Assert.AreEqual(true, field1.IsInitOnly);
        }

        [Test]
        public void TestProperties()
        {
            Vehicle vehicle = new Semi();

            Assert.AreEqual(10, vehicle.Capacity);
            Assert.AreEqual(true, typeof(Vehicle).GetProperty("Trunk").CanWrite == false);
            Assert.AreEqual(false, vehicle.IsFull);
            Assert.AreEqual(true, vehicle.IsEmpty);
        }

        [Test]
        public void TestLoadProduct()
        {
            Vehicle vehicle = new Semi();

            vehicle.LoadProduct(new Gpu(5));

            Assert.AreEqual(1, vehicle.Trunk.Count);
        }

        [Test]
        public void TestUnloadProduct()
        {
            Vehicle vehicle = new Semi();

            vehicle.LoadProduct(new Gpu(5));
            vehicle.Unload();

            Assert.AreEqual(0, vehicle.Trunk.Count);
        }

        //Test Semi

        [Test]
        public void SemiInheritsVehicle()
        {
            Semi semi = new Semi();

            Assert.IsInstanceOf<Vehicle>(semi);
        }

        [Test]
        public void TestSemiConstField()
        {
            Vehicle vehicle = new Semi();

            Assert.AreEqual(10, vehicle.Capacity);
        }

        //Test Truck

        [Test]
        public void TruckInheritsVehicle()
        {
            Truck truck = new Truck();

            Assert.IsInstanceOf<Vehicle>(truck);
        }

        [Test]
        public void TestTruckConstField()
        {
            Vehicle vehicle = new Truck();

            Assert.AreEqual(5, vehicle.Capacity);
        }


        //Test Van

        [Test]
        public void VanInheritsVehicle()
        {
            Van van = new Van();

            Assert.IsInstanceOf<Vehicle>(van);
        }

        [Test]
        public void TestVanConstField()
        {
            Vehicle vehicle = new Van();

            Assert.AreEqual(2, vehicle.Capacity);
        }
    }
}
