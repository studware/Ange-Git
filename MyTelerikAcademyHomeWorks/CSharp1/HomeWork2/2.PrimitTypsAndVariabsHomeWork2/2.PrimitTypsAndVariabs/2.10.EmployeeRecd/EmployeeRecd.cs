using System;
using System.Text;

class EmployeeRecd
{
    static void Main()
    {
        // This program creates the information for a single employee using appropriate data types and descriptive names.
        Console.OutputEncoding=Encoding.UTF8;
        string firstName="Иван";
        string familyName="Стоянов";
        byte age=27;
        char gender='m';
        string numberOfID="TE12789";
        uint emplNum=15696;
        Console.WriteLine("Name: {0} {1}", firstName, familyName);
        Console.WriteLine("ID Number: {0}\t Employee Number: {1}", numberOfID , emplNum );
        Console.WriteLine("Age: {0}\t\t\t Gender: {1}", age, gender);
    }
}

