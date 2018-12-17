using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using TheTankGame.Entities.Parts.Contracts;
using TheTankGame.Entities.Parts.Factories.Contracts;

namespace TheTankGame.Entities.Vehicles.Factories
{
    public class PartFactory : IPartFactory
    {
        public IPart CreatePart(string partType, string model, double weight, decimal price, int additionalParameter)
        {
            Assembly assembly = Assembly.GetCallingAssembly();

            Type type = assembly.DefinedTypes.FirstOrDefault(x => x.Name == partType + "Part");
            IPart part = (IPart)Activator.CreateInstance(type, model, weight, price, additionalParameter);

            return part;
        }
    }
}
