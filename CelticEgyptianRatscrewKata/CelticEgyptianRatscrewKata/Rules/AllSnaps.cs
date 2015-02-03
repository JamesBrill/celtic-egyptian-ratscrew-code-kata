using System.Collections.Generic;
using System.Linq;

namespace CelticEgyptianRatscrewKata.Rules
{
	public class AllSnaps : ISnapRule
	{
		private readonly IEnumerable<ISnapRule> snaps;

		public AllSnaps(params ISnapRule[] snaps)
		{
			this.snaps = snaps;
		}

		public bool IsValidFor(Cards stack)
		{
			return snaps.Any(r => r.IsValidFor(stack));
		}
	}
}