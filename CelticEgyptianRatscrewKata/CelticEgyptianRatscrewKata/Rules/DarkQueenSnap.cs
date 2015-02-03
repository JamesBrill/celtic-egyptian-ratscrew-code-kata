using System.Linq;

namespace CelticEgyptianRatscrewKata.Rules
{
	public class DarkQueenSnap : ISnapRule
	{
		private readonly Card queenOfSpades = new Card(Suit.Spades, Rank.Queen);

		public bool IsValidFor(Cards stack)
		{
			if (!stack.Any())
			{
				return false;
			}

			return stack.First().Equals(queenOfSpades);
		}
	}
}
