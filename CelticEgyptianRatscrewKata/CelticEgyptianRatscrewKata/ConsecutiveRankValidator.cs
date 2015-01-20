using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CelticEgyptianRatscrewKata
{
    class ConsecutiveRankValidator : ISnapValidator
    {
        public int Distance { get; set; }

        public ConsecutiveRankValidator(ConsecutiveRankDistance distance)
        {
            Distance = (int)distance;
        }

        public bool IsValidSnap(Stack stack)
        {
            if (stack.Size <= Distance)
            {
                return false;
            }
            var currentEnumerator = stack.GetEnumerator();
            var previousEnumerator = stack.GetEnumerator();
            for (var i = 0; i < Distance; i++)
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
