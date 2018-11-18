using System;
using System.Collections.Generic;
using System.Text;
using AnimalCentre.Models.Contracts;
using AnimalCentre.Models.Entities.Animals;

namespace AnimalCentre.Models.Entities.Procedures
{
    public class Chip : Procedure
    {
        public Chip()
        {
        }

        public override void DoService(IAnimal animal, int procedureTime)
        {
            base.DoService(animal, procedureTime);
            ((Animal)animal).Happiness -= 5;
            if (((Animal)animal).IsChipped)
            {
                throw new ArgumentException($"{((Animal)animal).Name} is already chipped");
            }
            ((Animal)animal).IsChipped = true;
            ((Animal)animal).ProcedureTime -= procedureTime;
            if (!procedureHistory.ContainsKey(this))
            {
                procedureHistory.Add(this, new List<Animal>());
            }
            procedureHistory[this].Add((Animal)animal);
            //procedureHistory.Add((Animal)animal);
        }
    }
}
