﻿using System.Collections;
using System.Collections.Generic;

namespace CelticEgyptianRatscrewKata
{
    public class Stack : IEnumerable<Card>
    {
        private readonly List<Card> m_Cards;

        public Stack(IEnumerable<Card> cards)
        {
            m_Cards = new List<Card>(cards);
        }

        public IEnumerator<Card> GetEnumerator()
        {
            return m_Cards.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}