namespace Travel.Core
{
    using System;
    using System.Linq;
	using Contracts;
	using Controllers.Contracts;

	public class Engine : IEngine
	{
		private readonly IAirportController airportController;
		private readonly IFlightController flightController;

		public Engine(IAirportController airportController,
			IFlightController flightController)
		{
			this.airportController = airportController;
			this.flightController = flightController;
		}

		public void Run()
		{
			while (true)
			{
                var input = Console.ReadLine(); ;

				if (input == "END")
				{
					break;
				}

				try
				{
					var result = this.ProcessCommand(input);
					Console.WriteLine(result);
				}
				catch (InvalidOperationException ex)
				{
					Console.WriteLine("ERROR: " + ex.Message);
				}
			}
		}

		public string ProcessCommand(string input)
		{
			var tokens = input.Split(' ');

			var command = tokens.First();
			var args = tokens.Skip(1).ToArray();

			switch (command)
			{
				case "RegisterPassenger":
				{
					var name = args[0];
					var output = this.airportController.RegisterPassenger(name);
					return output;
				}
				case "RegisterTrip":
				{
					var source = args[0];
					var destination = args[1];
					var planeType = args[2];

					var output = this.airportController.RegisterTrip(source, destination, planeType);
					return output;
				}
				case "RegisterBag":
				{
					var username = args[0];
					var bagItems = args.Skip(1);

					var output = this.airportController.RegisterBag(username, bagItems);
					return output;
				}
				case "CheckIn":
				{
					var username = args[0];
					var tripId = args[1];
					var bagCheckInIndices = args.Skip(2).Select(Int32.Parse);

					var output = this.airportController.CheckIn(username, tripId, bagCheckInIndices);
					return output;
				}
				case "TakeOff":
				{
					var output = this.flightController.TakeOff();
					return output;
				}
				default:
					throw new System.InvalidOperationException("Invalid command!");
			}
		}
	}
}