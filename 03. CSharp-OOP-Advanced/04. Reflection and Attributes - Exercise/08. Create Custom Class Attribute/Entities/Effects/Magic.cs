using System;
using System.Collections.Generic;
using System.Text;

namespace Exercise.Entities.Weapons
{
    public class Magic : Gem
    {
        public Magic(string quality, string name) : base(quality, name)
        {
            ApplyGem(name);
            ApplyQuality(quality);
        }

        private void ApplyQuality(string gemQuality)
        {
            int stat = 0;
            switch (gemQuality)
            {
                case "Chipped":
                    stat = 1;
                    break;
                case "Regular":
                    stat = 2;
                    break;
                case "Perfect":
                    stat = 5;
                    break;
                case "Flawless":
                    stat = 10;
                    break;
            }
            Strength += stat;
            Agility += stat;
            Vitality += stat;
        }

        private void ApplyGem(string gemType)
        {
            switch (gemType)
            {
                case "Ruby":
                    Strength += 7;
                    Agility += 2;
                    Vitality += 5;
                    break;
                case "Emerald":
                    Strength += 1;
                    Agility += 4;
                    Vitality += 9;
                    break;
                case "Amethyst":
                    Strength += 2;
                    Agility += 8;
                    Vitality += 4;
                    break;
            }
        }

        public int Strength { get; private set; }
        public int Agility { get; private set; }
        public int Vitality { get; private set; }
    }
}
