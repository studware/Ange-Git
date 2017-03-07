using System;
    class IntDoubleString
    {
        static void Main()
        {
            string varType;
            do
            {
                Console.Write("Enter the type of variable you will unput: int, double, or string: ");
                varType = Console.ReadLine();
            }
            while (!(varType == "int" || varType == "double" || varType == "string"));
            Console.Write("Enter variable of type {0}: ", varType);
            string inputVar = Console.ReadLine();
            int intVar;
            double doubleVar;

            switch (varType)
            {
                case "int":
                    {
                        if (int.TryParse(inputVar, out intVar))
                        {
                            intVar++;
                            Console.WriteLine("The integer variable you just entered is now {0}.", intVar);
                        }
                        else
                        { 
                            Console.WriteLine("Please, enter a valid integer variable!"); 
                        }
                        break;
                    }
                case "double":
                    {
                        if (double.TryParse(inputVar, out doubleVar))
                        {
                            doubleVar+=1.0;
                            Console.WriteLine("The double type variable you just entered is now {0}.", doubleVar);
                        }
                        else
                        {
                            Console.WriteLine("Please, enter a valid variable of type double!");
                        }
                        break;
                    }
                case "string":
                    {
                        inputVar += "*";
                        Console.WriteLine("The string variable you just entered has becomed {0}.", inputVar);
                        break;
                    }
            }
        }

    }
