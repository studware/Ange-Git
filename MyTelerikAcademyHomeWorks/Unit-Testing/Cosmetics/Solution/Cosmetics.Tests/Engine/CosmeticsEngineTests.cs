namespace Cosmetics.Tests
{
    using Cosmetics.Common;
    using Cosmetics.Contracts;
    using Cosmetics.Tests.Engine.Mocks;
    using Moq;
    using NUnit.Framework;
    using System.Collections.Generic;

    [TestFixture]
    public class CosmeticsEngineTests
    {
        [Test]
        public void Start_WhenInputFormatIsValidCreateCategoryCommand_ShouldAddNewCategoryToCategoriesList()
        {
            //Arrange
            var categoryName = "ForFemale";

            var mockedFactory = new Mock<ICosmeticsFactory>();
            var mockedShoppingCart = new Mock<IShoppingCart>();
            var mockedCommandParser = new Mock<ICommandParser>();

            var mockedCommand = new Mock<ICommand>();
            var mockedCategory = new Mock<ICategory>();

            mockedCommand.SetupGet(x => x.Name).Returns("CreateCategory");
            mockedCommand.SetupGet(x => x.Parameters).Returns(new List<string>() { categoryName });

            mockedCommandParser.Setup(p => p.ReadCommands()).Returns(() => new List<ICommand>() { mockedCommand.Object });

            mockedCategory.SetupGet(x => x.Name).Returns(categoryName);

            mockedFactory.Setup(x => x.CreateCategory(categoryName)).Returns(mockedCategory.Object);

            var engine = new MockedCosmeticsEngine(mockedFactory.Object, mockedShoppingCart.Object, mockedCommandParser.Object);

            //Act
            engine.Start();

            //Assert
            Assert.IsTrue(engine.Categories.ContainsKey(categoryName));
            Assert.AreSame(mockedCategory.Object, engine.Categories[categoryName]);
        }

        [Test]
        public void Start_WhenInputFormatIsValidAddToCategoryCommand_ShouldAddProductToTheCategory()
        {
            //Arrange
            var categoryName = "ForFemale";
            var productName = "Fa Shampoo";

            var mockedFactory = new Mock<ICosmeticsFactory>();
            var mockedShoppingCart = new Mock<IShoppingCart>();
            var mockedCommandParser = new Mock<ICommandParser>();

            var mockedCommand = new Mock<ICommand>();
            var mockedCategory = new Mock<ICategory>();
            var mockedShampoo = new Mock<IShampoo>();

            mockedCommand.SetupGet(x => x.Name).Returns("AddToCategory");
            mockedCommand.SetupGet(x => x.Parameters).Returns(new List<string>() { categoryName, productName });

            mockedCommandParser.Setup(p => p.ReadCommands()).Returns(() => new List<ICommand>() { mockedCommand.Object });

            var engine = new MockedCosmeticsEngine(mockedFactory.Object, mockedShoppingCart.Object, mockedCommandParser.Object);

            engine.Categories.Add(categoryName, mockedCategory.Object);
            engine.Products.Add(productName, mockedShampoo.Object);

            //Act
            engine.Start();

            //Assert
            mockedCategory.Verify(x => x.AddProduct(mockedShampoo.Object), Times.Once);
        }

        [Test]
        public void Start_WhenInputFormatIsValidRemoveFromCategoryCommand_ShouldRemoveProductFromTheCategory()
        {
            //Arrange
            var categoryName = "ForFemale";
            var productName = "Fa Shampoo";

            var mockedFactory = new Mock<ICosmeticsFactory>();
            var mockedShoppingCart = new Mock<IShoppingCart>();
            var mockedCommandParser = new Mock<ICommandParser>();

            var mockedCommand = new Mock<ICommand>();
            var mockedCategory = new Mock<ICategory>();
            var mockedShampoo = new Mock<IShampoo>();

            mockedCommand.SetupGet(x => x.Name).Returns("RemoveFromCategory");
            mockedCommand.SetupGet(x => x.Parameters).Returns(new List<string>() { categoryName, productName });

            mockedCommandParser.Setup(p => p.ReadCommands()).Returns(() => new List<ICommand>() { mockedCommand.Object });

            var engine = new MockedCosmeticsEngine(mockedFactory.Object, mockedShoppingCart.Object, mockedCommandParser.Object);

            engine.Categories.Add(categoryName, mockedCategory.Object);
            engine.Products.Add(productName, mockedShampoo.Object);

            //Act
            engine.Start();

            //Assert
            mockedCategory.Verify(x => x.RemoveProduct(mockedShampoo.Object), Times.Once);
        }

        [Test]
        public void Start_WhenInputFormatIsValidShowCategoryCommand_ShouldCallPrintOfThisCategory()
        {
            //Arrange
            var categoryName = "ForFemale";
            var productName = "Fa Shampoo";

            var mockedFactory = new Mock<ICosmeticsFactory>();
            var mockedShoppingCart = new Mock<IShoppingCart>();
            var mockedCommandParser = new Mock<ICommandParser>();

            var mockedCommand = new Mock<ICommand>();
            var mockedCategory = new Mock<ICategory>();
            var mockedShampoo = new Mock<IShampoo>();

            mockedCommand.SetupGet(x => x.Name).Returns("ShowCategory");
            mockedCommand.SetupGet(x => x.Parameters).Returns(new List<string>() { categoryName });

            mockedCommandParser.Setup(p => p.ReadCommands()).Returns(() => new List<ICommand>() { mockedCommand.Object });

            var engine = new MockedCosmeticsEngine(mockedFactory.Object, mockedShoppingCart.Object, mockedCommandParser.Object);

            engine.Categories.Add(categoryName, mockedCategory.Object);
            engine.Products.Add(productName, mockedShampoo.Object);

            //Act
            engine.Start();

            //Assert
            mockedCategory.Verify(x => x.Print(), Times.Once);
        }

        [Test]
        public void Start_WhenInputFormatIsValidCreateShampooCommand_ShouldAddShampooToProducts()
        {
            //Arrange
            var shampooName = "Rose";
            var brandName = "Lavera";

            var mockedFactory = new Mock<ICosmeticsFactory>();
            var mockedShoppingCart = new Mock<IShoppingCart>();
            var mockedCommandParser = new Mock<ICommandParser>();

            var mockedCommand = new Mock<ICommand>();
            var mockedShampoo = new Mock<IShampoo>();

            mockedCommand.SetupGet(x => x.Name).Returns("CreateShampoo");
            mockedCommand.SetupGet(x => x.Parameters).Returns(new List<string>() { shampooName, brandName, "5.50", "women", "250", "EveryDay"});

            mockedCommandParser.Setup(p => p.ReadCommands()).Returns(() => new List<ICommand>() { mockedCommand.Object });

            mockedFactory.Setup(x=>x.CreateShampoo
                (shampooName, brandName, 5.50M, GenderType.Women, 250, UsageType.EveryDay )).Returns(mockedShampoo.Object);

            var engine = new MockedCosmeticsEngine(mockedFactory.Object, mockedShoppingCart.Object, mockedCommandParser.Object);

            engine.Products.Add(shampooName, mockedShampoo.Object);

            //Act
            engine.Start();

            //Assert
            Assert.IsTrue(engine.Products.ContainsKey(shampooName));
            Assert.AreSame(mockedShampoo.Object, engine.Products[shampooName]);
        }
        
        [Test]
        public void Start_WhenInputFormatIsValidCreateToothpasteCommand_ShouldAddToothpasteToProducts()
        {
            //Arrange
            var toothpasteName = "Maraslavin";
            var brandName = "Aroma";

            var mockedFactory = new Mock<ICosmeticsFactory>();
            var mockedShoppingCart = new Mock<IShoppingCart>();
            var mockedCommandParser = new Mock<ICommandParser>();

            var mockedCommand = new Mock<ICommand>();
            var mockedToothpaste = new Mock<IToothpaste>();

            mockedCommand.SetupGet(x => x.Name).Returns("CreateToothpaste");
            mockedCommand.SetupGet(x => x.Parameters).Returns(new List<string>() { toothpasteName, brandName, "2.58", "women", "sealye, fluoride" });

            mockedCommandParser.Setup(p => p.ReadCommands()).Returns(() => new List<ICommand>() { mockedCommand.Object });

            mockedFactory.Setup(x => x.CreateToothpaste
                (toothpasteName, brandName, 2.58M, GenderType.Women, 
                new List<string>() {"sealye", "fluoride"})).Returns(mockedToothpaste.Object);

            var engine = new MockedCosmeticsEngine(mockedFactory.Object, mockedShoppingCart.Object, mockedCommandParser.Object);

            engine.Products.Add(toothpasteName, mockedToothpaste.Object);

            //Act
            engine.Start();

            //Assert
            Assert.IsTrue(engine.Products.ContainsKey(toothpasteName));
            Assert.AreSame(mockedToothpaste.Object, engine.Products[toothpasteName]);
        }

        [Test]
        public void Start_WhenInputFormatIsValidAddToShoppingCartCommand_ShouldAddProductToTheShoppingCart()
        {
            //Arrange
            var productName = "Fa Shampoo";

            var mockedFactory = new Mock<ICosmeticsFactory>();
            var mockedShoppingCart = new Mock<IShoppingCart>();
            var mockedCommandParser = new Mock<ICommandParser>();

            var mockedCommand = new Mock<ICommand>();
            var mockedProduct = new Mock<IProduct>();

            mockedCommand.SetupGet(x => x.Name).Returns("AddToShoppingCart");
            mockedCommand.SetupGet(x => x.Parameters).Returns(new List<string>() { productName });

            mockedCommandParser.Setup(p => p.ReadCommands()).Returns(() => new List<ICommand>() { mockedCommand.Object });

            var engine = new MockedCosmeticsEngine(mockedFactory.Object, mockedShoppingCart.Object, mockedCommandParser.Object);

            engine.Products.Add(productName, mockedProduct.Object);
            
            //Act
            engine.Start();

            //Assert
            mockedShoppingCart.Verify(x => x.AddProduct(mockedProduct.Object), Times.Once);
        }

        [Test]
        public void Start_WhenInputFormatIsValidRemoveFromShoppingCartCommand_ShouldRemoveProductFromTheShoppingCart()
        {
            //Arrange
            var productName = "Fa Shampoo";

            var mockedFactory = new Mock<ICosmeticsFactory>();
            var mockedShoppingCart = new Mock<IShoppingCart>();
            var mockedCommandParser = new Mock<ICommandParser>();

            var mockedCommand = new Mock<ICommand>();
            var mockedProduct = new Mock<IProduct>();

            mockedCommand.SetupGet(x => x.Name).Returns("RemoveFromShoppingCart");
            mockedCommand.SetupGet(x => x.Parameters).Returns(new List<string>() { productName });

            mockedCommandParser.Setup(p => p.ReadCommands()).Returns(() => new List<ICommand>() { mockedCommand.Object });

            mockedShoppingCart.Setup(x => x.ContainsProduct(mockedProduct.Object)).Returns(true);

            var engine = new MockedCosmeticsEngine(mockedFactory.Object, mockedShoppingCart.Object, mockedCommandParser.Object);

            engine.Products.Add(productName, mockedProduct.Object);

            //Act
            engine.Start();

            //Assert
            mockedShoppingCart.Verify(x => x.RemoveProduct(mockedProduct.Object), Times.Once);
        }
    }
}
