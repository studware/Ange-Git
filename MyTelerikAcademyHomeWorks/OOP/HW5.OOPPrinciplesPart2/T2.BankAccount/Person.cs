namespace T2.BankAccount
{
using System;

    public class Person : Customer
    {
        private ulong personID;

        public Person(string name, string address, ulong personID)
            :base(name, address)
        {
            this.PersonID = personID;
        }

        public ulong PersonID
        {
            get { return this.personID; }

            set
            {
                if (value.ToString().Length!=12)
                {
                    throw new ArgumentOutOfRangeException("Person ID must be 12-digits value!");   
                }

                this.personID = value; 
            }
        }        
    }
}
