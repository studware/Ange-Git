using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infestation
{
    public class HoldingPenWithSupplements : HoldingPen
    {
        protected override void ExecuteInsertUnitCommand(string[] commandWords)
        {
            var unitType = commandWords[1];
            var unitId = commandWords[2];

            Unit unitTobeAdded = null;

            switch (unitType)
            {
                case "Marine":
                    unitTobeAdded = new Marine(unitId);
                    break;

                case "Parasite":
                    unitTobeAdded = new Parasite(unitId);
                    break;

                case "Queen":
                    unitTobeAdded = new Queen(unitId);
                    break;

                case "Tank":
                    unitTobeAdded = new Tank(unitId);
                    break;

                default:
                    break;
            }

            base.ExecuteInsertUnitCommand(commandWords);

            if (unitTobeAdded!=null)
            {
                this.InsertUnit(unitTobeAdded);
            }
        }
        
        protected override void ExecuteAddSupplementCommand(string[] commandWords)
        {
            var supplementType = commandWords[1];

            ISupplement supplement = null;

            switch (supplementType)
            {
                case "AggressionCatalyst":
                    supplement = new AggressionCatalyst();
                    break;
                case "PowerCatalyst":
                    supplement = new PowerCatalyst();
                    break;
                case "HealthCatalyst":
                    supplement = new HealthCatalyst();
                    break;
                case "Weapon":
                    supplement = new Weapon();
                    break;
                default:
                    break;
            }

            var unitId = commandWords[2];
            var unit = this.GetUnit(unitId);
            if (unit!=null)
            {
                unit.AddSupplement(supplement);   
            }
        }

        protected override void ProcessSingleInteraction(Interaction interaction)
        {
            //	Infesting is equivalent to adding an InfestationSpores Supplement to the target
            switch (interaction.InteractionType)
            {
                case InteractionType.Infest:
                    Unit targetUnit = this.GetUnit(interaction.TargetUnit);
                    targetUnit.AddSupplement(new InfestationSpores());
                    break;
                default:
                    break;
            }
            base.ProcessSingleInteraction(interaction);
        }
    }
}
