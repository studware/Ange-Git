namespace T2.HumanSociety
{
    using System;

    public class TestPerson
    {
        public static void MakePerson(int personAge)
        {
            Person newPerson = new Person();
            newPerson.Age = personAge;
            if (personAge % 2 == 0)
            {
                newPerson.PersonName = "Prokopy";
                newPerson.Gender = Gender.male;
            }
            else
            {
                newPerson.PersonName = "Karamfilka";
                newPerson.Gender = Gender.female;
            }

            Console.WriteLine(newPerson);
        }

        public static void Main()
        { 
            MakePerson(27);
            MakePerson(32);
        }
    }
}
