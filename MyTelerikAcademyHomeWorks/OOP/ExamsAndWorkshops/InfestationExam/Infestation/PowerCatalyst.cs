using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infestation
{
    public class PowerCatalyst : Catalyst
    {
        public const int PowerCatalystEffect = 3;
        
        public PowerCatalyst()
            : base(0, PowerCatalystEffect, 0)
        { 
        }
    }
}
