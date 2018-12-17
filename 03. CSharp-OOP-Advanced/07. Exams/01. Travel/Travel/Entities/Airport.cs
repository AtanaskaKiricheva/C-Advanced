namespace Travel.Entities
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using Contracts;
	
	public class Airport : IAirport
	{
        private List<IBag> checkedInBags;
        private List<IBag> confiscatedBags;
        private List<IPassenger> passengers;
        private List<ITrip> trips;
             
        public Airport()
        {
            checkedInBags = new List<IBag>();
            confiscatedBags = new List<IBag>();
            passengers = new List<IPassenger>();
            trips = new List<ITrip>();
        }

        public IReadOnlyCollection<IBag> CheckedInBags => checkedInBags.AsReadOnly();

        public IReadOnlyCollection<IBag> ConfiscatedBags => confiscatedBags.AsReadOnly();

        public IReadOnlyCollection<IPassenger> Passengers => passengers.AsReadOnly();

        public IReadOnlyCollection<ITrip> Trips => trips.AsReadOnly();

        public IPassenger GetPassenger(string username)
        {
            var passenger = passengers.FirstOrDefault(x => x.Username == username);

            return passenger;
        }

		public ITrip GetTrip(string id)
        {
            var trip = trips.FirstOrDefault(x => x.Id == id);

            return trip;
        }

		public void AddPassenger(IPassenger passenger)
        {
            passengers.Add(passenger);
        }

		public void AddTrip(ITrip trip)
        {
            trips.Add(trip);
        }

		public void AddCheckedBag(IBag bag)
        {
            checkedInBags.Add(bag);
        }

		public void AddConfiscatedBag(IBag bag)
        {
            confiscatedBags.Add(bag);
        }
	}
}