/*  Create a class Person with two fields – name and age. 
    Age can be left unspecified (may contain null value. 
    Override ToString() to display the information of a person and if age is not specified – to say so.
    Write a program to test this functionality. */

namespace T4.PersonWithNullableAge
{
using System;

    class PersonTest
    {
        static void Main()
        {
            Person person1 = new Person("Prokopi Prokopiev", 27);
            Person person2 = new Person("Karamphilka Karamphilova");

            Console.WriteLine(person1);
            Console.WriteLine(person2);
        }
    }
}
