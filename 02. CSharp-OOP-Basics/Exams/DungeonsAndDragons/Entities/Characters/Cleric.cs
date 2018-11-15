using DungeonsAndCodeWizards.Contracts;
using DungeonsAndCodeWizards.Entities.Bags;
using DungeonsAndCodeWizards.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonsAndCodeWizards.Entities.Characters
{
    public class Cleric : Character, IHealable
    {
        const double health = 50;
        const double armor = 25;
        const double abilityPoints = 40;

        public Cleric(string name, Faction faction) 
            : base(name, health, armor, abilityPoints, bag: new Backpack(), faction: faction)
        {
            RestHealMultiplier = 0.5;
        }

        public void Heal(Character character)
        {
            this.CheckIfAlive();
            character.CheckIfAlive();

            if (character.Faction != this.Faction)
            {
                throw new InvalidOperationException("Cannot heal enemy character!");
            }
            character.IncreaseHealth(this.GetAbilityPoints());
        }
    }
}
