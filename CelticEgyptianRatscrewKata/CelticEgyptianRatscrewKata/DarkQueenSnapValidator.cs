using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CelticEgyptianRatscrewKata
{
    public class DarkQueenSnapValidator : ISnapValidator
    {
        public string Name { get; private set; }

        public DarkQueenSnapValidator()
        {
            Name = "dark queen";
        }

        public bool IsValidSnap(Stack stack)
        {
            var darkQueen = new Card(Suit.Spades, Rank.Queen);
            return darkQueen.Equals(stack.Top);
        }
    }
}
