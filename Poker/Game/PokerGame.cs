using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Poker.Players;
using Poker.Data;

namespace Poker.Game
{
    class PokerGame
    {
        protected int bigBlind = 20;
        protected int smallBlind = 10;
        protected float pot;
        protected float currentBet;
        protected Deck deck;
        protected List<Player> players;
        protected List<Enum> allowedActionsList;

        public PokerGame(List<Player> pl)
        {
            players = pl;
            deck = new Deck();
            deck.setUpDeck();
        }

        public void playRound()
        {
            List<Player> playersInRound = players;
            postBlinds();
            //dealCards();
            
            foreach (Player p in players)
            {
                p.yourTurn(allowedActionsList);
                //p.MinBet = currentBet;
                //if (p.pAction.Equals(Enum.bet))
               // {

               // }
            }
        }

        private void makeBet(Player p, float betAmount)
        {
           // p.Bet(betAmount);
        }

        private void postBlinds()
        {

        }
    }
}