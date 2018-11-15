using DungeonsAndCodeWizards.Entities.Characters;
using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonsAndCodeWizards.Entities.Items
{
    public class HealthPotion : Item
    {
        private const int weight = 5;

        public HealthPotion() : base(weight)
        {
        }

        public override void AffectCharacter(Character character)
        {
            base.AffectCharacter(character);
            character.IncreaseHealth(20);
        }
    }
}
