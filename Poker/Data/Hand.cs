using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker.Data
{
    class Hand
    {
        private int value { get; set; }
        List<Card> cards;
        Tuple<Card, Card> hand;

        public Hand(Tuple<Card, Card> t)
        {
            hand = t;
        }
        
        public int calculateValue(List<Card> allCards)
        {

            return value;
        }

        public static bool operator <(Hand h1, Hand h2)
        {
            return h1.value < h2.value;
        }

        public static bool operator >(Hand h1, Hand h2)
        {
            return h1.value > h2.value;
        }
    }
}
