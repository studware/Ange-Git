# Abstract Factory
### Creational Design Pattern

## Обобщение
Abstract Factory Pattern-ът предоставя начин, по който да се енкапсулира създаването на сходни конкретни обекти, 
без да се конкретизират техните класове.
Клиентът създава конкретна имплементация на абстрактната фабрика и я използва през абстрактния интерфейс,
за да създава конкретни обекти. Той не се интересува какъв конкретен обект получава, тъй като използва само
интерфейса на продукта.

Този шаблон разделя създаването на обект от използването му - фабриката определя конкретния обект и го създава,
но връща само абстрактен показател към конкретния обект. Това изолира клиентския код от създаването на обекта, тъй 
като клиентът получава абстрактен обект от желания тип.

Abstract Factory Pattern-ът се използва при системи, които често се изменят. Предоставя лесен и гъвкъв механизъм
за замяна на конкретни групи от обекти.

## Клас диаграма:

![Factory method](http://www.codeproject.com/KB/architecture/430590/Factory_Method.jpg)

## Конкретна имплементация

##### Фабрика за производство на коли:
```
public interface ICarFactory
{
    Car CreateCar();
}

public abstract class Car
{
    public string Model { get; set; }
    public string Engine { get; set; }
    public string Transmission { get; set; }
    public int Doors { get; set; }
    public List<string> Accessories = new List<string>();
    
    public abstract void ShowInfo();
}

public class MercedesFactory:ICarFactory
{
    public Car CreateCar()
    {
        return new Mercedes("Some model", "Engine type", "Transmission type", 4);
    }
}

public class BMWFactory:ICarFactory
{
    public Car CreateCar()
    {
        return new BMW("Some model", "Engine type", "Transmission type", 4);
    }
}

public class Mercedes:Car
{
    public Mercedes(string model, string engine, string transmission, int doors)
    {
        Model = model;
        Engine = engine;
        Transmission = transmission;
        Doors = doors;
        Accessories.Add("Leather Look Seat Covers");
        Accessories.Add("Chequered Plate Racing Floor");
        Accessories.Add("Car Cover");
        Accessories.Add("Sun Shade");
    }

    public override void ShowInfo()
    {
        Console.WriteLine("Model: {0}", Model);
        Console.WriteLine("Engine: {0}", Engine);
        Console.WriteLine("Doors: {0}", Doors);
        Console.WriteLine("Transmission: {0}", Transmission);
        Console.WriteLine("Accessories:");
        foreach (var accessory in Accessories)
        {
            Console.WriteLine("\t{0}", accessory);
        }
    }
}

public class BMW:Car
{
    public BMW(string model, string engine, string transmission, string body, int doors)
    {
        Model = model;
        Engine = engine;
        Transmission = transmission;
        Doors = doors;
        Accessories.Add("Leather Look Seat Covers");
        Accessories.Add("Chequered Plate Racing Floor");
        Accessories.Add("4x 200 Watt Coaxial Speekers");
        Accessories.Add("500 Watt Bass Subwoofer");
    }

    public override void ShowInfo()
    {
        Console.WriteLine("Model: {0}", Model);
        Console.WriteLine("Engine: {0}", Engine);
        Console.WriteLine("Doors: {0}", Doors);
        Console.WriteLine("Transmission: {0}", Transmission);
        Console.WriteLine("Accessories:");
        foreach (var accessory in Accessories)
        {
            Console.WriteLine("\t{0}", accessory);
        }
    }
}
```