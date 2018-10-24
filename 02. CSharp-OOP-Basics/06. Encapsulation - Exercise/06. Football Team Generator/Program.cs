using System;
using System.Collections.Generic;
using System.Linq;

namespace Exercise
{
    class Program
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine();
            List<Team> teams = new List<Team>();

            while (command != "END")
            {
                string[] data = command.Split(";", StringSplitOptions.RemoveEmptyEntries);
                string teamName = data[1];
                string playerName = "";

                switch (data[0])
                {
                    case "Team":
                        try
                        {
                            teams.Add(new Team(teamName));
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("A name should not be empty.");
                        }
                        break;
                    case "Add":
                        playerName = data[2];
                        int endurance = int.Parse(data[3]);
                        int sprint = int.Parse(data[4]);
                        int dribble = int.Parse(data[5]);
                        int passing = int.Parse(data[6]);
                        int shooting = int.Parse(data[7]);

                        if (teams.FirstOrDefault(x => x.Name == teamName) == null)
                        {
                            Console.WriteLine($"Team {teamName} does not exist.");
                            break;
                        }
                        try
                        {
                            Player playerAdd = new Player(playerName, endurance, sprint, dribble, passing, shooting);
                            teams.FirstOrDefault(x => x.Name == teamName).AddPlayer(playerAdd);
                        }
                        catch (Exception ex) { }

                        break;
                    case "Remove":
                        playerName = data[2];
                        teams.FirstOrDefault(x => x.Name == teamName).RemovePlayer(playerName);
                        break;
                    case "Rating":
                        if (teams.FirstOrDefault(x => x.Name == teamName) == null)
                        {
                            Console.WriteLine($"Team {teamName} does not exist.");
                            break;
                        }
                        Console.WriteLine(teams.FirstOrDefault(x => x.Name == teamName));
                        break;
                }

                command = Console.ReadLine();
            }

        }
    }
}