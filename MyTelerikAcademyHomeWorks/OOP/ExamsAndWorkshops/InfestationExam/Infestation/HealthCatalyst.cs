using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infestation
{
    public class HealthCatalyst : Catalyst
    {
        public const int HealthCatalystEffect = 3;
        
        public HealthCatalyst()
            : base(HealthCatalystEffect, 0, 0)
        { 
        }
    }
}
