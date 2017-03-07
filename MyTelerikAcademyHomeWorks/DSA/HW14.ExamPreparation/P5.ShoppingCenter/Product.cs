using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Wintellect.PowerCollections;
using System.Threading;
using System.Globalization;
using System.IO;

/// <summary>
/// Product class (name, price, producer)
/// </summary>
public class Product : IComparable<Product>
{
    private string name;
    private decimal price;
    private string producer;

    public Product(string name, string price, string producer)
    {
        this.name = name;
        this.price = decimal.Parse(price);
        this.producer = producer;
    }

    public string Name
    {
        get
        {
            return name;
        }
        set
        {
            name = value;
        }
    }

    public decimal Price
    {
        get
        {
            return price;
        }
        set
        {
            price = value;
        }
    }

    public string Producer
    {
        get
        {
            return producer;
        }
        set
        {
            producer = value;
        }
    }

    public string GetNameAndProducerKey()
    {
        string key = name + ";" + producer;
        return key;
    }

    public int CompareTo(Product other)
    {
        int resultOfCompare = name.CompareTo(other.name);
        if (resultOfCompare == 0)
        {
            resultOfCompare = producer.CompareTo(other.producer);
        }
        if (resultOfCompare == 0)
        {
            resultOfCompare = price.CompareTo(other.price);
        }
        return resultOfCompare;
    }

    public override string ToString()
    {
        string toString = "{" + name + ";" + producer + ";" + price.ToString("0.00") + "}";
        return toString;
    }

}