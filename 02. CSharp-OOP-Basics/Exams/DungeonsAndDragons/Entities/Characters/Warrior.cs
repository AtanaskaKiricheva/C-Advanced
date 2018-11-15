using DungeonsAndCodeWizards.Contracts;
using DungeonsAndCodeWizards.Entities.Bags;
using DungeonsAndCodeWizards.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonsAndCodeWizards.Entities.Characters
{
    public class Warrior : Character, IAttackable
    {
        const double health = 100;
        const double armor = 50;
        const double abilityPoints = 40;

        public Warrior(string name, Faction faction)
            : base(name, health, armor, abilityPoints, bag : new Satchel(), faction: faction)
        {
        }

        public void Attack(Character character)
        {
            this.CheckIfAlive();
            character.CheckIfAlive();

            if (character == this)
            {
                throw new InvalidOperationException("Cannot attack self!");
            }
            if (character.Faction == this.Faction)
            {
                throw new ArgumentException($"Friendly fire! Both characters are from {this.Faction} faction!");
            }
            character.TakeDamage(this.AbilityPoints);
        }
    }
}
