using System.Collections.Generic;
using System.Linq;
using Autofac;
using Autofac.Core;
using NUnit.Framework;

namespace CelticEgyptianRatscrewKata.Tests
{
    public class SnapValidatorTests
    {
        private IContainer m_Container;
        private IEnumerable<ISnapValidator> m_SnapValidators;
          
        [SetUp]
        public void Setup()
        {
            var containerBuilder = new ContainerBuilder();
            containerBuilder.RegisterModule<SnapValidatorModule>();
            m_Container = containerBuilder.Build();
            m_SnapValidators = m_Container.Resolve<IEnumerable<ISnapValidator>>();
        }

        [Test]
        public void StandardSnapIsValid()
        {
            var cardsInStack = new List<Card>
            {
                new Card(Suit.Clubs, Rank.Ace),
                new Card(Suit.Clubs, Rank.Ace),
            };
            var stack = new Stack(cardsInStack);
            var validator = m_SnapValidators.First(x => x.GetType() == typeof(StandardSnapValidator));
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
            var validator = m_SnapValidators.First(x => x.GetType() == typeof(StandardSnapValidator));
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
            var validator = m_SnapValidators.First(x => x.GetType() == typeof(SandwichSnapValidator));
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
            var validator = m_SnapValidators.First(x => x.GetType() == typeof(SandwichSnapValidator));
            var isValid = validator.IsValidSnap(stack);
            Assert.That(!isValid);
        }

        [Test]
        public void DarkQueenOnTopIsValidSnap()
        {
            var cardsInStack = new List<Card>
            {
                new Card(Suit.Clubs, Rank.Ace),
                new Card(Suit.Spades, Rank.Queen)
            };
            var stack = new Stack(cardsInStack);
            var validator = m_SnapValidators.First(x => x.GetType() == typeof(DarkQueenSnapValidator));
            var isValid = validator.IsValidSnap(stack);
            Assert.That(isValid);
        }

        [Test]
        public void DarkQueenNotOnTopIsNotValidSnap()
        {
            var cardsInStack = new List<Card>
            {
                new Card(Suit.Spades, Rank.Queen),
                new Card(Suit.Clubs, Rank.Ace)
            };
            var stack = new Stack(cardsInStack);
            var validator = m_SnapValidators.First(x => x.GetType() == typeof(DarkQueenSnapValidator));
            var isValid = validator.IsValidSnap(stack);
            Assert.That(!isValid);
        }
    }
}
