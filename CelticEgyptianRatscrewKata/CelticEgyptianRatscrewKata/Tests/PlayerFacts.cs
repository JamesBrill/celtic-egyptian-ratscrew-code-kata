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
    }

    internal class Player
    {
        public Player(IEnumerable<Card> cards)
        {
            
        }

        public bool HasWon()
        {
            return true;
        }
    }
}
