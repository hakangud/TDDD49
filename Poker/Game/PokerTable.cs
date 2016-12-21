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
        private List<Player> players;
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

        public PokerTable(List<Player> pl)
        {
            players = pl;

            foreach (var player in players)
            {
                player.table = this;
            }
        }

        public void dealCards()
        {
            deck.setUpDeck();
            Stack<Card> cards = deck.getDeck;

            foreach (var player in players)
            {
                player.Cards.Add(cards.Pop());
                player.Cards.Add(cards.Pop());
            }

            GameUtility.SavePlayerHands(players);
        }


    }
}
