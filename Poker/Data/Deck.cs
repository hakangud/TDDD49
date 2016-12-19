using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker.Data
{
    class Deck : Card
    {
        const int NUM_OF_CARDS = 52;
        private Card[] deck;

        public Deck()
        {
            deck = new Card[NUM_OF_CARDS];
        }

        public Card[] getDeck { get { return deck; } }

        public void setUpDeck()
        {
            int i = 0;

            foreach (SUIT s in Enum.GetValues(typeof(SUIT)))
            {
                foreach (VALUE v in Enum.GetValues(typeof(VALUE)))
                {
                    deck[i] = new Card { MySuit = s, MyValue = v };
                    i++;
                }
            }
            shuffleDeck();
        }

        public void shuffleDeck()
        {
            Random r = new Random();
            Card tempCard;

            for (int shuffles = 0; shuffles < 1000; shuffles++)
            {
                for (int i = 0; i < NUM_OF_CARDS; i++)
                {
                    int cardIndex = r.Next(13);
                    tempCard = deck[i];
                    deck[i] = deck[cardIndex];
                    deck[cardIndex] = tempCard;
                }
            }
        }

    }
}
