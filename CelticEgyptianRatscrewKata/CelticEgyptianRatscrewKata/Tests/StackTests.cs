﻿using System.Collections.Generic;
using NUnit.Framework;

namespace CelticEgyptianRatscrewKata.Tests
{
    public class StackTests
    {
        [Test]
        public void ShouldReadTopCardOnStack()
        {
            var expectedCard = new Card(Suit.Clubs, Rank.Ace);
            var stack = new Stack(new List<Card> {expectedCard});

            CollectionAssert.AreEqual(stack, new List<Card> {expectedCard});
        }

        [Test]
        public void ShouldReadAllCards()
        {
            var expectedCardsInStack = new List<Card>
            {
                new Card(Suit.Clubs, Rank.Ace),
                new Card(Suit.Clubs, Rank.Two),
                new Card(Suit.Clubs, Rank.Three),
            };
            var stack = new Stack(expectedCardsInStack);

            CollectionAssert.AreEqual(stack, expectedCardsInStack);
        }

        [Test]
        public void CorrectNumberOfCardsReturned()
        {
            var expectedCardsInStack = new List<Card>
            {
                new Card(Suit.Clubs, Rank.Ace),
                new Card(Suit.Clubs, Rank.Two),
                new Card(Suit.Clubs, Rank.Three),
            };
            var stack = new Stack(expectedCardsInStack);
            var numberOfCardsInStack = stack.Size;
            Assert.AreEqual(3, numberOfCardsInStack);
        }

        [Test]
        public void TopCardReturned()
        {
            var expectedCardsInStack = new List<Card>
            {
                new Card(Suit.Clubs, Rank.Ace),
                new Card(Suit.Clubs, Rank.Two),
                new Card(Suit.Clubs, Rank.Three),
            };
            var stack = new Stack(expectedCardsInStack);
            var topCard = stack.Top;
            Assert.AreEqual(new Card(Suit.Clubs, Rank.Three), topCard);
        }
    }
}