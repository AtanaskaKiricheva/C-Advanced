using DungeonsAndCodeWizards.Entities.Bags;
using DungeonsAndCodeWizards.Entities.Enums;
using DungeonsAndCodeWizards.Entities.Items;
using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonsAndCodeWizards.Entities.Characters
{
    public abstract class Character
    {
        private string name;
        private double baseHealth;
        private double health;
        private double baseArmor;
        private double armor;
        private double abilityPoints;
        private Bag bag;
        private Faction faction;
        private bool isAlive;
        private double restHealMultiplier;

        public Character(string name, double health, double armor, double abilityPoints, Bag bag, Faction faction)
        {
            Name = name;
            BaseHealth = health;
            Health = health;
            BaseArmor = armor;
            Armor = armor;
            AbilityPoints = abilityPoints;
            Bag = bag;
            Faction = faction;
            isAlive = true;
            restHealMultiplier = 0.2;
        }

        internal void RestoreArmor()
        {
            Armor = BaseArmor;
        }

        internal void IncreaseHealth(double points)
        {
            Health += points;
        }

        internal void DecreaseHealth(int points)
        {
            Health -= points;
        }

        internal void CheckIfAlive()
        {
            if (IsAlive == false || health <= 0)
            {
                throw new InvalidOperationException("Must be alive to perform this action!");
            }
        }

        internal double GetAbilityPoints()
        {
            return AbilityPoints;
        }

        public void TakeDamage(double hitPoints)
        {
            CheckIfAlive();
            if (Armor - hitPoints <= 0)
            {
                Health -= hitPoints - armor;
                Armor = 0;
            }
            else
            {
                Armor -= hitPoints;
            }

        }

        public void Rest()
        {
            CheckIfAlive();
            Health += BaseHealth * RestHealMultiplier;
        }

        public void UseItem(Item item)
        {
            CheckIfAlive();
            item.AffectCharacter(this);
        }

        public void UseItemOn(Item item, Character character)
        {
            CheckIfAlive();
            character.CheckIfAlive();
            item.AffectCharacter(character);
        }

        public void GiveCharacterItem(Item item, Character character)
        {
            CheckIfAlive();
            character.CheckIfAlive();
            character.ReceiveItem(item);
        }

        public void ReceiveItem(Item item)
        {
            CheckIfAlive();
            bag.AddItem(item);
        }

        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be null or whitespace!");
                }
                name = value;
            }
        }
        public double BaseHealth { get => baseHealth; private set => baseHealth = value; }
        public double Health
        {
            get => health;
            private set
            {
                if (value <= 0)
                {
                    health = 0;
                    isAlive = false;
                }
                else if (value >= baseHealth)
                {
                    health = baseHealth;
                }
                else
                {
                    health = value;
                }
            }
        }
        public double BaseArmor { get => baseArmor; private set => baseArmor = value; }
        public double Armor
        {
            get => armor;
            private set
            {
                if (value >= baseArmor)
                {
                    armor = baseArmor;
                }
                else if (value <= 0)
                {
                    armor = 0;
                }
                else
                {
                    armor = value;
                }
            }
        }
        public double AbilityPoints { get => abilityPoints; private set => abilityPoints = value; }
        public Bag Bag { get => bag; private set => bag = value; }
        public Faction Faction { get => faction; private set => faction = value; }
        public bool IsAlive { get => isAlive; private set => isAlive = value; }
        public double RestHealMultiplier { get => restHealMultiplier; set => restHealMultiplier = value; }
    }
}
