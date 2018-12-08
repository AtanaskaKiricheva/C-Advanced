using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Travel.Entities.Airplanes.Contracts;
using Travel.Entities.Contracts;

namespace Travel.Entities.Airplanes
{
    public abstract class Airplane : IAirplane
    {
        private List<IPassenger> passengers;
        private List<IBag> baggageCompartment;

        public Airplane(int seats, int bags)
        {
            Seats = seats;
            BaggageCompartments = bags;
            passengers = new List<IPassenger>();
            baggageCompartment = new List<IBag>();
        }

        public int Seats { get; private set; }
        public int BaggageCompartments { get; private set; }
        public bool IsOverbooked {
            get
            {
                if (passengers.Count <= Seats)
                {
                    return false;
                }
                return true;
            }
            private set
            {
                IsOverbooked = value;
            }
        }
        public IReadOnlyCollection<IBag> BaggageCompartment => this.baggageCompartment;
        public IReadOnlyCollection<IPassenger> Passengers => this.passengers;

        public IEnumerable<IBag> EjectPassengerBags(IPassenger passenger)
        {
            var passengerBags = this.baggageCompartment
                .Where(b => b.Owner == passenger).ToArray();

            for (int i = 0; i < passengerBags.Length; i++)
            {
                baggageCompartment.Remove(passengerBags[i]);
            }

            return passengerBags;
        }

        public IPassenger RemovePassenger(int seat)
        {
            var passenger = passengers[seat];
            passengers.RemoveAt(seat);
            return passenger;
        }

        public void AddPassenger(IPassenger passenger)
        {
            passengers.Add(passenger);
        }

        public void LoadBag(IBag bag)
        {
            var isBaggageCompartmentFull = this.BaggageCompartment.Count > this.BaggageCompartments;

            if (isBaggageCompartmentFull)
                throw new InvalidOperationException($"No more bag room in {this.GetType().ToString()}!");

            this.baggageCompartment.Add(bag);
        }

    }
}
