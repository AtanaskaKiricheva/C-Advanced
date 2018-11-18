using AnimalCentre.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnimalCentre.Models.Entities.Animals
{
    public abstract class Animal: IAnimal
    {
        //TODO for structure check props, private?

        private string name;
        private int happiness;
        private int energy;
        private int procedureTime;
        private string owner;
        private bool isAdopt;
        private bool isChipped;
        private bool isVaccinated;

        public Animal(string name, int energy, int happiness, int procedureTime)
        {
            Name = name;
            Energy = energy;
            Happiness = happiness;
            ProcedureTime = procedureTime;
            Owner = "Centre";
            IsAdopt = false;
            IsChipped = false;
            IsVaccinated = false;
        }


        public string Name { get => name; set => name = value; }
        public int Happiness
        {
            get => happiness;
            set
            {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentException("Invalid happiness");
                }
                happiness = value;
            }
        }
        public int Energy
        {
            get => energy;
            set
            {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentException("Invalid energy");
                }
                energy = value;
            }
        }
        public int ProcedureTime { get => procedureTime; set => procedureTime = value; }
        public string Owner { get => owner; set => owner = value; }
        public bool IsAdopt { get => isAdopt; set => isAdopt = value; }
        public bool IsChipped { get => isChipped; set => isChipped = value; }
        public bool IsVaccinated { get => isVaccinated; set => isVaccinated = value; }
    }
}
