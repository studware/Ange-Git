using System;

namespace Population
{
    public class Population
    {
        public static void Main()
        {
            var female = new Person();
            female = female.CreatePerson(21);
            Console.WriteLine(female);

            var male = new Person();
            male = male.CreatePerson(24);
            Console.WriteLine(male);
        }
    }
}