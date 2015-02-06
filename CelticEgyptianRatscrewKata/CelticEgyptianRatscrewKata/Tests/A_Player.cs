using System.Collections.Generic;
using System.Linq;
using CelticEgyptianRatscrewKata.Rules;
using Moq;
using NUnit.Framework;

namespace CelticEgyptianRatscrewKata.Tests
{
    [TestFixture]
    class A_Player
    {
        [Test]
        public void Has_Won_If_They_Have_All_The_Cards()
        {
            var player = CreateSut(
                Cards.With(
                    Enumerable.Repeat(
                        new Card(Suit.Clubs, Rank.Ace), 52).ToArray()));
            var hasWon = player.HasWon();

            Assert.That(hasWon);
        }

        [Test]
        public void Has_Not_Won_If_They_Do_Not_Have_All_The_Cards()
        {
            var player = CreateSut(Cards.With(new Card(Suit.Clubs, Rank.Ace)));
            
            var playerHasWon = player.HasWon();

            Assert.That(playerHasWon, Is.False);
        }

        [Test]
        public void Correctly_Calling_Snap_Has_The_Stack_Added_To_The_Bottom_Of_Their_Pile()
        {
            var stack = Cards.With(new Card(Suit.Spades, Rank.Queen));
            var validSnap = new Mock<ISnapRule>();
            validSnap.Setup(x => x.IsValidFor(stack)).Returns(true);

            var player = CreateSut(Cards.Empty(), validSnap.Object);
            player.CallSnap(stack);
            var pile = player.Hand;
            
            CollectionAssert.AreEqual(stack, pile.Take(stack.Count()));
        }

        [Test]
        public void Incorrectly_Calling_Snap_Has_No_Change_Made_To_Their_Pile()
        {
            var stack = Cards.With(
                    new Card(Suit.Diamonds, Rank.Three));
            var player = CreateSut(
                Cards.With(
                    new Card(Suit.Spades, Rank.Ace)));
            var handBeforeCallingSnap = player.Hand;

            player.CallSnap(stack);

            var handAfterCallingSnap = player.Hand;
            Assert.AreEqual(handBeforeCallingSnap, handAfterCallingSnap);
        }

        [Test]
        public void Plays_A_Card_On_To_The_Top_Of_The_Stack()
        {
            var stack = Cards.Empty();
            var playersTopCard = new Card(Suit.Clubs, Rank.Ace);
            var player = CreateSut(Cards.With(playersTopCard));

            player.PlayCard(stack);

            var cardOnTopOfStack = stack.CardAt(stack.Count() - 1);
            Assert.That(cardOnTopOfStack, Is.EqualTo(playersTopCard));
        }

        private static Player CreateSut(Cards hand = null, ISnapRule snapRule = null)
        {
            if (hand == null)
            {
                hand = Cards.Empty();
            }

            if (snapRule == null)
            {
                snapRule = Mock.Of<ISnapRule>();
            }

            return new Player(hand, snapRule);
        }
    }

    internal class Player
    {
        private Cards _cards;
        private readonly ISnapRule _validSnap;

        public Player(Cards cards, ISnapRule validSnap)
        {
            _cards = cards;
            _validSnap = validSnap;
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
            if (_validSnap.IsValidFor(stack))
            {
                var cardList = _cards.ToList();
                cardList.InsertRange(0, stack);
                _cards = Cards.With(cardList.ToArray());
            }
        }

        public void PlayCard(Cards stack)
        {
            stack.AddToTop(_cards.CardAt(0));
        }
    }
}
