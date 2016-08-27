namespace Cosmetics.Tests.Products.Mocks
{
    using Cosmetics.Contracts;
    using Cosmetics.Products;
    using System.Collections.Generic;
    internal class MockedCategory: Category
    {
        public MockedCategory(string name) : base(name)
        {
        }

        public IList<IProduct> Products
        {
            get
            {
                return base.products;
            }
        }
    }
}
