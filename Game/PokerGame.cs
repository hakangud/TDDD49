using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;

namespace Game
{
    class PokerGame
    {
        protected int bigBlind = 20;
        protected int smallBlind = 10;
        protected float pot;
        protected float currentBet;

        List<PlayerEntity> players;
        List<Enum> allowedActionsList;

        public PokerGame(List<PlayerEntity> pl)
        {
            players = pl;
        }

        public void playRound()
        {
            List<PlayerEntity> playersInRound = players;
            postBlinds();
            dealCards();
            
            foreach (Player p in players)
            {
                p.yourTurn(allowedActionsList);
                p.MinBet = currentBet;
            }
        }

        private void makeBet(Player p, float betAmount)
        {
            p.Bet(betAmount);
        }

        private void postBlinds()
        {

        }
    }
}