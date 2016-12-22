using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Poker.Data
{
    class Card
    {
        Image i = new Image();
        
        public enum SUIT
        {
            HEARTS,
            DIAMONDS,
            SPADES,
            CLUBS
        }

        public enum VALUE
        {
            TWO,
            THREE,
            FOUR,
            FIVE,
            SIX,
            SEVEN,
            EIGHT,
            NINE,
            TEN,
            JACK,
            QUEEN,
            KING,
            ACE
        }

        public Image MyImage
        {
            get
            {

                return MyImage; }
            set
            {

            }

        }
        public SUIT MySuit { get; set; }
        public VALUE MyValue { get; set; }

        public static bool operator ==(Card c1, Card c2)
        {
            return c1.MySuit == c2.MySuit && c1.MyValue == c2.MyValue;
        }

        public static bool operator !=(Card c1, Card c2)
        {
            return c1.MySuit != c2.MySuit || c1.MyValue != c2.MyValue;
        }
    }
}
