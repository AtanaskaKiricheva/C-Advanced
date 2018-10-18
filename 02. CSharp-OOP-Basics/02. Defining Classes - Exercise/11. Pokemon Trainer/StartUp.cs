using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class StartUp
    {
        public static void Main()
        {
            Dictionary<Trainer,List<Pokemon>> trainers = new Dictionary<Trainer,List<Pokemon>>();

            string[] command = Console.ReadLine().Split();

            while (command[0] != "Tournament")
            {
                string trainerName = command[0];
                string pokemonName = command[1];
                string pokemonElement = command[2];
                int pokemonHealth = int.Parse(command[3]);

                Pokemon pokemon = new Pokemon(pokemonName, pokemonElement, pokemonHealth);
                Trainer trainer = new Trainer(trainerName, 0, pokemon);

                if (!trainers.Any(x=>x.Key.Name == trainerName))
                {
                    trainers.Add(trainer,new List<Pokemon>());
                }
                trainers.Where(x => x.Key.Name == trainerName).FirstOrDefault().Value.Add(pokemon);

                command = Console.ReadLine().Split();
            }
            command = Console.ReadLine().Split();
            while (command[0] != "End")
            {
                string element = command[0];
          
                foreach (var trainer in trainers)
                {
                    if (trainer.Value.Contains(trainer.Value.Where(x => x.Element == element).FirstOrDefault()))
                    {
                        trainer.Key.Badges++;
                    }
                    else
                    {
                        for (int i = 0; i < trainer.Value.Count; i++)
                        {
                            trainer.Value[i].Health -= 10;
                            if (trainer.Value[i].Health <= 0)
                            {
                                trainer.Value.RemoveAt(i);
                            }
                        }
                    }
                }
          
                command = Console.ReadLine().Split();
            }
          
            foreach (var trainer in trainers.OrderByDescending(x => x.Key.Badges))
            {
                Console.WriteLine($"{trainer.Key.Name} {trainer.Key.Badges} {trainer.Value.Count}");
            }

        }
    }
}
