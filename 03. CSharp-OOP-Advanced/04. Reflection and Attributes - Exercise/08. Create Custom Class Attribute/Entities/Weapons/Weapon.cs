using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Exercise.Entities.Weapons
{
    [Custom(author: "Pesho", revision: 3, description: "Used for C# OOP Advanced Course - Enumerations and Attributes.", reviewers:new string[] {"Pesho", "Svetlio"})]
    public abstract class Weapon
    {
        public Weapon(string name, int minDamage, int maxDamage, Magic[] sockets, string rarity)
        {
            Name = name;
            MinDamage = minDamage;
            MaxDamage = maxDamage;
            Sockets = sockets;
            ApplyRarity(rarity);
        }

        private void ApplyRarity(string rarity)
        {
            switch (rarity)
            {
                case "Uncommon":
                    MinDamage *= 2;
                    MaxDamage *= 2; break;
                case "Rare":
                    MinDamage *= 3;
                    MaxDamage *= 3; break;
                case "Epic":
                    MinDamage *= 5;
                    MaxDamage *= 5; break;
            }
        }

        public void AddGem(int index, Magic gem)
        {
            if (index >= 0 && index < Sockets.Length)
            {
                Sockets[index] = gem;
            }
        }

        public void RemoveGem(int index)
        {
            if (index >= 0 && index < Sockets.Length)
            {
                Sockets[index] = null;
            }
        }

        public void ApplyMagic(Magic magic)
        {
            MinDamage += (magic.Strength * 2) + (magic.Agility);
            MaxDamage += (magic.Strength * 3) + (magic.Agility * 4);
        }

        public override string ToString()
        {
            foreach (var gem in Sockets.Where(x=>x!=null))
            {
                ApplyMagic(gem);
            }
            return $"{Name}: {MinDamage}-{MaxDamage} Damage, +{Sockets.Where(x=>x!=null).Sum(x=>x.Strength)} Strength, +{Sockets.Where(x => x != null).Sum(x => x.Agility)} Agility, +{Sockets.Where(x => x != null).Sum(x => x.Vitality)} Vitality";
        }

        public string Name { get; private set; }
        public int MinDamage { get; private set; }
        public int MaxDamage { get; private set; }
        public Magic[] Sockets { get; private set; }
    }
}
