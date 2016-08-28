using System.Collections.Generic;

namespace Bunnies.Utils
{
    public class IntroduceAllBunnies
    {
        internal static void IntroduceBunnies(List<Bunny> bunnies, ConsoleWriter consoleWriter)
        {
            foreach (var bunny in bunnies)
            {
                bunny.Introduce(consoleWriter);
            }
        }
    }
}
