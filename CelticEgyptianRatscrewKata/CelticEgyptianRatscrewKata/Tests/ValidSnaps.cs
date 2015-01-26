using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace CelticEgyptianRatscrewKata.Tests
{
	class ValidSnapsIncludes
	{
		[TestFixture]
		class StandardSnap
		{
			[Test]
			public void Should_Match_Two_Consecutive_Cards_Of_The_Same_Rank()
			{
				var cards = new List<Card>
				{
					new Card(Suit.Clubs, Rank.Ace),
					new Card(Suit.Diamonds, Rank.Ace)
				};
				var stack = new Stack(cards);

				var standardSnap = new StandardSnap();
				var matches = standardSnap.IsValidFor(stack);

				Assert.That(matches);
			}

			[Test]
			public void Should_Not_Match_For_A_Single_Card_Stack()
			{
				var stack = new Stack(new List<Card> { new Card(Suit.Clubs, Rank.Ace) });

				var standardSnap = new StandardSnap();
				var theSnap = standardSnap.IsValidFor(stack);

				Assert.That(theSnap, Is.False);
			}

			[Test]
			public void Should_Not_Match_Stack_Where_All_Cards_Have_Different_Ranks()
			{
				var stack = new Stack(new List<Card>
				{
					new Card(Suit.Clubs, Rank.Ace),
					new Card(Suit.Hearts, Rank.Two)
				});

				var standardSnap = new StandardSnap();
				var theSnap = standardSnap.IsValidFor(stack);

				Assert.That(theSnap, Is.False);
			}

			[Test]
			public void Should_Not_Match_Stack_Where_Consecutive_Cards_Have_Different_Ranks()
			{
				var stack = new Stack(new List<Card>
				{
					new Card(Suit.Clubs, Rank.Ace),
					new Card(Suit.Hearts, Rank.Two),
					new Card(Suit.Diamonds, Rank.Ace)
				});
				var standardSnap = new StandardSnap();

				var theSnap = standardSnap.IsValidFor(stack);

				Assert.That(theSnap, Is.False);
			}

			[Test]
			public void Should_Match_Two_Consecutive_Cards_Not_On_Top_Of_The_Stack()
			{
				var stack = new Stack(new List<Card>
				{
					new Card(Suit.Hearts, Rank.Two),
					new Card(Suit.Clubs, Rank.Ace),
					new Card(Suit.Diamonds, Rank.Ace)
				});
				var standardSnap = new StandardSnap();

				var snapMatched = standardSnap.IsValidFor(stack);

				Assert.That(snapMatched);
			}

			private bool IsValidFor(Stack stack)
			{
				using (var firstIterator = stack.GetEnumerator())
				using (var secondIterator = stack.GetEnumerator())
				{
					secondIterator.MoveNext();

					while (firstIterator.MoveNext() && secondIterator.MoveNext())
					{
						var first = firstIterator.Current;
						var second = secondIterator.Current;

						if (!first.Equals(second) && first.HasSameRankAs(second))
						{
							return true;
						}
					}
				}

				return false;
			}
		}
	}
}
