using System.Collections.Generic;
using System.Text;
using Cooking.CookingProducts;

namespace Cooking
{
    public class Bowl
    {
        public Bowl()
        {
            this.Ingredients = new List<Vegetable>();
        }

        public ICollection<Vegetable> Ingredients { get; set; }

        public void Add(Vegetable vegetable)
        {
            this.Ingredients.Add(vegetable);
        }

        public void Cook()
        {
            foreach (var ingredient in this.Ingredients)
            {
                ingredient.Cook();
            }
        }

        public override string ToString()
        {
            return string.Join("; ", this.Ingredients);
        }
    }
}