using System.Collections.Generic;
using System.Linq;

namespace CelticEgyptianRatscrewKata
{
	public class AllSnaps : ISnapRule
	{
		private readonly IEnumerable<ISnapRule> snaps;

		public AllSnaps(params ISnapRule[] snaps)
		{
			this.snaps = snaps;
		}

		public bool IsValidFor(Stack stack)
		{
			return snaps.Any(r => r.IsValidFor(stack));
		}
	}
}