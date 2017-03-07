using System;
    class Standard52Cards
{
    static void Main()
    {
        string[] cards = {"Ace", "Deuce", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten",
                             "Jack", "Queen", "King"};

        for (int cardNum = 0; cardNum <=12; cardNum++)
        {
            string cardName = cards[cardNum]; 
            for(int suitNum=0; suitNum < 4; suitNum++)
            {
                switch (suitNum)
                {
                    case 0: Console.Write("{0} of Hearts\t\t", cardName);
                    break;
                    case 1: Console.Write("{0} of Spades\t ", cardName);
                    break;
                    case 2: Console.Write("{0} of Clubs\t ", cardName);
                    break;
                    case 3: Console.Write("{0} of Diamonds\n", cardName);
                    break;
                }
            }
        }
    }
}
