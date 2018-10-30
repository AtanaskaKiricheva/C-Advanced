using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace PersonInfo.Core
{
    public class Engine
    {
        public void Run()
        {
            string[] phoneNumbers = Console.ReadLine().Split();
            string[] sites = Console.ReadLine().Split();

            for (int i = 0; i < phoneNumbers.Length; i++)
            {
                if (Regex.IsMatch(phoneNumbers[i],"[^0-9]"))
                {
                    Console.WriteLine("Invalid number!");
                    continue;
                }
                Console.WriteLine($"Calling... {phoneNumbers[i]}");
            }

            for (int i = 0; i < sites.Length; i++)
            {
                if (Regex.IsMatch(sites[i],"[0-9]"))
                {
                    Console.WriteLine("Invalid URL!");
                    continue;
                }
                Console.WriteLine($"Browsing: {sites[i]}!");
            }

        }
    }
}
