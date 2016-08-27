namespace Cosmetics.Tests.Products.Mocks
{
    using Cosmetics.Contracts;
    using Cosmetics.Products;
    using System.Collections.Generic;
    internal class MockedShoppingCart: ShoppingCart
    {
        public IList<IProduct> Products
        {
            get
            {
                return base.products;
            }
        }
    }
}
