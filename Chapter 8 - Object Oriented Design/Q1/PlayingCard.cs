using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/*
 * This is a generic class for a playing card that I would expect to be extended for each game it was going to be played in.
 * 
 * The abstract Value function, would be used to determine the value of each card. Such as Ace, Queens, Kings, etc.
 * 
 */

namespace CrackingTheCodingInterview.Chapter_8___Object_Oriented_Design.Q1
{
    public abstract class PlayingCard
    {

        public PlayingCard(suitType suit, cardValue value)
        {
            _suit = suit;
            _value = value;
        }



        // Suits
        private readonly suitType _suit;
        public suitType suit { get { return _suit; } }
        public enum suitType
        {
            Hearts,
            Diamonds,
            Spades,
            Clubs
        };


        // Colours
        public enum colourType
        {
            Red,
            Black
        };


        public colourType Colour()
        {
            if (suit == suitType.Hearts || suit == suitType.Diamonds) return colourType.Red;
            else return colourType.Black;
        }


        // Card Value
        public enum cardValue
        {
            Ace = 1,
            Two = 2,
            Three = 3,
            Four = 4,
            Five = 5,
            Six = 6,
            Seven = 7,
            Eight = 8,
            Nine = 9,
            Jack = 10,
            Queen = 11,
            King = 12
        }
        protected readonly cardValue _value;

        // Calculates the value of the card for the given game.
        public abstract Int16 Value();

        

    }
}
