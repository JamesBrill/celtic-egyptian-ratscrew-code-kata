using System.Linq;

namespace CelticEgyptianRatscrewKata.Rules
{
	public class DarkQueenSnap : ISnapRule
	{
		private readonly Card queenOfSpades = new Card(Suit.Spades, Rank.Queen);

		public bool IsValidFor(Stack stack)
		{
			if (!stack.Any())
			{
				return false;
			}

			return stack.First().Equals(queenOfSpades);
		}
	}
}
