//  Dogs, frogs and cats are Animals. All animals can produce sound (specified by the ISound interface).
//  All animals are described by age, name and sex. Dogs, frogs and cats are Animals.

namespace CreaturesClassLib
{
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

    public abstract class Animal: ISound
    {
        public Species Species {get; set;}
        public string Name { get; set; }
        public int Age { get; set; }
        public Gender Sex { get; set; }

        protected Animal(string name, int age, Gender sex)
        {
            this.Name = name;
            this.Age = age;
            this.Sex = sex;
            this.Species = Species.Uknown;
        }

        public virtual string MakeSound()
        {
            return "M-m-m-m!";
        }

        public override string ToString()
        {
            return String.Format("{0} I'm a {1} {2} - my name is {3} and I am {4} years old",
            this.MakeSound(), this.Sex, this.Species, this.Name, this.Age);
        }
        public static StringBuilder AverageAge(IEnumerable<Animal> animals)
        {
            var avgAgeBySpecies = from an in animals
                            group an.Age by an.Species into g
                            select new { SpeciesName = g.Key, AnimalAge = g};

            StringBuilder sb = new StringBuilder();

            foreach (var item in avgAgeBySpecies)
	        {
                var species=item.SpeciesName;
                var avg=item.AnimalAge.Average();
                sb.AppendFormat("Average Age of {0}s: {1} years.\n", item.SpeciesName, Math.Round(avg));
	        }
            return sb;
        }
    }
}
