namespace _03BarracksFactory.Core.Factories
{
    using System;
    using _03BarracksFactory.Models.Units;
    using Contracts;
    using P03_BarraksWars.Models.Units;

    public class UnitFactory : IUnitFactory
    {
        public IUnit CreateUnit(string unitType)
        {
            IUnit unit;

            switch (unitType)
            {
                case "Archer":
                    unit = new Archer();
                    break;
                case "Pikeman":
                    unit = new Pikeman();
                    break;
                case "Swordsman":
                    unit = new Swordsman();
                    break;
                case "Gunner":
                    unit = new Gunner();
                    break;
                case "Horseman":
                    unit = new Horseman();
                    break;
                default: throw new ArgumentException("Invalid unit type");
            }

            return unit;
        }
    }
}
