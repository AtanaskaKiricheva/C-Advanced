namespace Travel.Core.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using Contracts;
    using Entities;
    using Entities.Contracts;
    using Travel.Entities.Airplanes;
    using Travel.Entities.Items;

    public class AirportController : IAirportController
    {
        private const int BagValueConfiscationThreshold = 3000;

        private IAirport airport;
        Assembly assembly = Assembly.GetExecutingAssembly();

        public AirportController(IAirport airport)
        {
            this.airport = airport;
        }

        public string RegisterPassenger(string username)
        {
            if (this.airport.GetPassenger(username) != null)
            {
                throw new InvalidOperationException($"Passenger {username} already registered!");
            }

            IPassenger passenger = new Passenger(username);

            this.airport.AddPassenger(passenger);

            return $"Registered {passenger.Username}";
        }
        
        public string RegisterBag(string username, IEnumerable<string> bagItems)
        {
            var passenger = this.airport.GetPassenger(username);

            List<Item> items = new List<Item>();

            foreach (var item in bagItems)
            {
                Type currentItem = assembly.DefinedTypes.FirstOrDefault(x => x.Name == item);
                Item itemInstance = (Item)Activator.CreateInstance(currentItem);
                items.Add(itemInstance);
            }

            var bag = new Bag(passenger, items);

            passenger.Bags.Add(bag);

            return $"Registered bag with {string.Join(", ", bagItems)} for {username}";
        }
        
        public string RegisterTrip(string source, string destination, string planeType)
        {
            Type type = assembly.DefinedTypes.FirstOrDefault(x => x.Name == planeType);
            Airplane airplane = (Airplane)Activator.CreateInstance(type);

            var trip = new Trip(source, destination, airplane);

            this.airport.AddTrip(trip);

            return $"Registered trip {trip.Id}";
        }

        public string CheckIn(string username, string tripId, IEnumerable<int> bagIndices)
        {
            IPassenger passenger = this.airport.GetPassenger(username);

            var trip = airport.GetTrip(tripId);

            var person = this.airport.Passengers.FirstOrDefault(p => p.Username == username);

            if (person.IsChecked)
            {
                throw new InvalidOperationException($"{username} is already checked in!");
            }

            person.IsChecked = true;

            var confiscatedBags = CheckInBags(passenger, bagIndices);
            trip.Airplane.AddPassenger(passenger);

            return
                $"Checked in {passenger.Username} with {bagIndices.Count() - confiscatedBags}/{bagIndices.Count()} checked in bags";
        }

        private int CheckInBags(IPassenger passenger, IEnumerable<int> bagsToCheckIn)
        {
            var bags = passenger.Bags;

            var confiscatedBagCount = 0;
            foreach (var i in bagsToCheckIn)
            {
                var currentBag = bags[i];
                bags.RemoveAt(i);

                if (ShouldConfiscate(currentBag))
                {
                    airport.AddConfiscatedBag(currentBag);
                    confiscatedBagCount++;
                }
                else
                {
                    this.airport.AddCheckedBag(currentBag);
                }
            }

            return confiscatedBagCount;
        }

        private bool ShouldConfiscate(IBag bag)
        {
            var luggageValue = 0;

            for (int i = 0; i < bag.Items.Count; i++)
            {
                luggageValue += bag.Items.ToArray()[i].Value;
            }

            var shouldConfiscate = luggageValue > BagValueConfiscationThreshold;
            return shouldConfiscate;
        }

    }
}