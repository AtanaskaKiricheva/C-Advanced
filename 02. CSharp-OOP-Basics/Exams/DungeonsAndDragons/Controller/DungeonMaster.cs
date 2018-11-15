using DungeonsAndCodeWizards.Entities.Bags;
using DungeonsAndCodeWizards.Entities.Characters;
using DungeonsAndCodeWizards.Entities.Enums;
using DungeonsAndCodeWizards.Entities.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DungeonsAndCodeWizards.Controller
{
    public class DungeonMaster
    {
        List<Character> party;
        List<Item> itemPool;
        int lastSurvivor;

        public DungeonMaster()
        {
            party = new List<Character>();
            itemPool = new List<Item>();
            lastSurvivor = 0;
        }

        public string JoinParty(string[] args)
        {
            string faction = args[0];
            string characterType = args[1];
            string name = args[2];

            Character character;

            if (characterType == "Cleric")
            {
                if (faction == "CSharp")
                {
                    character = new Cleric(name, Faction.CSharp);
                }
                else if (faction == "Java")
                {
                    character = new Cleric(name, Faction.Java);
                }
                else
                {
                    throw new ArgumentException($"Invalid faction \"{faction}\"!");
                }
            }
            else if (characterType == "Warrior")
            {
                if (faction == "CSharp")
                {
                    character = new Warrior(name, Faction.CSharp);
                }
                else if (faction == "Java")
                {
                    character = new Warrior(name, Faction.Java);
                }
                else
                {
                    throw new ArgumentException($"Invalid faction \"{faction}\"!");
                }
            }
            else
            {
                throw new ArgumentException($"Invalid character type \"{characterType}\"!");
            }
            party.Add(character);
            return $"{name} joined the party!";
        }

        public string AddItemToPool(string[] args)
        {
            string itemName = args[0];

            switch (itemName)
            {
                case "ArmorRepairKit": itemPool.Add(new ArmorRepairKit()); break;
                case "HealthPotion": itemPool.Add(new HealthPotion()); break;
                case "PoisonPotion": itemPool.Add(new PoisonPotion()); break;
                default: throw new ArgumentException($"Invalid item \"{itemName}\"!");
            }

            return $"{itemName} added to pool.";
        }

        public string PickUpItem(string[] args)
        {
            string characterName = args[0];

            Character character = party.FirstOrDefault(x => x.Name == characterName);

            if (character == null)
            {
                throw new ArgumentException($"Character {characterName} not found!");
            }
            if (itemPool.Count == 0)
            {
                throw new InvalidOperationException("No items left in pool!");
            }

            Item item = itemPool.Last();
            character.ReceiveItem(item);
            itemPool.Remove(item);

            return $"{characterName} picked up {item.GetType().Name}!";
        }

        public string UseItem(string[] args)
        {
            string characterName = args[0];
            string itemName = args[1];

            Character character = party.FirstOrDefault(x => x.Name == characterName);

            if (character == null)
            {
                throw new ArgumentException($"Character {characterName} not found!");
            }

            Item item = character.Bag.GetItem(itemName);

            character.UseItem(item);

            return $"{characterName} used {itemName}.";
        }

        public string UseItemOn(string[] args)
        {
            string giverName = args[0];
            string receiverName = args[1];
            string itemName = args[2];

            Character giver = party.FirstOrDefault(x => x.Name == giverName);
            Character receiver = party.FirstOrDefault(x => x.Name == receiverName);

            if (giver == null)
            {
                throw new ArgumentException($"Character {giverName} not found!");
            }
            if (receiver == null)
            {
                throw new ArgumentException($"Character {receiverName} not found!");
            }

            Item item = giver.Bag.GetItem(itemName);
            giver.UseItemOn(item, receiver);

            return $"{giverName} used {itemName} on {receiverName}.";
        }

        public string GiveCharacterItem(string[] args)
        {
            string giverName = args[0];
            string receiverName = args[1];
            string itemName = args[2];

            Character giver = party.FirstOrDefault(x => x.Name == giverName);
            Character receiver = party.FirstOrDefault(x => x.Name == receiverName);

            if (giver == null)
            {
                throw new ArgumentException($"Character {giverName} not found!");
            }
            if (receiver == null)
            {
                throw new ArgumentException($"Character {receiverName} not found!");
            }

            Item item = giver.Bag.GetItem(itemName);
            giver.GiveCharacterItem(item, receiver);

            return $"{giverName} gave {receiverName} {itemName}.";
        }

        public string GetStats()
        {
            List<string> output = new List<string>();

            foreach (var character in party.OrderByDescending(x => x.IsAlive).ThenByDescending(x => x.Health))
            {
                output.Add($"{character.Name} - HP: {character.Health}/{character.BaseHealth}, AP: {character.Armor}/{character.BaseArmor}, Status: {(character.IsAlive ? "Alive" : "Dead")}");
            }

            return string.Join("\r\n", output);
        }

        public string Attack(string[] args)
        {
            string attackerName = args[0];
            string receiverName = args[1];

            Character attacker = party.FirstOrDefault(x => x.Name == attackerName);
            Character receiver = party.FirstOrDefault(x => x.Name == receiverName);

            if (attacker == null)
            {
                throw new ArgumentException($"Character {attackerName} not found!");
            }
            if (receiver == null)
            {
                throw new ArgumentException($"Character {receiverName} not found!");
            }
            if (!(attacker is Warrior))
            {
                throw new ArgumentException($"{attackerName} cannot attack!");
            }
            ((Warrior)attacker).Attack(receiver);

            string output = $"{attackerName} attacks {receiverName} for {attacker.AbilityPoints} hit points! {receiverName} has {receiver.Health}/{receiver.BaseHealth} HP and {receiver.Armor}/{receiver.BaseArmor} AP left!";

            if (!receiver.IsAlive)
            {
                output += $"\r\n{receiver.Name} is dead!";
            }

            return output;
        }

        public string Heal(string[] args)
        {
            string healerName = args[0];
            string receiverName = args[1];

            Character healer = party.FirstOrDefault(x => x.Name == healerName);
            Character receiver = party.FirstOrDefault(x => x.Name == receiverName);

            if (healer == null)
            {
                throw new ArgumentException($"Character {healerName} not found!");
            }
            if (receiver == null)
            {
                throw new ArgumentException($"Character {receiverName} not found!");
            }
            if (!(healer is Cleric))
            {
                throw new ArgumentException($"{healerName} cannot heal!");
            }
            ((Cleric)healer).Heal(receiver);

            string output = $"{healer.Name} heals {receiver.Name} for {healer.AbilityPoints}! {receiver.Name} has {receiver.Health} health now!";

            return output;
        }

        public string EndTurn(string[] args)
        {
            List<string> output = new List<string>();
            int alives = 0;

            foreach (var character in party)
            {
                if (character.IsAlive)
                {
                    string str = $"{character.Name} rests ({character.Health} => ";
                    character.Rest();
                    str += character.Health + ")";
                    output.Add(str);
                    alives++;
                }
            }

            if (alives <= 1)
            {
                lastSurvivor++;
            }
            if (output.Count > 0)
            {
                return string.Join("\r\n", output);
            }
            else
            {
                return "";
            }
        }

        public bool IsGameOver()
        {
            if (lastSurvivor > 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
