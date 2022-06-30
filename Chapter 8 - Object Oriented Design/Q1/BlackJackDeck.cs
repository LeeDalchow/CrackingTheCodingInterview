using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CrackingTheCodingInterview.Chapter_8___Object_Oriented_Design.Q1
{
    public class BlackJackDeck
    {
        private LinkedList<PlayingCard> _activeDeck = new LinkedList<PlayingCard>();

        public BlackJackDeck()
        { // Pre-generate pack of 52 cards
            foreach(PlayingCard.suitType curType in Enum.GetValues(typeof(PlayingCard.suitType))) // for each suit
            {
                foreach (PlayingCard.cardValue curValue in Enum.GetValues(typeof(PlayingCard.cardValue)))
                {
                    _activeDeck.AddLast(new BlackJackCard(curType, curValue));
                }
            }

            // TODO - Need some code here to randomise the _activeDeck, but this is not really relevant to the OOP side of the question, so I won't include it.
        }

        public PlayingCard getCardFromDeck()
        {
            if (_activeDeck.Count == 0) return null;

            PlayingCard newCard = _activeDeck.First.Value;
            _activeDeck.RemoveFirst();
            return newCard;
        }


    }
}
