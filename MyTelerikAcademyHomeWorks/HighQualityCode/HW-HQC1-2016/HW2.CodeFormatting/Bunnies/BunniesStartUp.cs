using System.Collections.Generic;
using Bunnies.Enums;
using Bunnies.Utils;

namespace Bunnies
{
    public class BunniesStartUp
    {
        internal const string BunniesFilePath = @"..\..\bunnies.txt";

        public static void Main()
        {
            var bunnies = InitiaizeBunnies();

            var consoleWriter = new ConsoleWriter();
            IntroduceAllBunnies.IntroduceBunnies(bunnies, consoleWriter);

            BunniesDataBase.UpdateBunniesDataBase(bunnies);
        }

        private static List<Bunny> InitiaizeBunnies()
        {
            List<Bunny> bunnies = new List<Bunny>
            {
                new Bunny 
                {
                    Name = "Leonid",
                    Age= 1,
                    FurType = FurType.NotFluffy
                },
                new Bunny
                {
                    Name = "Rasputin",
                    Age= 2,
                    FurType = FurType.ALittleFluffy
                },
                new Bunny
                {
                    Name = "Tiberii",
                    Age= 3,
                    FurType = FurType.ALittleFluffy,
                },
                new Bunny
                {
                    Name = "Neron",
                    Age= 1, 
                    FurType = FurType.ALittleFluffy,
                },
                new Bunny
                {
                    Name = "Klavdii",
                    Age= 3,
                    FurType = FurType.Fluffy,
                },
                new Bunny
                {
                    Name = "Vespasian",
                    Age= 3,
                    FurType = FurType.Fluffy
                },
                new Bunny
                {
                    Name = "Domician",
                    Age = 4,
                    FurType = FurType.FluffyToTheLimit
                },
                new Bunny
                {
                    Name = "Tit",
                    Age= 2,
                    FurType = FurType.FluffyToTheLimit
                }
            };

            return bunnies;
        }
    }
}