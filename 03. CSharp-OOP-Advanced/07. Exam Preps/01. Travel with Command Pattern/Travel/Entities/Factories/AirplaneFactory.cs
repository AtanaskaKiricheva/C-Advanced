namespace Travel.Entities.Factories
{
    using Contracts;
    using Airplanes.Contracts;
    using Travel.Entities.Airplanes;
    using System;
    using System.Reflection;
    using System.Linq;

    public class AirplaneFactory : IAirplaneFactory
    {
        public IAirplane CreateAirplane(string planeType)
        {
            Assembly assembly = Assembly.GetCallingAssembly();

            Type type = assembly.DefinedTypes.FirstOrDefault(x => x.Name == planeType);
            IAirplane airplane = (IAirplane)Activator.CreateInstance(type);

            return airplane;
        }
    }
}