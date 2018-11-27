namespace P01_HarvestingFields
{
    using System;
    using System.Linq;
    using System.Reflection;

    public class HarvestingFieldsTest
    {
        public static void Main()
        {
            string command = Console.ReadLine();

            var currentAssembly = typeof(HarvestingFields);

            FieldInfo[] fields ;

            while (command != "HARVEST")
            {
                switch (command)
                {
                    case "private":
                        fields = currentAssembly.GetFields(
                            BindingFlags.Static | BindingFlags.Instance |
                            BindingFlags.Public | BindingFlags.NonPublic)
                            .Where(x=>x.IsPrivate).ToArray();
                        break;
                    case "protected":
                        fields = currentAssembly.GetFields(
                            BindingFlags.Static | BindingFlags.Instance |
                            BindingFlags.Public | BindingFlags.NonPublic)
                            .Where(x => x.IsFamily).ToArray(); 
                            break;
                    case "public":
                        fields = currentAssembly.GetFields(
                            BindingFlags.Static | BindingFlags.Instance |
                            BindingFlags.Public | BindingFlags.NonPublic)
                            .Where(x=>x.IsPublic).ToArray();
                        break;
                    case "all":
                        fields = currentAssembly.GetFields(
                            BindingFlags.Static | BindingFlags.Instance |
                            BindingFlags.Public | BindingFlags.NonPublic);
                            break;
                    default: throw new ArgumentException();
                }
                foreach (var field in fields)
                {
                    Console.WriteLine($"{field.Attributes.ToString().ToLower().Replace("family","protected")} {field.FieldType.Name} {field.Name}");
                }

                command = Console.ReadLine();
            }
        }
    }
}
