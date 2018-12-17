using NUnit.Framework;
using System.Reflection;

namespace TheTankGame.Tests
{
    using TheTankGame.Entities.Miscellaneous;
    using TheTankGame.Entities.Miscellaneous.Contracts;
    using TheTankGame.Entities.Parts;
    using TheTankGame.Entities.Parts.Contracts;
    using TheTankGame.Entities.Vehicles;

    [TestFixture]
    public class BaseVehicleTests
    {
        [Test]
        public void TestConstructor()
        {
            IAssembler assembler = new VehicleAssembler();
            Vanguard revenger = new Vanguard("SA-203", 100, 300, 1000, 450, 2000, assembler);

            PropertyInfo propInfoModel = typeof(Revenger).GetProperty("Model");
            PropertyInfo propInfoWeight = typeof(Revenger).GetProperty("Weight");
            PropertyInfo propInfoPrice = typeof(Revenger).GetProperty("Price");
            PropertyInfo propInfoAttack = typeof(Revenger).GetProperty("Attack");
            PropertyInfo propInfoDefense = typeof(Revenger).GetProperty("Defense");
            PropertyInfo propInfoHitPoints = typeof(Revenger).GetProperty("HitPoints");

            Assert.AreEqual("SA-203", propInfoModel.GetValue(revenger));
            Assert.AreEqual(100, propInfoWeight.GetValue(revenger));
            Assert.AreEqual(300, propInfoPrice.GetValue(revenger));
            Assert.AreEqual(1000, propInfoAttack.GetValue(revenger));
            Assert.AreEqual(450, propInfoDefense.GetValue(revenger));
            Assert.AreEqual(2000, propInfoHitPoints.GetValue(revenger));

        }

        [Test]
        public void TestTotalWeight()
        {
            IAssembler assembler = new VehicleAssembler();
            Vanguard revenger = new Vanguard("SA-203", 100, 300, 1000, 450, 2000, assembler);

            PropertyInfo TotalWeight = typeof(Revenger).GetProperty("TotalWeight");
            PropertyInfo TotalPrice = typeof(Revenger).GetProperty("TotalPrice");
            PropertyInfo TotalAttack = typeof(Revenger).GetProperty("TotalAttack");
            PropertyInfo TotalDefense = typeof(Revenger).GetProperty("TotalDefense");
            PropertyInfo TotalHitPoints = typeof(Revenger).GetProperty("TotalHitPoints");

            Assert.AreEqual(100, TotalWeight.GetValue(revenger));
            Assert.AreEqual(300, TotalPrice.GetValue(revenger));
            Assert.AreEqual(1000, TotalAttack.GetValue(revenger));
            Assert.AreEqual(450, TotalDefense.GetValue(revenger));
            Assert.AreEqual(2000, TotalHitPoints.GetValue(revenger));
        }

        [Test]
        public void AddArsenalPart()
        {
            IAssembler assembler = new VehicleAssembler();
            Vanguard revenger = new Vanguard("SA-203", 100, 300, 1000, 450, 2000, assembler);
            IPart part = new ArsenalPart("SA-203", 300, 500, 450);

            revenger.AddArsenalPart(part);

            Assert.AreEqual(1, assembler.ArsenalParts.Count);
        }

        [Test]
        public void AddShellPart()
        {
            IAssembler assembler = new VehicleAssembler();
            Vanguard revenger = new Vanguard("SA-203", 100, 300, 1000, 450, 2000, assembler);
            IPart part = new ShellPart("SA-203", 300, 500, 450);

            revenger.AddShellPart(part);

            Assert.AreEqual(1, assembler.ShellParts.Count);
        }

        [Test]
        public void AddEndurancePart()
        {
            IAssembler assembler = new VehicleAssembler();
            Vanguard revenger = new Vanguard("SA-203", 100, 300, 1000, 450, 2000, assembler);
            IPart part = new EndurancePart("SA-203", 300, 500, 450);

            revenger.AddEndurancePart(part);

            Assert.AreEqual(1, assembler.EnduranceParts.Count);
        }

        [Test]
        public void TestToString()
        {
            IAssembler assembler = new VehicleAssembler();
            Vanguard revenger = new Vanguard("SA-203", 100, 300, 1000, 450, 2000, assembler);
            IPart part = new EndurancePart("SA-203", 300, 500, 450);

            Assert.AreEqual("Vanguard - SA-203\r\nTotal Weight: 100.000\r\nTotal Price: 300.000\r\nAttack: 1000\r\nDefense: 450\r\nHitPoints: 2000\r\nParts: None", revenger.ToString());
        }
    }
}