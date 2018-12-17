namespace Travel.Core
{
    using System;
    using System.Linq;
    using System.Reflection;
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

                    var result = this.ProcessCommand(input);
                    Console.WriteLine(result);
            }
        }

        public string ProcessCommand(string input)
        {
            var tokens = input.Split(' ');

            var command = tokens.First();
            var args = tokens.Skip(1).ToArray();

            string output;

            if (command == "TakeOff")
            {
                output = this.flightController.TakeOff();
            }
            else
            {
                Assembly assembly = Assembly.GetExecutingAssembly();

                try
                {
                    var airportController = this.airportController.GetType().GetMethods().FirstOrDefault(x => x.Name == command);

                    output = (string)airportController.Invoke(this.airportController, new object[] { args });
                }
                catch  (TargetInvocationException ex)
                {
                    return "ERROR: "+ex.InnerException.Message;
                }
                catch (Exception ex)
                {
                    return "ERROR: "+ex.Message;
                }

            }
            return output;

            //switch (command)
            //{
            //	case "RegisterPassenger":
            //	{
            //		var name = args[0];
            //		var output = this.airportController.RegisterPassenger(name);
            //		return output;
            //	}
            //	case "RegisterTrip":
            //	{
            //		var source = args[0];
            //		var destination = args[1];
            //		var planeType = args[2];

            //		var output = this.airportController.RegisterTrip(source, destination, planeType);
            //		return output;
            //	}
            //	case "RegisterBag":
            //	{
            //		var username = args[0];
            //		var bagItems = args.Skip(1);

            //		var output = this.airportController.RegisterBag(username, bagItems);
            //		return output;
            //	}
            //	case "CheckIn":
            //	{
            //		var username = args[0];
            //		var tripId = args[1];
            //		var bagCheckInIndices = args.Skip(2).Select(Int32.Parse);

            //		var output = this.airportController.CheckIn(username, tripId, bagCheckInIndices);
            //		return output;
            //	}
            //	case "TakeOff":
            //	{
            //		var output = this.flightController.TakeOff();
            //		return output;
            //	}
            //	default:
            //		throw new System.InvalidOperationException("Invalid command!");
            //}
        }
    }
}