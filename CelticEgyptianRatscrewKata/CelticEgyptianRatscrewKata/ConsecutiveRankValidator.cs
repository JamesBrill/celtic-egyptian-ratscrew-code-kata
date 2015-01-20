using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CelticEgyptianRatscrewKata
{
    public class ConsecutiveRankValidator : IConsecutiveRankValidator
    {
        public bool IsValidSnap(Stack stack, int distanceBetweenConsecutiveRanks)
        {
            if (stack.Size <= distanceBetweenConsecutiveRanks)
            {
                return false;
            }
            var currentEnumerator = stack.GetEnumerator();
            var previousEnumerator = stack.GetEnumerator();
            for (var i = 0; i < distanceBetweenConsecutiveRanks; i++)
            {
                currentEnumerator.MoveNext();
            }

            while (currentEnumerator.MoveNext())
            {
                previousEnumerator.MoveNext();
                var currentCard = currentEnumerator.Current;
                var previousCard = previousEnumerator.Current;
                if (currentCard.SameRank(previousCard))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
