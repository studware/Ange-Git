using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Wintellect.PowerCollections;
using System.Threading;
using System.Globalization;
using System.IO;

/// <summary>
/// The shopping center engine: processes commands for products data manipulation and output
/// </summary>
public class ShoppingCenter
{
    private const string PRODUCT_ADDED = "Product added";
    private const string X_PRODUCTS_DELETED = " products deleted";
    private const string NO_PRODUCTS_FOUND = "No products found";
    private const string INCORRECT_COMMAND = "Incorrect command";

    private readonly MultiDictionary<string, Product> productsByName;
    private readonly MultiDictionary<string, Product> nameAndProducer;
    private readonly OrderedMultiDictionary<decimal, Product> productsByPrice;
    private readonly MultiDictionary<string, Product> productsByProducer;

    /// <summary>
    /// These are the data structures to accept results from different queries efficiently regarding memory and time
    /// </summary>
    public ShoppingCenter()
    {
        productsByName = new MultiDictionary<string, Product>(true);
        nameAndProducer = new MultiDictionary<string, Product>(true);
        productsByPrice = new OrderedMultiDictionary<decimal, Product>(true);
        productsByProducer = new MultiDictionary<string, Product>(true);
    }

    /// <summary>
    /// Adds a product to the data base
    /// </summary>
    /// <param name="name">Product name</param>
    /// <param name="price">Product price</param>
    /// <param name="producer">Product manufacturer</param>
    /// <returns>message</returns>
    private string AddProduct(string name, string price, string producer)
    {
        Product product = new Product(name, price, producer);
        productsByName.Add(name, product);
        string nameAndProducerKey = product.GetNameAndProducerKey();
        nameAndProducer.Add(nameAndProducerKey, product);
        productsByPrice.Add(product.Price, product);
        productsByProducer.Add(producer, product);
        return PRODUCT_ADDED;
    }

    /// <summary>
    /// Deletes products with given name and producer
    /// </summary>
    /// <param name="name">Product Name</param>
    /// <param name="producer">producer Name</param>
    /// <returns>count message</returns>
    private string DeleteProducts(string name, string producer)
    {
        string nameAndProducerKey = name + ";" + producer;
        if (!nameAndProducer.ContainsKey(nameAndProducerKey))
        {
            return NO_PRODUCTS_FOUND;
        }
        else
        {
            var productsToBeRemoved = nameAndProducer[nameAndProducerKey];
            foreach (var product in productsToBeRemoved)
            {
                productsByName.Remove(name, product);
                productsByProducer.Remove(producer, product);
                productsByPrice.Remove(product.Price, product);
            }
            int countOfRemovedProducts = nameAndProducer[nameAndProducerKey].Count;
            nameAndProducer.Remove(nameAndProducerKey);
            string countMessage = countOfRemovedProducts + X_PRODUCTS_DELETED;
            return countMessage;
        }
    }

    /// <summary>
    /// Deletes products by producer
    /// </summary>
    /// <param name="producer">Producer name</param>
    /// <returns>count message</returns>
    private string DeleteProducts(string producer)
    {
        if (!productsByProducer.ContainsKey(producer))
        {
            return NO_PRODUCTS_FOUND;
        }
        else
        {
            var productsToBeRemoved = productsByProducer[producer];
            foreach (var product in productsToBeRemoved)
            {
                productsByName.Remove(product.Name, product);
                string nameAndProducerKey = product.GetNameAndProducerKey();
                nameAndProducer.Remove(nameAndProducerKey, product);
                productsByPrice.Remove(product.Price, product);
            }
            int countOfRemovedProducts = productsByProducer[producer].Count;
            productsByProducer.Remove(producer);
            string countMessage = countOfRemovedProducts + X_PRODUCTS_DELETED;
            return countMessage;
        }
    }

    /// <summary>
    /// Finds products by name
    /// </summary>
    /// <param name="name">Product name</param>
    /// <returns>Count of products found</returns>
    private string FindProductsByName(string name)
    {
        if (!productsByName.ContainsKey(name))
        {
            return NO_PRODUCTS_FOUND;
        }
        else
        {
            var productsFound = productsByName[name];
            string formattedProducts = FormatProductForPrint(productsFound);
            return formattedProducts;
        }
    }

    /// <summary>
    /// Finds products by price range
    /// </summary>
    /// <param name="from">From price</param>
    /// <param name="to">To price</param>
    /// <returns>Count of products found</returns>
    private string FindProductsByPriceRange(string from, string to)
    {
        decimal rangeStart = decimal.Parse(from);
        decimal rangeEnd = decimal.Parse(to);
        var productsFound = productsByPrice.Range(rangeStart, true, rangeEnd, true).Values;
        if (productsFound.Count == 0)
        {
            return NO_PRODUCTS_FOUND;
        }
        else
        {
            string formattedProducts = FormatProductForPrint(productsFound);
            return formattedProducts;
        }
    }

    /// <summary>
    /// Finds products by producer
    /// </summary>
    /// <param name="producer">Producer</param>
    /// <returns>Count of products found</returns>
    private string FindProductsByProducer(string producer)
    {
        if (!productsByProducer.ContainsKey(producer))
        {
            return NO_PRODUCTS_FOUND;
        }
        else
        {
            var productsFound = productsByProducer[producer];
            string formattedProducts = FormatProductForPrint(productsFound);
            return formattedProducts;
        }
    }

    /// <summary>
    /// Formats Product for print using String Builder
    /// </summary>
    /// <param name="products">Collection of products to print</param>
    /// <returns>Formatted products in a string</returns>
    private string FormatProductForPrint(ICollection<Product> products)
    {
        List<Product> sortedProducts = new List<Product>(products);
        sortedProducts.Sort();
        StringBuilder builder = new StringBuilder();
        foreach (var product in sortedProducts)
        {
            builder.AppendLine(product.ToString());
        }
        string formattedProducts = builder.ToString().TrimEnd();
        return formattedProducts;
    }

    /// <summary>
    /// Processes commands for manipulation of the shopping center data base
    /// </summary>
    /// <param name="command">string with command</param>
    /// <returns>Command result</returns>
    public string ProcessCommand(string command)
    {
        int indexOfFirstSpace = command.IndexOf(' ');
        string method = command.Substring(0, indexOfFirstSpace);
        string parameterValues = command.Substring(indexOfFirstSpace + 1);
        string[] parameters = parameterValues.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
        string commandResult;
        switch (method)
        {
            case "AddProduct":
                {
                    commandResult = AddProduct(parameters[0], parameters[1], parameters[2]);
                    break;
                }
            case "DeleteProducts":
                {
                    if (parameters.Length == 1)
                    {
                        commandResult = DeleteProducts(parameters[0]);
                    }
                    else
                    {
                        commandResult = DeleteProducts(parameters[0], parameters[1]);
                    }
                    break;
                }
            case "FindProductsByName":
                {
                    commandResult = FindProductsByName(parameters[0]);
                    break;
                }

            case "FindProductsByPriceRange":
                {
                    commandResult = FindProductsByPriceRange(parameters[0], parameters[1]);
                    break;
                }
            case "FindProductsByProducer":
                {
                    commandResult = FindProductsByProducer(parameters[0]);
                    break;
                }
            default:
                {
                    commandResult = INCORRECT_COMMAND;
                    break;
                }
        }
        return commandResult;
    }
}
