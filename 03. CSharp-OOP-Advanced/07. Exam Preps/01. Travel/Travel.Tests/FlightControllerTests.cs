using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using Travel.Core.Controllers;
using Travel.Entities;
using Travel.Entities.Airplanes;
using Travel.Entities.Contracts;
using Travel.Entities.Items;

[TestFixture]
public class FlightControllerTests
{
    Type type = typeof(FlightController);

    [Test]
    public void TestConstructor()
    {
        IAirport airport = new Airport();
        FlightController flightController = new FlightController(airport);

        FieldInfo airportField = type.GetField("airport", BindingFlags.NonPublic | BindingFlags.Instance);
        FieldInfo randomGeneratorField = type.GetField("randomGenerator", BindingFlags.NonPublic | BindingFlags.Instance);

        Assert.AreEqual(true, airportField.IsInitOnly);
        Assert.AreEqual(true, airportField.GetValue(flightController) == airport);
        Assert.AreEqual(true, randomGeneratorField.IsInitOnly);
        Assert.AreEqual(true, randomGeneratorField != null);
    }

    [Test]
    public void TestFields()
    {
        FieldInfo constField = type.GetField("EjectionSeed", BindingFlags.NonPublic | BindingFlags.Static);

        Assert.AreEqual(true, constField.IsLiteral);
        Assert.AreEqual(1337, constField.GetValue(type));
    }

    [Test]
    public void TestTakeOff()
    {
        IAirport airport = new Airport();

        FlightController flightController = new FlightController(airport);

        Assert.AreEqual("Confiscated bags: 0 (0 items) => $0", flightController.TakeOff());
    }

    [Test]
    public void TestTakeOffWithSuccess()
    {
        IAirport airport = new Airport();

        airport.AddTrip(new Trip("Pesho", "BG", new LightAirplane()));

        FlightController flightController = new FlightController(airport);

        Assert.AreEqual("PeshoBG4:\r\nSuccessfully transported 0 passengers from Pesho to BG.\r\nConfiscated bags: 0 (0 items) => $0", flightController.TakeOff());
    }

    [Test]
    public void TestTakeOffWithConfiscatedBags()
    {
        IAirport airport = new Airport();

        IPassenger passenger = new Passenger("Pesho");
        airport.AddTrip(new Trip("Pesho", "BG", new LightAirplane()));
        List<Item> items = new List<Item>() { new Laptop(), new Laptop(), new Laptop(), new Laptop(), new Laptop(), new Laptop(), new Laptop(), new Laptop(), new Laptop(), new Laptop() };
        airport.AddConfiscatedBag(new Bag(passenger, items));

        FlightController flightController = new FlightController(airport);

        Assert.AreEqual("PeshoBG2:\r\nSuccessfully transported 0 passengers from Pesho to BG.\r\nConfiscated bags: 1 (10 items) => $30000", flightController.TakeOff());
    }

    [Test]
    public void TestTakeOffWithOverbooked()
    {
        IAirport airport = new Airport();
        FlightController flightController = new FlightController(airport);
        Airplane plane = new LightAirplane();

        var passenger1 = new Passenger("Pesho");
        var passenger2 = new Passenger("Gosho");
        var passenger3 = new Passenger("Kiro");
        var passenger4 = new Passenger("Mimi");
        var passenger5 = new Passenger("Naska");
        var passenger6 = new Passenger("Spaska");

        plane.AddPassenger(passenger1);
        plane.AddPassenger(passenger2);
        plane.AddPassenger(passenger3);
        plane.AddPassenger(passenger4);
        plane.AddPassenger(passenger5);
        plane.AddPassenger(passenger6);

        airport.AddTrip(new Trip("Pesho", "BG",plane));

        Assert.AreEqual("PeshoBG3:\r\nOverbooked! Ejected Gosho\r\nConfiscated 0 bags ($0)\r\nSuccessfully transported 5 passengers from Pesho to BG.\r\nConfiscated bags: 0 (0 items) => $0", flightController.TakeOff());
    }

    [Test]
    public void TestEjectOverbookedPassengers()
    {
        MethodInfo method = typeof(FlightController).GetMethod("EjectOverbookedPassengers", BindingFlags.NonPublic | BindingFlags.Instance);

        Assert.AreEqual(true, method != null);
    }

    [Test]
    public void TestTripIsCompleted()
    {
        IAirport airport = new Airport();
        Trip trip = new Trip("Pesho", "BG", new LightAirplane());

        airport.AddTrip(trip);

        FlightController flightController = new FlightController(airport);
        flightController.TakeOff();

        Assert.AreEqual("Confiscated bags: 0 (0 items) => $0", flightController.TakeOff());

    }

    [Test]
    public void TestConfiscatedBags()
    {
        IAirport airport = new Airport();
        FlightController flightController = new FlightController(airport);
        Airplane plane = new LightAirplane();

        var passenger1 = new Passenger("Pesho");
        var passenger2 = new Passenger("Gosho");
        var passenger3 = new Passenger("Kiro");
        var passenger4 = new Passenger("Mimi");
        var passenger5 = new Passenger("Naska");
        var passenger6 = new Passenger("Spaska");

        IBag bag = new Bag(passenger2, new[] { new Laptop() });

        passenger2.Bags.Add(bag);

        plane.AddPassenger(passenger1);
        plane.AddPassenger(passenger2);
        plane.AddPassenger(passenger3);
        plane.AddPassenger(passenger4);
        plane.AddPassenger(passenger5);
        plane.AddPassenger(passenger6);

        airport.AddTrip(new Trip("Pesho", "BG", plane));

        Assert.AreEqual("PeshoBG1:\r\nOverbooked! Ejected Gosho\r\nConfiscated 1 bags ($3000)\r\nSuccessfully transported 5 passengers from Pesho to BG.\r\nConfiscated bags: 1 (1 items) => $3000", flightController.TakeOff());

    }
}
