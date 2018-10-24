using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Exercise
{
    public class Team
    {
        private List<Player> players;
        private string name;
        private int rating;

        public Team(string name)
        {
            Name = name;
            rating = 0;
            players = new List<Player>();
        }

        public void AddPlayer(Player player)
        {
            players.Add(player);
        }

        public void RemovePlayer(string playerName)
        {
            if (players.FirstOrDefault(x => x.Name == playerName) == null)
            {
                Console.WriteLine($"Player {playerName} is not in {name} team.");
            }
            else
            {
                players.Remove(players.FirstOrDefault(x => x.Name == playerName));
            }
        }

        public override string ToString()
        {
            if (players.Count > 0)
            {
                rating = (int)Math.Round(players.Sum(x => x.skillLevel) / players.Count);
            }
            return $"{name} - {rating}";
        }

        public string Name
        {
            get => name;
            set
            {
                if (value == "" || value == null || value == " ")
                {
                    throw new Exception();
                }
                name = value;
            }
        }
    }
}
