using System.Collections.Generic;
using NUnit.Framework;

namespace CelticEgyptianRatscrewKata.Tests
{
    public class SnapValidatorTests
    {
        [Test]
        public void StandardSnapIsValid()
        {
            var cardsInStack = new List<Card>
            {
                new Card(Suit.Clubs, Rank.Ace),
                new Card(Suit.Clubs, Rank.Ace),
            };
            var stack = new Stack(cardsInStack);
            var validator = new ConsecutiveRankValidator(ConsecutiveRankDistance.Standard);
            var isValid = validator.IsValidSnap(stack);
            Assert.That(isValid);
        }

        [Test]
        public void NoStandardSnapIsNotValid()
        {
            var cardsInStack = new List<Card>
            {
                new Card(Suit.Clubs, Rank.Ace),
                new Card(Suit.Clubs, Rank.Two),
                new Card(Suit.Clubs, Rank.Ace),
            };
            var stack = new Stack(cardsInStack);
            var validator = new ConsecutiveRankValidator(ConsecutiveRankDistance.Standard);
            var isValid = validator.IsValidSnap(stack);
            Assert.That(!isValid);
        }

        [Test]
        public void SandwichSnapIsValid()
        {
            var cardsInStack = new List<Card>
            {
                new Card(Suit.Clubs, Rank.Ace),
                new Card(Suit.Clubs, Rank.Two),
                new Card(Suit.Clubs, Rank.Ace),
            };
            var stack = new Stack(cardsInStack);
            var validator = new ConsecutiveRankValidator(ConsecutiveRankDistance.Sandwich);
            var isValid = validator.IsValidSnap(stack);
            Assert.That(isValid);
        }

        [Test]
        public void NoSandwichSnapIsNotValid()
        {
            var cardsInStack = new List<Card>
            {
                new Card(Suit.Clubs, Rank.Ace),
                new Card(Suit.Clubs, Rank.Two),
                new Card(Suit.Clubs, Rank.Two),
                new Card(Suit.Clubs, Rank.Ace),
            };
            var stack = new Stack(cardsInStack);
            var validator = new ConsecutiveRankValidator(ConsecutiveRankDistance.Sandwich);
            var isValid = validator.IsValidSnap(stack);
            Assert.That(!isValid);
        }
    }
}
