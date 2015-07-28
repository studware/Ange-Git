using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infestation
{
    public class InfestationSpores : EffectableSupplement
    {
        const int InfestationSporesHealthEffect = 0;
        const int InfestationSporesPowerEffect = -1;
        const int InfestationSporesAggressionEffect = 20;

        public InfestationSpores() : base
            (InfestationSpores.InfestationSporesHealthEffect, 
            InfestationSpores.InfestationSporesPowerEffect,
            InfestationSpores.InfestationSporesAggressionEffect)
        {
            this.hasEffect = true;
        }

        public override void ReactTo(ISupplement otherSupplement)
        {
            if (otherSupplement is InfestationSpores)
            {
                this.hasEffect = false;
            }
        }
    }
}
