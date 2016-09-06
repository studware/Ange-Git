using Cooking;
using Cooking.CookingProducts;
using System;

namespace RefactorIfStatements
{
    class PotatoRefactored
    {
        public static void PrepareMeal()
        {
            var potato = GetPotato();
            var chef = new Chef();

            if (potato == null)
            {
                throw new ArgumentNullException();
            }

            if((!potato.IsRotten)&&(potato.IsPeeled))
            {
                var bowl = chef.Cook();
            }
            else
            {
                throw new NotImplementedException();
            }
        }

        private static Potato GetPotato()
        {
            throw new NotImplementedException();
        }
    }
}