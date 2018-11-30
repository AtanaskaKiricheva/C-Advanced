using System;
using System.Collections.Generic;
using System.Text;

namespace Exercise.Entities.Weapons
{
    public class Axe : Weapon
    {
        const int minDamage = 5;
        const int maxDamage = 10;

        public Axe(string name, string rarity) 
            : base(name, minDamage, maxDamage, new Magic[4], rarity)
        {
        }
    }
}
