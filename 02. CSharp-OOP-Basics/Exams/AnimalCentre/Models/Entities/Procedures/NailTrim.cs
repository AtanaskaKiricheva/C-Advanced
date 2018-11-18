using System;
using System.Collections.Generic;
using System.Text;
using AnimalCentre.Models.Contracts;
using AnimalCentre.Models.Entities.Animals;

namespace AnimalCentre.Models.Entities.Procedures
{
    public class NailTrim : Procedure
    {
        public NailTrim()
        {
        }

        public override void DoService(IAnimal animal, int procedureTime)
        {
            base.DoService(animal, procedureTime);
            Animal currentAnimal = ((Animal)animal);
            currentAnimal.Happiness -= 7;
            ((Animal)animal).ProcedureTime -= procedureTime;
            if (!procedureHistory.ContainsKey(this))
            {
                procedureHistory.Add(this, new List<Animal>());
            }
            procedureHistory[this].Add((Animal)animal);
        }
    }
}
