namespace T2.BankAccount
{
    public class MortgageAccount : BankAccount
    {
        public MortgageAccount(Customer customer, double interestRate, double balance = 0)
                    : base(customer, interestRate, balance)
        {         
        }

        public override double CalculateInterest(int numberOfMonths)
        {
            if (this.Customer is Person && numberOfMonths > 6)
            {
                return (numberOfMonths - 6) * InterestRate;
            }

            if (this.Customer is Company)
            {
                return ((numberOfMonths - 12)>0)? (numberOfMonths-6.0)*InterestRate:((numberOfMonths *InterestRate)/2.0);
            }

            return 0;
        }
    }
}
