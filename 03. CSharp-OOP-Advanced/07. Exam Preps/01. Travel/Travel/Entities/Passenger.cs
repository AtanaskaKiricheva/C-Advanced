namespace Travel.Entities
{
	using System.Collections.Generic;
	using Contracts;

	public class Passenger : IPassenger
	{
        private bool isChecked = false;
		public Passenger(string username)
		{
			this.Username = username;
			this.Bags = new List<IBag>();
            IsChecked = isChecked;
		}

		public string Username { get; }

		public IList<IBag> Bags { get; }

        public bool IsChecked { get; set; }
	}
}