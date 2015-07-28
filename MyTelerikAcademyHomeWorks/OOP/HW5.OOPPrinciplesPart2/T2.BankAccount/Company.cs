namespace T2.BankAccount
{
using System;

    public class Company : Customer
    {
        private ulong companyID;
        
        public Company(string name, string address, ulong companyID)
            :base(name, address)
        {
            this.CompanyID = companyID;
        }

        public ulong CompanyID
        {
            get { return this.companyID; }

            set
            {
                if (value.ToString().Length != 10)
                {
                    throw new ArgumentOutOfRangeException("Company ID must be 10-digits value!");
                }

                this.companyID = value;
            }
        }        
    }
}
