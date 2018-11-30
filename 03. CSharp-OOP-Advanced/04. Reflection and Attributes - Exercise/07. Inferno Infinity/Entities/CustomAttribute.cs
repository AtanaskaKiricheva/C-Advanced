using System;
using System.Collections.Generic;
using System.Text;

namespace Exercise.Entities
{
    [AttributeUsage(AttributeTargets.Class)]
    public class CustomAttribute : Attribute
    {
        public CustomAttribute(string author, int revision, string description, string[] reviewers)
        {
            Author = author;
            Revision = revision;
            Description = description;
            Reviewers = reviewers;
        }

        public void Print(string command)
        {
            switch (command)
            {
                case "Author":
                    Console.WriteLine($"Author: {Author}");
                    break;
                case "Revision":
                    Console.WriteLine($"Revision: {Revision}");
                    break;
                case "Description":
                    Console.WriteLine($"Class description: {Description}");
                    break;
                case "Reviewers":
                    Console.WriteLine($"Reviewers: {Reviewers}");
                    break;
            }
        }

        public string Author { get; set; }
        public int Revision { get; set; }
        public string Description { get; set; }
        public string[] Reviewers { get; set; }
    }
}
