using NUnit.Framework;
using Santase.Logic;
using Santase.Logic.Cards;
using Santase.Logic.Players;
using Santase.Logic.RoundStates;
using System.Collections.Generic;

namespace Santase.Tests
{
    [TestFixture]
    public class PlayerActionValidatorTests
    {
        private PlayerActionValidator validator = new PlayerActionValidator();

        [Test]
        public void PlayingCardThatsNotInHand_ShouldBeInvalid()
        {
            var cards = new List<Card>() { new Card(CardSuit.Club, CardType.Ace) };
            var action = new PlayerAction(PlayerActionType.PlayCard, new Card(CardSuit.Club, CardType.Jack), Announce.None);
            var state = new FinalRoundState();
            var context = new PlayerTurnContext(state, new Card(CardSuit.Club, CardType.Jack), 0);

            Assert.IsFalse(validator.IsValid(action, context, cards));
        }

        [Test]
        public void PlayingCardFromHand_ShouldBeValid()
        {
            var cards = new List<Card>() { new Card(CardSuit.Club, CardType.Ace) };
            var action = new PlayerAction(PlayerActionType.PlayCard, new Card(CardSuit.Club, CardType.Ace), Announce.None);
            var state = new FinalRoundState();
            var context = new PlayerTurnContext(state, new Card(CardSuit.Club, CardType.Jack), 0);

            Assert.IsTrue(validator.IsValid(action, context, cards));
        }

        [Test]
        public void PlayerChangesTrumpWithNine_ShouldBeValid()
        {
            var cards = new List<Card>() { new Card(CardSuit.Club, CardType.Nine) };
            var action = new PlayerAction(PlayerActionType.ChangeTrump, new Card(CardSuit.Club, CardType.Nine), Announce.None);
            var round = new GameRound(new Player(), new Player(), PlayerPosition.FirstPlayer);
            var state = new MoreThanTwoCardsLeftRoundState(round);
            var context = new PlayerTurnContext(state, new Card(CardSuit.Club, CardType.Jack), 0);

            Assert.IsTrue(validator.IsValid(action, context, cards));
        }

        [Test]
        public void PlayerChangesTrumpWithQueen_ShouldBeInvalid()
        {
            var cards = new List<Card>() { new Card(CardSuit.Club, CardType.Queen) };
            var action = new PlayerAction(PlayerActionType.ChangeTrump, new Card(CardSuit.Club, CardType.Queen), Announce.None);
            var round = new GameRound(new Player(), new Player(), PlayerPosition.FirstPlayer);
            var state = new MoreThanTwoCardsLeftRoundState(round);
            var context = new PlayerTurnContext(state, new Card(CardSuit.Club, CardType.Jack), 0);

            Assert.IsFalse(validator.IsValid(action, context, cards));
        }

        [Test]
        public void FourtyAnnounce_ShouldBeValid()
        {
            var cards = new List<Card>() { new Card(CardSuit.Club, CardType.Queen), new Card(CardSuit.Club, CardType.King) };
            var announce = Announce.Fourty;
            var action = new PlayerAction(PlayerActionType.PlayCard, new Card(CardSuit.Club, CardType.Queen), announce);
            var round = new GameRound(new Player(), new Player(), PlayerPosition.FirstPlayer);
            var state = new MoreThanTwoCardsLeftRoundState(round);
            var context = new PlayerTurnContext(state, new Card(CardSuit.Club, CardType.Jack), 0);
            validator.IsValid(action, context, cards);

            Assert.AreEqual(Announce.Fourty, announce);
        }

        [Test]
        public void FourtyAnnounceWithoutQueenOrKing_ShouldBeInvalid()
        {
            var cards = new List<Card>() { new Card(CardSuit.Club, CardType.Queen), new Card(CardSuit.Club, CardType.King), new Card(CardSuit.Heart, CardType.Jack) };
            var announce = Announce.Fourty;
            var action = new PlayerAction(PlayerActionType.PlayCard, new Card(CardSuit.Heart, CardType.Jack), announce);
            var round = new GameRound(new Player(), new Player(), PlayerPosition.FirstPlayer);
            var state = new MoreThanTwoCardsLeftRoundState(round);
            var context = new PlayerTurnContext(state, new Card(CardSuit.Club, CardType.Jack), 0);
            validator.IsValid(action, context, cards);

            Assert.AreNotEqual(Announce.Fourty, action.Announce);
        }

        [Test]
        public void FourtyAnnounceWhenPlayerIsNotFirst_ShouldChangeAnnounceToNone()
        {
            var cards = new List<Card>() { new Card(CardSuit.Club, CardType.Queen), new Card(CardSuit.Club, CardType.King), new Card(CardSuit.Heart, CardType.Jack) };
            var announce = Announce.Fourty;
            var action = new PlayerAction(PlayerActionType.PlayCard, new Card(CardSuit.Heart, CardType.Jack), announce);
            var round = new GameRound(new Player(), new Player(), PlayerPosition.SecondPlayer);
            var state = new MoreThanTwoCardsLeftRoundState(round);
            var context = new PlayerTurnContext(state, new Card(CardSuit.Club, CardType.Jack), 0);
            validator.IsValid(action, context, cards);

            Assert.AreEqual(Announce.None, action.Announce);
        }
    }
}
