using System;
using System.Collections.Generic;

namespace DefiningClasses
{
    public class Trainer
    {
        private string name;
        private int badges;
        private Pokemon pokemon;

        public Trainer(string name, int badges, Pokemon pokemon)
        {
            this.Name = name;
            this.Badges = badges;
            this.Pokemon = pokemon;
        }

        public string Name { get; set; }
        public int Badges { get; set; }
        public Pokemon Pokemon { get; set; }
    }
}