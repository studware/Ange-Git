using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infestation
{
    public class EffectableSupplement : Supplement
    {
        protected bool hasEffect = false;

        public EffectableSupplement(int healthEffect, int powerEffect, int aggressionEffect) :
            base(healthEffect, powerEffect, aggressionEffect)
        {
        }


        public override int HealthEffect
        {
            get
            {
                return 0;
            }
        }

        public override int PowerEffect
        {
            get
            {
                if (!this.hasEffect)
                {
                    return 0;
                }
                else
                {
                    return base.PowerEffect;
                }
            }
        }
        public override int AggressionEffect
        {
            get
            {
                if (!this.hasEffect)
                {
                    return 0;
                }
                else
                {
                    return base.AggressionEffect;
                }
            }
        }
    }
}
