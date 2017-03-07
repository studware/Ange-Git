using System;
using System.Text;

    class CompanyVisitCard
    {
        static void Main()
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.Write("Enter company name: ");
            string compName=Console.ReadLine();
            Console.Write("Enter company address: ");
            string compAddress=Console.ReadLine();
            Console.Write("Enter phone number: ");
            string compPhoneNum=Console.ReadLine();
            Console.Write("Enter fax number:");
            string compFaxNum=Console.ReadLine();
            Console.Write("Enter Web site: ");
            string webSite=Console.ReadLine();
            Console.Write("Enter manager first name: ");
            string manFirstName=Console.ReadLine();
            Console.Write("Enter manager last name: ");
            string manLastName=Console.ReadLine();
            Console.Write("Enter manager age: ");
            int manAge = int.Parse(Console.ReadLine());
            Console.Write("Enter manager phone: ");
            string ManPhone=Console.ReadLine();
            Console.WriteLine();
            Console.WriteLine("{0} Company", compName);
            Console.Write("Address: {0}  {1}", compAddress, Environment.NewLine);
            Console.WriteLine("Phone: {0} \t Fax: {1}{2}Web site: {3}",
                                compPhoneNum, compFaxNum, Environment.NewLine, webSite);
            Console.Write("Manager: {0} {1},\t\t age: {2}{3}", manFirstName, manLastName, manAge, Environment.NewLine);
            Console.WriteLine("Phone: {0}", ManPhone);
        }
    }
