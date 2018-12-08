namespace Travel.Entities.Factories
{
    using Contracts;
    using Items;
    using Items.Contracts;
    using System;
    using System.Linq;
    using System.Reflection;

    public class ItemFactory : IItemFactory
    {
        public IItem CreateItem(string item)
        {
            Assembly assembly = Assembly.GetCallingAssembly();

            Type currentItem = assembly.DefinedTypes.FirstOrDefault(x => x.Name == item);
            IItem itemInstance = (IItem)Activator.CreateInstance(currentItem);

            return itemInstance;
        }
    }
}
