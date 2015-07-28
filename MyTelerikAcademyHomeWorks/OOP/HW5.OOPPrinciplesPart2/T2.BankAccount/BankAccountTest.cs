/*  A bank holds different types of accounts for its customers: deposit accounts, loan accounts and mortgage accounts. 
    Customers could be individuals or companies.
    All accounts have customer, balance and interest rate (monthly based).
        Deposit accounts are allowed to deposit and withdraw money.
        Loan and mortgage accounts can only deposit money.
    All accounts can calculate their interest amount for a given period (in months).
    In the common case its is calculated as follows: number_of_months * interest_rate.
    Loan accounts have no interest for the first 3 months if are held by individuals and for the first 2 months if are held by a company.
    Deposit accounts have no interest if their balance is positive and less than 1000.
    Mortgage accounts have ½ interest for the first 12 months for companies and no interest for the first 6 months for individuals.
    Your task is to write a program to model the bank system by classes and interfaces.
    You should identify the classes, interfaces, base classes and abstract actions 
    and implement the calculation of the interest functionality through overridden methods. */

namespace T2.BankAccount
{
using System;
using System.Collections.Generic;

    class BankAccountTest
    {
        static void Main()
        {
            List<Customer> customers = new List<Customer>()
            {
                new Company("\"NEK PLC.\"","Sofia \"Vesletz\" 2 ", 3248565464),
                new Person("Elka Petrova", "Sofia \"Oboriste\" 87", 454545465567),
                new Company("\"Chemko\"", "Sofia \"Tzar Boris III\" 254", 1234556789),
                new Person("Peter Petrov","Sofia \"Dondukov\" 24 ",987549876123),
                new Person("Jordan Takov","Sopot \"Christo Botev\" 82", 876554446678),
                new Company("\"Palm Beach\"","Lake Worth \"Glarous Hotel\"", 7654332243),
                new Company("\"Sofijska Voda\"","Sofia \"Al. Malinov\" 64", 6534285645),
                new Person("John Pen","London \"Time Square\" 125",564332324893),
                new Company("\"Speedy\"","Sofia \"Tzar Boris III\" 48", 7342634354),
                new Person("Tom Buttler","Manchester \"Nelson\" 59", 765432451678),
                new Company("\"Apis OOD\"","Sofia \"Polygona\" 63", 7543924578),
            };

            List<BankAccount> accounts = new List<BankAccount>()
            {
                new DepositeAccount(customers[1],0.54,2000),
                new LoanAccount(customers[5],0.75,500),
                new LoanAccount(customers[8],0.67,20000),
                new DepositeAccount(customers[7],0.32,467),
                new MortgageAccount(customers[4],0.68,30000),
                new DepositeAccount(customers[0],0.32,25000),
                new DepositeAccount(customers[9],0.34,3400),
                new LoanAccount(customers[7],0.79,3000),
                new DepositeAccount(customers[3],0.25,1200),
                new MortgageAccount(customers[2],0.82,6800),
                new DepositeAccount(customers[5],0.34,1000),
            };

            Random rand = new Random();
            Console.WriteLine("Customer\tBalance\t    Interest  Accum.Int  Months\tAccount Type\n");
            foreach (var elem in accounts)
            {
                int months = rand.Next(1, 12);
                Console.WriteLine("{0,-12}{1,10:F2} BGN\t{2}\t{3:F2}\t  {4,2}\t{5}",
                    elem.Customer.Name, elem.Balance, elem.InterestRate, elem.CalculateInterest(months), months, elem.GetType().ToString().Substring(15));
            }

            Person aConsumer = new Person("Sophia Loren", "Sofia \"Kn. Maria Louiza\" 25", 489544554567);
            DepositeAccount account = new DepositeAccount(aConsumer, 0.68, 2700);
            Console.WriteLine("\n{0}, balance: {1}", account.Customer.Name, account.Balance);

            Console.WriteLine("After 700 BGN withdrawn:");
            account.WithdrawMoney(700);
            Console.WriteLine("{0}, balance: {1}", account.Customer.Name, account.Balance);
            
            Console.WriteLine("\nAfter attempt to withdraw 2700 BGN:");
            account.WithdrawMoney(2700);

            Console.WriteLine("\nAfter deposite of 2000 BGN");
            account.DepositeMoney(2000);
            Console.WriteLine("{0}, balance: {1}", account.Customer.Name, account.Balance);
        }
    }
}
