using System;

class AgeIn10Years
{
    static void Main()
    {
        DateTime birthDate = new DateTime(); // your birth date
        DateTime dateInTenYears = DateTime.Now.AddYears(10);    // the date 10 years after now

        Console.Write("Please, enter your birth date: ");  // enter your birth date from the console,
        // then check if valid (assume the eldest person on Earth was 132 years old:)

        if (DateTime.TryParse(Console.ReadLine(), out birthDate) && birthDate.Year < DateTime.Now.Year && birthDate.Year >= 1880)
        {
            // if data input was correct, then compute your age in 10 years and write it at the console:            
            int ageInTenYears = dateInTenYears.Year - birthDate.Year;
            Console.WriteLine("Ten years later you will be " + ageInTenYears); //
        }
        else
        {
            // wrong input - illegal date, or birth date >= now, or you seem to be an ancient person :)
            Console.WriteLine("Sorry, wrong input! Try again!");
        }
    }
}



