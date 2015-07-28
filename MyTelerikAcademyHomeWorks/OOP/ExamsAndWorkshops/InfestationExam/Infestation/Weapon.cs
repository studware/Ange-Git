using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infestation
{
    public class Weapon : EffectableSupplement
    {
        const int WeaponHealthEffect = 0;
        const int WeaponPowerEffect = 10;
        const int WeaponAggressionEffect = 3;

        public Weapon() :
            base(Weapon.WeaponHealthEffect, Weapon.WeaponPowerEffect, Weapon.WeaponAggressionEffect)
        {
            this.hasEffect = false;
        }

         public override void ReactTo(ISupplement otherSupplement)
        {
            if (otherSupplement is WeaponrySkill)
            {
                this.hasEffect = true;
            }
        }
    }
}
