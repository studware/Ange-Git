using System;

    class StringObjString
{
    static void Main()
    {
        string hello="Hello";
        string world="World";
        object greetingObject = hello + " " + world + "!";
        Console.WriteLine("The object \"greetingObject\" as a result of concatenating two strings:");
        Console.WriteLine("{0}", greetingObject);
        hello = greetingObject.ToString();
        Console.WriteLine("The string that represents the object \"greetingObject\":");
        Console.WriteLine("{0}", hello);
    }
}

