namespace T3.AnimalHierarchy
{
using System;
using CreaturesClassLib;
    public class Kitten: Animal
    {
        public Kitten(string name, int age, Gender sex) : base(name, age, sex)
        {
            this.Species = Species.Cat;
        }
    }
}
