using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infestation
{
    public class Marine : Human
    {
        public Marine(string id): base(id)
        {
            this.AddSupplement(new WeaponrySkill());
        }

 //       IEnumerable<UnitInfo> attackableUnits = new IEnumerable<UnitInfo>();

        protected override bool CanAttackUnit(UnitInfo unit)
        {
            if (this.Id==unit.Id)
            {
                return false;   
            }
            
            //  The target’s Power should be less than or equal to the Marine’s Aggression
            if (unit.Power <= this.Aggression)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        protected override UnitInfo GetOptimalAttackableUnit(IEnumerable<UnitInfo> attackableUnits)
        {
            return attackableUnits
                .OrderByDescending(unit => unit.Health)
                .FirstOrDefault();
        }
    }
}
