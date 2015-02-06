using System.Collections.Generic;
using System.Linq;
using CelticEgyptianRatscrewKata.Rules;
using Moq;
using NUnit.Framework;

namespace CelticEgyptianRatscrewKata.Tests
{
    [TestFixture]
    class PlayerFacts
    {
        [Test]
        public void Has_Won_If_They_Have_All_The_Cards()
        {
            var player = new Player(
                Cards.With(
                    Enumerable.Repeat(new Card(Suit.Clubs, Rank.Ace), 52).ToArray()), 
                Mock.Of<ISnapRule>());
            var hasWon = player.HasWon();

            Assert.That(hasWon);
        }

        [Test]
        public void Has_Not_Won_If_They_Do_Not_Have_All_The_Cards()
        {
            var player = new Player(Cards.With(new Card(Suit.Clubs, Rank.Ace)), Mock.Of<ISnapRule>());
            
            var playerHasWon = player.HasWon();

            Assert.That(playerHasWon, Is.False);
        }

        [Test]
        public void If_Player_Correctly_Calls_Snap_Then_Stack_Is_Added_To_Bottom_Of_Their_Pile()
        {
            var stack = Cards.With(new Card(Suit.Spades, Rank.Queen));
            var validSnap = new Mock<ISnapRule>();
            validSnap.Setup(x => x.IsValidFor(stack)).Returns(true);

            var player = new Player(Cards.Empty(), validSnap.Object);
            player.CallSnap(stack);
            var pile = player.Hand;
            
            CollectionAssert.AreEqual(stack, pile.Take(stack.Count()));
        }
    }

    internal class Player
    {
        private Cards _cards;

        public Player(Cards cards, ISnapRule validSnap)
        {
            _cards = cards;
        }

        public Cards Hand
        {
            get
            {
                return _cards;
            }
        }

        public bool HasWon()
        {
            return _cards.Count() == 52;
        }

        public void CallSnap(Cards stack)
        {
            var cardList = _cards.ToList();
            cardList.InsertRange(0, stack);

            _cards = Cards.With(cardList.ToArray());
        }
    }
}
