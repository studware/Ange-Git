using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infestation
{
    public abstract class InfestUnit : Unit
    {
        public InfestUnit(string id, UnitClassification unitType, int health, int power, int aggression)
                            :base(id, unitType, health, power, aggression)
        {
        }

        protected override bool CanAttackUnit(UnitInfo unit)
        {
            //	The target Unit can be any unit different than itself
            if (unit.Id != this.Id
                && (InfestationRequirements.RequiredClassificationToInfest(unit.UnitClassification)==this.UnitClassification))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //	If there are multiple such units, the Infest Unit picks the one with the least Health
        protected override UnitInfo GetOptimalAttackableUnit(IEnumerable<UnitInfo> attackableUnits)
        {
            return attackableUnits
                .OrderBy(unit => unit.Health)
                .FirstOrDefault();
        }

        public override Interaction DecideInteraction(IEnumerable<UnitInfo> units)
        {
            IEnumerable<UnitInfo> infestableUnits = units.Where((unit) => this.CanAttackUnit(unit));

            UnitInfo optimalInfestableUnit = GetOptimalAttackableUnit(infestableUnits);

            if (optimalInfestableUnit.Id != null)
            {
                return new Interaction(new UnitInfo(this), optimalInfestableUnit, InteractionType.Infest);
            }

            return Interaction.PassiveInteraction;
        }
    }
}
