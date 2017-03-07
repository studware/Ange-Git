using System;
    class NumberToText
    {
        static void Main()
        {
            int num;
            int units;
            int tens;
            int hundreds;
            string numString;
            string unStr = "";
            string tenStr = "";
            string hunStr = "";
            string andStr = "and";
            string htSpace1 = " ";
            string htSpace2 = " ";
            string tuSpace = " ";
            do
            {
                Console.Write("Please enter a number (from 0 to 999): ");
            }
            while (!int.TryParse(numString = Console.ReadLine(), out num) || num > 999);
            Console.WriteLine();
            units = num % 10;
            tens = (num/10) % 10;
            hundreds = (num/100) % 10;
            if (hundreds == 0)
            {
                htSpace1 = htSpace2 = andStr = "";
            }
            if (tens == 0)
            {
                tuSpace = "";
                if (hundreds == 0 || units==0)
                {
                    andStr = "";
                }
            }
            if (units == 0)
            {
                tuSpace = "";
                if (hundreds == 0)
                { 
                    htSpace1 = htSpace2 = andStr = "";
                }
                if (tens == 0)
                { 
                    htSpace1 = htSpace2 = andStr = "";
                }
            }
            switch (hundreds)
            {
                case 0:
                    andStr = "";
                    break;
                case 1:
                    hunStr= "One Hundred";
                    break;
                case 2:
                    hunStr = "Two Hundred";
                    break;
                case 3:
                    hunStr = "Three Hundred";
                    break;
                case 4:
                    hunStr = "Four Hundred";
                    break;
                case 5:
                    hunStr = "Five Hundred";
                    break;
                case 6:
                    hunStr = "Six Hundred";
                    break;
                case 7:
                    hunStr = "Seven Hundred";
                    break;
                case 8:
                    hunStr = "Eight Hundred";
                    break;
                case 9:
                    hunStr = "Nine Hundred";
                    break; 
            }
            switch (tens)
            { 
                case 1:
                    tenStr = "";
                    tuSpace = "";
                    switch (units)
                        {
                            case 1:
                                unStr = "Eleven";
                                break;
                            case 2:
                                unStr = "Twelve";
                                break;
                            case 3:
                                unStr = "Thirteen";
                                break;
                            case 4:
                                unStr = "Fourteen";
                                break;
                            case 5:
                                unStr = "Fifteen";
                                break;
                            case 6:
                                unStr = "Sixteen";
                                break;
                            case 7:
                                unStr = "Seventeen";
                                break;
                            case 8:
                                unStr = "Eighteen";
                                break;
                            case 9:
                                unStr = "Nineteen";
                                break;
                            default:
                                break;
                        }
                    break;
                case 2:
                    tenStr = "Twenty";
                    break;
                case 3:
                    tenStr = "Thirty";
                    break;
                case 4:
                    tenStr = "Fourty";
                    break;
                case 5:
                    tenStr = "Fifty";
                    break;
                case 6:
                    tenStr = "Sixty";
                    break;
                case 7:
                    tenStr = "Seventy";
                    break;
                case 8:
                    tenStr = "Eighty";
                    break;
                case 9:
                    tenStr = "Ninety";
                    break;
                default:
                    break;
            }
            if (tens > 1 || tens==0)
            {
                switch (units)
                {
                    case 1:
                        unStr = "One";
                        break;
                    case 2:
                        unStr = "Two";
                        break;
                    case 3:
                        unStr = "Three";
                        break;
                    case 4:
                        unStr = "Four";
                        break;
                    case 5:
                        unStr = "Five";
                        break;
                    case 6:
                        unStr = "Six";
                        break;
                    case 7:
                        unStr = "Seven";
                        break;
                    case 8:
                        unStr = "Eight";
                        break;
                    case 9:
                        unStr = "Nine";
                        break;
                }
            }
            if (num == 0)
            {
                Console.WriteLine("The English for {0} is \"Zero\".", num);
                Console.WriteLine();
            }
            else
            {
                numString = hunStr + htSpace1 + andStr + htSpace2 + tenStr + tuSpace + unStr;
                Console.WriteLine("The English for {0} is \"{1}\".", num, numString);
                Console.WriteLine();
            }
        }
    }
