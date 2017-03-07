using System;

class WhatGender
{
    static void Main()
    {
        bool isFemale=true;
        string gender;
        Console.Write("Please, enter your gender (female - f, or male - m : )");

        if ((gender = Console.ReadLine()) == "m")
        {
            isFemale = false;
        }
        
        if (!(gender=="m"||gender=="f"))
        {
            Console.WriteLine("Illegal Input! Try again!");
        }
        else
        {
            Console.WriteLine("Congratulations! You are a"+(isFemale?" female!":" male!"));
        }
    } 
}

