namespace T2.BankAccount
{
using System;

    public abstract class Customer
    {
        private string name;

        public Customer(string name, string address)
        {
            this.Name = name;
            this.Address = Address;
        }

        public string Name
        {
            get { return this.name; }
            set 
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Name is mandatory.");
                }
                this.name = value; 
            }
        }

        public string Address { get; set; }
        
    }
}
