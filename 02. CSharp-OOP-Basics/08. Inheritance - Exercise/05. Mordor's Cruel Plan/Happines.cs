using System;
using System.Collections.Generic;
using System.Text;

namespace Exercise
{
    public class Happines
    {
        const int cram = 2;
        const int lembas = 3;
        const int apple = 1;
        const int melon = 1;
        const int honeyCake = 5;
        const int mushrooms = -10;
        const int other = -1;
        private string food;

        public Happines()
        {

        }
        public Happines(string food)
        {
            Food = food;
        }

        public int GetHappiness()
        {
            switch (food.ToLower())
            {
                case "cram": return cram;
                case "lembas": return lembas;
                case "apple": return apple;
                case "melon": return melon;
                case "honeycake": return honeyCake;
                case "mushrooms": return mushrooms;
                default: return other;
            }
        }

        public string CheckHappiness(int totalHappiness)
        {
            if (totalHappiness < -5)
            {
                return $"{totalHappiness}\r\nAngry";
            }
            else if(totalHappiness>=-5 && totalHappiness<=0)
            {
                return $"{totalHappiness}\r\nSad";
            }
            else if(totalHappiness >=1 && totalHappiness <=15)
            {
                return $"{totalHappiness}\r\nHappy";
            }
            else
            {
                return $"{totalHappiness}\r\nJavaScript";
            }
        }

        public string Food { get => food; set => food = value; }
    }
}
