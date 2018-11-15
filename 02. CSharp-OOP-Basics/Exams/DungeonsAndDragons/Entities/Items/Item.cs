using DungeonsAndCodeWizards.Entities.Characters;
using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonsAndCodeWizards.Entities.Items
{
    public abstract class Item
    {
        private int weight;

        public Item(int weight)
        {
            Weight = weight;
        }

        public virtual void AffectCharacter(Character character)
        {
            character.CheckIfAlive();
        }

        public int Weight { get => weight; private set => weight = value; }
    }
}
