namespace Travel.Core.Controllers.Contracts
{
	using System.Collections.Generic;

	public interface IAirportController
	{
		string RegisterPassenger(string[] args);

		string RegisterBag(string[] args);

		string RegisterTrip(string[] args);

		string CheckIn(string[] args);
	}
}