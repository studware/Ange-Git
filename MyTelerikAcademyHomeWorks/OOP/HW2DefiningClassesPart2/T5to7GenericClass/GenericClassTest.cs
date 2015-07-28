//  Tasks 5 and 6

namespace T5and6GenericClass
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    class GenericClassTest
    {
        static void Main()
        {
            GenericList<int> genList = new GenericList<int>();
            Console.WriteLine("Add elements, double capacity when exceeded capacity:");
            genList.AddElement(8);
            genList.AddElement(2);
            Console.WriteLine("{0,-25}List capacity = {1}; Count = {2}", genList, genList.Capacity, genList.Count);
            genList.AddElement(1);
            genList.AddElement(5);
            Console.WriteLine("{0,-25}List capacity = {1}; Count = {2}", genList, genList.Capacity, genList.Count);
            genList.AddElement(9);
            Console.WriteLine("{0,-25}List capacity = {1}; Count = {2}", genList, genList.Capacity, genList.Count);
            Console.WriteLine("Insert element:");
            Console.WriteLine(genList);
            genList.InsertElement(4, 789);
            Console.WriteLine("{0,-25}List capacity = {1}; Count = {2}", genList, genList.Capacity, genList.Count);
            Console.WriteLine("Remove element:");
            genList.RemoveElement(3);
            Console.WriteLine("{0,-25}List capacity = {1}; Count = {2}", genList, genList.Capacity, genList.Count);

            Console.WriteLine("Find min and max elements:");
            Console.WriteLine("\nThe min element in genList is: {0}", genList.Min());
            Console.WriteLine("\nThe max element in genList is: {0}", genList.Max());

            Console.WriteLine("Clear the list:");
            genList.Clear();
            Console.WriteLine("Count = {0}", genList.Count);
            Console.WriteLine("\nThe genList is now cleared.");
        }
    }
}
