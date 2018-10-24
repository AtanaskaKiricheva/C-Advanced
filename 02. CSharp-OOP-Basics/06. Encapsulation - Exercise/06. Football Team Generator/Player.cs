using System;
using System.Collections.Generic;
using System.Text;

namespace Exercise
{
    public class Player
    {
        private string name;
        private int endurance;
        private int sprint;
        private int dribble;
        private int passing;
        private int shooting;
        internal double skillLevel;

        public Player(string name, int endurance, int sprint, int dribble, int passing, int shooting)
        {
            this.Name = name;
            this.Endurance = endurance;
            this.Sprint = sprint;
            this.Dribble = dribble;
            this.Passing = passing;
            this.Shooting = shooting;
            CalcSkill();
        }

        private void CalcSkill()
        {
            skillLevel = (endurance + sprint + dribble + passing + shooting) / 5.0;
        }

        public string Name
        {
            get => name;
            set
            {
                if (value == "" || value == null || value == " ")
                {
                    Console.WriteLine("A name should not be empty.");
                    throw new Exception();
                }
                name = value;
            }
        }
        public int Endurance
        {
            get => endurance;
            set
            {
                if (value < 0 || value > 100)
                {
                    Console.WriteLine($"Endurance should be between 0 and 100.");
                    throw new Exception();
                }
                endurance = value;
            }
        }
        public int Sprint
        {
            get => sprint;
            set
            {
                if (value < 0 || value > 100)
                {
                    Console.WriteLine($"Sprint should be between 0 and 100.");
                    throw new Exception();
                }
                sprint = value;
            }
        }
        public int Dribble
        {
            get => dribble;
            set
            {
                if (value < 0 || value > 100)
                {
                    Console.WriteLine($"Dribble should be between 0 and 100.");
                    throw new Exception();
                }
                dribble = value;
            }
        }
        public int Passing
        {
            get => passing;
            set
            {
                if (value < 0 || value > 100)
                {
                    Console.WriteLine($"Passizng should be between 0 and 100.");
                    throw new Exception();
                }
                passing = value;
            }
        }
        public int Shooting
        {
            get => shooting;
            set
            {
                if (value < 0 || value > 100)
                {
                    Console.WriteLine($"Shooting should be between 0 and 100.");
                    throw new Exception();
                }
                shooting = value;
            }
        }
    }
}
