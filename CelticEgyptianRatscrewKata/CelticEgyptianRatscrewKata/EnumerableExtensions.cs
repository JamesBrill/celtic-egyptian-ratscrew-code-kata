using System.Collections.Generic;
using System.Linq;

namespace CelticEgyptianRatscrewKata
{
	public static class EnumerableExtensions
	{
		public static IEnumerable<IEnumerable<T>> ToWindowedEnumerable<T>(this IEnumerable<T> source, int windowSize)
		{
			var numberOfWindows = source.Count() - windowSize + 1;
			for (int i = 0; i < numberOfWindows; i++)
			{
				yield return source.Skip(i).Take(windowSize);
			}
		}
	}
}