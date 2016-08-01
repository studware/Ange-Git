using Santase.Logic.Cards;
using System;
using System.Collections.Generic;

namespace Santase.Logic
{
    public class CardComparer : IEqualityComparer<Card>
    {
        //  The CardComparer class from Dentia
        public bool Equals(Card x, Card y)
        {
            return x.Type == y.Type && x.Suit == y.Suit;
        }

        public int GetHashCode(Card x)
        {
            return GetTypeValue(x.Type) + GetSuitValue(x.Suit);
        }

        public int GetSuitValue(CardSuit suit)
        {
            switch (suit)
            {
                case CardSuit.Club:
                    return 100;
                case CardSuit.Diamond:
                    return 200;
                case CardSuit.Heart:
                    return 300;
                case CardSuit.Spade:
                    return 400;
                default:
                    throw new ArgumentException();
            }
        }

        public int GetTypeValue(CardType type)
        {
            switch (type)
            {
                case CardType.Nine:
                    return 9;
                case CardType.Ten:
                    return 10;
                case CardType.Jack:
                    return 11;
                case CardType.Queen:
                    return 12;
                case CardType.King:
                    return 13;
                case CardType.Ace:
                    return 14;
                default:
                    throw new ArgumentException();
            }
        }
    }
}