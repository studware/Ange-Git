namespace T3.AnimalHierarchy
{
using System;
using System.Collections.Generic;
using System.Linq;
using CreaturesClassLib;
    class Dog: Animal
    {
        public Dog(string name, int age, Gender sex) : base(name, age, sex)
        {
            this.Species = Species.Dog;
        }

        public override string MakeSound()
        {
            return ("Bauwow!");
        }
    }
}
