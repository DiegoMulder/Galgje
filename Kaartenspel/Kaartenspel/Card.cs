using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardLogic
{
    internal class Card
    {
        public CardValue Value { get; private set; }
        public Suit Suit { get; private set; }

        public Card(CardValue value, Suit suit)
        {
            Value = value;
            Suit = suit;
        }

        public override string ToString()
        {
            return $"{Value} of {Suit}";
        }
    }
}
