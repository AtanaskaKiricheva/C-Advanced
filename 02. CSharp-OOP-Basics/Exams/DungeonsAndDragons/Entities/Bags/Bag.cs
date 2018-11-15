using DungeonsAndCodeWizards.Entities.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DungeonsAndCodeWizards.Entities.Bags
{
    public abstract class Bag
    {
        private int capacity = 100;
        private List<Item> items;

        public Bag(int capacity)
        {
            Capacity = capacity;
            items = new List<Item>();
        }

        public void AddItem(Item item)
        {
            if (Load + item.Weight > capacity)
            {
                throw new InvalidOperationException("Bag is full!");
            }
            items.Add(item);
        }

        public Item GetItem(string name)
        {
            Item item = items.FirstOrDefault(x => x.GetType().Name == name);

            if (items.Count == 0)
            {
                throw new InvalidOperationException("Bag is empty!");
            }
            if (item == null)
            {
                throw new ArgumentException($"No item with name {name} in bag!");
            }

            items.Remove(item);
            return item;
        }

        public int Capacity { get => capacity; private set => capacity = value; }
        public int Load { get => items.Sum(x => x.Weight); }
        public IReadOnlyCollection<Item> Items { get => items.AsReadOnly(); }
    }
}
