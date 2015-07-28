namespace T2.BankAccount
{
using System;

    public abstract class BankAccount : ICalculable
    {
        private Customer customer;
        private double interestRate;
        private double balance;

        public BankAccount(Customer customer, double interestRate, double balance=0)
        {
            this.Customer = customer;
            this.Balance = balance;
            this.InterestRate = interestRate;
        }

        public Customer Customer
        {
            get
            {
                return this.customer; 
            }
            protected set
            {
                this.customer = value;
            }
        }


        public double InterestRate //  monthly based
        {
            get
            {
                return interestRate;
            }

            set
            {
                if (value < 0)
                    throw new ArgumentNullException("The interest rate cannot be negative!");
                else
                {
                    interestRate = value;
                }
            }
        }
        
        public double Balance
        {
            get
            {
                return balance;
            }

            set
            {
                if (value < 0)
                    throw new ArgumentNullException("The balance cannot be negative!");

                else
                {
                    balance = value;
                }
            }
        }

        public virtual void DepositeMoney(double money)
        {
            if (money <= 0)
            {
                throw new ArgumentOutOfRangeException("Deposited money should be positive number!");
            }

            Balance += money;
        }

        public virtual double CalculateInterest(int numberOfMonths)
        {
            return InterestRate*numberOfMonths;
        }
    }
}
