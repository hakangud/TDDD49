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
        private Stack<Card> deck;

        public Deck()
        {
            deck = new Stack<Card>();
        }

        public Stack<Card> getDeck { get { return deck; } }

        public void setUpDeck()
        {
            foreach (SUIT s in Enum.GetValues(typeof(SUIT)))
            {
                foreach (VALUE v in Enum.GetValues(typeof(VALUE)))
                {
                    deck.Push(new Card { MySuit = s, MyValue = v });
                }
            }
            shuffleDeck();
        }

        public void setUpDeck(List<Card> cardsOnTable)
        {
            foreach (SUIT s in Enum.GetValues(typeof(SUIT)))
            {
                foreach (VALUE v in Enum.GetValues(typeof(VALUE)))
                {
                    foreach (Card c in cardsOnTable)
                    {
                        if (c.MySuit == s && c.MyValue == v) { break; }
                        else { deck.Push(new Card { MySuit = s, MyValue = v }); }
                    }
                }
            }
            shuffleDeck();
        }

        public void shuffleDeck()
        {
            Random r = new Random();
            var cards = deck.ToArray();
            deck.Clear();

            foreach (var card in cards.OrderBy(x => r.Next()))
                    deck.Push(card);
        }
    }
}
