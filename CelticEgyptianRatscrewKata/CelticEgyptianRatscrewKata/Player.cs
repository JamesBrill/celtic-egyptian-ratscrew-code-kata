using System.Linq;
using CelticEgyptianRatscrewKata.Rules;

namespace CelticEgyptianRatscrewKata
{
    internal class Player
    {
        private Cards _cards;
        private readonly ISnapRule _validSnap;

        public Player(Cards cards, ISnapRule validSnap)
        {
            _cards = cards;
            _validSnap = validSnap;
        }

        public Cards Hand
        {
            get
            {
                return _cards;
            }
        }

        public bool HasWon()
        {
            return _cards.Count() == 52;
        }

        public void CallSnap(Cards stack)
        {
            if (_validSnap.IsValidFor(stack))
            {
                var cardList = _cards.ToList();
                cardList.InsertRange(0, stack);
                _cards = Cards.With(cardList.ToArray());
            }
        }

        public void PlayCard(Cards stack)
        {
            stack.AddToTop(_cards.CardAt(0));
            _cards.RemoveCardAt(0);
        }
    }
}