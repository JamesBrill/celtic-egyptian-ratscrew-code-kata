using System;
using System.Linq;

namespace CelticEgyptianRatscrewKata
{
	public class WindowedSnap
	{
		private readonly int _windowSize;

		public WindowedSnap(int windowSize)
		{
			if (windowSize < 1)
			{
				throw new ArgumentOutOfRangeException("windowSize", "Window size must be greater than or equal to 1.");
			}

			_windowSize = windowSize;
		}

		public bool IsValidFor(Stack stack)
		{
			if (stack.Count() < _windowSize)
			{
				return false;
			}

			var windows = stack.ToWindowedEnumerable(_windowSize);
			return windows.Any(window => window.First().HasSameRankAs(window.Last()));
		}
	}
}