using System;

namespace Cooking
{
    class CookingStart
    {
        static void Main(string[] args)
        {
            var chef = new Chef();
            var bowl = chef.Cook();
            Console.WriteLine("Ingredients prepared in the cooking bowl:\n{0}", bowl);
        }
    }
}
