using System;
using System.Collections.Generic;
using System.Text;

namespace Exercise
{
    public class Dough
    {
        private string flourType;
        private string bakingTechnique;
        private double weight;

        public Dough()
        {

        }
        public Dough(string flourType, string bakingTechnique, double weight)
        {
            this.FlourType = flourType;
            this.BakingTechnique = bakingTechnique;
            this.Weight = weight;
        }

        public double DoughCalories()
        {
            int basee = 2;
            double flourModifier = 0;
            double bakingModifier = 0;

            switch (flourType.ToLower())
            {
                case "white": flourModifier = 1.5; break;
                case "wholegrain": flourModifier = 1; break;
            }
            switch (bakingTechnique.ToLower())
            {
                case "crispy": bakingModifier = 0.9; break;
                case "chewy": bakingModifier = 1.1; break;
                case "homemade": bakingModifier = 1; break;
            }

            return (basee * weight) * flourModifier * bakingModifier;
        }

        public string FlourType
        {
            get => flourType;
            set
            {
                if (value.ToLower() != "white" && value.ToLower() != "wholegrain")
                {
                    Console.WriteLine("Invalid type of dough.");
                    Environment.Exit(1);
                }
                flourType = value;
            }
        }
        public string BakingTechnique
        {
            get => bakingTechnique;
            set
            {
                if (value.ToLower() != "crispy" && value.ToLower() != "chewy" && value.ToLower() != "homemade")
                {
                    Console.WriteLine("Invalid type of dough.");
                    Environment.Exit(1);
                }
                bakingTechnique = value;
            }
        }
        public double Weight
        {
            get => weight;
            set
            {
                if (value < 0 || value > 200)
                {
                    Console.WriteLine("Dough weight should be in the range [1..200].");
                    Environment.Exit(1);
                }
                weight = value;
            }
        }

    }
}
