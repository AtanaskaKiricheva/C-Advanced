using DungeonsAndCodeWizards.Controller;
using System;
using System.Linq;

namespace DungeonsAndCodeWizards.Core
{
    public class Engine
    {
        DungeonMaster master;
        public Engine()
        {
            master = new DungeonMaster();
        }
        public void Run()
        {
            string command = Console.ReadLine();
            bool isGameOver = false;

            while (!string.IsNullOrEmpty(command))
            {
                string[] args = command.Split();

                try
                {
                    switch (args[0])
                    {
                        case "JoinParty":
                            Console.WriteLine(master.JoinParty(args.Skip(1).ToArray()));
                            break;
                        case "AddItemToPool":
                            Console.WriteLine(master.AddItemToPool(args.Skip(1).ToArray()));
                            break;
                        case "PickUpItem":
                            Console.WriteLine(master.PickUpItem(args.Skip(1).ToArray()));
                            break;
                        case "UseItem":
                            Console.WriteLine(master.UseItem(args.Skip(1).ToArray()));
                            break;
                        case "UseItemOn":
                            Console.WriteLine(master.UseItemOn(args.Skip(1).ToArray()));
                            break;
                        case "GiveCharacterItem":
                            Console.WriteLine(master.GiveCharacterItem(args.Skip(1).ToArray()));
                            break;
                        case "GetStats":
                            Console.WriteLine(master.GetStats());
                            break;
                        case "Attack":
                            Console.WriteLine(master.Attack(args.Skip(1).ToArray()));
                            break;
                        case "Heal":
                            Console.WriteLine(master.Heal(args.Skip(1).ToArray()));
                            break;
                        case "EndTurn":
                            Console.WriteLine(master.EndTurn(args.Skip(1).ToArray()));
                            break;
                        case "IsGameOver":
                            isGameOver = master.IsGameOver();
                            break;
                    }
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine($"Parameter Error: {ex.Message}");
                }
                catch (InvalidOperationException ex)
                {
                    Console.WriteLine($"Invalid Operation: {ex.Message}");
                }
                if (master.IsGameOver() || isGameOver)
                {
                    break;
                }
                command = Console.ReadLine();
            }
            Console.WriteLine("Final stats:");
            Console.WriteLine(master.GetStats());
        }
    }
}
