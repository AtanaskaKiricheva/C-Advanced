using System;
using System.Collections.Generic;
using System.Linq;

namespace P05_GreedyTimes
{

    public class Potato
    {
        static void Main(string[] args)
        {
            long input = long.Parse(Console.ReadLine());
            string[] quantities = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            var bag = new Dictionary<string, Dictionary<string, long>>();
            long gold = 0;
            long gems = 0;
            long money = 0;

            for (int i = 0; i < quantities.Length; i += 2)
            {
                string name = quantities[i];
                long quantity = long.Parse(quantities[i + 1]);

                string kind = string.Empty;

                if (name.Length == 3)
                {
                    kind = "Cash";
                }
                else if (name.ToLower().EndsWith("gem"))
                {
                    kind = "Gem";
                }
                else if (name.ToLower() == "gold")
                {
                    kind = "Gold";
                }

                if (kind == "")
                {
                    continue;
                }
                else if (input < bag.Values.Select(x => x.Values.Sum()).Sum() + quantity)
                {
                    continue;
                }

                switch (kind)
                {
                    case "Gem":
                        if (!bag.ContainsKey(kind))
                        {
                            if (bag.ContainsKey("Gold"))
                            {
                                if (quantity > bag["Gold"].Values.Sum())
                                {
                                    continue;
                                }
                            }
                            else
                            {
                                continue;
                            }
                        }
                        else if (bag[kind].Values.Sum() + quantity > bag["Gold"].Values.Sum())
                        {
                            continue;
                        }
                        break;
                    case "Cash":
                        if (!bag.ContainsKey(kind))
                        {
                            if (bag.ContainsKey("Gem"))
                            {
                                if (quantity > bag["Gem"].Values.Sum())
                                {
                                    continue;
                                }
                            }
                            else
                            {
                                continue;
                            }
                        }
                        else if (bag[kind].Values.Sum() + quantity > bag["Gem"].Values.Sum())
                        {
                            continue;
                        }
                        break;
                }

                if (!bag.ContainsKey(kind))
                {
                    bag[kind] = new Dictionary<string, long>();
                }

                if (!bag[kind].ContainsKey(name))
                {
                    bag[kind][name] = 0;
                }

                bag[kind][name] += quantity;
                if (kind == "Gold")
                {
                    gold += quantity;
                }
                else if (kind == "Gem")
                {
                    gems += quantity;
                }
                else if (kind == "Cash")
                {
                    money += quantity;
                }
            }

            foreach (var x in bag)
            {
                Console.WriteLine($"<{x.Key}> ${x.Value.Values.Sum()}");
                foreach (var item2 in x.Value.OrderByDescending(y => y.Key).ThenBy(y => y.Value))
                {
                    Console.WriteLine($"##{item2.Key} - {item2.Value}");
                }
            }
        }
    }
}