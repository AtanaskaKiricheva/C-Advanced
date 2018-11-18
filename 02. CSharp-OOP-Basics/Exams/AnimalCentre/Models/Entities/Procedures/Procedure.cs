using AnimalCentre.Models.Contracts;
using AnimalCentre.Models.Entities.Animals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AnimalCentre.Models.Entities.Procedures
{
    public abstract class Procedure : IProcedure
    {
        protected Dictionary<Procedure, List<Animal>> procedureHistory;
        //protected List<Animal> procedureHistory;

        public Procedure()
        {
            procedureHistory = new Dictionary<Procedure, List<Animal>>();
            //procedureHistory = new List<Animal>();
        }

        public string History()
        {
            List<string> output = new List<string>();

            foreach (var procedure in procedureHistory)
            {
                output.Add($"{procedure.Key}");
                foreach (var animals in procedure.Value)
                {
                    output.Add($"    - {animals.Name} - Happiness: {animals.Happiness} - Energy: {animals.Energy}");
                }
            }

            //foreach (var animals in procedureHistory)
            //{
            //    output.Add($"    - {animals.Name} - Happiness: {animals.Happiness} - Energy: {animals.Energy}");
            //}

            return string.Join("\r\n", output);
        }

        public virtual void DoService(IAnimal animal, int procedureTime)
        {
            if (((Animal)animal).ProcedureTime < procedureTime)
            {
                throw new ArgumentException("Animal doesn't have enough procedure time");
            }
        }
        public IReadOnlyDictionary<Procedure, List<Animal>> ProcedureHistory { get => procedureHistory ;}
    }
}
