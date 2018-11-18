using System;
using System.Collections.Generic;
using System.Text;
using AnimalCentre.Models.Contracts;
using AnimalCentre.Models.Entities.Animals;

namespace AnimalCentre.Models.Entities.Procedures
{
    public class Fitness : Procedure
    {
        public Fitness()
        {
        }

        public override void DoService(IAnimal animal, int procedureTime)
        {
            base.DoService(animal, procedureTime);
            Animal currentAnimal = ((Animal)animal);
            currentAnimal.Happiness -= 3;
            currentAnimal.Energy += 10;
            ((Animal)animal).ProcedureTime -= procedureTime;
            if (!procedureHistory.ContainsKey(this))
            {
                procedureHistory.Add(this, new List<Animal>());
            }
            procedureHistory[this].Add((Animal)animal);
        }
    }
}
