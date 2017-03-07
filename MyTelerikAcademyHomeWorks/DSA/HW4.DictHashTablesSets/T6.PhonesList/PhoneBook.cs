using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Wintellect.PowerCollections;

namespace T6.PhonesList
{
    class PhoneBook
    {
        private MultiDictionary<string, string> phoneBook = new MultiDictionary<string, string>(true);

        public PhoneBook(string inputFile)
        {
            string[] input = File.ReadAllLines(@"..\..\phones.txt");

            foreach (var line in input)
            {
                string name = line.Split('|')[0].TrimEnd(' ');
                string town = line.Split('|')[1].TrimEnd(' ');
                string phone = line.Split('|')[2].TrimEnd(' ');
                this.phoneBook.AddMany(name, new string[] { town, phone });
            }
        }

        public void Find(string name)
        {
            if (this.phoneBook.Keys.Any(key => key.Contains(name)))
            {
                var entry = this.phoneBook.Keys.Where(key => key.Contains(name));

                foreach (var item in entry)
                {
                    Console.WriteLine("{0} - {1}", item, this.phoneBook[item].ToString());
                }

            }
            else
            {
                Console.WriteLine("No such item in the phone book!");
            }
        }

        public void Find(string name, string town)
        {
            bool thereIsSuchEntry = false;
            if (this.phoneBook.Keys.Any(key => key.Contains(name)))
            {
                var entry = this.phoneBook.Keys.Where(key => key.Contains(name));

                foreach (var item in entry)
                {
                    if (this.phoneBook[item].ToString().Contains(town))
                    {
                        Console.WriteLine("{0} - {1}", item, this.phoneBook[item].ToString());
                        thereIsSuchEntry = true;
                    }
                }
            }
            else
            {
                Console.WriteLine("No such item in the phone book!");
            }

            if (thereIsSuchEntry == false) // there could be the same name but not the same town
            {
                Console.WriteLine("No such item in the phone book!");
            }
        }
    }
}
