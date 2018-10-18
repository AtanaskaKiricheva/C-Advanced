using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class Family
    {
        Dictionary<string, int> family = new Dictionary<string, int>();

        public void AddMember(Person member)
        {
            family.Add(member.Name, member.Age);
        }

        public string GetOldestMember()
        {
            family = new Dictionary<string, int>(family.OrderByDescending(x => x.Value));

            return family.First().Key + " "+ family.First().Value;
        }
    }
}