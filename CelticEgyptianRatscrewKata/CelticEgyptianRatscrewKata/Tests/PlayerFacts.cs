using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace CelticEgyptianRatscrewKata.Tests
{
    [TestFixture]
    class PlayerFacts
    {
        [Test]
        public void Has_Won_If_They_Have_All_The_Cards()
        {
            var player = new Player(Enumerable.Repeat(new Card(Suit.Clubs, Rank.Ace), 52));
            var hasWon = player.HasWon();

            Assert.That(hasWon);
        }

        [Test]
        public void Has_Not_Won_If_They_Do_Not_Have_All_The_Cards()
        {
            var player = new Player(Cards.With(new Card(Suit.Clubs, Rank.Ace)));
            
            var playerHasWon = player.HasWon();

            Assert.That(playerHasWon, Is.False);
        }
    }

    internal class Player
    {
        private readonly IEnumerable<Card> _cards;

        public Player(IEnumerable<Card> cards)
        {
            _cards = cards;
        }

        public bool HasWon()
        {
            return _cards.Count() == 52;
        }
    }
}
