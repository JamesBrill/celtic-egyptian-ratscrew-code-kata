using System.Linq;

namespace CelticEgyptianRatscrewKata
{
	public class DarkQueenSnap
	{
		private readonly Card QueenOfSpades = new Card(Suit.Spades, Rank.Queen);

		public bool IsValidFor(Stack stack)
		{
			if (!stack.Any())
			{
				return false;
			}

			return stack.First().Equals(QueenOfSpades);
		}
	}
}
