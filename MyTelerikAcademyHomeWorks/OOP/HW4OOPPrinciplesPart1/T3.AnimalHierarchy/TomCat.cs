namespace T3.AnimalHierarchy
{
using System;
using System.Collections.Generic;
using System.Linq;
using CreaturesClassLib;
    public class Tomcat: Kitten
    {
        public Tomcat(string name, int age) 
            :base(name, age, Gender.Male)
        {
            this.Species = Species.Cat;
        }

        public override string MakeSound()
        {
            return ("Miaou!");
        }
    }
}
