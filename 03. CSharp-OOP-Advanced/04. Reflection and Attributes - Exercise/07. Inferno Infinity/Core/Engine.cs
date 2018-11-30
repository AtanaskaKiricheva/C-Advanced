using Exercise.Entities.Weapons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Exercise.Core
{
    public class Engine
    {
        public void Run()
        {
            string[] command = Console.ReadLine().Split(";");
            List<Weapon> weapons = new List<Weapon>();

            while (command[0] != "END")
            {
                string weaponType;
                string weaponRarity;
                string weaponName;
                int index;
                string gemQuality;
                string gemType;

                switch (command[0])
                {
                    case "Create":
                        weaponRarity = command[1].Split()[0];
                        weaponType = command[1].Split()[1];
                        weaponName = command[2];

                        var type = Assembly.GetExecutingAssembly().GetTypes()
                            .FirstOrDefault(x => x.Name == weaponType);
                        var weaponInstance = Activator.CreateInstance(type, new object[] { weaponName, weaponRarity });

                        weapons.Add((Weapon)weaponInstance);
                        break;
                    case "Add":
                        weaponName = command[1];
                        index = int.Parse(command[2]);
                        gemQuality = command[3].Split()[0];
                        gemType = command[3].Split()[1];

                        Magic gem = new Magic(gemQuality, gemType);
                        weapons.FirstOrDefault(x => x.Name == weaponName).AddGem(index, gem);
                        break;
                    case "Remove":
                        weaponName = command[1];
                        index = int.Parse(command[2]);

                        weapons.FirstOrDefault(x => x.Name == weaponName).RemoveGem(index);
                        break;
                    case "Print":
                        weaponName = command[1];

                        Console.WriteLine(weapons.FirstOrDefault(x => x.Name == weaponName));
                        break;
                    default: throw new ArgumentException("Invalid command!");
                }

                command = Console.ReadLine().Split(";");
            }
        }
    }
}
