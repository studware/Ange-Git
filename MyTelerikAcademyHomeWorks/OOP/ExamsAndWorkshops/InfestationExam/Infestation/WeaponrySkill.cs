using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infestation
{
    public class WeaponrySkill : Supplement
    {
        const int WeaponrySkillHealthEffect = 0;
        const int WeaponrySkillPowerEffect = 0;
        const int WeaponrySkillAggressionEffect = 0;

        public WeaponrySkill() :
            base(WeaponrySkill.WeaponrySkillHealthEffect, WeaponrySkill.WeaponrySkillPowerEffect, WeaponrySkill.WeaponrySkillAggressionEffect)
        {
        }
    }
}
