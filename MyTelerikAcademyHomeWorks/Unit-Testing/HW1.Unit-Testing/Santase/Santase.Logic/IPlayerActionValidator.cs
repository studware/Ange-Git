using Santase.Logic.Cards;
using Santase.Logic.Players;
using System.Collections.Generic;

namespace Santase.Logic
{
    public interface IPlayerActionValidator
    {
        bool IsValid(PlayerAction action, PlayerTurnContext context, IList<Card> playerCards);
    }
}