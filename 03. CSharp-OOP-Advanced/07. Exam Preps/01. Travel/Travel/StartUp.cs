namespace Travel
{
	using Core;
	using Core.Controllers;
	using Entities;
	using Entities.Contracts;

	public static class StartUp
	{
		public static void Main(string[] args)
		{
			IAirport airport = new Airport();
			var airportController = new AirportController(airport);
			var flightController = new FlightController(airport);

			var engine = new Engine(airportController, flightController);

			engine.Run();
		}
	}
}