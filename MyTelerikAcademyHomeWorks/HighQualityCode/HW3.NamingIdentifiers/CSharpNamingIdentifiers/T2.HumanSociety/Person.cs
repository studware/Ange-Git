namespace T2.HumanSociety
{
    using System;

    public class Person
    {
        private Gender gender;
        private string personName;
        private int age;

        public Gender Gender { get; set; }

        public string PersonName { get; set; }

        public int Age { get; set; }

        public override string ToString()
        {
            return string.Format("Person Name: {0}\nGender: {1}\nAge: {2}\n", this.PersonName, this.Gender, this.Age);
        }
    }
}
