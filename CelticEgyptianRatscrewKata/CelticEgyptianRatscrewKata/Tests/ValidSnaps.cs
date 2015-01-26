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

		[TestFixture]
		class SandwichSnap
		{
			[Test]
			public void Should_Match_Two_Cards_With_The_Same_Rank_Separated_By_A_Card_With_A_Different_Rank()
			{
				var stack = new Stack(new List<Card>
				{
					new Card(Suit.Clubs, Rank.Ace),
					new Card(Suit.Clubs, Rank.Two),
					new Card(Suit.Diamonds, Rank.Ace)
				});

				var snapMatched = new SandwichSnap().IsValidFor(stack);

				Assert.That(snapMatched);
			}

			[TestCase(2)]
			[TestCase(1)]
			[TestCase(0)]
			public void Should_Not_Match_Stack_With_Less_Than_Three_Cards(int size)
			{
				var cards = new List<Card>
				{
					new Card(Suit.Clubs, Rank.Ace),
					new Card(Suit.Diamonds, Rank.Ace)
				};
				var stack = new Stack(cards.Take(size));

				var theSnap = new SandwichSnap().IsValidFor(stack);

				Assert.That(theSnap, Is.False);
			}

			[Test]
			public void Should_Not_Match_Stack_Where_All_Cards_Have_Different_Ranks()
			{
				var stack = new Stack(new List<Card>
				{
					new Card(Suit.Clubs, Rank.Ace),
					new Card(Suit.Clubs, Rank.Two),
					new Card(Suit.Diamonds, Rank.Three)
				});

				var theSnap = new SandwichSnap().IsValidFor(stack);

				Assert.That(theSnap, Is.False);
			}

			[Test]
			public void Should_Match_Stack_Where_Sandwich_Snap_Is_Not_On_Top()
			{
				var stack = new Stack(new List<Card>
				{
					new Card(Suit.Clubs, Rank.Three),
					new Card(Suit.Clubs, Rank.Ace),
					new Card(Suit.Clubs, Rank.Two),
					new Card(Suit.Diamonds, Rank.Ace)
				});

				var snapMatched = new SandwichSnap().IsValidFor(stack);

				Assert.That(snapMatched);
			}

			[Test]
			public void Should_Match_Stack_With_Sandwich_Snap_Not_On_The_Bottom()
			{
				var stack = new Stack(new List<Card>
				{
					new Card(Suit.Clubs, Rank.Ace),
					new Card(Suit.Clubs, Rank.Two),
					new Card(Suit.Diamonds, Rank.Ace),
					new Card(Suit.Clubs, Rank.Three)
				});

				var snapMatched = new SandwichSnap().IsValidFor(stack);

				Assert.That(snapMatched);
			}

			private bool IsValidFor(Stack stack)
			{
				if (stack.Count() < 3)
				{
					return false;
				}

				var thirdFromBottomCard = stack.Skip(stack.Count() - 3).First();
				var bottomCard = stack.Last();
				var validSnapOnBottom = thirdFromBottomCard.HasSameRankAs(bottomCard);

				var thirdFromTopCard = stack.Skip(2).First();
				var topCard = stack.First();
				var validSnapOnTop = thirdFromTopCard.HasSameRankAs(topCard);
				return validSnapOnBottom || validSnapOnTop;
			}
		}
	}
}
