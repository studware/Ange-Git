using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infestation
{
    public abstract class Catalyst : Supplement
    {
        public Catalyst(int healthEffect, int powerEffect, int aggressionEffect) 
            :base (healthEffect, powerEffect, aggressionEffect)
        { 
        }
    }
}
