using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrackingTheCodingInterview.Chapter_8___Object_Oriented_Design.Q1
{
    public class BlackJackCard : PlayingCard
    {
        public BlackJackCard(suitType suit, cardValue value) : base(suit, value)
        {
        }

        public bool aceIs11 { get; set; } = true;

        public override Int16 Value()
        {
            if (base._value == cardValue.Ace)
                if (aceIs11) return 11;
                else return 1;
            else if (base._value == cardValue.Queen || base._value == cardValue.King || base._value == cardValue.Jack)
                return 10;
            else
                return (Int16)_value;
        }
    }
}