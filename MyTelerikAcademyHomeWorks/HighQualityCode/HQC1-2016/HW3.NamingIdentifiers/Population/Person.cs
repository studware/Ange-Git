namespace Population
{
    public class Person
    {
        public Person()
        {
        }

        public Person(string name, Gender gender, int age)
            : this()
        {
            this.Name = name;
            this.Gender = gender;
            this.Age = age;
        }

        public string Name { get; set; }

        public Gender Gender { get; set; }

        public int Age { get; set; }

        public Person CreatePerson(int age)
        {
            var person = new Person();

            person.Age = age;
            int ageResidueMod2 = age % 2;

            person.Gender = (Gender)ageResidueMod2;
            person.Name = ((Name)ageResidueMod2).ToString();

            return person;
        }

        public override string ToString()
        {
            return string.Format("{0}\t({1}, {2})", this.Name, this.Gender, this.Age);
        }
    }
}