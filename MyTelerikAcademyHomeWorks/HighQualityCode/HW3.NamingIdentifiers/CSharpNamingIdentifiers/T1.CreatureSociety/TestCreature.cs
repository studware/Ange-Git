namespace T1.CreatureSociety
{
    using System;

    public class TestCreature
    {
        public static void Main()
        {
            const int MAX_COUNT = 6;
            Creature creature = new Creature();

            for (int i = 0; i < MAX_COUNT; i++)
            {
                creature.CheckIsCreature(true);
                creature.CheckIsCreature(false);                
            }
        }
    }
}
