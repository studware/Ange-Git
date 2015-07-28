/*  Create a hierarchy Dog, Frog, Cat, Kitten, Tomcat and define useful constructors and methods. 
 * Dogs, frogs and cats are Animals. All animals can produce sound (specified by the ISound interface). 
 * Kittens and tomcats are cats. All animals are described by age, name and sex. 
 * Kittens can be only female and tomcats can be only male. 
 * Each animal produces a specific sound.
 * Create arrays of different kinds of animals and calculate the average age of each kind of animal 
 * using a static method (you may use LINQ).  */

namespace T3.AnimalHierarchy
{
using System;
using System.Collections.Generic;
using System.Linq;
using CreaturesClassLib;
    class AnimalHierarchy
    {
        static void Main()
        {
//  Create array of animals
            Animal[] animals = new Animal[]
            {
                new Dog("Bella", 4, Gender.Female),
                new Kitten("Mimi", 3, Gender.Female),
                new Frog("Jabcho", 6, Gender.Male),
                new Tomcat("Pancho", 4),
                new Cat("Matza", 4),
                new Dog("Darina", 12, Gender.Female),
                new Tomcat("Nerro", 11),
                new Cat("Topsy", 7),
                new Dog("Buck", 7, Gender.Male),
                new Dog("Murdjo", 5, Gender.Male),
                new Dog("Sharo", 8, Gender.Male),
                new Dog("Rex", 4, Gender.Male),
                new Dog("Zitta", 2, Gender.Female),
                new Frog("Kekeritza", 8, Gender.Female),
                new Kitten("Fluffy",8, Gender.Female),
                new Tomcat("Prokopy", 2),
                new Cat("Britta", 4),
                new Tomcat("Pesho", 5),
                new Cat("Street Excellency", 2),
            };

            Console.WriteLine("Introduce animals:\n");
            IntroduceAnimal(animals);

            Console.WriteLine(Animal.AverageAge(animals));

        }

        private static void IntroduceAnimal(Animal[] animals)
        {
            foreach (var animal in animals)
            {
                Console.WriteLine(animal);
            }
            Console.WriteLine();
        }
    }
}
