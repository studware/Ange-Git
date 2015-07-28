namespace T3.AnimalHierarchy
{
using System;
using System.Collections.Generic;
using System.Linq;
using CreaturesClassLib;
    class Frog: Animal
    {
        public Frog(string name, int age, Gender sex) : base(name, age, sex)
        {
            this.Species = Species.Frog;
        }

        public override string MakeSound()
        {
            return ("Kwak-Kwak!");
        }
    }
}
