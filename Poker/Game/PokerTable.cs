using Poker.Data;
using Poker.Players;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker.Game
{
    class PokerTable : Changeable
    {
        public List<Player> players { get; set; }
        public Deck deck { get; set; }

        private List<Card> cardsOnTable;
        public List<Card> CardsOnTable
        {
            get { return cardsOnTable; }
            set
            {
                if (cardsOnTable != value)
                {
                    cardsOnTable = value;
                    OnpropertyChanged("CardsOnTable");
                }
            }
        }

        private int pot;
        public int Pot
        {
            get { return pot; }
            set
            {
                if (pot != value)
                {
                    pot = value;
                    OnpropertyChanged("Pot");
                }
            }
        }
    }
}
