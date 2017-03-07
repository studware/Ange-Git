using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using Wintellect.PowerCollections;

namespace T6.PhonesList
{
    /*  A text file phones.txt holds information about people, their town and phone number (duplicates can occur).
     * Write a program to read the phones file and execute a sequence of commands given in the file commands.txt:
     * find(name) – display all matching records by given name (first, middle, last or nickname)
     * find(name, town) – display all matching records by given name and town */

    class PhonesListMain
    {
        static void Main()
        {
            Console.WriteLine("Phone Book MultiDictionary (Task 6)");
            Console.WriteLine("\nThe files phones.txt and commands.txt in this project contain the test entries.\n");
            Console.WriteLine("The results are:\n");

            PhoneBook phoneBook = new PhoneBook(@"..\..\phones.txt"); // the input phonebook file
            List<string> commands = GetCommands();

            ExecuteCommands(commands, phoneBook);

            Console.WriteLine();
        }

        private static void ExecuteCommands(List<string> commands, PhoneBook phoneBook)
        {
            foreach (var command in commands)
            {
                string[] arguments = command.Split();
                if (arguments.Length == 1)
                {
                    phoneBook.Find(arguments[0]);
                }
                else if (arguments.Length == 2)
                {
                    phoneBook.Find(arguments[0], arguments[1]);
                }
            }
        }

        private static List<string> GetCommands()
        {
            List<string> commands = new List<string>();

            StreamReader sr = new StreamReader("..\\..\\commands.txt"); // the input commands file
            using (sr)
            {
                while (!sr.EndOfStream)
                {
                    string command = sr.ReadLine();
                    var matches = Regex.Matches(command, @"""([^""]*)");
                    if (matches.Count == 2)
                    {
                        var match = matches[0].ToString();
                        commands.Add(match.Substring(1, match.Length - 1));
                    }
                    else if (matches.Count == 4)
                    {
                        var match1 = matches[0].ToString();
                        var match2 = matches[2].ToString();
                        commands.Add(match1.Substring(1, match1.Length - 1) + " " + match2.Substring(1, match2.Length - 1));
                    }
                }
            }
            return commands;
        }
    }
}