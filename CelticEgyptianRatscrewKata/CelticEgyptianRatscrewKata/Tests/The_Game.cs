using System;
using System.Linq;
using CelticEgyptianRatscrewKata.Rules;
using Moq;
using NUnit.Framework;

namespace CelticEgyptianRatscrewKata.Tests
{
    [TestFixture]
    class The_Game
    {
        [Test]
        public void In_One_Player_Game_The_Player_Receives_All_Cards()
        {
            var allCards = Cards.With(Enumerable.Repeat(new Card(Suit.Clubs, Rank.Ace), 52).ToArray());
            var player = new Player(Cards.Empty(), Mock.Of<ISnapRule>());
            var game = new Game(player);

            game.Setup(allCards);

            CollectionAssert.AreEqual(allCards, player.Hand);
        }

        [Test]
        public void Deals_Cards_To_All_Players()
        {
            
        }
    }

    internal struct Game
    {
        private readonly Player _player;

        public Game(Player player)
        {
            _player = player;
        }

        public void Setup(Cards allCards)
        {
            _player.Hand = allCards;
        }
    }
}
