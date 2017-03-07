using System;
using System.Text;

    class BankAccount
    {
        static void Main()
        {
            // This program creates the bank account for a single client using appropriate data types and descriptive names.
            Console.OutputEncoding = Encoding.UTF8;
            string firstName = "Елена";
            string middleName = "Петрова";
            string familyName = "Маринова";
            decimal amountAvail = 845239.63m;
            char currency = '$';
            string bankName = "UniCredit BulBank";
            string iban = "BG80 UNCR 9545 1020 3456 78";
            string bic= "UNCR BGSF";
            string creditCard1 = "5555-5555-5555-5555";
            string creditCard2 = "6666-6666-5555-1214";
            string creditCard3 = "7777-7777-5555-6889";
            Console.WriteLine("BankName: {0}", bankName);
            Console.WriteLine("Name: {0} {1} {2}", firstName, middleName, familyName);
            Console.WriteLine("IBAN: {0}\t\t BIC: {1}", iban, bic);
            Console.WriteLine("Credit Cards: ");
            Console.WriteLine("{0} \t {1} \t {2}", creditCard1, creditCard2, creditCard3); 
            Console.WriteLine("Available Amount: ${0}", amountAvail);
        }
    }

