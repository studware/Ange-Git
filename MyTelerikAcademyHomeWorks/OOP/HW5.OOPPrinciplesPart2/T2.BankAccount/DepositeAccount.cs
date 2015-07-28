namespace T2.BankAccount
{
using System;

    public class DepositeAccount : BankAccount, IDrawable
    {
        public DepositeAccount(Customer customer, double interestRate, double balance = 0)
            : base(customer, interestRate, balance)
        {
        }
        
        public void WithdrawMoney(double money)
        {
            if (this.Balance > money)
            {
                this.Balance -= money;
            }
            else
            {
                Console.WriteLine("Not enough money! Please, feed your deposite account!");
            }
        }

        public override double CalculateInterest(int numberOfMonths)
        {
            if (this.Balance >= 1000)
            {
                return InterestRate * numberOfMonths;
            }
            return 0;
        }

    }
}
