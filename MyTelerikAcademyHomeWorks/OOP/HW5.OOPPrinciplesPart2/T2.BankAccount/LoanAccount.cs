namespace T2.BankAccount
{
    public class LoanAccount : BankAccount
    {
        public LoanAccount(Customer customer, double interestRate, double balance = 0)
                    : base(customer, interestRate, balance)
        {

        }

        public override double CalculateInterest(int numberOfMonths)
        {
            if (this.Customer is Person && numberOfMonths > 3)
            {
                return (numberOfMonths - 3) * InterestRate;
            }

            if(this.Customer is Company && numberOfMonths > 2)
            {
                return (numberOfMonths - 2) * InterestRate;            
            }

            return 0;
        }
    }
}
