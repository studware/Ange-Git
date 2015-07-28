namespace T3.AnimalHierarchy
{
using System;
using System.Collections.Generic;
using System.Linq;
using CreaturesClassLib;
    public class Cat: Kitten
    {
        public Cat(string name, int age) 
            :base(name, age, Gender.Female)
        {
            this.Species = Species.Cat;
        }

        public override string MakeSound()
        {
            return ("Miaou!");
        }
    }
}
